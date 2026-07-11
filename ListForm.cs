using MarkStickyNotes.DbContexts;
using MarkStickyNotes.Entities;
using MarkStickyNotes.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.ComponentModel;
using System.Text.Json;

namespace MarkStickyNotes
{
    public partial class ListForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private BindingList<NoteSearchResult>? currentResults;
        private string currentSortColumn = "Updated";
        private ListSortDirection currentSortDirection = ListSortDirection.Descending;

        // 検索条件の保存先パス
        private static readonly string SearchConditionsFilePath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "chishige1217200",
                "MarkStickyNotes",
                "SearchConditions.json"
            );

        public ListForm()
        {
            Logger.Debug("ListForm コンストラクタ");
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, resultsDataGridView, new object[] { true });

            // 検索条件チェックボックスのイベントを登録
            issueTypeCheckedListBox.ItemCheck += SearchConditionCheckBox_ItemCheck;
            assigneeCheckedListBox.ItemCheck += SearchConditionCheckBox_ItemCheck;
            statusCheckedListBox.ItemCheck += SearchConditionCheckBox_ItemCheck;
            categoryCheckedListBox.ItemCheck += SearchConditionCheckBox_ItemCheck;
            priorityCheckedListBox.ItemCheck += SearchConditionCheckBox_ItemCheck;
        }

        // 検索条件チェックボックスのイベントハンドラ
        private void SearchConditionCheckBox_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            string checkBoxName = sender?.GetType().Name ?? "Unknown";
            Logger.Debug($"検索条件変更: {checkBoxName}, インデックス={e.Index}, 新しい状態={e.NewValue}");
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            Logger.Info("ListForm読み込み開始");
            LoadIssueTypeData();
            LoadAssigneeData();
            LoadStatusData();
            LoadCategoryData();
            LoadPriorityData();
            InitializeDataGridView();
            RestoreSearchConditions(); // 検索条件を復元
            PerformSearch(); // 初期表示時に全件検索
            Logger.Info("ListForm読み込み完了");
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
            Logger.Debug("種別データ読み込み");
            // 現在の選択状態を保存
            var selectedIds = issueTypeCheckedListBox.CheckedItems.Cast<IssueType>().Select(i => i.Id).ToList();

            using var db = new AppDbContext();
            var issueTypes = db.IssueTypes.Where(i => !i.IsDeleted).OrderBy(i => i.Order).ToList();

            issueTypeCheckedListBox.Items.Clear();
            foreach (var issueType in issueTypes)
            {
                issueTypeCheckedListBox.Items.Add(issueType, false);
            }
            issueTypeCheckedListBox.DisplayMember = "Name";
            issueTypeCheckedListBox.ValueMember = "Id";

            // 選択状態を復元
            for (int i = 0; i < issueTypeCheckedListBox.Items.Count; i++)
            {
                var item = (IssueType)issueTypeCheckedListBox.Items[i];
                if (selectedIds.Contains(item.Id))
                {
                    issueTypeCheckedListBox.SetItemChecked(i, true);
                }
            }
            Logger.Debug($"種別データ読み込み完了: {issueTypes.Count}件");
        }

        // Assignee データを CheckedListBox に読み込む
        private void LoadAssigneeData()
        {
            Logger.Debug("担当者データ読み込み");
            // 現在の選択状態を保存
            var selectedIds = assigneeCheckedListBox.CheckedItems.Cast<Assignee>().Select(a => a.Id).ToList();

            using var db = new AppDbContext();
            var assignees = db.Assignees.Where(a => !a.IsDeleted).OrderBy(a => a.Order).ToList();

            assigneeCheckedListBox.Items.Clear();
            foreach (var assignee in assignees)
            {
                assigneeCheckedListBox.Items.Add(assignee, false);
            }
            assigneeCheckedListBox.DisplayMember = "Name";
            assigneeCheckedListBox.ValueMember = "Id";

            // 選択状態を復元
            for (int i = 0; i < assigneeCheckedListBox.Items.Count; i++)
            {
                var item = (Assignee)assigneeCheckedListBox.Items[i];
                if (selectedIds.Contains(item.Id))
                {
                    assigneeCheckedListBox.SetItemChecked(i, true);
                }
            }
            Logger.Debug($"担当者データ読み込み完了: {assignees.Count}件");
        }

        // Status データを CheckedListBox に読み込む
        private void LoadStatusData()
        {
            Logger.Debug("状態データ読み込み");
            // 現在の選択状態を保存
            var selectedIds = statusCheckedListBox.CheckedItems.Cast<Status>().Select(s => s.Id).ToList();

            using var db = new AppDbContext();
            var statuses = db.Statuses.Where(s => !s.IsDeleted).OrderBy(s => s.Order).ToList();

            statusCheckedListBox.Items.Clear();
            foreach (var status in statuses)
            {
                statusCheckedListBox.Items.Add(status, false);
            }
            statusCheckedListBox.DisplayMember = "Name";
            statusCheckedListBox.ValueMember = "Id";

            // 選択状態を復元
            for (int i = 0; i < statusCheckedListBox.Items.Count; i++)
            {
                var item = (Status)statusCheckedListBox.Items[i];
                if (selectedIds.Contains(item.Id))
                {
                    statusCheckedListBox.SetItemChecked(i, true);
                }
            }
            Logger.Debug($"状態データ読み込み完了: {statuses.Count}件");
        }

        // Category データを CheckedListBox に読み込む
        private void LoadCategoryData()
        {
            Logger.Debug("カテゴリデータ読み込み");
            // 現在の選択状態を保存
            var selectedIds = categoryCheckedListBox.CheckedItems.Cast<Category>().Select(c => c.Id).ToList();

            using var db = new AppDbContext();
            var categories = db.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.Order).ToList();

            categoryCheckedListBox.Items.Clear();
            foreach (var category in categories)
            {
                categoryCheckedListBox.Items.Add(category, false);
            }
            categoryCheckedListBox.DisplayMember = "Name";
            categoryCheckedListBox.ValueMember = "Id";

            // 選択状態を復元
            for (int i = 0; i < categoryCheckedListBox.Items.Count; i++)
            {
                var item = (Category)categoryCheckedListBox.Items[i];
                if (selectedIds.Contains(item.Id))
                {
                    categoryCheckedListBox.SetItemChecked(i, true);
                }
            }
            Logger.Debug($"カテゴリデータ読み込み完了: {categories.Count}件");
        }

        // Priority データを CheckedListBox に読み込む
        private void LoadPriorityData()
        {
            Logger.Debug("優先度データ読み込み");
            // 現在の選択状態を保存
            var selectedIds = priorityCheckedListBox.CheckedItems.Cast<Priority>().Select(p => p.Id).ToList();

            using var db = new AppDbContext();
            var priorities = db.Priorities.Where(p => !p.IsDeleted).OrderBy(p => p.Order).ToList();

            priorityCheckedListBox.Items.Clear();
            foreach (var priority in priorities)
            {
                priorityCheckedListBox.Items.Add(priority, false);
            }
            priorityCheckedListBox.DisplayMember = "Name";
            priorityCheckedListBox.ValueMember = "Id";

            // 選択状態を復元
            for (int i = 0; i < priorityCheckedListBox.Items.Count; i++)
            {
                var item = (Priority)priorityCheckedListBox.Items[i];
                if (selectedIds.Contains(item.Id))
                {
                    priorityCheckedListBox.SetItemChecked(i, true);
                }
            }
        }

        // 検索条件のリストを更新（外部から呼び出し可能）
        public void RefreshSearchConditionLists()
        {
            LoadIssueTypeData();
            LoadAssigneeData();
            LoadStatusData();
            LoadCategoryData();
            LoadPriorityData();
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
        private void ResultsDataGridView_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentResults == null || currentResults.Count == 0) return;

            var column = resultsDataGridView.Columns[e.ColumnIndex];
            var columnName = column.DataPropertyName;
            Logger.Info($"ソート実行: 列={columnName}, 方向={currentSortDirection}");

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
            List<NoteSearchResult> sortedList = currentSortDirection == ListSortDirection.Ascending
                ? SortAscending((currentResults ?? new BindingList<NoteSearchResult>()).ToList(), currentSortColumn)
                : SortDescending((currentResults ?? new BindingList<NoteSearchResult>()).ToList(), currentSortColumn);

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
            Logger.Info("検索ボタンクリック");
            PerformSearch();
        }

        // 検索を実行
        private void PerformSearch()
        {
            Logger.Debug("検索実行開始");
            using var db = new AppDbContext();

            // クエリの基本部分（削除されていない付箋）
            IQueryable<Note> query = db.Notes.Where(n => !n.IsDeleted);

            // 件名検索
            if (!string.IsNullOrWhiteSpace(titleSearchTextBox.Text))
            {
                var titleKeyword = titleSearchTextBox.Text.Trim();
                Logger.Debug($"件名検索キーワード: {titleKeyword}");
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

            // 現在のソート順を適用
            SortResults();

            // ソートインジケーターを表示
            foreach (DataGridViewColumn col in resultsDataGridView.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            var sortedColumn = resultsDataGridView.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == currentSortColumn);
            if (sortedColumn != null)
            {
                sortedColumn.HeaderCell.SortGlyphDirection = currentSortDirection == ListSortDirection.Ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }

            // 検索条件を保存
            SaveSearchConditions();
            Logger.Info($"検索完了: {results.Count}件ヒット");
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
                Logger.Info($"付箋ダブルクリック (ID: {noteId}) - EditForm表示");
                // EditFormを開く
                var editForm = new EditForm(noteId);
                editForm.Show();
            }
        }

        // 付箋追加ボタンクリックイベント
        private void NewButton_Click(object sender, EventArgs e)
        {
            Logger.Info("新規付箋追加ボタンクリック");
            ShowNote();
        }

        private void ShowNote()
        {
            Logger.Info("新規付箋フォーム表示");
            // EditFormを開く
            var editForm = new EditForm();
            editForm.Show();
        }

        // キーボードショートカットの処理
        private void ListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logger.Debug("Enterキー押下（検索実行）");
                // Enter キーで検索を実行
                PerformSearch();
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                Logger.Debug("Ctrl+Nキー押下（新規付箋作成）");
                // Ctrl + N で新規付箋作成
                ShowNote();
            }
        }

        /// <summary>
        /// 現在の検索条件をJSONファイルに保存
        /// </summary>
        private void SaveSearchConditions()
        {
            try
            {
                var conditions = new SearchConditions
                {
                    TitleSearch = titleSearchTextBox.Text,
                    SelectedIssueTypeIds = issueTypeCheckedListBox.CheckedItems.Cast<IssueType>().Select(i => i.Id).ToList(),
                    SelectedAssigneeIds = assigneeCheckedListBox.CheckedItems.Cast<Assignee>().Select(a => a.Id).ToList(),
                    SelectedStatusIds = statusCheckedListBox.CheckedItems.Cast<Status>().Select(s => s.Id).ToList(),
                    SelectedCategoryIds = categoryCheckedListBox.CheckedItems.Cast<Category>().Select(c => c.Id).ToList(),
                    SelectedPriorityIds = priorityCheckedListBox.CheckedItems.Cast<Priority>().Select(p => p.Id).ToList(),
                    StartDateFrom = startDateFromPicker.Checked ? startDateFromPicker.Value.Date : null,
                    StartDateFromEnabled = startDateFromPicker.Checked,
                    StartDateTo = startDateToPicker.Checked ? startDateToPicker.Value.Date : null,
                    StartDateToEnabled = startDateToPicker.Checked,
                    DueDateFrom = dueDateFromPicker.Checked ? dueDateFromPicker.Value.Date : null,
                    DueDateFromEnabled = dueDateFromPicker.Checked,
                    DueDateTo = dueDateToPicker.Checked ? dueDateToPicker.Value.Date : null,
                    DueDateToEnabled = dueDateToPicker.Checked,
                    UpdatedDateFrom = updatedDateFromPicker.Checked ? updatedDateFromPicker.Value.Date : null,
                    UpdatedDateFromEnabled = updatedDateFromPicker.Checked,
                    UpdatedDateTo = updatedDateToPicker.Checked ? updatedDateToPicker.Value.Date : null,
                    UpdatedDateToEnabled = updatedDateToPicker.Checked,
                    SortColumn = currentSortColumn,
                    SortDirection = (int)currentSortDirection
                };

                // ディレクトリが存在しない場合は作成
                var directory = Path.GetDirectoryName(SearchConditionsFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // JSONファイルに保存
                var json = JsonSerializer.Serialize(conditions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SearchConditionsFilePath, json);
                Logger.Debug("検索条件をJSONファイルに保存");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "検索条件の保存に失敗");
            }
        }

        /// <summary>
        /// JSONファイルから検索条件を復元
        /// </summary>
        private void RestoreSearchConditions()
        {
            try
            {
                // ファイルが存在しない場合は何もしない
                if (!File.Exists(SearchConditionsFilePath))
                {
                    Logger.Debug("検索条件ファイルなし（初期状態）");
                    return;
                }

                // JSONファイルから読み込み
                var json = File.ReadAllText(SearchConditionsFilePath);
                var conditions = JsonSerializer.Deserialize<SearchConditions>(json);

                if (conditions == null)
                {
                    return;
                }

                // 件名
                titleSearchTextBox.Text = conditions.TitleSearch;

                // 種別の復元
                for (int i = 0; i < issueTypeCheckedListBox.Items.Count; i++)
                {
                    var item = (IssueType)issueTypeCheckedListBox.Items[i];
                    issueTypeCheckedListBox.SetItemChecked(i, conditions.SelectedIssueTypeIds.Contains(item.Id));
                }

                // 担当者の復元
                for (int i = 0; i < assigneeCheckedListBox.Items.Count; i++)
                {
                    var item = (Assignee)assigneeCheckedListBox.Items[i];
                    assigneeCheckedListBox.SetItemChecked(i, conditions.SelectedAssigneeIds.Contains(item.Id));
                }

                // 状態の復元
                for (int i = 0; i < statusCheckedListBox.Items.Count; i++)
                {
                    var item = (Status)statusCheckedListBox.Items[i];
                    statusCheckedListBox.SetItemChecked(i, conditions.SelectedStatusIds.Contains(item.Id));
                }

                // カテゴリの復元
                for (int i = 0; i < categoryCheckedListBox.Items.Count; i++)
                {
                    var item = (Category)categoryCheckedListBox.Items[i];
                    categoryCheckedListBox.SetItemChecked(i, conditions.SelectedCategoryIds.Contains(item.Id));
                }

                // 優先度の復元
                for (int i = 0; i < priorityCheckedListBox.Items.Count; i++)
                {
                    var item = (Priority)priorityCheckedListBox.Items[i];
                    priorityCheckedListBox.SetItemChecked(i, conditions.SelectedPriorityIds.Contains(item.Id));
                }

                // 開始日Fromの復元
                if (conditions.StartDateFromEnabled && conditions.StartDateFrom.HasValue)
                {
                    startDateFromPicker.Value = conditions.StartDateFrom.Value;
                    startDateFromPicker.Checked = true;
                }
                else
                {
                    startDateFromPicker.Checked = false;
                }

                // 開始日Toの復元
                if (conditions.StartDateToEnabled && conditions.StartDateTo.HasValue)
                {
                    startDateToPicker.Value = conditions.StartDateTo.Value;
                    startDateToPicker.Checked = true;
                }
                else
                {
                    startDateToPicker.Checked = false;
                }

                // 期限日Fromの復元
                if (conditions.DueDateFromEnabled && conditions.DueDateFrom.HasValue)
                {
                    dueDateFromPicker.Value = conditions.DueDateFrom.Value;
                    dueDateFromPicker.Checked = true;
                }
                else
                {
                    dueDateFromPicker.Checked = false;
                }

                // 期限日Toの復元
                if (conditions.DueDateToEnabled && conditions.DueDateTo.HasValue)
                {
                    dueDateToPicker.Value = conditions.DueDateTo.Value;
                    dueDateToPicker.Checked = true;
                }
                else
                {
                    dueDateToPicker.Checked = false;
                }

                // 更新日時Fromの復元
                if (conditions.UpdatedDateFromEnabled && conditions.UpdatedDateFrom.HasValue)
                {
                    updatedDateFromPicker.Value = conditions.UpdatedDateFrom.Value;
                    updatedDateFromPicker.Checked = true;
                }
                else
                {
                    updatedDateFromPicker.Checked = false;
                }

                // 更新日時Toの復元
                if (conditions.UpdatedDateToEnabled && conditions.UpdatedDateTo.HasValue)
                {
                    updatedDateToPicker.Value = conditions.UpdatedDateTo.Value;
                    updatedDateToPicker.Checked = true;
                }
                else
                {
                    updatedDateToPicker.Checked = false;
                }

                // ソート順の復元
                if (!string.IsNullOrEmpty(conditions.SortColumn))
                {
                    currentSortColumn = conditions.SortColumn;
                    currentSortDirection = (ListSortDirection)conditions.SortDirection;
                }
            }
            catch (Exception ex)
            {
                // エラーが発生しても初期表示は継続するため、ログ出力のみ
                System.Diagnostics.Debug.WriteLine($"検索条件の復元に失敗: {ex.Message}");
            }
        }
    }
}
