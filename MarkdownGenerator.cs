using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class MarkdownGenerator
    {
        static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contents");

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
        /// ファイル一覧取得
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFileList()
        {
            var fileList = new List<string>();
            var files = Directory.GetFiles(folderPath, "*.md");
            foreach (var file in files)
            {
                fileList.Add(Path.GetFileNameWithoutExtension(file));
            }
            return fileList;
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
    }
}
