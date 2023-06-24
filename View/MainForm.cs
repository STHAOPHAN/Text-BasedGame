using System;
using System.Windows.Forms;
using Text_BasedGame.Models;

namespace View
{
    public partial class MainForm : Form
    {
        private Player player;
        private Enemy enemy;
        private System.Windows.Forms.Timer timer;
        private int tickInterval = 1000; // Thời gian giữa các tick của Timer (ms)

        public MainForm(Player player, Enemy enemy)
        {
            InitializeComponent();

            this.player = player;
            this.enemy = enemy;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = tickInterval;
            timer.Tick += Timer_Tick;
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Tăng giá trị hiện tại của ProgressBar người chơi lên 1
            playerTimerBar.Value += (int)(6000 / (player.attackSpeed));
            enemyTimerBar.Value += (int)(6000 / (enemy.attackSpeed));

            // Nếu ProgressBar đã đạt giá trị tối đa
            if (playerTimerBar.Value >= playerTimerBar.Maximum)
            {
                // Reset giá trị ProgressBar về 0
                playerTimerBar.Value = 0;

                // Thực hiện hành động tấn công của người chơi
                player.Attack(enemy);

                // Cập nhật thông tin hiển thị
                UpdatePlayerInfo();
                UpdateEnemyInfo();
            }
            if (enemyTimerBar.Value >= enemyTimerBar.Maximum)
            {
                // Reset giá trị ProgressBar về 0
                enemyTimerBar.Value = 0;

                // Thực hiện hành động tấn công của người chơi
                enemy.Attack(player);

                // Cập nhật thông tin hiển thị
                UpdatePlayerInfo();
                UpdateEnemyInfo();
            }
        }

        private void UpdatePlayerInfo()
        {
            lblPlayerName.Text = player.name;
            playerHealthProgressBar.Maximum = (int)player.maxHealth;
            playerHealthProgressBar.Value = (int)player.curHealth;
            lblPlayerHealth.Text = $"{player.curHealth}/{player.maxHealth}";
        }

        private void UpdateEnemyInfo()
        {
            lblEnemyName.Text = enemy.name;
            enemyHealthProgressBar.Maximum = (int)enemy.maxHealth;
            enemyHealthProgressBar.Value = (int)enemy.curHealth;
            lblEnemyHealth.Text = $"{enemy.curHealth}/{enemy.maxHealth}";
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnSkill_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        // Các sự kiện và phương thức khác cần thiết cho MainForm
        // ...
    }
}
