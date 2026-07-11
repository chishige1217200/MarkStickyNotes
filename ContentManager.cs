using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MarkStickyNotes
{
    public class ContentManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static readonly string rootDirPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "chishige1217200",
            "MarkStickyNotes");
        public static readonly string contentsDirPath = Path.Combine(rootDirPath, "contents");

        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Init()
        {
            Logger.Debug("コンテンツマネージャー初期化開始");
            // コンテンツ保存用ディレクトリの作成
            if (!Directory.Exists(contentsDirPath))
            {
                Directory.CreateDirectory(contentsDirPath);
                Logger.Info($"コンテンツディレクトリ作成: {contentsDirPath}");
            }
            else
            {
                Logger.Debug("コンテンツディレクトリは既に存在します");
            }
        }

        /// <summary>
        /// ファイル読込
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public static string Load(string fileName)
        {
            var filePath = Path.Combine(contentsDirPath, fileName + ".md");
            if (File.Exists(filePath))
            {
                Logger.Debug($"ファイル読込: {fileName}");
                return File.ReadAllText(filePath);
            }
            Logger.Debug($"ファイルが存在しません: {fileName}");
            return string.Empty;
        }

        /// <summary>
        /// ファイル保存（新規）
        /// </summary>
        /// <param name="contents">本文</param>
        /// <returns></returns>
        public static string Save(string contents)
        {
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return Save(contents, fileName);
        }

        /// <summary>
        /// ファイル保存（更新）
        /// </summary>
        /// <param name="contents">本文</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static string Save(string contents, string fileName)
        {
            var filePath = Path.Combine(contentsDirPath, fileName + ".md");
            try
            {
                File.WriteAllText(filePath, contents);
                Logger.Debug($"ファイル保存: {fileName}");
                return fileName;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"ファイル保存に失敗: {fileName}");
                throw;
            }
        }

        /// <summary>
        /// 添付ファイル用ディレクトリパスを取得
        /// </summary>
        /// <param name="fileName">コンテンツファイル名</param>
        /// <returns>添付ファイルディレクトリのフルパス</returns>
        public static string GetAttachmentDirectoryPath(string fileName)
        {
            return Path.Combine(contentsDirPath, fileName + "_files");
        }

        /// <summary>
        /// 添付ファイルを保存
        /// </summary>
        /// <param name="sourceFilePath">ソースファイルのフルパス</param>
        /// <param name="contentFileName">コンテンツファイル名</param>
        /// <returns>Markdown用の相対パス</returns>
        public static string SaveAttachment(string sourceFilePath, string contentFileName)
        {
            var attachmentDir = GetAttachmentDirectoryPath(contentFileName);

            // ディレクトリが存在しない場合は作成
            if (!Directory.Exists(attachmentDir))
            {
                Directory.CreateDirectory(attachmentDir);
            }

            // ファイル名を取得
            var originalFileName = Path.GetFileName(sourceFilePath);
            var fileName = originalFileName;
            var destinationPath = Path.Combine(attachmentDir, fileName);

            // 同名ファイルが存在する場合は連番を付与
            int counter = 1;
            while (File.Exists(destinationPath))
            {
                var nameWithoutExt = Path.GetFileNameWithoutExtension(originalFileName);
                var extension = Path.GetExtension(originalFileName);
                fileName = $"{nameWithoutExt}_{counter}{extension}";
                destinationPath = Path.Combine(attachmentDir, fileName);
                counter++;
            }

            // ファイルをコピー
            File.Copy(sourceFilePath, destinationPath);

            // Markdown用の相対パス（コンテンツファイルからの相対パス）
            return $"{contentFileName}_files/{fileName}";
        }
    }
}
