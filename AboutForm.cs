using System;
using System.Diagnostics;
using NLog;

namespace MarkStickyNotes
{
    public partial class AboutForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AboutForm()
        {
            Logger.Debug("AboutForm コンストラクタ");
            InitializeComponent();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel linkLabel && linkLabel.Tag is string url)
            {
                Logger.Info($"外部リンク開く: {url}");
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, $"リンクを開けませんでした: {url}");
                    // リンクを開けない場合は無視
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Logger.Debug("AboutForm閉じる");
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.Debug("AboutFormフォーム閉じる");
            base.OnFormClosed(e);
        }
    }
}
