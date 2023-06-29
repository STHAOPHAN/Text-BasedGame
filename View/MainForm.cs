using System;
using System.Windows.Forms;
using Text_BasedGame.Models;
using Text_BasedGame.Controllers;

namespace View
{
    public partial class MainForm : Form
    {
        private Player player;
        private Enemy enemy;
        private System.Windows.Forms.Timer timer;
        private int tickInterval = 1000; // Thời gian giữa các tick của Timer (ms)
        private List<Player> playerTeam;
        private List<Enemy> enemyTeam;
        private Random random = new Random();
        private Player player1, player2, player3, player4, player5;
        private Enemy enemy1, enemy2, enemy3, enemy4, enemy5;
        private List<Item> items;
        private EquipmentControllercs equipmentControllercs = new EquipmentControllercs();
        private System.Windows.Forms.Timer moveTimer;
        private Panel playerPanel;
        private Panel targetPanel;
        private Point targetPosition;
        private int moveSpeed = 10; // Tốc độ di chuyển của panel (có thể điều chỉnh)
        private Point originalPlayerPosition;
        private CharacterForm characterForm;
        private InventoryForm inventoryForm;

        public MainForm(List<Player> playerTeam, List<Enemy> enemyTeam, List<Item> items)
        {
            InitializeComponent();

            this.playerTeam = playerTeam;
            this.enemyTeam = enemyTeam;
            this.items = items;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = tickInterval;
            timer.Tick += Timer_Tick;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public List<Player> GetPlayers()
        {
            return playerTeam;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Thiết lập giao diện ban đầu

            // Hiển thị thông tin người chơi và kẻ địch
            UpdatePlayerInfo();
            UpdateEnemyInfo();

            // Bắt đầu đếm ngược để tấn công tự động
            timer.Start();
        }

        private void MovePlayerToTarget(Panel playerpanel, Point originalPlayerPosition, Point targetPosition)
        {
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = moveSpeed;
            moveTimer.Tick += (sender, e) => MoveToTargetTimer_Tick(sender, e, playerpanel, originalPlayerPosition, targetPosition, moveTimer);
            moveTimer.Start();
        }

        private void MovePlayerToOriginalPosition(Panel playerpanel, Point originalPlayerPosition, System.Windows.Forms.Timer moveTimer)
        {
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = moveSpeed;
            moveTimer.Tick += (sender, e) => MoveToOriginalTimer_Tick(sender, e, playerpanel, originalPlayerPosition, moveTimer);
            moveTimer.Start();
        }

        private void MoveToTargetTimer_Tick(object sender, EventArgs e, Panel playerpanel, Point originalPlayerPosition, Point targetPosition, System.Windows.Forms.Timer moveTimer)
        {
            if (!playerpanel.Bounds.IntersectsWith(new Rectangle(targetPosition, playerPanel.Size)))
            {
                // Di chuyển nhân vật đến vị trí cần tấn công
                playerpanel.Left += (playerpanel.Location.X < targetPosition.X) ? moveSpeed : -moveSpeed;
                playerpanel.Top += (playerpanel.Location.Y < targetPosition.Y) ? moveSpeed : -moveSpeed;
            }
            else
            {
                // Đã đến vị trí cần tấn công
                moveTimer.Stop();

                // Thực hiện hành động tấn công

                // Di chuyển nhân vật trở về vị trí ban đầu
                MovePlayerToOriginalPosition(playerpanel, originalPlayerPosition, moveTimer);
                UpdatePlayerInfo();
                UpdateEnemyInfo();
            }
        }

        private void MoveToOriginalTimer_Tick(object sender, EventArgs e, Panel playerpanel, Point originalPlayerPosition, System.Windows.Forms.Timer moveTimer)
        {
            if (playerpanel.Location != originalPlayerPosition)
            {
                // Di chuyển nhân vật về vị trí ban đầu
                playerpanel.Left += (playerpanel.Location.X < originalPlayerPosition.X) ? moveSpeed : -moveSpeed;
                playerpanel.Top += (playerpanel.Location.Y < originalPlayerPosition.Y) ? moveSpeed : -moveSpeed;
            }
            else
            {
                // Đã đến vị trí ban đầu
                moveTimer.Stop();

                // Tiếp tục đếm ngược để tấn công tự động
                timer.Start();
            }
        }

        private void PlayerStrike(Player player, ProgressBar timerbar, Panel playerpanel)
        {
            if (player.curHealth <= 0)
            {
                // Người chơi đã chết, không thể tấn công nữa
                timerbar.Enabled = false;
                return;
            }
            int bonus = 0;
            if ((timerbar.Value + (6000 / (player.attackSpeed))) > 6000)
            {
                bonus = (int)((timerbar.Value + (6000 / (player.attackSpeed))) - 6000);
                timerbar.Value = 6000;
            }
            else
            {
                timerbar.Value += (int)(6000 / (player.attackSpeed));
            }
            if (timerbar.Value >= timerbar.Maximum)
            {
                timer.Stop();
                // Reset giá trị ProgressBar về 0
                timerbar.Value = 0 + bonus;

                // Lựa chọn ngẫu nhiên một đối thủ từ danh sách địch
                Enemy targetEnemy = GetRandomEnemy();
                int count = 0;
                while (targetEnemy.curHealth <= 0)
                {
                    // Đối thủ đã chết, chọn một đối thủ khác
                    targetEnemy = GetRandomEnemy();
                    count++;
                    if (count > 5) break;
                }
                Point targetPosition = new Point();
                if (targetEnemy.name.Contains('1'))
                {
                    targetPosition = pnlEnemy1.Location;
                }
                else if (targetEnemy.name.Contains('2'))
                {
                    targetPosition = pnlEnemy2.Location;
                }
                else if (targetEnemy.name.Contains('3'))
                {
                    targetPosition = pnlEnemy3.Location;
                }
                else if (targetEnemy.name.Contains('4'))
                {
                    targetPosition = pnlEnemy4.Location;
                }
                else if (targetEnemy.name.Contains('5'))
                {
                    targetPosition = pnlEnemy5.Location;
                }
                // Lưu vị trí ban đầu của nhân vật
                Point originalPlayerPosition = playerpanel.Location;

                playerPanel = playerpanel;

                // Di chuyển nhân vật đến vị trí của đối tượng cần tấn công

                MovePlayerToTarget(playerpanel, originalPlayerPosition, targetPosition);

                // Thực hiện hành động tấn công của người chơi lên đối thủ được chọn
                player.Attack(targetEnemy);

                // Di chuyển nhân vật trở lại vị trí ban đầu
                playerPanel = playerpanel;
            }
        }
        private void EnemyStrike(Enemy enemy, ProgressBar timerbar)
        {
            if (enemy.curHealth <= 0)
            {
                // Người chơi đã chết, không thể tấn công nữa
                timerbar.Enabled = false;
                return;
            }
            int bonus = 0;
            if ((timerbar.Value + (6000 / (enemy.attackSpeed))) > 6000)
            {
                bonus = (int)((timerbar.Value + (6000 / (enemy.attackSpeed))) - 6000);
            }
            else
            {
                timerbar.Value += (int)(6000 / (enemy.attackSpeed));
            }
            if (timerbar.Value >= timerbar.Maximum)
            {
                // Reset giá trị ProgressBar về 0
                timerbar.Value = 0 + bonus;

                // Lựa chọn ngẫu nhiên một đối thủ từ danh sách đồng minh
                Player targetPlayer = GetRandomPlayer();
                while (targetPlayer.curHealth <= 0)
                {
                    // Đối thủ đã chết, chọn một đối thủ khác
                    targetPlayer = GetRandomPlayer();
                }
                // Thực hiện hành động tấn công của địch lên đồng minh được chọn
                enemy.Attack(targetPlayer);

                // Cập nhật thông tin hiển thị
                UpdatePlayerInfo();
                UpdateEnemyInfo();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Tăng giá trị hiện tại của ProgressBar người chơi lên 1
            if (player1 != null)
            {
                PlayerStrike(player1, playerTimerBar1, pnlPlayer1);
            }
            if (player2 != null)
            {
                PlayerStrike(player2, playerTimerBar2, pnlPlayer2);
            }
            if (player3 != null)
            {
                PlayerStrike(player3, playerTimerBar3, pnlPlayer3);
            }
            if (player4 != null)
            {
                PlayerStrike(player4, playerTimerBar4, pnlPlayer4);
            }
            if (player5 != null)
            {
                PlayerStrike(player5, playerTimerBar5, pnlPlayer5);
            }
            if (enemy1 != null)
            {
                EnemyStrike(enemy1, enemyTimerBar1);
            }
            if (enemy2 != null)
            {
                EnemyStrike(enemy2, enemyTimerBar2);
            }
            if (enemy3 != null)
            {
                EnemyStrike(enemy3, enemyTimerBar3);
            }
            if (enemy4 != null)
            {
                EnemyStrike(enemy4, enemyTimerBar4);
            }
            if (enemy5 != null)
            {
                EnemyStrike(enemy5, enemyTimerBar5);
            }
            CheckWinCondition();
        }

        private void UpdatePlayerInfo()
        {
            // Hiển thị thông tin của nhân vật đầu tiên trong đội hình người chơi
            if (playerTeam.Count > 0)
            {
                player1 = playerTeam[0];
                ShowPlayer(player1, lblPlayerName1, playerHealthProgressBar1, lblPlayerHealth1);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblPlayerName1, playerHealthProgressBar1, lblPlayerHealth1, playerTimerBar1, pnlPlayer1);
            }
            if (playerTeam.Count > 1)
            {
                player2 = playerTeam[1];
                ShowPlayer(player2, lblPlayerName2, playerHealthProgressBar2, lblPlayerHealth2);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblPlayerName2, playerHealthProgressBar2, lblPlayerHealth2, playerTimerBar2, pnlPlayer2);
            }
            if (playerTeam.Count > 2)
            {
                player3 = playerTeam[2];
                ShowPlayer(player3, lblPlayerName3, playerHealthProgressBar3, lblPlayerHealth3);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblPlayerName3, playerHealthProgressBar3, lblPlayerHealth3, playerTimerBar3, pnlPlayer3);
            }
            if (playerTeam.Count > 3)
            {
                player4 = playerTeam[3];
                ShowPlayer(player4, lblPlayerName4, playerHealthProgressBar4, lblPlayerHealth4);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblPlayerName4, playerHealthProgressBar4, lblPlayerHealth4, playerTimerBar4, pnlPlayer4);
            }
            if (playerTeam.Count > 4)
            {
                player5 = playerTeam[4];
                ShowPlayer(player5, lblPlayerName5, playerHealthProgressBar5, lblPlayerHealth5);
            }
            else
            {
                HideSlotEmpty(lblPlayerName5, playerHealthProgressBar5, lblPlayerHealth5, playerTimerBar5, pnlPlayer5);
            }
        }

        private void UpdateEnemyInfo()
        {
            // Hiển thị thông tin của nhân vật đầu tiên trong đội hình kẻ địch
            if (enemyTeam.Count > 0)
            {
                enemy1 = enemyTeam[0];
                ShowEnemy(enemy1, lblEnemyName1, enemyHealthProgressBar1, lblEnemyHealth1);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblEnemyName1, enemyHealthProgressBar1, lblEnemyHealth1, enemyTimerBar1, pnlEnemy1);
            }
            if (enemyTeam.Count > 1)
            {
                enemy2 = enemyTeam[1];
                ShowEnemy(enemy2, lblEnemyName2, enemyHealthProgressBar2, lblEnemyHealth2);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblEnemyName2, enemyHealthProgressBar2, lblEnemyHealth2, enemyTimerBar2, pnlEnemy2);
            }
            if (enemyTeam.Count > 2)
            {
                enemy3 = enemyTeam[2];
                ShowEnemy(enemy3, lblEnemyName3, enemyHealthProgressBar3, lblEnemyHealth3);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblEnemyName3, enemyHealthProgressBar3, lblEnemyHealth3, enemyTimerBar3, pnlEnemy3);
            }
            if (enemyTeam.Count > 3)
            {
                enemy4 = enemyTeam[3];
                ShowEnemy(enemy4, lblEnemyName4, enemyHealthProgressBar4, lblEnemyHealth4);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblEnemyName4, enemyHealthProgressBar4, lblEnemyHealth4, enemyTimerBar4, pnlEnemy4);
            }
            if (enemyTeam.Count > 4)
            {
                enemy5 = enemyTeam[4];
                ShowEnemy(enemy5, lblEnemyName5, enemyHealthProgressBar5, lblEnemyHealth5);
            }
            else
            {
                // Ẩn các điều khiển
                HideSlotEmpty(lblEnemyName5, enemyHealthProgressBar5, lblEnemyHealth5, enemyTimerBar5, pnlEnemy5);
            }
        }

        private void HideSlotEmpty(Label namelabel, ProgressBar pb, Label healthlabel, ProgressBar timerbar, Panel panel)
        {
            // Ẩn các điều khiển
            namelabel.Visible = false;
            pb.Visible = false;
            healthlabel.Visible = false;
            timerbar.Visible = false;
            panel.Visible = false;
        }

        private void ShowPlayer(Player player, Label namelabel, ProgressBar pb, Label healthlabel)
        {
            namelabel.Text = player.name;
            pb.Maximum = (int)player.maxHealth;
            if (player.curHealth < 0)
            {
                player.curHealth = 0;
            }
            pb.Value = (int)player.curHealth;
            healthlabel.Text = $"{player.curHealth}/{player.maxHealth}";
        }

        private void ShowEnemy(Enemy enemy, Label namelabel, ProgressBar pb, Label healthlabel)
        {
            namelabel.Text = enemy.name;
            pb.Maximum = (int)enemy.maxHealth;
            if (enemy.curHealth < 0)
            {
                enemy.curHealth = 0;
            }
            pb.Value = (int)enemy.curHealth;
            healthlabel.Text = $"{enemy.curHealth}/{enemy.maxHealth}";
        }

        private Enemy GetRandomEnemy()
        {
            int randomIndex = random.Next(enemyTeam.Count);
            return enemyTeam[randomIndex];
        }

        private Player GetRandomPlayer()
        {
            int randomIndex = random.Next(playerTeam.Count);
            return playerTeam[randomIndex];
        }

        private void CheckWinCondition()
        {
            bool playerTeamAlive = playerTeam.Any(player => player.curHealth > 0);
            bool enemyTeamAlive = enemyTeam.Any(enemy => enemy.curHealth > 0);
            if (!playerTeamAlive)
            {
                // Ví dụ: Hiển thị thông báo chiến thắng
                MessageBox.Show("Bạn đã thua!", "Thông báo");
                // Hồi máu đầy cho các nhân vật người chơi
                foreach (Player player in playerTeam)
                {
                    player.curHealth = player.maxHealth;
                }
            }
            else if (!enemyTeamAlive)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string imagePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
                Equipment equipment = equipmentControllercs.LoadEquipmentFromFile(imagePath);
                items.Add(equipment);
                foreach (Enemy enemy in enemyTeam)
                {
                    enemy.curHealth = enemy.maxHealth;
                }
                lblMessage.Visible = true;
                lblMessage.Text = "Bạn đã chiến thắng! Bạn nhận được một trang bị mới:\n" + equipment.Name.ToString();

                UpdateInventory(items);

            }
        }

        private void UpdateInventory(List<Item> items)
        {
            if (inventoryForm != null)
            {
                inventoryForm.UpdateItems(items);
            }
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            if (characterForm == null || characterForm.IsDisposed)
            {
                // Tạo một instance mới của CharacterForm và truyền danh sách người chơi vào constructor
                characterForm = new CharacterForm(playerTeam, items);
            }

            // Hiển thị CharacterForm
            characterForm.BringToFront();
            characterForm.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (inventoryForm == null || inventoryForm.IsDisposed)
            {
                // Tạo một instance mới của InventoryForm và truyền danh sách vật phẩm và đội ngũ người chơi vào constructor
                inventoryForm = new InventoryForm(items, playerTeam);
            }

            // Hiển thị InventoryForm
            inventoryForm.BringToFront();
            inventoryForm.Show();
        }

        private void btnSkill_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng ứng dụng hoặc xử lý tắt trò chơi ở đây
                Application.Exit(); // Đóng ứng dụng

                // Hoặc
                // this.Close(); // Đóng cửa sổ chứa trò chơi
            }
        }

        // Các sự kiện và phương thức khác cần thiết cho MainForm
        // ...
    }
}
