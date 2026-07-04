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
            LoadStatusList();
        }

        private void LoadStatusList()
        {
            using var db = new AppDbContext();
            var statuses = db.Status
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .ToList();

            statusListBox.Items.Clear();
            foreach (var status in statuses)
            {
                statusListBox.Items.Add(status);
            }
            statusListBox.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // ステータス名を入力するダイアログを表示
            string? statusName = ShowInputDialog("新しいステータス名を入力してください:", "ステータス追加", "");

            if (string.IsNullOrWhiteSpace(statusName))
            {
                return;
            }

            using var db = new AppDbContext();

            // 現在の最大Order値を取得
            int maxOrder = db.Status
                .Where(s => !s.IsDeleted)
                .Select(s => (int?)s.Order)
                .Max() ?? 0;

            // 新しいStatusを追加
            var newStatus = new Status
            {
                Name = statusName.Trim(),
                Order = maxOrder + 1,
                IsDeleted = false
            };

            db.Status.Add(newStatus);
            db.SaveChanges();

            // リストを再読み込み
            LoadStatusList();

            // 追加した項目を選択
            statusListBox.SelectedItem = statusListBox.Items
                .Cast<Status>()
                .FirstOrDefault(s => s.Id == newStatus.Id);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (statusListBox.SelectedItem is not Status selectedStatus)
            {
                MessageBox.Show("編集するステータスを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 現在の名称を初期値として入力ダイアログを表示
            string? newStatusName = ShowInputDialog("ステータス名を入力してください:", "ステータス編集", selectedStatus.Name);

            if (string.IsNullOrWhiteSpace(newStatusName))
            {
                return;
            }

            using var db = new AppDbContext();
            var status = db.Status.Find(selectedStatus.Id);

            if (status != null)
            {
                status.Name = newStatusName.Trim();
                db.SaveChanges();

                // リストを再読み込み
                LoadStatusList();

                // 編集した項目を選択
                statusListBox.SelectedItem = statusListBox.Items
                    .Cast<Status>()
                    .FirstOrDefault(s => s.Id == selectedStatus.Id);
            }
        }

        private string? ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 340, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 200, Width = 80, Top = 75, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "キャンセル", Left = 285, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (statusListBox.SelectedItem is not Status selectedStatus)
            {
                MessageBox.Show("削除するステータスを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"ステータス「{selectedStatus.Name}」を削除してもよろしいですか？",
                "削除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using var db = new AppDbContext();
            var status = db.Status.Find(selectedStatus.Id);

            if (status != null)
            {
                // 論理削除
                status.IsDeleted = true;
                db.SaveChanges();

                // リストを再読み込み
                LoadStatusList();
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (statusListBox.SelectedItem is not Status selectedStatus)
            {
                MessageBox.Show("移動するステータスを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = statusListBox.SelectedIndex;
            if (selectedIndex <= 0)
            {
                return; // 一番上の項目は上に移動できない
            }

            using var db = new AppDbContext();
            var currentStatus = db.Status.Find(selectedStatus.Id);
            var previousStatus = statusListBox.Items[selectedIndex - 1] as Status;
            var previousStatusDb = db.Status.Find(previousStatus!.Id);

            if (currentStatus != null && previousStatusDb != null)
            {
                // Order値を入れ替え
                int tempOrder = currentStatus.Order;
                currentStatus.Order = previousStatusDb.Order;
                previousStatusDb.Order = tempOrder;

                db.SaveChanges();

                // リストを再読み込み
                LoadStatusList();

                // 選択状態を維持
                statusListBox.SelectedIndex = selectedIndex - 1;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (statusListBox.SelectedItem is not Status selectedStatus)
            {
                MessageBox.Show("移動するステータスを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = statusListBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= statusListBox.Items.Count - 1)
            {
                return; // 一番下の項目は下に移動できない
            }

            using var db = new AppDbContext();
            var currentStatus = db.Status.Find(selectedStatus.Id);
            var nextStatus = statusListBox.Items[selectedIndex + 1] as Status;
            var nextStatusDb = db.Status.Find(nextStatus!.Id);

            if (currentStatus != null && nextStatusDb != null)
            {
                // Order値を入れ替え
                int tempOrder = currentStatus.Order;
                currentStatus.Order = nextStatusDb.Order;
                nextStatusDb.Order = tempOrder;

                db.SaveChanges();

                // リストを再読み込み
                LoadStatusList();

                // 選択状態を維持
                statusListBox.SelectedIndex = selectedIndex + 1;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
