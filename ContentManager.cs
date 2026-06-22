using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class ContentManager
    {
        static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");
        static readonly string uncategorizedFolderPath = Path.Combine(folderPath, "uncategorized");

        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Init()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// カテゴリ一覧取得
        /// </summary>
        /// <returns></returns>
        public static string[] GetCategories()
        {
            return Directory.GetDirectories(folderPath);
        }

        /// <summary>
        /// ファイル一覧取得
        /// </summary>
        /// <param name="categories">カテゴリ</param>
        /// <returns></returns>
        public static string[] GetDocuments(string[]? categories)
        {
            if (categories == null || categories.Length == 0)
            {
                return Directory.GetFiles(folderPath, "*.md", SearchOption.AllDirectories);
            }
            else
            {
                var files = new List<string>();
                foreach (var category in categories)
                {
                    var categoryPath = Path.Combine(folderPath, category);
                    if (Directory.Exists(categoryPath))
                    {
                        files.AddRange(Directory.GetFiles(categoryPath, "*.md", SearchOption.AllDirectories));
                    }
                }
                return files.ToArray();
            }
        }

        /// <summary>
        /// ファイル一覧取得
        /// </summary>
        /// <returns></returns>
        public static string[] GetDocuments()
        {
            return GetDocuments(null);
        }

        /// <summary>
        /// ファイル読込
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        public static void Load(string fileName, out string contents)
        {
            var filePath = Path.Combine(folderPath, fileName + ".md");
            if (File.Exists(filePath))
            {
                contents = File.ReadAllText(filePath);
            }
            else
            {
                contents = string.Empty;
            }
        }

        /// <summary>
        /// ファイル保存（新規）
        /// </summary>
        /// <param name="contents"></param>
        public static void Save(string contents)
        {
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Save(contents, fileName);
        }

        /// <summary>
        /// ファイル保存（更新）
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="fileName"></param>
        public static void Save(string contents, string fileName)
        {
            var filePath = Path.Combine(folderPath, fileName + ".md");
            File.WriteAllText(filePath, contents);
        }
    }
}
