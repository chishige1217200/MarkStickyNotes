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
            tabControl = new TabControl();
            statusTabPage = new TabPage();
            statusEditor = new OrderedEntityEditorControl();
            issueTypeTabPage = new TabPage();
            issueTypeEditor = new OrderedEntityEditorControl();
            assigneeTabPage = new TabPage();
            assigneeEditor = new OrderedEntityEditorControl();
            categoryTabPage = new TabPage();
            categoryEditor = new OrderedEntityEditorControl();
            priorityTabPage = new TabPage();
            priorityEditor = new OrderedEntityEditorControl();
            closeButton = new Button();
            tabControl.SuspendLayout();
            statusTabPage.SuspendLayout();
            issueTypeTabPage.SuspendLayout();
            assigneeTabPage.SuspendLayout();
            categoryTabPage.SuspendLayout();
            priorityTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(statusTabPage);
            tabControl.Controls.Add(issueTypeTabPage);
            tabControl.Controls.Add(assigneeTabPage);
            tabControl.Controls.Add(categoryTabPage);
            tabControl.Controls.Add(priorityTabPage);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(428, 394);
            tabControl.TabIndex = 0;
            // 
            // statusTabPage
            // 
            statusTabPage.Controls.Add(statusEditor);
            statusTabPage.Location = new Point(4, 24);
            statusTabPage.Name = "statusTabPage";
            statusTabPage.Padding = new Padding(3);
            statusTabPage.Size = new Size(420, 366);
            statusTabPage.TabIndex = 0;
            statusTabPage.Text = "状態";
            statusTabPage.UseVisualStyleBackColor = true;
            // 
            // statusEditor
            // 
            statusEditor.Location = new Point(6, 6);
            statusEditor.Name = "statusEditor";
            statusEditor.Size = new Size(412, 355);
            statusEditor.TabIndex = 0;
            // 
            // issueTypeTabPage
            // 
            issueTypeTabPage.Controls.Add(issueTypeEditor);
            issueTypeTabPage.Location = new Point(4, 24);
            issueTypeTabPage.Name = "issueTypeTabPage";
            issueTypeTabPage.Padding = new Padding(3);
            issueTypeTabPage.Size = new Size(420, 366);
            issueTypeTabPage.TabIndex = 1;
            issueTypeTabPage.Text = "種別";
            issueTypeTabPage.UseVisualStyleBackColor = true;
            // 
            // issueTypeEditor
            // 
            issueTypeEditor.Location = new Point(6, 6);
            issueTypeEditor.Name = "issueTypeEditor";
            issueTypeEditor.Size = new Size(412, 355);
            issueTypeEditor.TabIndex = 0;
            // 
            // assigneeTabPage
            // 
            assigneeTabPage.Controls.Add(assigneeEditor);
            assigneeTabPage.Location = new Point(4, 24);
            assigneeTabPage.Name = "assigneeTabPage";
            assigneeTabPage.Padding = new Padding(3);
            assigneeTabPage.Size = new Size(420, 366);
            assigneeTabPage.TabIndex = 2;
            assigneeTabPage.Text = "担当者";
            assigneeTabPage.UseVisualStyleBackColor = true;
            // 
            // assigneeEditor
            // 
            assigneeEditor.Location = new Point(6, 6);
            assigneeEditor.Name = "assigneeEditor";
            assigneeEditor.Size = new Size(412, 355);
            assigneeEditor.TabIndex = 0;
            // 
            // categoryTabPage
            // 
            categoryTabPage.Controls.Add(categoryEditor);
            categoryTabPage.Location = new Point(4, 24);
            categoryTabPage.Name = "categoryTabPage";
            categoryTabPage.Padding = new Padding(3);
            categoryTabPage.Size = new Size(420, 366);
            categoryTabPage.TabIndex = 3;
            categoryTabPage.Text = "カテゴリー";
            categoryTabPage.UseVisualStyleBackColor = true;
            // 
            // categoryEditor
            // 
            categoryEditor.Location = new Point(6, 6);
            categoryEditor.Name = "categoryEditor";
            categoryEditor.Size = new Size(412, 355);
            categoryEditor.TabIndex = 0;
            // 
            // priorityTabPage
            // 
            priorityTabPage.Controls.Add(priorityEditor);
            priorityTabPage.Location = new Point(4, 24);
            priorityTabPage.Name = "priorityTabPage";
            priorityTabPage.Padding = new Padding(3);
            priorityTabPage.Size = new Size(420, 366);
            priorityTabPage.TabIndex = 4;
            priorityTabPage.Text = "優先度";
            priorityTabPage.UseVisualStyleBackColor = true;
            // 
            // priorityEditor
            // 
            priorityEditor.Location = new Point(6, 6);
            priorityEditor.Name = "priorityEditor";
            priorityEditor.Size = new Size(412, 355);
            priorityEditor.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(340, 412);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(100, 30);
            closeButton.TabIndex = 1;
            closeButton.Text = "閉じる";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 454);
            Controls.Add(closeButton);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkStickyNotes - 設定";
            Load += SettingsForm_Load;
            tabControl.ResumeLayout(false);
            statusTabPage.ResumeLayout(false);
            issueTypeTabPage.ResumeLayout(false);
            assigneeTabPage.ResumeLayout(false);
            categoryTabPage.ResumeLayout(false);
            priorityTabPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage statusTabPage;
        private OrderedEntityEditorControl statusEditor;
        private TabPage issueTypeTabPage;
        private OrderedEntityEditorControl issueTypeEditor;
        private TabPage assigneeTabPage;
        private OrderedEntityEditorControl assigneeEditor;
        private TabPage categoryTabPage;
        private OrderedEntityEditorControl categoryEditor;
        private TabPage priorityTabPage;
        private OrderedEntityEditorControl priorityEditor;
        private Button closeButton;
    }
}