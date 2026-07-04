using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarkStickyNotes.DbContexts;
using MarkStickyNotes.Entities;
using Markdig;

namespace MarkStickyNotes
{
    public partial class EditForm : Form
    {
        private bool isEditMode = false;
        private Note? currentNote = null;
        private bool isNewNote = true; // 新規作成フラグ

        public EditForm()
        {
            InitializeComponent();
            LoadComboBoxData();
            InitializeWebView();

            // タイトルの変更を監視
            titleTextBox.TextChanged += TitleTextBox_TextChanged;

            // ドラッグ&ドロップイベントハンドラを登録
            markdownRichTextBox.DragEnter += MarkdownRichTextBox_DragEnter;
            markdownRichTextBox.DragDrop += MarkdownRichTextBox_DragDrop;
        }

        public EditForm(int noteId) : this()
        {
            isNewNote = false; // 既存ノートの場合
            LoadNote(noteId);
        }

        // WebView2の初期化
        private async void InitializeWebView()
        {
            await webView.EnsureCoreWebView2Async(null);

            // contentsフォルダを仮想ホスト名にマッピング
            var contentsDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "markstickynotesapp.local",
                contentsDirPath,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

            // NavigationStartingイベントを登録（ファイルリンクを外部アプリで開く）
            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            // 新規作成の場合は編集モードで起動
            if (isNewNote)
            {
                CreateNewNote();
            }
            else
            {
                // 既存ノートの場合、初期化完了後にレンダリング
                if (!isEditMode)
                {
                    RenderMarkdown();
                }
            }
        }

        // ComboBoxデータの読み込み
        private void LoadComboBoxData()
        {
            using var db = new AppDbContext();

            // Colors ComboBox
            var colors = db.Colors.OrderBy(c => c.Order).ToList();
            colorComboBox.DisplayMember = "Name";
            colorComboBox.ValueMember = "Id";
            colorComboBox.DataSource = colors;

            // Status ComboBox
            var statuses = db.Status.Where(s => !s.IsDeleted).OrderBy(s => s.Order).ToList();
            statusComboBox.DisplayMember = "Name";
            statusComboBox.ValueMember = "Id";
            statusComboBox.DataSource = statuses;

            // デフォルトを選択
            if (colors.Count > 0)
            {
                colorComboBox.SelectedIndex = 0;
            }
            if (statuses.Count > 0)
            {
                statusComboBox.SelectedIndex = 0;
            }
        }

        // タイトルを取得・設定するプロパティ
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get => titleTextBox.Text;
            set => titleTextBox.Text = value;
        }

        // Markdownテキストを取得・設定するプロパティ
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MarkdownText
        {
            get => markdownRichTextBox.Text;
            set => markdownRichTextBox.Text = value;
        }

        // 既存のノートを読み込む
        public void LoadNote(int noteId)
        {
            using var db = new AppDbContext();
            currentNote = db.Notes.FirstOrDefault(n => n.Id == noteId && !n.IsDeleted);
            if (currentNote != null)
            {
                Text += $" - id: {noteId}"; // フォームタイトルを変更
                titleTextBox.Text = currentNote.Subject;

                // ContentManagerからMarkdownを読み込む
                if (!string.IsNullOrEmpty(currentNote.ContentFileName))
                {
                    markdownRichTextBox.Text = ContentManager.Load(currentNote.ContentFileName);
                }

                // Color と Status を選択
                if (!string.IsNullOrEmpty(currentNote.ColorId) && int.TryParse(currentNote.ColorId, out int colorId))
                {
                    colorComboBox.SelectedValue = colorId;
                    // 背景色を適用
                    var color = db.Colors.Find(colorId);
                    if (color != null)
                    {
                        try
                        {
                            this.BackColor = ColorTranslator.FromHtml(color.ColorCode);
                        }
                        catch { }
                    }
                }
                if (!string.IsNullOrEmpty(currentNote.StatusId) && int.TryParse(currentNote.StatusId, out int statusId))
                {
                    statusComboBox.SelectedValue = statusId;
                }

                // 開始日と期限日を設定
                if (currentNote.StartDate.HasValue)
                {
                    startDatePicker.Checked = true;
                    startDatePicker.Value = currentNote.StartDate.Value;
                }
                else
                {
                    startDatePicker.Checked = false;
                }

                if (currentNote.DueDate.HasValue)
                {
                    dueDatePicker.Checked = true;
                    dueDatePicker.Value = currentNote.DueDate.Value;
                }
                else
                {
                    dueDatePicker.Checked = false;
                }

                SetViewMode(false); // 閲覧モードで表示
            }
            else
            {
                // ノートが見つからない場合は新規作成
                CreateNewNote();
            }
        }

