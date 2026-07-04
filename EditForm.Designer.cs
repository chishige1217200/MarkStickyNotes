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
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleTextBox.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            titleTextBox.Location = new Point(12, 12);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "タイトル";
            titleTextBox.Size = new Size(591, 29);
            titleTextBox.TabIndex = 0;
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editButton.Location = new Point(609, 12);
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
            markdownRichTextBox.Location = new Point(12, 80);
            markdownRichTextBox.Name = "markdownRichTextBox";
            markdownRichTextBox.Size = new Size(776, 358);
            markdownRichTextBox.TabIndex = 2;
            markdownRichTextBox.Text = "";
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = System.Drawing.Color.White;
            webView.Location = new Point(12, 80);
            webView.Name = "webView";
            webView.Size = new Size(776, 358);
            webView.TabIndex = 3;
            webView.ZoomFactor = 1D;
            // 
            // colorComboBox
            // 
            colorComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorComboBox.FormattingEnabled = true;
            colorComboBox.Location = new Point(696, 50);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(92, 23);
            colorComboBox.TabIndex = 7;
            colorComboBox.SelectedIndexChanged += ColorComboBox_SelectedIndexChanged;
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(56, 50);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(100, 23);
            statusComboBox.TabIndex = 4;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.Location = new Point(697, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(91, 29);
            closeButton.TabIndex = 2;
            closeButton.Text = "閉じる";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // startDatePicker
            // 
            startDatePicker.CustomFormat = "yyyy/MM/dd";
            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.Location = new Point(226, 50);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.ShowCheckBox = true;
            startDatePicker.Size = new Size(150, 23);
            startDatePicker.TabIndex = 5;
            // 
            // dueDatePicker
            // 
            dueDatePicker.CustomFormat = "yyyy/MM/dd";
            dueDatePicker.Format = DateTimePickerFormat.Custom;
            dueDatePicker.Location = new Point(446, 50);
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.ShowCheckBox = true;
            dueDatePicker.Size = new Size(150, 23);
            dueDatePicker.TabIndex = 6;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 53);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(38, 15);
            statusLabel.TabIndex = 8;
            statusLabel.Text = "状況:";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(162, 53);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(58, 15);
            startDateLabel.TabIndex = 9;
            startDateLabel.Text = "開始日:";
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(382, 53);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(58, 15);
            dueDateLabel.TabIndex = 10;
            dueDateLabel.Text = "期限日:";
            // 
            // colorLabel
            // 
            colorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(666, 53);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(24, 15);
            colorLabel.TabIndex = 11;
            colorLabel.Text = "色:";
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            FormBorderStyle = FormBorderStyle.Sizable;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(400, 300);
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
    }
}