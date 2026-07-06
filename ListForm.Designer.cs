namespace MarkStickyNotes
{
    partial class ListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            titleSearchTextBox = new TextBox();
            issueTypeCheckedListBox = new CheckedListBox();
            assigneeCheckedListBox = new CheckedListBox();
            statusCheckedListBox = new CheckedListBox();
            categoryCheckedListBox = new CheckedListBox();
            priorityCheckedListBox = new CheckedListBox();
            startDateFromPicker = new DateTimePicker();
            startDateToPicker = new DateTimePicker();
            dueDateFromPicker = new DateTimePicker();
            dueDateToPicker = new DateTimePicker();
            updatedDateFromPicker = new DateTimePicker();
            updatedDateToPicker = new DateTimePicker();
            searchButton = new Button();
            resultsDataGridView = new DataGridView();
            titleLabel = new Label();
            issueTypeLabel = new Label();
            assigneeLabel = new Label();
            statusLabel = new Label();
            categoryLabel = new Label();
            priorityLabel = new Label();
            startDateLabel = new Label();
            dueDateLabel = new Label();
            updatedDateLabel = new Label();
            toLabel1 = new Label();
            toLabel2 = new Label();
            toLabel3 = new Label();
            newButton = new Button();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // titleSearchTextBox
            // 
            titleSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleSearchTextBox.Location = new Point(80, 12);
            titleSearchTextBox.Name = "titleSearchTextBox";
            titleSearchTextBox.PlaceholderText = "件名で検索";
            titleSearchTextBox.Size = new Size(852, 23);
            titleSearchTextBox.TabIndex = 0;
            // 
            // issueTypeCheckedListBox
            // 
            issueTypeCheckedListBox.CheckOnClick = true;
            issueTypeCheckedListBox.FormattingEnabled = true;
            issueTypeCheckedListBox.Location = new Point(80, 59);
            issueTypeCheckedListBox.Name = "issueTypeCheckedListBox";
            issueTypeCheckedListBox.Size = new Size(120, 94);
            issueTypeCheckedListBox.TabIndex = 1;
            // 
            // assigneeCheckedListBox
            // 
            assigneeCheckedListBox.CheckOnClick = true;
            assigneeCheckedListBox.FormattingEnabled = true;
            assigneeCheckedListBox.Location = new Point(218, 59);
            assigneeCheckedListBox.Name = "assigneeCheckedListBox";
            assigneeCheckedListBox.Size = new Size(120, 94);
            assigneeCheckedListBox.TabIndex = 2;
            // 
            // statusCheckedListBox
            // 
            statusCheckedListBox.CheckOnClick = true;
            statusCheckedListBox.FormattingEnabled = true;
            statusCheckedListBox.Location = new Point(356, 59);
            statusCheckedListBox.Name = "statusCheckedListBox";
            statusCheckedListBox.Size = new Size(120, 94);
            statusCheckedListBox.TabIndex = 3;
            // 
            // categoryCheckedListBox
            // 
            categoryCheckedListBox.CheckOnClick = true;
            categoryCheckedListBox.FormattingEnabled = true;
            categoryCheckedListBox.Location = new Point(494, 59);
            categoryCheckedListBox.Name = "categoryCheckedListBox";
            categoryCheckedListBox.Size = new Size(120, 94);
            categoryCheckedListBox.TabIndex = 4;
            // 
            // priorityCheckedListBox
            // 
            priorityCheckedListBox.CheckOnClick = true;
            priorityCheckedListBox.FormattingEnabled = true;
            priorityCheckedListBox.Location = new Point(632, 59);
            priorityCheckedListBox.Name = "priorityCheckedListBox";
            priorityCheckedListBox.Size = new Size(120, 94);
            priorityCheckedListBox.TabIndex = 5;
            // 
            // startDateFromPicker
            // 
            startDateFromPicker.Checked = false;
            startDateFromPicker.CustomFormat = "yyyy/MM/dd";
            startDateFromPicker.Format = DateTimePickerFormat.Custom;
            startDateFromPicker.Location = new Point(80, 163);
            startDateFromPicker.Name = "startDateFromPicker";
            startDateFromPicker.ShowCheckBox = true;
            startDateFromPicker.Size = new Size(120, 23);
            startDateFromPicker.TabIndex = 6;
            // 
            // startDateToPicker
            // 
            startDateToPicker.Checked = false;
            startDateToPicker.CustomFormat = "yyyy/MM/dd";
            startDateToPicker.Format = DateTimePickerFormat.Custom;
            startDateToPicker.Location = new Point(226, 163);
            startDateToPicker.Name = "startDateToPicker";
            startDateToPicker.ShowCheckBox = true;
            startDateToPicker.Size = new Size(120, 23);
            startDateToPicker.TabIndex = 7;
            // 
            // dueDateFromPicker
            // 
            dueDateFromPicker.Checked = false;
            dueDateFromPicker.CustomFormat = "yyyy/MM/dd";
            dueDateFromPicker.Format = DateTimePickerFormat.Custom;
            dueDateFromPicker.Location = new Point(80, 192);
            dueDateFromPicker.Name = "dueDateFromPicker";
            dueDateFromPicker.ShowCheckBox = true;
            dueDateFromPicker.Size = new Size(120, 23);
            dueDateFromPicker.TabIndex = 10;
            // 
            // dueDateToPicker
            // 
            dueDateToPicker.Checked = false;
            dueDateToPicker.CustomFormat = "yyyy/MM/dd";
            dueDateToPicker.Format = DateTimePickerFormat.Custom;
            dueDateToPicker.Location = new Point(226, 192);
            dueDateToPicker.Name = "dueDateToPicker";
            dueDateToPicker.ShowCheckBox = true;
            dueDateToPicker.Size = new Size(120, 23);
            dueDateToPicker.TabIndex = 11;
            // 
            // updatedDateFromPicker
            // 
            updatedDateFromPicker.Checked = false;
            updatedDateFromPicker.CustomFormat = "yyyy/MM/dd";
            updatedDateFromPicker.Format = DateTimePickerFormat.Custom;
            updatedDateFromPicker.Location = new Point(424, 163);
            updatedDateFromPicker.Name = "updatedDateFromPicker";
            updatedDateFromPicker.ShowCheckBox = true;
            updatedDateFromPicker.Size = new Size(120, 23);
            updatedDateFromPicker.TabIndex = 8;
            // 
            // updatedDateToPicker
            // 
            updatedDateToPicker.Checked = false;
            updatedDateToPicker.CustomFormat = "yyyy/MM/dd";
            updatedDateToPicker.Format = DateTimePickerFormat.Custom;
            updatedDateToPicker.Location = new Point(570, 163);
            updatedDateToPicker.Name = "updatedDateToPicker";
            updatedDateToPicker.ShowCheckBox = true;
            updatedDateToPicker.Size = new Size(120, 23);
            updatedDateToPicker.TabIndex = 9;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(857, 187);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 29);
            searchButton.TabIndex = 12;
            searchButton.Text = "検索";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.AllowUserToAddRows = false;
            resultsDataGridView.AllowUserToDeleteRows = false;
            resultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            resultsDataGridView.Location = new Point(12, 222);
            resultsDataGridView.MultiSelect = false;
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.ReadOnly = true;
            resultsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsDataGridView.Size = new Size(920, 275);
            resultsDataGridView.TabIndex = 14;
            resultsDataGridView.CellDoubleClick += ResultsDataGridView_CellDoubleClick;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(24, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(43, 15);
            titleLabel.TabIndex = 15;
            titleLabel.Text = "件名：";
            // 
            // issueTypeLabel
            // 
            issueTypeLabel.AutoSize = true;
            issueTypeLabel.Location = new Point(80, 41);
            issueTypeLabel.Name = "issueTypeLabel";
            issueTypeLabel.Size = new Size(43, 15);
            issueTypeLabel.TabIndex = 16;
            issueTypeLabel.Text = "種別：";
            // 
            // assigneeLabel
            // 
            assigneeLabel.AutoSize = true;
            assigneeLabel.Location = new Point(218, 41);
            assigneeLabel.Name = "assigneeLabel";
            assigneeLabel.Size = new Size(55, 15);
            assigneeLabel.TabIndex = 17;
            assigneeLabel.Text = "担当者：";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(356, 41);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(43, 15);
            statusLabel.TabIndex = 18;
            statusLabel.Text = "状態：";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(494, 41);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(54, 15);
            categoryLabel.TabIndex = 19;
            categoryLabel.Text = "カテゴリ：";
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new Point(632, 41);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(55, 15);
            priorityLabel.TabIndex = 20;
            priorityLabel.Text = "優先度：";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(12, 166);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(55, 15);
            startDateLabel.TabIndex = 21;
            startDateLabel.Text = "開始日：";
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(12, 195);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(55, 15);
            dueDateLabel.TabIndex = 22;
            dueDateLabel.Text = "期限日：";
            // 
            // updatedDateLabel
            // 
            updatedDateLabel.AutoSize = true;
            updatedDateLabel.Location = new Point(356, 166);
            updatedDateLabel.Name = "updatedDateLabel";
            updatedDateLabel.Size = new Size(67, 15);
            updatedDateLabel.TabIndex = 23;
            updatedDateLabel.Text = "更新日時：";
            // 
            // toLabel1
            // 
            toLabel1.AutoSize = true;
            toLabel1.Location = new Point(206, 166);
            toLabel1.Name = "toLabel1";
            toLabel1.Size = new Size(19, 15);
            toLabel1.TabIndex = 24;
            toLabel1.Text = "～";
            // 
            // toLabel2
            // 
            toLabel2.AutoSize = true;
            toLabel2.Location = new Point(206, 195);
            toLabel2.Name = "toLabel2";
            toLabel2.Size = new Size(19, 15);
            toLabel2.TabIndex = 25;
            toLabel2.Text = "～";
            // 
            // toLabel3
            // 
            toLabel3.AutoSize = true;
            toLabel3.Location = new Point(550, 166);
            toLabel3.Name = "toLabel3";
            toLabel3.Size = new Size(19, 15);
            toLabel3.TabIndex = 26;
            toLabel3.Text = "～";
            // 
            // newButton
            // 
            newButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newButton.Location = new Point(857, 59);
            newButton.Name = "newButton";
            newButton.Size = new Size(75, 29);
            newButton.TabIndex = 13;
            newButton.Text = "付箋追加";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += NewButton_Click;
            // 
            // ListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 509);
            Controls.Add(newButton);
            Controls.Add(toLabel3);
            Controls.Add(toLabel2);
            Controls.Add(toLabel1);
            Controls.Add(updatedDateLabel);
            Controls.Add(dueDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(priorityLabel);
            Controls.Add(categoryLabel);
            Controls.Add(statusLabel);
            Controls.Add(assigneeLabel);
            Controls.Add(issueTypeLabel);
            Controls.Add(titleLabel);
            Controls.Add(resultsDataGridView);
            Controls.Add(searchButton);
            Controls.Add(updatedDateToPicker);
            Controls.Add(updatedDateFromPicker);
            Controls.Add(dueDateToPicker);
            Controls.Add(dueDateFromPicker);
            Controls.Add(startDateToPicker);
            Controls.Add(startDateFromPicker);
            Controls.Add(priorityCheckedListBox);
            Controls.Add(categoryCheckedListBox);
            Controls.Add(statusCheckedListBox);
            Controls.Add(assigneeCheckedListBox);
            Controls.Add(issueTypeCheckedListBox);
            Controls.Add(titleSearchTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 548);
            Name = "ListForm";
            Text = "MarkStickyNotes - 検索";
            Load += ListForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleSearchTextBox;
        private CheckedListBox issueTypeCheckedListBox;
        private CheckedListBox assigneeCheckedListBox;
        private CheckedListBox statusCheckedListBox;
        private CheckedListBox categoryCheckedListBox;
        private CheckedListBox priorityCheckedListBox;
        private DateTimePicker startDateFromPicker;
        private DateTimePicker startDateToPicker;
        private DateTimePicker dueDateFromPicker;
        private DateTimePicker dueDateToPicker;
        private DateTimePicker updatedDateFromPicker;
        private DateTimePicker updatedDateToPicker;
        private Button searchButton;
        private DataGridView resultsDataGridView;
        private Label titleLabel;
        private Label issueTypeLabel;
        private Label assigneeLabel;
        private Label statusLabel;
        private Label categoryLabel;
        private Label priorityLabel;
        private Label startDateLabel;
        private Label dueDateLabel;
        private Label updatedDateLabel;
        private Label toLabel1;
        private Label toLabel2;
        private Label toLabel3;
        private Button newButton;
    }
}
