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

namespace View
{
    public partial class InventoryForm : Form
    {
        private List<Item> inventory;
        private ToolTip toolTip;

        public InventoryForm(List<Item> inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
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
                    cell.Controls.Clear();
                    cell.Controls.Add(pictureBox);
                }
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = GetItemFromCell(cell);

            // Hiển thị thông tin tooltip cho vật phẩm
            string tooltipText = GetItemTooltipText(item);
            SetToolTip(pictureBox, tooltipText);
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

            return tooltipText;
        }



        private void SetToolTip(Control control, string tooltipText)
        {
            if (toolTip == null)
            {
                toolTip = new ToolTip();
            }
            toolTip.SetToolTip(control, tooltipText);
        }

        public void UpdateItems(List<Item> items)
        {
            this.inventory = items;
            LoadItems();
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = GetItemFromCell(cell);

            if (item != null)
            {
                // Bắt đầu quá trình kéo thả với dữ liệu là vật phẩm (item)
                pictureBox.DoDragDrop(item, DragDropEffects.Move);
            }
        }

        private void CharacterForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void CharacterForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                Item item = (Item)e.Data.GetData(typeof(Item));
                Panel cell = (Panel)sender;

                // Kiểm tra xem ô đã có trang bị hay chưa
                if (cell.Controls.Count > 0)
                {
                    // Nếu ô đã có trang bị, trả về trang bị về vị trí ban đầu trong InventoryForm
                    PictureBox pictureBox = (PictureBox)cell.Controls[0];
                    Panel originalCell = (Panel)pictureBox.Parent;
                    Item originalItem = GetItemFromCell(originalCell);
                    if (originalItem != null)
                    {
                        originalCell.Controls.Clear();
                        originalCell.Controls.Add(pictureBox);
                    }
                }

                // Gắn trang bị vào ô và cập nhật chỉ số
                PictureBox itemPictureBox = (PictureBox)cell.Controls[0];
                cell.Controls.Clear();
                cell.Controls.Add(itemPictureBox);
                UpdateStats(item);
            }
        }

        private void UpdateStats(Item item)
        {
            // Cập nhật chỉ số cần thiết dựa trên trang bị (item)
            // Bạn cần triển khai logic cập nhật tương ứng cho trò chơi của mình

            // Example:
            // characterForm.UpdateStats(item);
        }
    }
}
