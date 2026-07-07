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

namespace MarkStickyNotes
{
    public partial class SettingsForm : Form
    {
        // 設定変更イベント
        public event EventHandler? SettingsChanged;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
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
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 設定変更を通知
        public void NotifySettingsChanged()
        {
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
