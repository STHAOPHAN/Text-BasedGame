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

            playerTeam.Add(new Player("Player1", 500, 500, 140, 10, 4.5f, 0));//Name, Max Health, Current Health, Damage, Armor, Attack Speed, Mana
            playerTeam.Add(new Player("Player2", 750, 750, 10, 10, 5, 0));
            playerTeam.Add(new Player("Player3", 600, 600, 14, 10, 5.5f, 0));
            playerTeam.Add(new Player("Player4", 250, 250, 30, 10, 3, 0));
            playerTeam.Add(new Player("Player5", 300, 300, 20, 10, 2, 0));

            // Thêm kẻ địch vào đội hình
            enemyTeam.Add(new Enemy("Enemy1", 400, 400, 20, 5, 5));//Name, Max Health, Current Health, Damage, Armor, Attack Speed
            enemyTeam.Add(new Enemy("Enemy2", 400, 400, 20, 5, 5));
            enemyTeam.Add(new Enemy("Enemy3", 400, 400, 20, 5, 5));
            enemyTeam.Add(new Enemy("Enemy4", 250, 250, 30, 0, 4));
            enemyTeam.Add(new Enemy("Enemy5", 250, 250, 30, 0, 4));

            // Khởi tạo và chạy form MainForm
            Application.Run(new MainForm(playerTeam, enemyTeam));
        }
    }
}