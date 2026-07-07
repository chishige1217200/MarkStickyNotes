namespace MarkStickyNotes.Models
{
    /// <summary>
    /// 検索条件を保持するクラス
    /// </summary>
    public class SearchConditions
    {
        /// <summary>
        /// 件名検索キーワード
        /// </summary>
        public string TitleSearch { get; set; } = string.Empty;

        /// <summary>
        /// 選択された種別のID一覧
        /// </summary>
        public List<int> SelectedIssueTypeIds { get; set; } = new();

        /// <summary>
        /// 選択された担当者のID一覧
        /// </summary>
        public List<int> SelectedAssigneeIds { get; set; } = new();

        /// <summary>
        /// 選択された状態のID一覧
        /// </summary>
        public List<int> SelectedStatusIds { get; set; } = new();

        /// <summary>
        /// 選択されたカテゴリのID一覧
        /// </summary>
        public List<int> SelectedCategoryIds { get; set; } = new();

        /// <summary>
        /// 選択された優先度のID一覧
        /// </summary>
        public List<int> SelectedPriorityIds { get; set; } = new();

        /// <summary>
        /// 開始日From
        /// </summary>
        public DateTime? StartDateFrom { get; set; }

        /// <summary>
        /// 開始日From有効フラグ
        /// </summary>
        public bool StartDateFromEnabled { get; set; }

        /// <summary>
        /// 開始日To
        /// </summary>
        public DateTime? StartDateTo { get; set; }

        /// <summary>
        /// 開始日To有効フラグ
        /// </summary>
        public bool StartDateToEnabled { get; set; }

        /// <summary>
        /// 期限日From
        /// </summary>
        public DateTime? DueDateFrom { get; set; }

        /// <summary>
        /// 期限日From有効フラグ
        /// </summary>
        public bool DueDateFromEnabled { get; set; }

        /// <summary>
        /// 期限日To
        /// </summary>
        public DateTime? DueDateTo { get; set; }

        /// <summary>
        /// 期限日To有効フラグ
        /// </summary>
        public bool DueDateToEnabled { get; set; }

        /// <summary>
        /// 更新日時From
        /// </summary>
        public DateTime? UpdatedDateFrom { get; set; }

        /// <summary>
        /// 更新日時From有効フラグ
        /// </summary>
        public bool UpdatedDateFromEnabled { get; set; }

        /// <summary>
        /// 更新日時To
        /// </summary>
        public DateTime? UpdatedDateTo { get; set; }

        /// <summary>
        /// 更新日時To有効フラグ
        /// </summary>
        public bool UpdatedDateToEnabled { get; set; }

        /// <summary>
        /// ソート対象列名（DataPropertyName）
        /// </summary>
        public string SortColumn { get; set; } = "Updated";

        /// <summary>
        /// ソート方向（0: Ascending, 1: Descending）
        /// </summary>
        public int SortDirection { get; set; } = 1; // Descending
    }
}
