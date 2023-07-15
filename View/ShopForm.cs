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
        private List<Equipment>? equipmentList = new List<Equipment>(); // Danh sách trang bị
        EquipmentController equipmentController = new EquipmentController();
        private List<Enemy> enemies;
        private Form tooltipForm;
        private Resource Resource;

        public ShopForm(List<Enemy> enemies, Resource resource)
        {
            InitializeComponent();
            this.enemies = enemies;
            this.Resource = resource;
            equipmentList = equipmentController.LoadEquipmentListFormJson();

        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

            if (equipmentList.Count == 0)
            {
                // Tạo danh sách trang bị ngẫu nhiên
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
                equipmentList = equipmentController.GenerateRandomEquipmentList(filePath, enemies.First());
            }
            lblGoldNesessaryToRefreshShop.Text = "Need " + (enemies[0].level * 300) + " Gold (Golds available: " + Resource.Gold;
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
                panel.Height = 250;
                panel.Width = 200;

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(equipment.Image);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Height = 150;

                if (equipment.Quality.Equals("Common")) pictureBox.BackColor = Color.White;
                else if (equipment.Quality.Equals("Rare")) pictureBox.BackColor = Color.Aqua;
                else if (equipment.Quality.Equals("Elite")) pictureBox.BackColor = Color.Violet;
                else if (equipment.Quality.Equals("Legendary")) pictureBox.BackColor = Color.Orange;

                Label nameLabel = new Label();
                nameLabel.Text = equipment.Name;
                nameLabel.Dock = DockStyle.Top;
                nameLabel.Font = new Font("Arial", 10, FontStyle.Bold);

                Label priceLabel = new Label();
                priceLabel.Text = "Price: " + equipment.pricebuy + " Gold";
                priceLabel.Dock = DockStyle.Bottom;

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

                // Thêm sự kiện MouseEnter và MouseLeave cho PictureBox trong Panel
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
            }
        }


        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = GetItemFromCell(cell);

            // Hiển thị thông tin tooltip cho vật phẩm
            string tooltipText = GetItemTooltipText(item);
            ShowItemTooltip(pictureBox, tooltipText, item);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            // Ẩn tooltip khi di chuột ra khỏi PictureBox
            HideItemTooltip();
        }

        private void ShowItemTooltip(PictureBox pictureBox, string tooltipText, Item item)
        {
            // Tạo một Form để hiển thị tooltip kèm hình ảnh
            tooltipForm = new Form();
            tooltipForm.FormBorderStyle = FormBorderStyle.None;
            tooltipForm.BackColor = Color.White;
            tooltipForm.ShowInTaskbar = false;
            tooltipForm.StartPosition = FormStartPosition.Manual;
            tooltipForm.Location = new Point(pictureBox.PointToScreen(Point.Empty).X + pictureBox.Width, pictureBox.PointToScreen(Point.Empty).Y);

            // Tạo PictureBox trong tooltipForm để hiển thị hình ảnh
            PictureBox tooltipPictureBox = new PictureBox();
            tooltipPictureBox.Size = new Size(100, 100);
            tooltipPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tooltipPictureBox.Image = pictureBox.Image;
            tooltipForm.Controls.Add(tooltipPictureBox);

            // Tạo Label trong tooltipForm để hiển thị thông tin vật phẩm
            Label tooltipLabel = new Label();
            tooltipLabel.AutoSize = true;
            tooltipLabel.Text = tooltipText;
            tooltipLabel.Location = new Point(tooltipPictureBox.Right + 5, tooltipPictureBox.Top);
            tooltipForm.Controls.Add(tooltipLabel);

            tooltipForm.Show();
        }

        private void HideItemTooltip()
        {
            // Đóng và giải phóng tooltipForm nếu nó đang hiển thị
            if (tooltipForm != null && !tooltipForm.IsDisposed)
            {
                tooltipForm.Close();
                tooltipForm.Dispose();
                tooltipForm = null;
            }
        }

        private Item GetItemFromCell(Panel cell)
        {
            // Tìm vật phẩm trong danh sách inventory dựa trên vị trí ô cell
            // Bạn có thể thay đổi logic này tùy theo cách bạn lưu trữ vật phẩm và kết hợp với vị trí ô trong lưới

            // Ví dụ:
            int cellIndex = flpEquipment.Controls.IndexOf(cell); // Lấy chỉ mục của ô trong danh sách các ô trong lưới
            if (cellIndex >= 0 && cellIndex < 9) // Kiểm tra nếu chỉ mục hợp lệ
            {
                return equipmentList[cellIndex]; // Trả về vật phẩm tại vị trí ô cell
            }

            return null; // Nếu không tìm thấy vật phẩm
        }

        private string GetItemTooltipText(Item item)
        {
            // Tạo nội dung tooltip cho vật phẩm dựa trên các thuộc tính của nó
            string tooltipText;
            if (item == null)
            {
                return "";
            }
            tooltipText = $"Name: {item.Name}\n";
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;
                tooltipText += $"Lvl: {equipment.Level}\n";
                tooltipText += $"Quality: {equipment.Quality}\n";
            }
            tooltipText += $"Type: {item.Type}\n";
            tooltipText += $"Description: \n{item.Description}\n";
            // Thêm các thông tin khác tùy thuộc vào thuộc tính của vật phẩm

            // Kiểm tra xem vật phẩm có phải là Equipment không
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;
                if (equipment.HP != 0)
                {
                    tooltipText += $"HP: +{equipment.HP}\n";
                }
                if (equipment.Damage != 0)
                {
                    tooltipText += $"Damage: +{equipment.Damage}\n";
                }
                if (equipment.AttackSpeed != 0)
                {
                    tooltipText += $"AS: +{equipment.AttackSpeed}%\n";
                }
                if (equipment.Armor != 0)
                {
                    tooltipText += $"Armor: +{equipment.Armor}\n";
                }
            }
            return tooltipText;
        }

        private void btnRefreshShop_Click(object sender, EventArgs e)
        {
            if (Resource.Gold >= (enemies[0].level * 300))
            {
                Resource.Gold -= (enemies[0].level * 300);
                equipmentList = new List<Equipment>();
                ShopForm_Load(sender, e);
            }
        }
    }
}
