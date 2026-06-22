using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private ListForm? _listForm;

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
