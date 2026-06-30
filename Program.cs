namespace MarkStickyNotes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using var mutex =
                new Mutex(true, "MarkStickyNotes", out bool created);

            if (!created)
            {
                MessageBox.Show("MarkStickyNotesは既に起動しています。通知領域を確認してください。", "MarkStickyNotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // SQLitePCLの初期化
            SQLitePCL.Batteries_V2.Init();
            ContentManager.Init();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new TrayApplicationContext());
        }
    }
}