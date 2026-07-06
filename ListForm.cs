using MarkStickyNotes.DbContexts;
using MarkStickyNotes.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MarkStickyNotes
{
    public partial class ListForm : Form
    {
        private BindingList<NoteSearchResult>? currentResults;
        private string currentSortColumn = "Updated";
        private ListSortDirection currentSortDirection = ListSortDirection.Descending;

        public ListForm()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, resultsDataGridView, new object[] { true });
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            LoadIssueTypeData();
            LoadAssigneeData();
            LoadStatusData();
            LoadCategoryData();
            LoadPriorityData();
            InitializeDataGridView();
            PerformSearch(); // 初期表示時に全件検索
        }

        // 検索結果表示用のクラス
        public class NoteSearchResult
        {
            public int Id { get; set; }
            public string Subject { get; set; } = string.Empty;
            public string IssueTypeName { get; set; } = string.Empty;
            public string AssigneeName { get; set; } = string.Empty;
            public string StatusName { get; set; } = string.Empty;
            public string CategoryName { get; set; } = string.Empty;
            public string PriorityName { get; set; } = string.Empty;
            public DateTime? StartDate { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime Updated { get; set; }
        }

        // IssueType データを CheckedListBox に読み込む
        private void LoadIssueTypeData()
        {
            using var db = new AppDbContext();
            var issueTypes = db.IssueTypes.Where(i => !i.IsDeleted).OrderBy(i => i.Order).ToList();

            issueTypeCheckedListBox.Items.Clear();
            foreach (var issueType in issueTypes)
            {
                issueTypeCheckedListBox.Items.Add(issueType, false);
            }
            issueTypeCheckedListBox.DisplayMember = "Name";
            issueTypeCheckedListBox.ValueMember = "Id";
        }

        // Assignee データを CheckedListBox に読み込む
        private void LoadAssigneeData()
        {
            using var db = new AppDbContext();
            var assignees = db.Assignees.Where(a => !a.IsDeleted).OrderBy(a => a.Order).ToList();

            assigneeCheckedListBox.Items.Clear();
            foreach (var assignee in assignees)
            {
                assigneeCheckedListBox.Items.Add(assignee, false);
            }
            assigneeCheckedListBox.DisplayMember = "Name";
            assigneeCheckedListBox.ValueMember = "Id";
        }

        // Status データを CheckedListBox に読み込む
        private void LoadStatusData()
        {
            using var db = new AppDbContext();
            var statuses = db.Statuses.Where(s => !s.IsDeleted).OrderBy(s => s.Order).ToList();

            statusCheckedListBox.Items.Clear();
            foreach (var status in statuses)
            {
                statusCheckedListBox.Items.Add(status, false);
            }
            statusCheckedListBox.DisplayMember = "Name";
            statusCheckedListBox.ValueMember = "Id";
        }

        // Category データを CheckedListBox に読み込む
        private void LoadCategoryData()
        {
            using var db = new AppDbContext();
            var categories = db.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.Order).ToList();

            categoryCheckedListBox.Items.Clear();
            foreach (var category in categories)
            {
                categoryCheckedListBox.Items.Add(category, false);
            }
            categoryCheckedListBox.DisplayMember = "Name";
            categoryCheckedListBox.ValueMember = "Id";
        }

        // Priority データを CheckedListBox に読み込む
        private void LoadPriorityData()
        {
            using var db = new AppDbContext();
            var priorities = db.Priorities.Where(p => !p.IsDeleted).OrderBy(p => p.Order).ToList();

            priorityCheckedListBox.Items.Clear();
            foreach (var priority in priorities)
            {
                priorityCheckedListBox.Items.Add(priority, false);
            }
            priorityCheckedListBox.DisplayMember = "Name";
            priorityCheckedListBox.ValueMember = "Id";
        }

        // DataGridView の列を初期化
        private void InitializeDataGridView()
        {
            resultsDataGridView.AutoGenerateColumns = false;
            resultsDataGridView.Columns.Clear();

            // 列ヘッダークリックイベントを追加
            resultsDataGridView.ColumnHeaderMouseClick += ResultsDataGridView_ColumnHeaderMouseClick;

            // Id 列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                MinimumWidth = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 件名列（画面幅に合わせて伸縮）
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subject",
                DataPropertyName = "Subject",
                HeaderText = "件名",
                Width = 250,
                MinimumWidth = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 種別列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IssueTypeName",
                DataPropertyName = "IssueTypeName",
                HeaderText = "種別",
                Width = 80,
                MinimumWidth = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 担当者列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AssigneeName",
                DataPropertyName = "AssigneeName",
                HeaderText = "担当者",
                Width = 80,
                MinimumWidth = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 状態列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusName",
                DataPropertyName = "StatusName",
                HeaderText = "状態",
                Width = 80,
                MinimumWidth = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // カテゴリ列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                DataPropertyName = "CategoryName",
                HeaderText = "カテゴリ",
                Width = 80,
                MinimumWidth = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 優先度列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PriorityName",
                DataPropertyName = "PriorityName",
                HeaderText = "優先度",
                Width = 70,
                MinimumWidth = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 開始日列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                DataPropertyName = "StartDate",
                HeaderText = "開始日",
                Width = 70,
                MinimumWidth = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd", NullValue = "" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 期限日列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DueDate",
                DataPropertyName = "DueDate",
                HeaderText = "期限日",
                Width = 70,
                MinimumWidth = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd", NullValue = "" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 更新日時列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Updated",
                DataPropertyName = "Updated",
                HeaderText = "更新日時",
                Width = 130,
                MinimumWidth = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd HH:mm:ss" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
        }

        // 列ヘッダークリックでソート
        private void ResultsDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentResults == null || currentResults.Count == 0) return;

            var column = resultsDataGridView.Columns[e.ColumnIndex];
            var columnName = column.DataPropertyName;

            // 同じ列をクリックした場合は昇順/降順を切り替え
            if (currentSortColumn == columnName)
            {
                currentSortDirection = currentSortDirection == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                currentSortColumn = columnName;
                currentSortDirection = ListSortDirection.Ascending;
            }

            // ソートを実行
            SortResults();

            // ソート方向のインジケーターを表示
            foreach (DataGridViewColumn col in resultsDataGridView.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            column.HeaderCell.SortGlyphDirection = currentSortDirection == ListSortDirection.Ascending
                ? SortOrder.Ascending
                : SortOrder.Descending;
        }

        // 検索結果をソート
        private void SortResults()
        {
            if (currentResults == null || currentResults.Count == 0) return;

            List<NoteSearchResult> sortedList = currentSortDirection == ListSortDirection.Ascending
                ? SortAscending(currentResults.ToList(), currentSortColumn)
                : SortDescending(currentResults.ToList(), currentSortColumn);

            currentResults = new BindingList<NoteSearchResult>(sortedList);
            resultsDataGridView.DataSource = currentResults;
        }

        // 昇順ソート
        private List<NoteSearchResult> SortAscending(List<NoteSearchResult> list, string propertyName)
        {
            return propertyName switch
            {
                "Id" => list.OrderBy(x => x.Id).ToList(),
                "Subject" => list.OrderBy(x => x.Subject).ToList(),
                "IssueTypeName" => list.OrderBy(x => x.IssueTypeName).ToList(),
                "AssigneeName" => list.OrderBy(x => x.AssigneeName).ToList(),
                "StatusName" => list.OrderBy(x => x.StatusName).ToList(),
                "CategoryName" => list.OrderBy(x => x.CategoryName).ToList(),
                "PriorityName" => list.OrderBy(x => x.PriorityName).ToList(),
                "StartDate" => list.OrderBy(x => x.StartDate).ToList(),
                "DueDate" => list.OrderBy(x => x.DueDate).ToList(),
                "Updated" => list.OrderBy(x => x.Updated).ToList(),
                _ => list
            };
        }

        // 降順ソート
        private List<NoteSearchResult> SortDescending(List<NoteSearchResult> list, string propertyName)
        {
            return propertyName switch
            {
                "Id" => list.OrderByDescending(x => x.Id).ToList(),
                "Subject" => list.OrderByDescending(x => x.Subject).ToList(),
                "IssueTypeName" => list.OrderByDescending(x => x.IssueTypeName).ToList(),
                "AssigneeName" => list.OrderByDescending(x => x.AssigneeName).ToList(),
                "StatusName" => list.OrderByDescending(x => x.StatusName).ToList(),
                "CategoryName" => list.OrderByDescending(x => x.CategoryName).ToList(),
                "PriorityName" => list.OrderByDescending(x => x.PriorityName).ToList(),
                "StartDate" => list.OrderByDescending(x => x.StartDate).ToList(),
                "DueDate" => list.OrderByDescending(x => x.DueDate).ToList(),
                "Updated" => list.OrderByDescending(x => x.Updated).ToList(),
                _ => list
            };
        }

        // 検索ボタンクリックイベント
        private void SearchButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // 検索を実行
        private void PerformSearch()
        {
            using var db = new AppDbContext();

            // クエリの基本部分（削除されていない付箋）
            IQueryable<Note> query = db.Notes.Where(n => !n.IsDeleted);

            // 件名検索
            if (!string.IsNullOrWhiteSpace(titleSearchTextBox.Text))
            {
                var titleKeyword = titleSearchTextBox.Text.Trim();
                query = query.Where(n => n.Subject.Contains(titleKeyword));
            }

            // 種別検索(複数選択)
            var selectedIssueTypes = issueTypeCheckedListBox.CheckedItems.Cast<IssueType>().ToList();
            if (selectedIssueTypes.Any())
            {
                var issueTypeIds = selectedIssueTypes.Select(i => i.Id.ToString()).ToList();
                query = query.Where(n => issueTypeIds.Contains(n.IssueTypeId));
            }

            // 担当者検索(複数選択)
            var selectedAssignees = assigneeCheckedListBox.CheckedItems.Cast<Assignee>().ToList();
            if (selectedAssignees.Any())
            {
                var assigneeIds = selectedAssignees.Select(a => a.Id.ToString()).ToList();
                query = query.Where(n => assigneeIds.Contains(n.AssigneeId));
            }

            // 状態検索(複数選択)
            var selectedStatuses = statusCheckedListBox.CheckedItems.Cast<Status>().ToList();
            if (selectedStatuses.Any())
            {
                var statusIds = selectedStatuses.Select(s => s.Id.ToString()).ToList();
                query = query.Where(n => statusIds.Contains(n.StatusId));
            }

            // カテゴリ検索(複数選択)
            var selectedCategories = categoryCheckedListBox.CheckedItems.Cast<Category>().ToList();
            if (selectedCategories.Any())
            {
                var categoryIds = selectedCategories.Select(c => c.Id.ToString()).ToList();
                query = query.Where(n => categoryIds.Contains(n.CategoryId));
            }

            // 優先度検索(複数選択)
            var selectedPriorities = priorityCheckedListBox.CheckedItems.Cast<Priority>().ToList();
            if (selectedPriorities.Any())
            {
                var priorityIds = selectedPriorities.Select(p => p.Id.ToString()).ToList();
                query = query.Where(n => priorityIds.Contains(n.PriorityId));
            }

            // 開始日の範囲
            if (startDateFromPicker.Checked)
            {
                var startDateFrom = startDateFromPicker.Value.Date;
                query = query.Where(n => n.StartDate.HasValue && n.StartDate.Value >= startDateFrom);
            }
            if (startDateToPicker.Checked)
            {
                var startDateTo = startDateToPicker.Value.Date;
                query = query.Where(n => n.StartDate.HasValue && n.StartDate.Value <= startDateTo);
            }

            // 期限日の範囲
            if (dueDateFromPicker.Checked)
            {
                var dueDateFrom = dueDateFromPicker.Value.Date;
                query = query.Where(n => n.DueDate.HasValue && n.DueDate.Value >= dueDateFrom);
            }
            if (dueDateToPicker.Checked)
            {
                var dueDateTo = dueDateToPicker.Value.Date;
                query = query.Where(n => n.DueDate.HasValue && n.DueDate.Value <= dueDateTo);
            }

            // 更新日時の範囲
            if (updatedDateFromPicker.Checked)
            {
                var updatedDateFrom = updatedDateFromPicker.Value.Date;
                query = query.Where(n => n.Updated >= updatedDateFrom);
            }
            if (updatedDateToPicker.Checked)
            {
                var updatedDateTo = updatedDateToPicker.Value.Date.AddDays(1).AddSeconds(-1);
                query = query.Where(n => n.Updated <= updatedDateTo);
            }

            // クエリを実行して結果を取得
            var results = query
                .OrderByDescending(n => n.Updated)
                .Select(n => new NoteSearchResult
                {
                    Id = n.Id,
                    Subject = n.Subject,
                    IssueTypeName = db.IssueTypes.Where(i => !i.IsDeleted).Where(i => i.Id.ToString() == n.IssueTypeId).Select(i => i.Name).FirstOrDefault() ?? "",
                    AssigneeName = db.Assignees.Where(a => !a.IsDeleted).Where(a => a.Id.ToString() == n.AssigneeId).Select(a => a.Name).FirstOrDefault() ?? "",
                    StatusName = db.Statuses.Where(s => !s.IsDeleted).Where(s => s.Id.ToString() == n.StatusId).Select(s => s.Name).FirstOrDefault() ?? "",
                    CategoryName = db.Categories.Where(c => !c.IsDeleted).Where(c => c.Id.ToString() == n.CategoryId).Select(c => c.Name).FirstOrDefault() ?? "",
                    PriorityName = db.Priorities.Where(p => !p.IsDeleted).Where(p => p.Id.ToString() == n.PriorityId).Select(p => p.Name).FirstOrDefault() ?? "",
                    StartDate = n.StartDate,
                    DueDate = n.DueDate,
                    Updated = n.Updated
                })
                .ToList();

            // currentResultsに保存
            currentResults = new BindingList<NoteSearchResult>(results);
            resultsDataGridView.DataSource = currentResults;

            // ソート状態をリセット
            currentSortColumn = "Updated";
            currentSortDirection = ListSortDirection.Descending;

            // ソートインジケーターを表示
            foreach (DataGridViewColumn col in resultsDataGridView.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            if (resultsDataGridView.Columns["Updated"] != null)
            {
                resultsDataGridView.Columns["Updated"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            }
        }

        // DataGridView のセルダブルクリックイベント
        private void ResultsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー行のクリックは無視
            if (e.RowIndex < 0) return;

            // 選択された行から付箋IDを取得
            var row = resultsDataGridView.Rows[e.RowIndex];
            if (row.Cells["Id"].Value is int noteId)
            {
                // EditFormを開く
                var editForm = new EditForm(noteId);
                editForm.Show();
            }
        }

        // 付箋追加ボタンクリックイベント
        private void NewButton_Click(object sender, EventArgs e)
        {
            ShowNote();
        }

        private void ShowNote()
        {
            // EditFormを開く
            var editForm = new EditForm();
            editForm.Show();
        }

        // キーボードショートカットの処理
        private void ListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // F5 キーで検索をリフレッシュ
                ListForm_Load(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                // Enter キーで検索を実行
                PerformSearch();
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                // Ctrl + N で新規付箋作成
                ShowNote();
            }
        }
    }
}
