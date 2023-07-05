using System.Reflection;
using Text_BasedGame.Models;

namespace View
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo và chạy form MainForm
            Application.Run(new MainMenuForm());
        }
    }
}