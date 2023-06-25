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
            // Tạo danh sách người chơi và địch
            List<Player> playerTeam = new List<Player>();
            List<Enemy> enemyTeam = new List<Enemy>();

            // Thêm người chơi vào đội hình

            playerTeam.Add(new Player("Player1", 1, 100, 100, 140, 10, 4.5f, 0, 5));//Name, Max Health, Current Health, Damage, Armor, Attack Speed, Mana
            playerTeam.Add(new Player("Player2", 1, 100, 100, 10, 10, 5, 0, 5));
            playerTeam.Add(new Player("Player3", 1, 100, 100, 14, 10, 5.5f, 0, 5));
            playerTeam.Add(new Player("Player4", 1, 100, 100, 30, 10, 3, 0, 5));
            playerTeam.Add(new Player("Player5", 1, 100, 100, 20, 10, 2, 0, 5));

            // Thêm kẻ địch vào đội hình
            enemyTeam.Add(new Enemy("Enemy1", 1, 100, 100, 20, 5, 5));//Name, Max Health, Current Health, Damage, Armor, Attack Speed
            enemyTeam.Add(new Enemy("Enemy2", 1, 100, 100, 20, 5, 5));
            enemyTeam.Add(new Enemy("Enemy3", 1, 100, 100, 20, 5, 5));
            enemyTeam.Add(new Enemy("Enemy4", 1, 100, 100, 30, 0, 4));
            enemyTeam.Add(new Enemy("Enemy5", 1, 100, 100, 30, 0, 4));

            // Khởi tạo và chạy form MainForm
            Application.Run(new MainForm(playerTeam, enemyTeam));
        }
    }
}