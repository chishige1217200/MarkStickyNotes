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
            categoryEditor.Initialize<Category>("カテゴリー");
            priorityEditor.Initialize<Priority>("優先度");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
