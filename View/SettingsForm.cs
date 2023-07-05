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
        private LoadForm LoadForm;
        private List<Player> players;
        private List<Enemy> enemies;
        private List<Item> items;

        public SettingsForm(List<Player> players, List<Enemy> enemies, List<Item> items)
        {
            InitializeComponent();
            this.players = players;
            this.enemies = enemies;
            this.items = items;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập tên file save
            string saveFileName = ShowSaveFileNameDialog();

            if (!string.IsNullOrEmpty(saveFileName))
            {
                // Tạo đường dẫn đầy đủ của file save
                string saveFilePath = GetSaveFilePath(saveFileName);

                // Tạo đối tượng GameSaveData từ danh sách người chơi, kẻ địch và vật phẩm
                GameSaveData gameSaveData = new GameSaveData(players, enemies, items);

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
    }
}
