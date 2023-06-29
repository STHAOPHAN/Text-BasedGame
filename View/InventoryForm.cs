using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_BasedGame.Models;
using View;

namespace View
{
    public partial class InventoryForm : Form
    {
        private List<Item> inventory;
        private ToolTip toolTip;
        private Form tooltipForm;
        private List<Player> players;
        private CharacterForm characterForm;

        public InventoryForm(List<Item> inventory, List<Player> players)
        {
            InitializeComponent();
            this.inventory = inventory;
            this.players = players;
            // Thêm các ô vào lưới
            for (int row = 0; row < tlpInventory.RowCount; row++)
            {
                for (int column = 0; column < tlpInventory.ColumnCount; column++)
                {
                    // Tạo ô mới và thiết lập các thuộc tính
                    Panel cell = new Panel();
                    cell.Margin = new Padding(5);
                    cell.BorderStyle = BorderStyle.FixedSingle;

                    // Thêm ô vào lưới
                    tlpInventory.Controls.Add(cell, column, row);
                }
            }
            this.Controls.Add(tlpInventory);

            LoadItems();
        }

        private void LoadItems()
        {
            foreach (Panel cell in tlpInventory.Controls)
            {
                Item item = GetItemFromCell(cell);
                if (item != null && !string.IsNullOrEmpty(item.Image))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = cell.Size;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string imagePath = Path.GetFullPath(Path.Combine(currentDirectory, item.Image));
                    if (File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                    }
                    pictureBox.MouseEnter += PictureBox_MouseEnter;
                    pictureBox.MouseLeave += PictureBox_MouseLeave;
                    pictureBox.MouseDown += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            panel_DragMouseDown(sender, e, cell);
                        }
                    };
                    pictureBox.MouseUp += PictureBox_MouseUp;
                    cell.Controls.Clear();
                    if (item != null)
                        cell.Controls.Add(pictureBox);
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Panel cell = (Panel)pictureBox.Parent;
                Item item = GetItemFromCell(cell);

                if (item != null && item is Equipment equipment)
                {
                    // Tạo ContextMenuStrip mới và thêm các MenuItem tùy chọn
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

                    // MenuItem "Trang Bị"
                    Label equipLabel = new Label();
                    equipLabel.Text = "Trang Bị";
                    equipLabel.MouseEnter += (menuSender, menuEvent) => EquipLabel_MouseEnter(menuSender, menuEvent, cell);
                    contextMenuStrip.Items.Add(new ToolStripControlHost(equipLabel));

                    // MenuItem "Xóa"
                    ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa");
                    deleteMenuItem.Click += (menuSender, menuEvent) => DeleteMenuItem_Click(menuSender, menuEvent, cell);
                    contextMenuStrip.Items.Add(deleteMenuItem);

                    // Hiển thị menu tại vị trí chuột phải
                    contextMenuStrip.Show(pictureBox, e.Location);
                }
            }
        }

        private void EquipLabel_MouseEnter(object sender, EventArgs e, Panel cell)
        {
            Item item = GetItemFromCell(cell);
            if (item != null && item is Equipment equipment)
            {
                // Tạo ToolStripDropDown
                ToolStripDropDown dropDown = new ToolStripDropDown();
                // Tạo ToolStripMenuItem cho mỗi người chơi và thêm vào ToolStripDropDown
                foreach (Player player in players)
                {
                    ToolStripMenuItem playerMenuItem = new ToolStripMenuItem(player.name);
                    playerMenuItem.Tag = player; // Lưu trữ thông tin người chơi trong Tag để lấy sau này
                    playerMenuItem.Click += (sender, e) => PlayerMenuItem_Click(sender, e, cell, item);
                    dropDown.Items.Add(playerMenuItem);
                }

                // Hiển thị ToolStripDropDown tại vị trí chuột phải
                dropDown.Show(MousePosition);
            }
        }

        private void PlayerMenuItem_Click(object sender, EventArgs e, Panel panel, Item item)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Player selectedPlayer = (Player)menuItem.Tag;
            Equipment equipment = (Equipment)item;
            // Thực hiện thao tác trang bị cho người chơi được chọn tại đây
            // ...
            characterForm = new CharacterForm(players, inventory);
            Equipment returnequipment = characterForm.EquipItemByButton(equipment, selectedPlayer);
            if (returnequipment == null)
            {
                inventory.Remove(equipment);
                panel.Controls.Clear();
                // Sau khi trang bị thành công, cập nhật lại danh sách vật phẩm trong kho đồ
                UpdateItems(inventory);
            }
            else
            {
                inventory.Add(returnequipment);
                inventory.Remove(equipment);
                panel.Controls.Clear();
                UpdateItems(inventory);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e, Panel cell)
        {
            Item item = GetItemFromCell(cell);

            if (item != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện thao tác xóa vật phẩm tại đây
                    // Ví dụ: xóa vật phẩm khỏi danh sách inventory
                    inventory.Remove(item);
                    cell.Controls.Clear();
                    LoadItems();
                }
            }
        }
        private void panel_DragMouseDown(object sender, MouseEventArgs e, Panel cell)
        {
            Item item = GetItemFromCell(cell);

            if (item != null)
            {
                cell.DoDragDrop(item, DragDropEffects.Move);
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = GetItemFromCell(cell);

            // Hiển thị thông tin tooltip cho vật phẩm
            string tooltipText = GetItemTooltipText(item);
            ShowItemTooltip(pictureBox, tooltipText);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            // Ẩn tooltip khi di chuột ra khỏi PictureBox
            HideItemTooltip();
        }

        public void AddItemToInventory(Equipment equipment)
        {
            if (equipment != null)
            {
                inventory.Add(equipment);
                LoadItems();
            }
        }

        private void ShowItemTooltip(PictureBox pictureBox, string tooltipText)
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
            int cellIndex = tlpInventory.Controls.IndexOf(cell); // Lấy chỉ mục của ô trong danh sách các ô trong lưới
            if (cellIndex >= 0 && cellIndex < inventory.Count) // Kiểm tra nếu chỉ mục hợp lệ
            {
                return inventory[cellIndex]; // Trả về vật phẩm tại vị trí ô cell
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

        public void UpdateItems(List<Item> items)
        {
            inventory = items;
            LoadItems();
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = GetItemFromCell(cell);

            if (item != null)
            {
                Equipment equipment = (Equipment)item;
                // Xóa trang bị khỏi danh sách trang bị trong kho đồ
                inventory.Remove(equipment);
                // Bắt đầu quá trình kéo thả với dữ liệu là vật phẩm (item)
                cell.DoDragDrop(item, DragDropEffects.Move);
            }
        }
    }
}
