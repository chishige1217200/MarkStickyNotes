using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MarkStickyNotes.DbContexts;
using MarkStickyNotes.Entities;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace MarkStickyNotes
{
    public partial class SettingsForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        // 設定変更イベント
        public event EventHandler? SettingsChanged;

        public SettingsForm()
        {
            Logger.Debug("SettingsForm コンストラクタ");
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Logger.Info("設定フォーム読み込み開始");
            // 各エディターを初期化
            statusEditor.Initialize<Status>("状態");
            issueTypeEditor.Initialize<IssueType>("種別");
            assigneeEditor.Initialize<Assignee>("担当者");
            categoryEditor.Initialize<Category>("カテゴリ");
            priorityEditor.Initialize<Priority>("優先度");

            // 各エディターのデータ変更イベントを購読
            statusEditor.DataChanged += (s, e) => NotifySettingsChanged();
            issueTypeEditor.DataChanged += (s, e) => NotifySettingsChanged();
            assigneeEditor.DataChanged += (s, e) => NotifySettingsChanged();
            categoryEditor.DataChanged += (s, e) => NotifySettingsChanged();
            priorityEditor.DataChanged += (s, e) => NotifySettingsChanged();
            Logger.Info("設定フォーム読み込み完了");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Logger.Debug("設定フォーム閉じるボタンクリック");
            Close();
        }

        // 設定変更を通知
        public void NotifySettingsChanged()
        {
            Logger.Info("設定変更イベント発生");
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.Debug("設定フォーム閉じる");
            base.OnFormClosed(e);
        }
    }
}
