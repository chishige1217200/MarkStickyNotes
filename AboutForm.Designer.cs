namespace MarkStickyNotes
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            iconPictureBox = new PictureBox();
            appNameLabel = new Label();
            versionLabel = new Label();
            copyrightLabel = new Label();
            descriptionLabel = new Label();
            tabControl = new TabControl();
            infoTabPage = new TabPage();
            infoTextBox = new TextBox();
            librariesTabPage = new TabPage();
            librariesTextBox = new TextBox();
            githubLinkLabel = new LinkLabel();
            closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            tabControl.SuspendLayout();
            infoTabPage.SuspendLayout();
            librariesTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.Image = (Image)resources.GetObject("iconPictureBox.Image");
            iconPictureBox.Location = new Point(12, 12);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(64, 64);
            iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold);
            appNameLabel.Location = new Point(82, 12);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new Size(182, 30);
            appNameLabel.TabIndex = 1;
            appNameLabel.Text = "MarkStickyNotes";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(82, 45);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(78, 15);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "バージョン 1.0.1";
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Location = new Point(82, 61);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(189, 15);
            copyrightLabel.TabIndex = 3;
            copyrightLabel.Text = "Copyright © chishige1217200 2026";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(12, 86);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(207, 15);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Markdownに対応した付箋アプリケーション";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(infoTabPage);
            tabControl.Controls.Add(librariesTabPage);
            tabControl.Location = new Point(12, 115);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(560, 270);
            tabControl.TabIndex = 5;
            // 
            // infoTabPage
            // 
            infoTabPage.Controls.Add(infoTextBox);
            infoTabPage.Location = new Point(4, 24);
            infoTabPage.Name = "infoTabPage";
            infoTabPage.Padding = new Padding(3);
            infoTabPage.Size = new Size(552, 242);
            infoTabPage.TabIndex = 0;
            infoTabPage.Text = "使用技術";
            infoTabPage.UseVisualStyleBackColor = true;
            // 
            // infoTextBox
            // 
            infoTextBox.BackColor = SystemColors.Window;
            infoTextBox.Dock = DockStyle.Fill;
            infoTextBox.Font = new Font("Yu Gothic UI", 9F);
            infoTextBox.Location = new Point(3, 3);
            infoTextBox.Multiline = true;
            infoTextBox.Name = "infoTextBox";
            infoTextBox.ReadOnly = true;
            infoTextBox.ScrollBars = ScrollBars.Vertical;
            infoTextBox.Size = new Size(546, 236);
            infoTextBox.TabIndex = 0;
            infoTextBox.Text = "【フレームワーク】\r\n.NET 10.0\r\nWindows Forms\r\n\r\n【データベース】\r\nSQLite\r\nEntity Framework Core\r\n\r\n【Markdown表示】\r\nMarkdig - Markdownパーサー\r\nMicrosoft Edge WebView2 - HTMLレンダリング";
            // 
            // librariesTabPage
            // 
            librariesTabPage.Controls.Add(librariesTextBox);
            librariesTabPage.Location = new Point(4, 24);
            librariesTabPage.Name = "librariesTabPage";
            librariesTabPage.Padding = new Padding(3);
            librariesTabPage.Size = new Size(552, 242);
            librariesTabPage.TabIndex = 1;
            librariesTabPage.Text = "使用ライブラリ";
            librariesTabPage.UseVisualStyleBackColor = true;
            // 
            // librariesTextBox
            // 
            librariesTextBox.BackColor = SystemColors.Window;
            librariesTextBox.Dock = DockStyle.Fill;
            librariesTextBox.Font = new Font("Yu Gothic UI", 9F);
            librariesTextBox.Location = new Point(3, 3);
            librariesTextBox.Multiline = true;
            librariesTextBox.Name = "librariesTextBox";
            librariesTextBox.ReadOnly = true;
            librariesTextBox.ScrollBars = ScrollBars.Vertical;
            librariesTextBox.Size = new Size(546, 236);
            librariesTextBox.TabIndex = 0;
            librariesTextBox.Text = resources.GetString("librariesTextBox.Text");
            // 
            // githubLinkLabel
            // 
            githubLinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            githubLinkLabel.AutoSize = true;
            githubLinkLabel.Location = new Point(12, 397);
            githubLinkLabel.Name = "githubLinkLabel";
            githubLinkLabel.Size = new Size(293, 15);
            githubLinkLabel.TabIndex = 6;
            githubLinkLabel.TabStop = true;
            githubLinkLabel.Tag = "https://github.com/chishige1217200/MarkStickyNotes";
            githubLinkLabel.Text = "https://github.com/chishige1217200/MarkStickyNotes";
            githubLinkLabel.LinkClicked += LinkLabel_LinkClicked;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(497, 391);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 27);
            closeButton.TabIndex = 7;
            closeButton.Text = "OK";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 430);
            Controls.Add(closeButton);
            Controls.Add(githubLinkLabel);
            Controls.Add(tabControl);
            Controls.Add(descriptionLabel);
            Controls.Add(copyrightLabel);
            Controls.Add(versionLabel);
            Controls.Add(appNameLabel);
            Controls.Add(iconPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(600, 469);
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkStickyNotes について";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            tabControl.ResumeLayout(false);
            infoTabPage.ResumeLayout(false);
            infoTabPage.PerformLayout();
            librariesTabPage.ResumeLayout(false);
            librariesTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox iconPictureBox;
        private Label appNameLabel;
        private Label versionLabel;
        private Label copyrightLabel;
        private Label descriptionLabel;
        private TabControl tabControl;
        private TabPage infoTabPage;
        private TextBox infoTextBox;
        private TabPage librariesTabPage;
        private TextBox librariesTextBox;
        private LinkLabel githubLinkLabel;
        private Button closeButton;
    }
}
