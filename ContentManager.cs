using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class ContentManager
    {
        static readonly string contentsDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");

        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Init()
        {
            // コンテンツ保存用ディレクトリの作成
            if (!Directory.Exists(contentsDirPath))
            {
                Directory.CreateDirectory(contentsDirPath);
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
                return File.ReadAllText(filePath);
            }
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
                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