        // 新規ノートを作成
        public void CreateNewNote()
        {
            currentNote = new Note
            {
                Subject = "",
                ContentFileName = "",
                ColorId = colorComboBox.SelectedValue?.ToString() ?? "1",
                StatusId = statusComboBox.SelectedValue?.ToString() ?? "1",
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            titleTextBox.Text = "";
            markdownRichTextBox.Text = "";

            // 日付ピッカーをリセット
            startDatePicker.Checked = false;
            dueDatePicker.Checked = false;

            // 背景色を適用
            if (colorComboBox.SelectedItem is Entities.Color selectedColor)
            {
                try
                {
                    this.BackColor = ColorTranslator.FromHtml(selectedColor.ColorCode);
                }
                catch { }
            }

            SetViewMode(true); // 編集モードで開始
        }

        // 編集/閲覧モードの切り替え
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // 編集モードから閲覧モードへ(保存)
                SaveNote();
                SetViewMode(false);
            }
            else
            {
                // 閲覧モードから編集モードへ
                SetViewMode(true);
            }
        }

        // モードの設定
        private void SetViewMode(bool editMode)
        {
            isEditMode = editMode;

            if (editMode)
            {
                // 編集モード
                editButton.Text = "保存";
                titleTextBox.ReadOnly = false;
                markdownRichTextBox.Visible = true;
                webView.Visible = false;

                // コントロールを有効化
                colorComboBox.Enabled = true;
                statusComboBox.Enabled = true;
                startDatePicker.Enabled = true;
                dueDatePicker.Enabled = true;

                // タイトルの入力状態をチェック
                UpdateSaveButtonState();
            }
            else
            {
                // 閲覧モード
                editButton.Text = "編集";
                titleTextBox.ReadOnly = true;
                markdownRichTextBox.Visible = false;
                webView.Visible = true;

                // コントロールを無効化
                colorComboBox.Enabled = false;
                statusComboBox.Enabled = false;
                startDatePicker.Enabled = false;
                dueDatePicker.Enabled = false;

                // MarkdownをHTMLに変換してWebViewに表示
                RenderMarkdown();
            }
        }

        // Markdownを表示
        private void RenderMarkdown()
        {
            // WebView2が初期化されていない場合は処理をスキップ
            if (webView.CoreWebView2 == null)
            {
                return;
            }

            var markdown = markdownRichTextBox.Text;
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var html = Markdown.ToHtml(markdown, pipeline);

            // 相対パスを仮想ホスト名のURLに変換
            // 例: "20241231_120000_files/image.png" -> "https://markstickynotesapp.local/20241231_120000_files/image.png"
            html = System.Text.RegularExpressions.Regex.Replace(
                html,
                @"(src|href)=""([^""]+)""",
                match =>
                {
                    var attribute = match.Groups[1].Value;
                    var path = match.Groups[2].Value;

                    // http:// または https:// で始まる場合はそのまま
                    if (path.StartsWith("http://") || path.StartsWith("https://"))
                    {
                        return match.Value;
                    }

                    // 相対パスの場合は仮想ホスト名のURLに変換
                    return $@"{attribute}=""https://markstickynotesapp.local/{path}""";
                });

            // HTMLテンプレート
            var fullHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='color-scheme' content='light'>
    <style>
        body {{
            font-family: 'Yu Gothic UI', 'Meiryo', sans-serif;
            padding: 8px;
            margin: 0;
            line-height: 1.3;
            background-color: #ffffff;
            color: #000000;
        }}
        h1, h2, h3, h4, h5, h6 {{
            margin-top: 8px;
            margin-bottom: 4px;
            font-weight: 600;
            line-height: 1.1;
            color: #000000;
        }}
        p {{
            margin-top: 4px;
            margin-bottom: 4px;
        }}
        ul, ol {{
            margin-top: 4px;
            margin-bottom: 4px;
            padding-left: 20px;
        }}
        code {{
            background-color: #f6f8fa;
            color: #000000;
            padding: 2px 4px;
            border-radius: 3px;
            font-family: Consolas, monospace;
        }}
        pre {{
            background-color: #f6f8fa;
            color: #000000;
            padding: 8px;
            margin: 4px 0;
            border-radius: 6px;
            overflow: auto;
        }}
        pre code {{
            background-color: transparent;
        }}
        blockquote {{
            border-left: 4px solid #dfe2e5;
            padding-left: 12px;
            margin: 4px 0;
            color: #6a737d;
        }}
        table {{
            border-collapse: collapse;
            width: 100%;
            margin: 4px 0;
            background-color: #ffffff;
        }}
        table th, table td {{
            border: 1px solid #dfe2e5;
            padding: 4px 8px;
            color: #000000;
        }}
        a {{
            color: #0366d6;
        }}
        img {{
            max-width: 100%;
            height: auto;
            display: block;
        }}
    </style>
</head>
<body>
    {html}
</body>
</html>";

            webView.NavigateToString(fullHtml);
        }

        // ノートを保存
        private void SaveNote()
        {
            if (currentNote == null) return;

            using var db = new AppDbContext();

            // タイトルを更新
            currentNote.Subject = titleTextBox.Text;
            currentNote.Updated = DateTime.Now;

            // Color と Status を保存
            currentNote.ColorId = colorComboBox.SelectedValue?.ToString() ?? "";
            currentNote.StatusId = statusComboBox.SelectedValue?.ToString() ?? "";

            // 開始日と期限日を保存（時分秒は00:00:00として保存）
            currentNote.StartDate = startDatePicker.Checked ? startDatePicker.Value.Date : null;
            currentNote.DueDate = dueDatePicker.Checked ? dueDatePicker.Value.Date : null;

            // ContentManagerを使用してMarkdownを保存
            if (string.IsNullOrEmpty(currentNote.ContentFileName))
            {
                // 新規作成
                currentNote.ContentFileName = ContentManager.Save(markdownRichTextBox.Text);
            }
            else
            {
                // 更新
                ContentManager.Save(markdownRichTextBox.Text, currentNote.ContentFileName);
            }

            // DBに保存
            if (currentNote.Id == 0)
            {
                // 新規登録
                db.Notes.Add(currentNote);
            }
            else
            {
                // 更新
                db.Notes.Update(currentNote);
            }

            db.SaveChanges();
        }

        //マウスのクリック位置を記憶
        private Point mousePoint;

        //タイトルバー領域のMouseDownイベントハンドラ
        private void EditForm_MouseDown(object sender, MouseEventArgs e)
        {
            // タイトルバー領域でのみドラッグ移動を有効化（最上部40ピクセル）
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && e.Y < 40)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        //タイトルバー領域のMouseMoveイベントハンドラ
        private void EditForm_MouseMove(object sender, MouseEventArgs e)
        {
            // タイトルバー領域でのドラッグ移動
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && mousePoint != Point.Empty)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        // Colorが変更されたときにフォームの背景色を変更
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.SelectedItem is Entities.Color selectedColor)
            {
                try
                {
                    this.BackColor = ColorTranslator.FromHtml(selectedColor.ColorCode);
                }
                catch
                {
                    // 色コードが無効な場合はデフォルトのまま
                }
            }
        }

        // 削除ボタンのクリックイベント
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // 新規作成中またはノートが存在しない場合は何もしない
            if (currentNote == null || currentNote.Id == 0)
            {
                MessageBox.Show("削除できるノートがありません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 削除確認ダイアログを表示
            var result = MessageBox.Show(
                $"「{currentNote.Subject}」を削除してもよろしいですか？",
                "削除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var db = new AppDbContext();

                // データベースで論理削除フラグを立てる
                var noteToDelete = db.Notes.FirstOrDefault(n => n.Id == currentNote.Id && !n.IsDeleted);
                if (noteToDelete != null)
                {
                    noteToDelete.IsDeleted = true;
                    noteToDelete.Updated = DateTime.Now;
                    db.Notes.Update(noteToDelete);
                    db.SaveChanges();
                }

                // フォームを閉じる
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"削除中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // タイトルの入力状態をチェックして保存ボタンの有効/無効を切り替え
        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                UpdateSaveButtonState();
            }
        }

        // 保存ボタンの状態を更新
        private void UpdateSaveButtonState()
        {
            // タイトルが空の場合は保存ボタンを無効化
            editButton.Enabled = !string.IsNullOrWhiteSpace(titleTextBox.Text);
        }

        // ドラッグ開始イベント
        private void MarkdownRichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            // ファイルがドラッグされている場合のみ許可
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // ドロップイベント
        private void MarkdownRichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            // 編集モードでない場合は処理しない
            if (!isEditMode)
            {
                MessageBox.Show("編集モードでドラッグ&ドロップしてください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ノートが保存されていない場合は先に保存
            if (currentNote == null || string.IsNullOrEmpty(currentNote.ContentFileName))
            {
                MessageBox.Show("ファイルを添付する前にノートを一度保存してください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                var insertTexts = new List<string>();

                foreach (var filePath in files)
                {
                    try
                    {
                        // ファイルを添付フォルダにコピー
                        var relativePath = ContentManager.SaveAttachment(filePath, currentNote.ContentFileName);

                        // ファイル名と拡張子を取得
                        var fileName = Path.GetFileName(filePath);
                        var extension = Path.GetExtension(filePath).ToLower();

                        // 画像ファイルかどうかを判定
                        var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".svg", ".webp" };
                        string markdownLink;

                        if (imageExtensions.Contains(extension))
                        {
                            // 画像の場合
                            markdownLink = $"![]({relativePath})";
                        }
                        else
                        {
                            // その他のファイルの場合
                            markdownLink = $"[{fileName}]({relativePath})";
                        }

                        insertTexts.Add(markdownLink);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ファイルの処理中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // カーソル位置にMarkdownリンクを挿入
                if (insertTexts.Count > 0)
                {
                    var insertText = string.Join("\n", insertTexts);
                    var selectionStart = markdownRichTextBox.SelectionStart;
                    markdownRichTextBox.Text = markdownRichTextBox.Text.Insert(selectionStart, insertText);
                    markdownRichTextBox.SelectionStart = selectionStart + insertText.Length;
                    markdownRichTextBox.Focus();
                }
            }
        }

        // WebView2のナビゲーション開始イベント（ファイルリンクを外部アプリで開く）
        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            var uri = new Uri(e.Uri);

            // 仮想ホスト名でない場合は通常のナビゲーション
            if (uri.Host != "markstickynotesapp.local")
            {
                return;
            }

            // 画像ファイルの拡張子
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".svg", ".webp" };
            var extension = Path.GetExtension(uri.LocalPath).ToLower();

            // 画像の場合はWebView内で表示
            if (imageExtensions.Contains(extension))
            {
                return;
            }

            // 画像以外のファイルは外部アプリで開く
            e.Cancel = true;

            try
            {
                // 仮想ホストのパスを実際のファイルパスに変換
                var contentsDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");
                var relativePath = uri.LocalPath.TrimStart('/');
                var actualFilePath = Path.Combine(contentsDirPath, relativePath);

                if (File.Exists(actualFilePath))
                {
                    // Windowsの規定のアプリでファイルを開く
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = actualFilePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show($"ファイルが見つかりません: {actualFilePath}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ファイルを開けませんでした: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
