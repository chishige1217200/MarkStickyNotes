using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using NLog;

namespace MarkStickyNotes
{
    public class TrayApplicationContext : ApplicationContext
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly NotifyIcon _notifyIcon;
        private ListForm? _listForm;
        private SettingsForm? _settingsForm;
        private AboutForm? _aboutForm;

        private static readonly string OpenedNotesFilePath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "chishige1217200",
                "MarkStickyNotes",
                "OpenedNotes.json"
            );

        public TrayApplicationContext()
        {
            Logger.Info("TrayApplicationContext 初期化開始");

            var menu = new ContextMenuStrip();

            menu.Items.Add(
                "付箋追加",
                null,
                (_, _) => ShowNote());

            menu.Items.Add(
                "付箋一覧",
                null,
                (_, _) => ShowList());

            menu.Items.Add(
                "アプリ設定",
                null,
                (_, _) => ShowSettings());

            menu.Items.Add(
                "アプリについて",
                null,
                (_, _) => ShowAbout());

            menu.Items.Add(
                "アプリ終了",
                null,
                (_, _) => ExitApplication());

            _notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.MarkStickyNotes,
                Text = "MarkStickyNotes",
                ContextMenuStrip = menu,
                Visible = true
            };

            _notifyIcon.MouseClick += notifyIcon_Click;

            Logger.Info("通知領域アイコン初期化完了");
            ShowList();
            RestoreAndOpenNotes();
        }

        private void ShowNote()
        {
            Logger.Debug("新規付箋フォーム表示");
            var editForm = new EditForm();
            editForm.FormClosed += EditForm_FormClosed;
            editForm.Show();
        }

        private void ShowNote(int noteId)
        {
            Logger.Debug($"既存付箋フォーム表示 (ID: {noteId})");
            var editForm = new EditForm(noteId);
            editForm.FormClosed += EditForm_FormClosed;
            editForm.Show();
        }

        private void EditForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            SaveOpenedNotes();
        }

        private void ShowList()
        {
            Logger.Debug("付箋一覧フォーム表示");
            if (_listForm == null || _listForm.IsDisposed)
            {
                _listForm = new ListForm();

                _listForm.FormClosed += (_, _) =>
                {
                    SaveOpenedNotes();
                    _listForm = null;
                };
            }

            if (!_listForm.Visible)
            {
                _listForm.Show();
            }

            _listForm.WindowState = FormWindowState.Normal;
            _listForm.Activate();
        }

        private void ShowSettings()
        {
            Logger.Debug("アプリ設定フォーム表示");
            if (_settingsForm == null || _settingsForm.IsDisposed)
            {
                _settingsForm = new SettingsForm();

                _settingsForm.FormClosed += (_, _) =>
                {
                    _settingsForm = null;
                };

                // 設定変更イベントを購読
                _settingsForm.SettingsChanged += (_, _) =>
                {
                    Logger.Debug("設定変更イベント受信");
                    // ListFormが開かれている場合、検索条件リストを更新
                    if (_listForm != null && !_listForm.IsDisposed)
                    {
                        _listForm.RefreshSearchConditionLists();
                    }
                };
            }

            if (!_settingsForm.Visible)
            {
                _settingsForm.Show();
            }

            _settingsForm.WindowState = FormWindowState.Normal;
            _settingsForm.Activate();
        }

        private void ShowAbout()
        {
            Logger.Debug("アプリについてフォーム表示");
            if (_aboutForm == null || _aboutForm.IsDisposed)
            {
                _aboutForm = new AboutForm();

                _aboutForm.FormClosed += (_, _) =>
                {
                    _aboutForm = null;
                };
            }

            if (!_aboutForm.Visible)
            {
                _aboutForm.Show();
            }

            _aboutForm.WindowState = FormWindowState.Normal;
            _aboutForm.Activate();
        }

        private void ExitApplication()
        {
            Logger.Info("アプリケーション終了処理開始");
            SaveOpenedNotes();

            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            _listForm?.Close();

            Logger.Info("アプリケーション終了処理完了");
            ExitThread();
        }

        private void RestoreAndOpenNotes()
        {
            try
            {
                Logger.Debug("開いていた付箋の復元開始");
                if (!File.Exists(OpenedNotesFilePath))
                {
                    Logger.Debug("開いていた付箋ファイルが存在しません");
                    return;
                }

                var json = File.ReadAllText(OpenedNotesFilePath);
                var noteIds = JsonSerializer.Deserialize<List<int>>(json);

                if (noteIds == null || noteIds.Count == 0)
                {
                    Logger.Debug("復元する付箋IDがありません");
                    return;
                }

                // DBに存在する付箋のみを開く
                using var db = new MarkStickyNotes.DbContexts.AppDbContext();
                var validIds = db.Notes.Where(n => noteIds.Contains(n.Id) && !n.IsDeleted).Select(n => n.Id).ToList();

                Logger.Info($"{validIds.Count}件の付箋を復元");
                foreach (var id in validIds)
                {
                    ShowNote(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "付箋の復元に失敗");
            }
        }

        private void SaveOpenedNotes()
        {
            try
            {
                var openedIds = new List<int>();

                // ListForm の DataGridView から開いている付箋IDを取得（ListFormは再表示されるため保存しない）

                // EditForm を探す
                foreach (var form in Application.OpenForms)
                {
                    if (form is EditForm editForm && editForm.CurrentNoteId > 0)
                    {
                        if (!openedIds.Contains(editForm.CurrentNoteId))
                        {
                            openedIds.Add(editForm.CurrentNoteId);
                        }
                    }
                }

                // ディレクトリが存在しない場合は作成
                var directory = Path.GetDirectoryName(OpenedNotesFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonSerializer.Serialize(openedIds, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(OpenedNotesFilePath, json);
                Logger.Debug($"{openedIds.Count}件の付箋情報を保存");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "付箋の保存に失敗");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notifyIcon?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void notifyIcon_Click(object? sender,
             System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 左クリックで付箋一覧を表示
                ShowList();
            }
        }
    }
}
