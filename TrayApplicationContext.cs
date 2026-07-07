using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private ListForm? _listForm;
        private SettingsForm? _settingsForm;
        private AboutForm? _aboutForm;

        public TrayApplicationContext()
        {
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

            _notifyIcon.Click += (_, _) => ShowList();

            ShowList();
        }

        private void ShowNote()
        {
            // EditFormを開く
            var editForm = new EditForm();
            editForm.Show();
        }

        private void ShowList()
        {
            if (_listForm == null || _listForm.IsDisposed)
            {
                _listForm = new ListForm();

                _listForm.FormClosed += (_, _) =>
                {
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
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            _listForm?.Close();

            ExitThread();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notifyIcon?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
