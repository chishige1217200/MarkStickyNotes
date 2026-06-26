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
            categoriesListBox = new CheckedListBox();
            SuspendLayout();
            // 
            // categoriesListBox
            // 
            categoriesListBox.FormattingEnabled = true;
            categoriesListBox.Location = new Point(12, 12);
            categoriesListBox.Name = "categoriesListBox";
            categoriesListBox.Size = new Size(120, 94);
            categoriesListBox.TabIndex = 0;
            // 
            // ListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(categoriesListBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListForm";
            Text = "MarkStickyNotes";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox categoriesListBox;
    }
}
