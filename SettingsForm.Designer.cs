namespace MarkStickyNotes
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            statusLabel = new Label();
            statusListBox = new ListBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            upButton = new Button();
            downButton = new Button();
            closeButton = new Button();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(96, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "状態管理:";
            // 
            // statusListBox
            // 
            statusListBox.FormattingEnabled = true;
            statusListBox.ItemHeight = 15;
            statusListBox.Location = new Point(12, 27);
            statusListBox.Name = "statusListBox";
            statusListBox.Size = new Size(300, 349);
            statusListBox.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Location = new Point(318, 27);
            addButton.Name = "addButton";
            addButton.Size = new Size(100, 30);
            addButton.TabIndex = 2;
            addButton.Text = "追加";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(318, 63);
            editButton.Name = "editButton";
            editButton.Size = new Size(100, 30);
            editButton.TabIndex = 3;
            editButton.Text = "編集";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += EditButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(318, 99);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(100, 30);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "削除";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // upButton
            // 
            upButton.Location = new Point(318, 135);
            upButton.Name = "upButton";
            upButton.Size = new Size(100, 30);
            upButton.TabIndex = 5;
            upButton.Text = "上へ";
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += UpButton_Click;
            // 
            // downButton
            // 
            downButton.Location = new Point(318, 171);
            downButton.Name = "downButton";
            downButton.Size = new Size(100, 30);
            downButton.TabIndex = 6;
            downButton.Text = "下へ";
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += DownButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(318, 346);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(100, 30);
            closeButton.TabIndex = 7;
            closeButton.Text = "閉じる";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 391);
            Controls.Add(closeButton);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(statusListBox);
            Controls.Add(statusLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkStickyNotes - 設定";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLabel;
        private ListBox statusListBox;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button upButton;
        private Button downButton;
        private Button closeButton;
    }
}