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

            // Khởi tạo đối tượng Player
            Player player = new Player("Player1",100, 90, 10, 10, 3, 100);

            // Khởi tạo đối tượng Enemy
            Enemy enemy = new Enemy("Enemy1",80, 80, 8, 0, 5);

            // Tạo form chính và truyền các đối tượng vào
            MainForm mainForm = new MainForm(player, enemy);

            // Hiển thị form chính
            Application.Run(mainForm);
        }
    }
}