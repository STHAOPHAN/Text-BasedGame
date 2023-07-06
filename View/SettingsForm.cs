using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_BasedGame.Models;
using Text_BasedGame.Controllers;

namespace View
{
    public partial class SettingsForm : Form
    {
        private List<Player> players;
        private List<Enemy> enemies;
        private List<Item> items;
        private List<Equipment> equipments;
        private Resource resources;

        public SettingsForm(List<Player> players, List<Enemy> enemies, List<Item> items, Resource resources)
        {
            InitializeComponent();
            this.players = players;
            this.enemies = enemies;
            this.items = items;
            this.resources = resources;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập tên file save
            string saveFileName = ShowSaveFileNameDialog();

            if (!string.IsNullOrEmpty(saveFileName))
            {
                // Tạo đường dẫn đầy đủ của file save
                string saveFilePath = GetSaveFilePath(saveFileName);

                equipments = new List<Equipment>();
                List<Item> itemsToRemove = new List<Item>();

                foreach (Item item in items)
                {
                    if (item is Equipment)
                    {
                        equipments.Add(item as Equipment);
                        itemsToRemove.Add(item);
                    }
                }

                foreach (Item itemToRemove in itemsToRemove)
                {
                    items.Remove(itemToRemove);
                }

                // Tạo đối tượng GameSaveData từ danh sách người chơi, kẻ địch và vật phẩm
                GameSaveData gameSaveData = new GameSaveData(players, enemies, items, equipments, resources);

                // Tạo đối tượng GameSaveDataController
                GameSaveDataController saveDataController = new GameSaveDataController();

                bool saveSuccess = saveDataController.SaveGame(gameSaveData, saveFilePath);

                if (saveSuccess)
                {
                    MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to save game.", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ShowSaveFileNameDialog()
        {
            using (var inputForm = new Form())
            {
                var label = new Label() { Text = "Enter the save file name:" };
                var textBox = new TextBox();
                var buttonOk = new Button() { Text = "OK", DialogResult = DialogResult.OK };
                var buttonCancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel };

                label.AutoSize = true;
                textBox.Dock = DockStyle.Fill;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                var flowLayoutPanel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    Padding = new Padding(10)
                };

                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.Add(textBox);
                flowLayoutPanel.Controls.Add(buttonOk);
                flowLayoutPanel.Controls.Add(buttonCancel);

                inputForm.Controls.Add(flowLayoutPanel);

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text.Trim();
                }

                return null;
            }
        }

        private string GetSaveFilePath(string saveFileName)
        {
            string directoryPath = "..\\..\\..\\..\\Text-BasedGame\\Saves"; // Đường dẫn thư mục lưu file save
            string extension = ".json"; // Phần mở rộng của file save

            // Tạo thư mục lưu file save nếu chưa tồn tại
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Kết hợp đường dẫn thư mục và tên file save để tạo đường dẫn đầy đủ
            string saveFilePath = Path.Combine(directoryPath, saveFileName + extension);

            return saveFilePath;
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
                List<Player> players = new List<Player>(gameSaveData.Players);
                List<Enemy> enemies = new List<Enemy>(gameSaveData.Enemies);
                List<Item> items = new List<Item>(gameSaveData.Items);
                List<Equipment> equipments = new List<Equipment>(gameSaveData.Equipments);
                foreach (var equipment in equipments)
                {
                    items.Add(equipment);
                }
                Resource resource = new Resource();
                resource = gameSaveData.Resource;
                // Khởi tạo và chạy form MainForm
                MainForm mainForm = new MainForm(players, enemies, items, resource);
                mainForm.Show();
                this.Hide(); // Ẩn form MainMenuForm
            }
        }
    }
}
