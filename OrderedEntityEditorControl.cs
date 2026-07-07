using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkStickyNotes.DbContexts;
using MarkStickyNotes.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarkStickyNotes
{
    /// <summary>
    /// OrderedEntityを編集するための汎用ユーザーコントロール
    /// </summary>
    public partial class OrderedEntityEditorControl : UserControl
    {
        private Type? _entityType;
        private string _entityDisplayName = string.Empty;

        // データ変更イベント
        public event EventHandler? DataChanged;

        public OrderedEntityEditorControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// エンティティタイプと表示名を設定して初期化
        /// </summary>
        public void Initialize<T>(string displayName) where T : OrderedEntity
        {
            _entityType = typeof(T);
            _entityDisplayName = displayName;
            LoadEntityList();
        }

        private void LoadEntityList()
        {
            if (_entityType == null)
            {
                return;
            }

            using var db = new AppDbContext();

            // リフレクションでDbSetを取得
            var dbSetProperty = typeof(AppDbContext).GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                   p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                   p.PropertyType.GetGenericArguments()[0] == _entityType);

            if (dbSetProperty == null)
            {
                return;
            }

            var dbSet = dbSetProperty.GetValue(db);
            if (dbSet == null)
            {
                return;
            }

            // IQueryableとしてクエリを構築
            var query = ((IQueryable<OrderedEntity>)dbSet)
                .Where(e => !e.IsDeleted)
                .OrderBy(e => e.Order)
                .ToList();

            entityListBox.Items.Clear();
            foreach (var entity in query)
            {
                entityListBox.Items.Add(entity);
            }
            entityListBox.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_entityType == null)
            {
                return;
            }

            // エンティティ名を入力するダイアログを表示
            string? entityName = ShowInputDialog($"新しい{_entityDisplayName}名を入力してください:", $"{_entityDisplayName}追加", "");

            if (string.IsNullOrWhiteSpace(entityName))
            {
                return;
            }

            using var db = new AppDbContext();

            // リフレクションでDbSetを取得
            var dbSetProperty = typeof(AppDbContext).GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                   p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                   p.PropertyType.GetGenericArguments()[0] == _entityType);

            if (dbSetProperty == null)
            {
                return;
            }

            var dbSet = dbSetProperty.GetValue(db) as IQueryable<OrderedEntity>;
            if (dbSet == null)
            {
                return;
            }

            // 現在の最大Order値を取得
            int maxOrder = dbSet
                .Where(e => !e.IsDeleted)
                .Select(e => (int?)e.Order)
                .Max() ?? 0;

            // 新しいエンティティを作成
            var newEntity = Activator.CreateInstance(_entityType) as OrderedEntity;
            if (newEntity == null)
            {
                return;
            }

            newEntity.Name = entityName.Trim();
            newEntity.Order = maxOrder + 1;
            newEntity.IsDeleted = false;

            // DbSetに追加
            db.Add(newEntity);
            db.SaveChanges();

            // データ変更イベントを発火
            DataChanged?.Invoke(this, EventArgs.Empty);

            // リストを再読み込み
            LoadEntityList();

            // 追加した項目を選択
            entityListBox.SelectedItem = entityListBox.Items
                .Cast<OrderedEntity>()
                .FirstOrDefault(e => e.Id == newEntity.Id);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_entityType == null || entityListBox.SelectedItem is not OrderedEntity selectedEntity)
            {
                MessageBox.Show($"編集する{_entityDisplayName}を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 現在の名称を初期値として入力ダイアログを表示
            string? newEntityName = ShowInputDialog($"{_entityDisplayName}名を入力してください:", $"{_entityDisplayName}編集", selectedEntity.Name);

            if (string.IsNullOrWhiteSpace(newEntityName))
            {
                return;
            }

            using var db = new AppDbContext();
            var entity = db.Find(_entityType, selectedEntity.Id) as OrderedEntity;

            if (entity != null)
            {
                entity.Name = newEntityName.Trim();
                db.SaveChanges();

                // データ変更イベントを発火
                DataChanged?.Invoke(this, EventArgs.Empty);

                // リストを再読み込み
                LoadEntityList();

                // 編集した項目を選択
                entityListBox.SelectedItem = entityListBox.Items
                    .Cast<OrderedEntity>()
                    .FirstOrDefault(e => e.Id == selectedEntity.Id);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_entityType == null || entityListBox.SelectedItem is not OrderedEntity selectedEntity)
            {
                MessageBox.Show($"削除する{_entityDisplayName}を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"{_entityDisplayName}「{selectedEntity.Name}」を削除してもよろしいですか？",
                "削除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using var db = new AppDbContext();
            var entity = db.Find(_entityType, selectedEntity.Id) as OrderedEntity;

            if (entity != null)
            {
                // 論理削除
                entity.IsDeleted = true;
                db.SaveChanges();

                // データ変更イベントを発火
                DataChanged?.Invoke(this, EventArgs.Empty);

                // リストを再読み込み
                LoadEntityList();
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (_entityType == null || entityListBox.SelectedItem is not OrderedEntity selectedEntity)
            {
                MessageBox.Show($"移動する{_entityDisplayName}を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = entityListBox.SelectedIndex;
            if (selectedIndex <= 0)
            {
                return; // 一番上の項目は上に移動できない
            }

            using var db = new AppDbContext();
            var currentEntity = db.Find(_entityType, selectedEntity.Id) as OrderedEntity;
            var previousEntity = entityListBox.Items[selectedIndex - 1] as OrderedEntity;
            var previousEntityDb = db.Find(_entityType, previousEntity!.Id) as OrderedEntity;

            if (currentEntity != null && previousEntityDb != null)
            {
                // Order値を入れ替え
                int tempOrder = currentEntity.Order;
                currentEntity.Order = previousEntityDb.Order;
                previousEntityDb.Order = tempOrder;

                db.SaveChanges();

                // データ変更イベントを発火
                DataChanged?.Invoke(this, EventArgs.Empty);

                // リストを再読み込み
                LoadEntityList();

                // 選択状態を維持
                entityListBox.SelectedIndex = selectedIndex - 1;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (_entityType == null || entityListBox.SelectedItem is not OrderedEntity selectedEntity)
            {
                MessageBox.Show($"移動する{_entityDisplayName}を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = entityListBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= entityListBox.Items.Count - 1)
            {
                return; // 一番下の項目は下に移動できない
            }

            using var db = new AppDbContext();
            var currentEntity = db.Find(_entityType, selectedEntity.Id) as OrderedEntity;
            var nextEntity = entityListBox.Items[selectedIndex + 1] as OrderedEntity;
            var nextEntityDb = db.Find(_entityType, nextEntity!.Id) as OrderedEntity;

            if (currentEntity != null && nextEntityDb != null)
            {
                // Order値を入れ替え
                int tempOrder = currentEntity.Order;
                currentEntity.Order = nextEntityDb.Order;
                nextEntityDb.Order = tempOrder;

                db.SaveChanges();

                // データ変更イベントを発火
                DataChanged?.Invoke(this, EventArgs.Empty);

                // リストを再読み込み
                LoadEntityList();

                // 選択状態を維持
                entityListBox.SelectedIndex = selectedIndex + 1;
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
    }
}
