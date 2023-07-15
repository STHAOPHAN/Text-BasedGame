using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace View
{
    public partial class MainMenuForm : Form
    {
        private List<Player> playerTeam = new List<Player>();
        private List<Enemy> enemyTeam = new List<Enemy>();
        private List<Item> items = new List<Item>();
        private List<Equipment> equipments = new List<Equipment>();
        private Resource resources = new Resource();
        private StatsPoint statsPoint = new StatsPoint(0, 0, 0, 0);
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            // Thêm người chơi vào đội hình
            playerTeam.Add(new Player("Player1", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint));//Name, Max Health, Current Health, Damage, Armor, Attack Speed, Mana, statspoint
            playerTeam.Add(new Player("Player2", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint));
            playerTeam.Add(new Player("Player3", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint));
            playerTeam.Add(new Player("Player4", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint));
            playerTeam.Add(new Player("Player5", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint));

            // Thêm kẻ địch vào đội hình
            enemyTeam.Add(new Enemy("Enemy1", 5, 100, 100, 8, 5, 5));//Name, Max Health, Current Health, Damage, Armor, Attack Speed
            enemyTeam.Add(new Enemy("Enemy2", 5, 100, 100, 8, 5, 5));
            enemyTeam.Add(new Enemy("Enemy3", 5, 100, 100, 8, 5, 5));
            enemyTeam.Add(new Enemy("Enemy4", 5, 100, 100, 8, 5, 5));
            enemyTeam.Add(new Enemy("Enemy5", 5, 100, 100, 8, 5, 5));

            // Khởi tạo tài nguyên ban đầu
            resources = new Resource(1500, 0);

            // Khởi tạo và chạy form MainForm
            MainForm mainForm = new MainForm(playerTeam, enemyTeam, items, resources);
            mainForm.Show();
            this.Hide(); // Ẩn form MainMenuForm
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string savesDirectory = "..\\..\\..\\..\\Text-BasedGame\\Saves";
            string[] saveFiles = Directory.GetFiles(savesDirectory, "*.json");

            if (saveFiles.Length == 0)
            {
                MessageBox.Show("No save files found.", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = System.Windows.Forms.View.List;
            listView.Columns.Add("Save File", 300);

            foreach (string saveFile in saveFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(saveFile);
                ListViewItem listItem = new ListViewItem(fileName);
                listView.Items.Add(listItem);
            }

            Button btnConfirm = new Button();
            btnConfirm.Text = "Load";
            btnConfirm.DialogResult = DialogResult.OK;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.FlowDirection = FlowDirection.RightToLeft;
            panel.Padding = new Padding(5);
            panel.Controls.Add(btnConfirm);

            Form form = new Form();
            form.Text = "Load Game";
            form.Size = new Size(400, 300);
            form.Controls.Add(listView);
            form.Controls.Add(panel);

            form.FormClosing += (sender, e) =>
            {
                if (listView.SelectedItems.Count == 0 && form.DialogResult == DialogResult.OK)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please select a save file.", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = Path.Combine(savesDirectory, listView.SelectedItems[0].Text + ".json");
                // Tiếp tục xử lý tải tệp được chọn ở đây
                GameSaveDataController gameSaveDataController = new GameSaveDataController();
                GameSaveData gameSaveData = gameSaveDataController.LoadGame(selectedFilePath);
                playerTeam = gameSaveData.Players;
                enemyTeam = gameSaveData.Enemies;
                items = gameSaveData.Items;
                equipments = gameSaveData.Equipments;
                foreach ( var equipment in equipments ) 
                { 
                    items.Add( equipment );
                }
                resources = gameSaveData.Resource;
                // Khởi tạo và chạy form MainForm
                MainForm mainForm = new MainForm(playerTeam, enemyTeam, items, resources);
                mainForm.Show();
                this.Hide(); // Ẩn form MainMenuForm
            }
        }



        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There's nothing to adjust at the moment (!__!)", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Đóng ứng dụng ngay lập tức mà không cần xác nhận
                Application.Exit();
            }
        }
    }
}
