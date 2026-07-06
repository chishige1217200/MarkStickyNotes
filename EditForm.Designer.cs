namespace MarkStickyNotes
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            titleTextBox = new TextBox();
            editButton = new Button();
            markdownRichTextBox = new RichTextBox();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            colorComboBox = new ComboBox();
            statusComboBox = new ComboBox();
            closeButton = new Button();
            startDatePicker = new DateTimePicker();
            dueDatePicker = new DateTimePicker();
            statusLabel = new Label();
            startDateLabel = new Label();
            dueDateLabel = new Label();
            colorLabel = new Label();
            issueTypeComboBox = new ComboBox();
            assigneeComboBox = new ComboBox();
            categoryComboBox = new ComboBox();
            priorityComboBox = new ComboBox();
            issueTypeLabel = new Label();
            assigneeLabel = new Label();
            categoryLabel = new Label();
            priorityLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleTextBox.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            titleTextBox.Location = new Point(12, 12);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "件名";
            titleTextBox.Size = new Size(735, 29);
            titleTextBox.TabIndex = 0;
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editButton.Location = new Point(753, 12);
            editButton.Name = "editButton";
            editButton.Size = new Size(82, 29);
            editButton.TabIndex = 1;
            editButton.Text = "編集";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += EditButton_Click;
            // 
            // markdownRichTextBox
            // 
            markdownRichTextBox.AllowDrop = true;
            markdownRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            markdownRichTextBox.Font = new Font("Yu Gothic UI", 10F);
            markdownRichTextBox.Location = new Point(12, 110);
            markdownRichTextBox.Name = "markdownRichTextBox";
            markdownRichTextBox.Size = new Size(920, 379);
            markdownRichTextBox.TabIndex = 11;
            markdownRichTextBox.Text = "";
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(12, 110);
            webView.Name = "webView";
            webView.Size = new Size(920, 379);
            webView.TabIndex = 11;
            webView.ZoomFactor = 1D;
            // 
            // colorComboBox
            // 
            colorComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorComboBox.FormattingEnabled = true;
            colorComboBox.Location = new Point(653, 80);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(130, 23);
            colorComboBox.TabIndex = 10;
            colorComboBox.SelectedIndexChanged += ColorComboBox_SelectedIndexChanged;
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(450, 50);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(130, 23);
            statusComboBox.TabIndex = 5;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.Location = new Point(841, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(91, 29);
            closeButton.TabIndex = 2;
            closeButton.Text = "削除";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // startDatePicker
            // 
            startDatePicker.CustomFormat = "yyyy/MM/dd";
            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.Location = new Point(64, 80);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.ShowCheckBox = true;
            startDatePicker.Size = new Size(122, 23);
            startDatePicker.TabIndex = 7;
            // 
            // dueDatePicker
            // 
            dueDatePicker.CustomFormat = "yyyy/MM/dd";
            dueDatePicker.Format = DateTimePickerFormat.Custom;
            dueDatePicker.Location = new Point(255, 80);
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.ShowCheckBox = true;
            dueDatePicker.Size = new Size(122, 23);
            dueDatePicker.TabIndex = 8;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(406, 53);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(34, 15);
            statusLabel.TabIndex = 12;
            statusLabel.Text = "状態:";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(12, 83);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(46, 15);
            startDateLabel.TabIndex = 13;
            startDateLabel.Text = "開始日:";
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(203, 83);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(46, 15);
            dueDateLabel.TabIndex = 14;
            dueDateLabel.Text = "期限日:";
            // 
            // colorLabel
            // 
            colorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(621, 83);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(22, 15);
            colorLabel.TabIndex = 15;
            colorLabel.Text = "色:";
            // 
            // issueTypeComboBox
            // 
            issueTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            issueTypeComboBox.FormattingEnabled = true;
            issueTypeComboBox.Location = new Point(64, 50);
            issueTypeComboBox.Name = "issueTypeComboBox";
            issueTypeComboBox.Size = new Size(122, 23);
            issueTypeComboBox.TabIndex = 3;
            // 
            // assigneeComboBox
            // 
            assigneeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            assigneeComboBox.FormattingEnabled = true;
            assigneeComboBox.Location = new Point(255, 50);
            assigneeComboBox.Name = "assigneeComboBox";
            assigneeComboBox.Size = new Size(122, 23);
            assigneeComboBox.TabIndex = 4;
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(653, 50);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(130, 23);
            categoryComboBox.TabIndex = 6;
            // 
            // priorityComboBox
            // 
            priorityComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityComboBox.FormattingEnabled = true;
            priorityComboBox.Location = new Point(450, 80);
            priorityComboBox.Name = "priorityComboBox";
            priorityComboBox.Size = new Size(130, 23);
            priorityComboBox.TabIndex = 9;
            // 
            // issueTypeLabel
            // 
            issueTypeLabel.AutoSize = true;
            issueTypeLabel.Location = new Point(24, 53);
            issueTypeLabel.Name = "issueTypeLabel";
            issueTypeLabel.Size = new Size(34, 15);
            issueTypeLabel.TabIndex = 16;
            issueTypeLabel.Text = "種別:";
            // 
            // assigneeLabel
            // 
            assigneeLabel.AutoSize = true;
            assigneeLabel.Location = new Point(203, 53);
            assigneeLabel.Name = "assigneeLabel";
            assigneeLabel.Size = new Size(46, 15);
            assigneeLabel.TabIndex = 17;
            assigneeLabel.Text = "担当者:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(598, 53);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(45, 15);
            categoryLabel.TabIndex = 18;
            categoryLabel.Text = "カテゴリ:";
            // 
            // priorityLabel
            // 
            priorityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new Point(394, 83);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(46, 15);
            priorityLabel.TabIndex = 19;
            priorityLabel.Text = "優先度:";
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 501);
            Controls.Add(priorityLabel);
            Controls.Add(categoryLabel);
            Controls.Add(assigneeLabel);
            Controls.Add(issueTypeLabel);
            Controls.Add(priorityComboBox);
            Controls.Add(categoryComboBox);
            Controls.Add(assigneeComboBox);
            Controls.Add(issueTypeComboBox);
            Controls.Add(colorLabel);
            Controls.Add(dueDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(statusLabel);
            Controls.Add(dueDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(closeButton);
            Controls.Add(statusComboBox);
            Controls.Add(colorComboBox);
            Controls.Add(webView);
            Controls.Add(markdownRichTextBox);
            Controls.Add(editButton);
            Controls.Add(titleTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 540);
            Name = "EditForm";
            Text = "MarkStickyNotes";
            MouseDown += EditForm_MouseDown;
            MouseMove += EditForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private Button editButton;
        private RichTextBox markdownRichTextBox;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private ComboBox colorComboBox;
        private ComboBox statusComboBox;
        private Button closeButton;
        private DateTimePicker startDatePicker;
        private DateTimePicker dueDatePicker;
        private Label statusLabel;
        private Label startDateLabel;
        private Label dueDateLabel;
        private Label colorLabel;
        private ComboBox issueTypeComboBox;
        private ComboBox assigneeComboBox;
        private ComboBox categoryComboBox;
        private ComboBox priorityComboBox;
        private Label issueTypeLabel;
        private Label assigneeLabel;
        private Label categoryLabel;
        private Label priorityLabel;
    }
}