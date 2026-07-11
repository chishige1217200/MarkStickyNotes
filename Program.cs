using MarkStickyNotes.DbContexts;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace MarkStickyNotes
{
    internal static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Info("MarkStickyNotes アプリケーション起動");

            using var mutex =
                new Mutex(true, "MarkStickyNotes", out bool created);

            if (!created)
            {
                Logger.Warn("アプリケーションは既に起動しています");
                MessageBox.Show("MarkStickyNotesは既に起動しています。通知領域を確認してください。", "MarkStickyNotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogManager.Shutdown();
                return;
            }

            try
            {
                using var db = new AppDbContext();
                db.Database.Migrate();
                Logger.Info("データベースマイグレーション完了");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "データベース初期化中にエラーが発生しました");
                MessageBox.Show($"データベースの初期化に失敗しました:\n{ex.Message}", "MarkStickyNotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Shutdown();
                return;
            }

            // SQLitePCLの初期化
            SQLitePCL.Batteries_V2.Init();
            ContentManager.Init();
            Logger.Info("コンテンツマネージャー初期化完了");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new TrayApplicationContext());
            
            Logger.Info("MarkStickyNotes アプリケーション終了");
            LogManager.Shutdown();
        }
    }
}