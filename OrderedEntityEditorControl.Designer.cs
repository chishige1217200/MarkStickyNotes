namespace MarkStickyNotes
{
    partial class OrderedEntityEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            entityListBox = new ListBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            upButton = new Button();
            downButton = new Button();
            SuspendLayout();
            // 
            // entityListBox
            // 
            entityListBox.FormattingEnabled = true;
            entityListBox.ItemHeight = 15;
            entityListBox.Location = new Point(3, 3);
            entityListBox.Name = "entityListBox";
            entityListBox.Size = new Size(300, 349);
            entityListBox.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(309, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(100, 30);
            addButton.TabIndex = 1;
            addButton.Text = "追加";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(309, 39);
            editButton.Name = "editButton";
            editButton.Size = new Size(100, 30);
            editButton.TabIndex = 2;
            editButton.Text = "編集";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += EditButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(309, 75);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(100, 30);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "削除";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // upButton
            // 
            upButton.Location = new Point(309, 111);
            upButton.Name = "upButton";
            upButton.Size = new Size(100, 30);
            upButton.TabIndex = 4;
            upButton.Text = "上へ";
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += UpButton_Click;
            // 
            // downButton
            // 
            downButton.Location = new Point(309, 147);
            downButton.Name = "downButton";
            downButton.Size = new Size(100, 30);
            downButton.TabIndex = 5;
            downButton.Text = "下へ";
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += DownButton_Click;
            // 
            // OrderedEntityEditorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(entityListBox);
            Name = "OrderedEntityEditorControl";
            Size = new Size(412, 355);
            ResumeLayout(false);
        }

        #endregion

        private ListBox entityListBox;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button upButton;
        private Button downButton;
    }
}
