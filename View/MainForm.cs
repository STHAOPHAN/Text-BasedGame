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
        private EquipmentController equipmentControllercs = new EquipmentController();
        private ResourceController resourceController = new ResourceController();
        private System.Windows.Forms.Timer moveTimer;
        private Panel playerPanel;
        private Panel targetPanel;
        private Point targetPosition;
        private int moveSpeed = 10; // Tốc độ di chuyển của panel (có thể điều chỉnh)
        private Point originalPlayerPosition;
        private CharacterForm characterForm;
        private InventoryForm inventoryForm;
        private SettingsForm settingsForm;
        private SkillsForm skillForm;
        private ShopForm dungeonForm;
        private int turnCount = 1;
        private Enemy boss;
        private Resource resources;
        private bool isGameOverMessageShown = false;

        public MainForm(List<Player> playerTeam, List<Enemy> enemyTeam, List<Item> items, Resource resource)
        {
            InitializeComponent();

            this.playerTeam = playerTeam;
            this.enemyTeam = enemyTeam;
            this.items = items;
            this.resources = resource;
            isGameOverMessageShown = false;
            if (enemyTeam[0].name.Equals("Boss")) boss = enemyTeam[0];
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
            UpdateResourceInfo();

            // Bắt đầu đếm ngược để tấn công tự động
            timer.Start();
        }

        private void UpdateResourceInfo()
        {
            if (resources != null)
            {
                lblGold.Text = resources.Gold.ToString();
                lblDiamond.Text = resources.Diamond.ToString();
            }
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
                if (bonus > 6000)
                {
                    bonus = 6000;
                }
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
                if (targetEnemy.name.Contains('1') || targetEnemy.name.Equals("Boss"))
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
                int count = 0;
                while (targetPlayer.curHealth <= 0)
                {
                    // Đối thủ đã chết, chọn một đối thủ khác
                    targetPlayer = GetRandomPlayer();
                    count++;
                    if (count > 5) break;
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
            namelabel.Text = $"{player.name} | Lvl {player.level}";
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
            namelabel.Text = $"{enemy.name} | Lvl {enemy.level}";
            pb.Maximum = (int)enemy.maxHealth;
            if (enemy.curHealth < 0)
            {
                enemy.curHealth = 0;
            }
            pb.Value = (int)enemy.curHealth;
            healthlabel.Text = $"{enemy.curHealth}/{enemy.maxHealth}";
        }

        private void ShowSlotEnemy(Label namelabel, ProgressBar pb, Label healthlabel, ProgressBar timerbar, Panel panel)
        {
            // Hiện các điều khiển
            namelabel.Visible = true;
            pb.Visible = true;
            healthlabel.Visible = true;
            timerbar.Visible = true;
            panel.Visible = true;
        }

        private Enemy GetRandomEnemy()
        {
            int randomIndex = random.Next(enemyTeam.Count);
            if (enemyTeam[randomIndex] == null) return null;
            else
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
                if (!isGameOverMessageShown)
                {
                    isGameOverMessageShown = true;
                    // Ví dụ: Hiển thị thông báo chiến thắng
                    DialogResult result = MessageBox.Show("Bạn đã thua!", "Thông báo", MessageBoxButtons.OK);
                    // Kiểm tra nếu người dùng đã bấm OK
                    if (result == DialogResult.OK)
                    {
                        // Hồi máu đầy cho các nhân vật người chơi
                        foreach (Player player in playerTeam)
                        {
                            player.curHealth = player.maxHealth;
                        }
                        if (enemyTeam[0].name.Equals("Boss"))
                        {
                            enemyTeam = new List<Enemy>
                            {
                                new Enemy("Enemy1", boss.level, 100 + boss.level * 50, 100 + boss.level * 50, 8 + boss.level * 2, 5 + boss.level, 5),
                                new Enemy("Enemy2", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5),
                                new Enemy("Enemy3", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5),
                                new Enemy("Enemy4", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5),
                                new Enemy("Enemy5", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5),
                            };
                            ShowSlotEnemy(lblEnemyName2, enemyHealthProgressBar2, lblEnemyHealth2, enemyTimerBar2, pnlEnemy2);
                            ShowSlotEnemy(lblEnemyName3, enemyHealthProgressBar3, lblEnemyHealth3, enemyTimerBar3, pnlEnemy3);
                            ShowSlotEnemy(lblEnemyName4, enemyHealthProgressBar4, lblEnemyHealth4, enemyTimerBar4, pnlEnemy4);
                            ShowSlotEnemy(lblEnemyName5, enemyHealthProgressBar5, lblEnemyHealth5, enemyTimerBar5, pnlEnemy5);
                        }
                        foreach (Enemy enemy in enemyTeam)
                        {
                            enemy.curHealth = enemy.maxHealth;
                        }
                        turnCount = 1;
                        isGameOverMessageShown = false;
                    }
                }
            }
            else if (!enemyTeamAlive && boss == null)
            {

                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
                Equipment equipment = equipmentControllercs.LoadEquipmentFromFile(filePath, enemyTeam[0]);
                items.Add(equipment);
                Resource resource = resourceController.DropResourceFormEnemy(enemyTeam[0]);
                resources.Gold += resource.Gold;
                resources.Diamond += resource.Diamond;
                if (turnCount < 5)
                {
                    foreach (Enemy enemy in enemyTeam)
                    {
                        enemy.curHealth = enemy.maxHealth;
                    }
                    turnCount++;
                }
                else
                {
                    enemy2.curHealth = enemy2.maxHealth;
                    boss = new Enemy("Boss", enemy2.level, enemy2.curHealth * 10, enemy2.maxHealth * 10, enemy2.damage * 10, enemy2.armor * 2, 5);
                    enemyTeam = new List<Enemy>
                    {
                        boss
                    };
                }
                lblTurnCount.Text = $"{turnCount} / 5";
                lblMessage.Visible = true;
                lblMessage.Text = "Bạn đã chiến thắng! Bạn nhận được phần thưởng: \n" + equipment.Name.ToString() + ", " + resource.Gold.ToString() + " vàng và " + resource.Diamond.ToString() + " kim cương!";

            }
            else if (!enemyTeamAlive && boss != null)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
                Equipment equipment = equipmentControllercs.LoadEquipmentFromFile(filePath, enemyTeam[0]);
                items.Add(equipment);
                Resource resource = resourceController.DropResourceFormEnemy(enemyTeam[0]);
                resources.Gold += resource.Gold;
                resources.Diamond += resource.Diamond;

                enemyTeam = new List<Enemy>();
                int level = boss.level + 1;
                enemy1 = new Enemy("Enemy1", level, 100 + level * 50, 100 + level * 50, 8 + level * 2, 5 + level, 5);
                enemy2 = new Enemy("Enemy2", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5);
                enemy3 = new Enemy("Enemy3", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5);
                enemy4 = new Enemy("Enemy4", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5);
                enemy5 = new Enemy("Enemy5", enemy1.level, enemy1.curHealth, enemy1.maxHealth, enemy1.damage, enemy1.armor, 5);
                enemyTeam.Add(enemy1);
                enemyTeam.Add(enemy2);
                enemyTeam.Add(enemy3);
                enemyTeam.Add(enemy4);
                enemyTeam.Add(enemy5);
                ShowSlotEnemy(lblEnemyName2, enemyHealthProgressBar2, lblEnemyHealth2, enemyTimerBar2, pnlEnemy2);
                ShowSlotEnemy(lblEnemyName3, enemyHealthProgressBar3, lblEnemyHealth3, enemyTimerBar3, pnlEnemy3);
                ShowSlotEnemy(lblEnemyName4, enemyHealthProgressBar4, lblEnemyHealth4, enemyTimerBar4, pnlEnemy4);
                ShowSlotEnemy(lblEnemyName5, enemyHealthProgressBar5, lblEnemyHealth5, enemyTimerBar5, pnlEnemy5);
                turnCount = 1;
                lblTurnCount.Text = $"{turnCount} / 10";
                lblMessage.Visible = true;
                lblMessage.Text = "Bạn đã chiến thắng Boss! Bạn nhận được phần thưởng: \n" + equipment.Name.ToString() + ", " + resource.Gold.ToString() + " vàng và " + resource.Diamond.ToString() + " kim cương!";
                foreach (Player player in playerTeam)
                {
                    player.curHealth = player.maxHealth;
                }
            }
            UpdateResourceInfo();
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
                characterForm = new CharacterForm(playerTeam, items, resources);
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
            if (skillForm == null || skillForm.IsDisposed)
            {
                // Tạo một instance mới của InventoryForm và truyền danh sách vật phẩm và đội ngũ người chơi vào constructor
                skillForm = new SkillsForm();
            }

            // Hiển thị InventoryForm
            skillForm.BringToFront();
            skillForm.Show();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            if (dungeonForm == null || dungeonForm.IsDisposed)
            {
                // Tạo một instance mới của InventoryForm và truyền danh sách vật phẩm và đội ngũ người chơi vào constructor
                dungeonForm = new ShopForm(enemyTeam, resources);
            }

            // Hiển thị InventoryForm
            dungeonForm.BringToFront();
            dungeonForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                // Tạo một instance mới của SettingsForm
                settingsForm = new SettingsForm(playerTeam, enemyTeam, items, resources);
                settingsForm.StartPosition = FormStartPosition.Manual;

                // Tính toán vị trí hiển thị
                int x = this.Left + (this.Width - settingsForm.Width) / 2;
                int y = this.Top + (this.Height - settingsForm.Height) / 2;

                // Đặt vị trí hiển thị của SettingsForm
                settingsForm.Location = new Point(x, y);
            }

            // Hiển thị InventoryForm
            settingsForm.BringToFront();
            settingsForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Đóng ứng dụng hoặc xử lý tắt trò chơi ở đây
            //Application.Exit(); // Đóng ứng dụng

            // Hoặc
            DeleteJsonFile();
            this.Close(); // Đóng cửa sổ chứa trò chơi
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteJsonFile();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Xử lý khi người dùng bấm nút "X" trên thanh tiêu đề

                // Hiển thị hộp thoại xác nhận hoặc lưu dữ liệu trước khi tắt chương trình
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy sự kiện đóng cửa sổ
                }
            }
        }

        private void DeleteJsonFile()
        {
            string savesDirectory = "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data";
            string[] saveFiles = Directory.GetFiles(savesDirectory, "ShopItemsList.json");

            // Kiểm tra xem có tồn tại file JSON chứa danh sách trang bị không
            if (saveFiles.Length > 0)
            {
                string saveFilePath = saveFiles[0];

                try
                {
                    // Xóa file JSON
                    File.Delete(saveFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting JSON file: " + ex.Message);
                }
            }
        }
    }
}
