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
            statusCheckedListBox = new CheckedListBox();
            startDateFromPicker = new DateTimePicker();
            startDateToPicker = new DateTimePicker();
            dueDateFromPicker = new DateTimePicker();
            dueDateToPicker = new DateTimePicker();
            updatedDateFromPicker = new DateTimePicker();
            updatedDateToPicker = new DateTimePicker();
            searchButton = new Button();
            resultsDataGridView = new DataGridView();
            titleLabel = new Label();
            statusLabel = new Label();
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
            titleSearchTextBox.PlaceholderText = "タイトルで検索";
            titleSearchTextBox.Size = new Size(516, 23);
            titleSearchTextBox.TabIndex = 0;
            // 
            // statusCheckedListBox
            // 
            statusCheckedListBox.CheckOnClick = true;
            statusCheckedListBox.FormattingEnabled = true;
            statusCheckedListBox.Location = new Point(80, 41);
            statusCheckedListBox.Name = "statusCheckedListBox";
            statusCheckedListBox.Size = new Size(150, 94);
            statusCheckedListBox.TabIndex = 1;
            // 
            // startDateFromPicker
            // 
            startDateFromPicker.Checked = false;
            startDateFromPicker.CustomFormat = "yyyy/MM/dd";
            startDateFromPicker.Format = DateTimePickerFormat.Custom;
            startDateFromPicker.Location = new Point(330, 41);
            startDateFromPicker.Name = "startDateFromPicker";
            startDateFromPicker.ShowCheckBox = true;
            startDateFromPicker.Size = new Size(120, 23);
            startDateFromPicker.TabIndex = 2;
            // 
            // startDateToPicker
            // 
            startDateToPicker.Checked = false;
            startDateToPicker.CustomFormat = "yyyy/MM/dd";
            startDateToPicker.Format = DateTimePickerFormat.Custom;
            startDateToPicker.Location = new Point(476, 41);
            startDateToPicker.Name = "startDateToPicker";
            startDateToPicker.ShowCheckBox = true;
            startDateToPicker.Size = new Size(120, 23);
            startDateToPicker.TabIndex = 3;
            // 
            // dueDateFromPicker
            // 
            dueDateFromPicker.Checked = false;
            dueDateFromPicker.CustomFormat = "yyyy/MM/dd";
            dueDateFromPicker.Format = DateTimePickerFormat.Custom;
            dueDateFromPicker.Location = new Point(330, 70);
            dueDateFromPicker.Name = "dueDateFromPicker";
            dueDateFromPicker.ShowCheckBox = true;
            dueDateFromPicker.Size = new Size(120, 23);
            dueDateFromPicker.TabIndex = 4;
            // 
            // dueDateToPicker
            // 
            dueDateToPicker.Checked = false;
            dueDateToPicker.CustomFormat = "yyyy/MM/dd";
            dueDateToPicker.Format = DateTimePickerFormat.Custom;
            dueDateToPicker.Location = new Point(476, 70);
            dueDateToPicker.Name = "dueDateToPicker";
            dueDateToPicker.ShowCheckBox = true;
            dueDateToPicker.Size = new Size(120, 23);
            dueDateToPicker.TabIndex = 5;
            // 
            // updatedDateFromPicker
            // 
            updatedDateFromPicker.Checked = false;
            updatedDateFromPicker.CustomFormat = "yyyy/MM/dd";
            updatedDateFromPicker.Format = DateTimePickerFormat.Custom;
            updatedDateFromPicker.Location = new Point(330, 99);
            updatedDateFromPicker.Name = "updatedDateFromPicker";
            updatedDateFromPicker.ShowCheckBox = true;
            updatedDateFromPicker.Size = new Size(120, 23);
            updatedDateFromPicker.TabIndex = 6;
            // 
            // updatedDateToPicker
            // 
            updatedDateToPicker.Checked = false;
            updatedDateToPicker.CustomFormat = "yyyy/MM/dd";
            updatedDateToPicker.Format = DateTimePickerFormat.Custom;
            updatedDateToPicker.Location = new Point(476, 99);
            updatedDateToPicker.Name = "updatedDateToPicker";
            updatedDateToPicker.ShowCheckBox = true;
            updatedDateToPicker.Size = new Size(120, 23);
            updatedDateToPicker.TabIndex = 7;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(713, 106);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 29);
            searchButton.TabIndex = 8;
            searchButton.Text = "検索";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.AllowUserToAddRows = false;
            resultsDataGridView.AllowUserToDeleteRows = false;
            resultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Location = new Point(12, 145);
            resultsDataGridView.MultiSelect = false;
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.ReadOnly = true;
            resultsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsDataGridView.Size = new Size(776, 293);
            resultsDataGridView.TabIndex = 9;
            resultsDataGridView.CellDoubleClick += ResultsDataGridView_CellDoubleClick;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(12, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(55, 15);
            titleLabel.TabIndex = 10;
            titleLabel.Text = "タイトル：";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 41);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(43, 15);
            statusLabel.TabIndex = 11;
            statusLabel.Text = "状況：";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(250, 44);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(55, 15);
            startDateLabel.TabIndex = 12;
            startDateLabel.Text = "開始日：";
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(250, 73);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(55, 15);
            dueDateLabel.TabIndex = 13;
            dueDateLabel.Text = "期限日：";
            // 
            // updatedDateLabel
            // 
            updatedDateLabel.AutoSize = true;
            updatedDateLabel.Location = new Point(250, 102);
            updatedDateLabel.Name = "updatedDateLabel";
            updatedDateLabel.Size = new Size(67, 15);
            updatedDateLabel.TabIndex = 14;
            updatedDateLabel.Text = "更新日時：";
            // 
            // toLabel1
            // 
            toLabel1.AutoSize = true;
            toLabel1.Location = new Point(456, 44);
            toLabel1.Name = "toLabel1";
            toLabel1.Size = new Size(19, 15);
            toLabel1.TabIndex = 15;
            toLabel1.Text = "～";
            // 
            // toLabel2
            // 
            toLabel2.AutoSize = true;
            toLabel2.Location = new Point(456, 73);
            toLabel2.Name = "toLabel2";
            toLabel2.Size = new Size(19, 15);
            toLabel2.TabIndex = 16;
            toLabel2.Text = "～";
            // 
            // toLabel3
            // 
            toLabel3.AutoSize = true;
            toLabel3.Location = new Point(456, 102);
            toLabel3.Name = "toLabel3";
            toLabel3.Size = new Size(19, 15);
            toLabel3.TabIndex = 17;
            toLabel3.Text = "～";
            // 
            // newButton
            // 
            newButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newButton.Location = new Point(713, 73);
            newButton.Name = "newButton";
            newButton.Size = new Size(75, 29);
            newButton.TabIndex = 18;
            newButton.Text = "付箋追加";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += NewButton_Click;
            // 
            // ListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newButton);
            Controls.Add(toLabel3);
            Controls.Add(toLabel2);
            Controls.Add(toLabel1);
            Controls.Add(updatedDateLabel);
            Controls.Add(dueDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(statusLabel);
            Controls.Add(titleLabel);
            Controls.Add(resultsDataGridView);
            Controls.Add(searchButton);
            Controls.Add(updatedDateToPicker);
            Controls.Add(updatedDateFromPicker);
            Controls.Add(dueDateToPicker);
            Controls.Add(dueDateFromPicker);
            Controls.Add(startDateToPicker);
            Controls.Add(startDateFromPicker);
            Controls.Add(statusCheckedListBox);
            Controls.Add(titleSearchTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 400);
            Name = "ListForm";
            Text = "MarkStickyNotes - 検索";
            Load += ListForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleSearchTextBox;
        private CheckedListBox statusCheckedListBox;
        private DateTimePicker startDateFromPicker;
        private DateTimePicker startDateToPicker;
        private DateTimePicker dueDateFromPicker;
        private DateTimePicker dueDateToPicker;
        private DateTimePicker updatedDateFromPicker;
        private DateTimePicker updatedDateToPicker;
        private Button searchButton;
        private DataGridView resultsDataGridView;
        private Label titleLabel;
        private Label statusLabel;
        private Label startDateLabel;
        private Label dueDateLabel;
        private Label updatedDateLabel;
        private Label toLabel1;
        private Label toLabel2;
        private Label toLabel3;
        private Button newButton;
    }
}
