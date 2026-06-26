using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class ContentManager
    {
        static readonly string contentsDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");
        static readonly string uncategorized = "uncategorized";
        static readonly string uncategorizedDirPath = Path.Combine(contentsDirPath, uncategorized);

        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Init()
        {
            if (!Directory.Exists(contentsDirPath))
            {
                Directory.CreateDirectory(contentsDirPath);
            }
            if (!Directory.Exists(uncategorizedDirPath))
            {
                Directory.CreateDirectory(uncategorizedDirPath);
            }
        }

        /// <summary>
        /// カテゴリ一覧取得
        /// </summary>
        /// <returns></returns>
        public static string[] GetCategories()
        {
            return Directory.GetDirectories(contentsDirPath);
        }

        /// <summary>
        /// カテゴリ作成
        /// </summary>
        /// <param name="categoryParam">カテゴリ名</param>
        /// <exception cref="InvalidOperationException">不正な操作</exception>
        public static void CreateCategory(string categoryParam)
        {
            // カテゴリ名を小文字に変換して、前後の空白を削除
            var category = categoryParam.ToLower().Trim();

            if (category == null || category == string.Empty)
            {
                throw new InvalidOperationException("カテゴリ名が指定されていません。");
            }
            if (category == uncategorized)
            {
                throw new InvalidOperationException("uncategorizedカテゴリは作成できません。");
            }
            var categoryPath = Path.Combine(contentsDirPath, category);
            if (!Directory.Exists(categoryPath))
            {
                Directory.CreateDirectory(categoryPath);
            }
            else
            {
                throw new InvalidOperationException("カテゴリが既に存在します。");
            }
        }

        /// <summary>
        /// カテゴリ削除
        /// </summary>
        /// <param name="categoryParam">カテゴリ名</param>
        /// <exception cref="InvalidOperationException">不正な操作</exception>
        public static void DeleteCategory(string categoryParam)
        {
            // カテゴリ名を小文字に変換して、前後の空白を削除
            var category = categoryParam.ToLower().Trim();

            if (category == null || category == string.Empty)
            {
                throw new InvalidOperationException("カテゴリ名が指定されていません。");
            }
            if (category == uncategorized)
            {
                throw new InvalidOperationException("uncategorizedカテゴリは削除できません。");
            }
            if (Directory.Exists(category))
            {
                try
                {
                    string dirFrom = Path.Combine(contentsDirPath, category);
                    string dirTo = uncategorizedDirPath;

                    var files = Directory.GetFiles(category);
                    foreach (var file in files)
                    {
                        string pathFrom = Path.Combine(dirFrom, Path.GetFileName(file));
                        string pathTo = Path.Combine(dirTo, Path.GetFileName(file));
                        File.Move(pathFrom, pathTo);
                    }

                    Console.WriteLine($"カテゴリ「{category}」のファイルを「{uncategorized}」に移動しました。");
                    Directory.Delete(dirFrom);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new InvalidOperationException("カテゴリが存在しません。");
            }
        }

        /// <summary>
        /// ファイル一覧取得
        /// </summary>
        /// <param name="categories">カテゴリ名（複数）</param>
        /// <returns></returns>
        public static string[] GetDocuments(string[]? categories)
        {
            if (categories == null || categories.Length == 0)
            {
                return Directory.GetFiles(contentsDirPath, "*.md", SearchOption.AllDirectories);
            }
            else
            {
                var files = new List<string>();
                foreach (var category in categories)
                {
                    var categoryPath = Path.Combine(contentsDirPath, category);
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
            var filePath = Path.Combine(contentsDirPath, fileName + ".md");
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
            var filePath = Path.Combine(contentsDirPath, fileName + ".md");

            // TODO: 同じファイル名が存在する場合は、上書き保存する
            try
            {
                File.WriteAllText(filePath, contents);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
