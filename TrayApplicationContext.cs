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

            _notifyIcon.DoubleClick += (_, _) => ShowList();

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
            }

            if (!_settingsForm.Visible)
            {
                _settingsForm.Show();
            }

            _settingsForm.WindowState = FormWindowState.Normal;
            _settingsForm.Activate();
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
