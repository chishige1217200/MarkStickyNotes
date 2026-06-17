using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private SettingsForm? _settingsForm;

        public TrayApplicationContext()
        {
            var menu = new ContextMenuStrip();

            menu.Items.Add(
                "設定",
                null,
                (_, _) => ShowSettings());

            menu.Items.Add(
                "終了",
                null,
                (_, _) => ExitApplication());

            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "SuperStickyNotes",
                ContextMenuStrip = menu,
                Visible = true
            };

            _notifyIcon.DoubleClick += (_, _) => ShowSettings();

            ShowSettings();
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

            _settingsForm?.Close();

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
