using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace View
{
    public partial class ShopForm : Form
    {
        private List<Equipment> equipmentList; // Danh sách trang bị
        private List<Enemy> enemies;

        public ShopForm(List<Enemy> enemies)
        {
            InitializeComponent();
            this.enemies = enemies;
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {


            // Tạo danh sách trang bị ngẫu nhiên
            EquipmentController equipmentController = new EquipmentController();
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
            equipmentList = equipmentController.GenerateRandomEquipmentList(filePath, enemies.First());

            // Hiển thị danh sách trang bị ban đầu
            DisplayEquipmentList();
        }

        private void DisplayEquipmentList()
        {
            // Xóa danh sách trang bị hiện tại
            flpEquipment.Controls.Clear();

            // Hiển thị danh sách trang bị
            for (int i = 0; i < 8; i++)
            {
                Equipment equipment = equipmentList[i];

                // Tạo control hiển thị trang bị và giá tiền
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Padding = new Padding(10);
                panel.Height = 200;
                panel.Width = 200;

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(equipment.Image);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Height = 150;

                Label nameLabel = new Label();
                nameLabel.Text = equipment.Name;
                nameLabel.Dock = DockStyle.Top;
                nameLabel.Font = new Font("Arial", 10, FontStyle.Bold);

                Label priceLabel = new Label();
                priceLabel.Text = "Price: ??? Gold";
                priceLabel.Dock = DockStyle.Top;

                Button buyButton = new Button();
                buyButton.Text = "Buy";
                buyButton.Dock = DockStyle.Bottom;

                // Thêm sự kiện click cho nút mua
                buyButton.Click += (sender, e) =>
                {
                    // Xử lý logic khi người dùng nhấn nút mua
                    // Ví dụ: Trừ vàng từ tài khoản người dùng, thêm trang bị vào danh sách sở hữu, vv.

                    // Sau khi xử lý, cập nhật lại giao diện hiển thị danh sách trang bị
                    DisplayEquipmentList();
                };

                // Thêm controls vào panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(buyButton);

                // Thêm panel vào FlowLayoutPanel
                flpEquipment.Controls.Add(panel);
            }
        }

        private void btnRefreshShop_Click(object sender, EventArgs e)
        {
            ShopForm_Load(sender, e);
        }
    }
}
