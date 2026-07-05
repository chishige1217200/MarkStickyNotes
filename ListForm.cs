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
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            LoadStatusData();
            InitializeDataGridView();
            PerformSearch(); // 初期表示時に全件検索
        }

        // 検索結果表示用のクラス
        public class NoteSearchResult
        {
            public int Id { get; set; }
            public string Subject { get; set; } = string.Empty;
            public string StatusName { get; set; } = string.Empty;
            public DateTime? StartDate { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime Updated { get; set; }
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

            // タイトル列（画面幅に合わせて伸縮）
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subject",
                DataPropertyName = "Subject",
                HeaderText = "タイトル",
                Width = 300,
                MinimumWidth = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 状態列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusName",
                DataPropertyName = "StatusName",
                HeaderText = "状態",
                Width = 100,
                MinimumWidth = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 開始日列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                DataPropertyName = "StartDate",
                HeaderText = "開始日",
                Width = 100,
                MinimumWidth = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd", NullValue = "" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 期限日列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DueDate",
                DataPropertyName = "DueDate",
                HeaderText = "期限日",
                Width = 100,
                MinimumWidth = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd", NullValue = "" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 更新日時列
            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Updated",
                DataPropertyName = "Updated",
                HeaderText = "更新日時",
                Width = 150,
                MinimumWidth = 120,
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
                "StatusName" => list.OrderBy(x => x.StatusName).ToList(),
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
                "StatusName" => list.OrderByDescending(x => x.StatusName).ToList(),
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

            // タイトル検索
            if (!string.IsNullOrWhiteSpace(titleSearchTextBox.Text))
            {
                var titleKeyword = titleSearchTextBox.Text.Trim();
                query = query.Where(n => n.Subject.Contains(titleKeyword));
            }

            // 状態検索（複数選択）
            var selectedStatuses = statusCheckedListBox.CheckedItems.Cast<Status>().ToList();
            if (selectedStatuses.Any())
            {
                var statusIds = selectedStatuses.Select(s => s.Id.ToString()).ToList();
                query = query.Where(n => statusIds.Contains(n.StatusId));
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
                    StatusName = db.Statuses.Where(s => !s.IsDeleted).Where(s => s.Id.ToString() == n.StatusId).Select(s => s.Name).FirstOrDefault() ?? "",
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
    }
}
