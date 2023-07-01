using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace View
{
    public partial class CharacterForm : Form
    {
        private PlayerController playerController = new PlayerController();
        private List<Player> players;
        private List<Item> items;
        private CharacterForm characterForm;
        private InventoryForm inventoryForm;
        private Form tooltipForm;

        public CharacterForm(List<Player> players, List<Item> items)
        {
            InitializeComponent();
            this.players = players;
            this.items = items;

            // Hiển thị danh sách người chơi
            foreach (var player in players)
            {
                playerListBox.Items.Add(player.name);
            }
        }


        private void playerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy người chơi được chọn
            var selectedPlayer = players[playerListBox.SelectedIndex];
            ptbWeapon.BackColor = Color.White;
            ptbSecondaryWeapon.BackColor = Color.White;
            ptbHelmet.BackColor = Color.White;
            ptbChestArmor.BackColor = Color.White;
            ptbArmArmor.BackColor = Color.White;
            ptbGlove.BackColor = Color.White;
            ptbBelt.BackColor = Color.White;
            ptbPants.BackColor = Color.White;
            ptbBoots.BackColor = Color.White;
            ptbRing.BackColor = Color.White;
            ptbBracelet.BackColor = Color.White;
            ptbNecklace.BackColor = Color.White;
            ptbArtifact.BackColor = Color.White;
            // Hiển thị chỉ số của nhân vật
            UpdatePlayerInfo(selectedPlayer);
            // Hiển thị các chỉ số khác của nhân vật
            RefreshCharacterForm();
        }

        private void CharacterForm_Load(object sender, EventArgs e)
        {
            if (players.Count > 0)
            {
                // Hiển thị thông tin của người chơi đầu tiên
                playerListBox.SelectedIndex = 0;
            }
        }

        private void UpdatePlayerInfo(Player player)
        {
            // Cập nhật các thông tin của người chơi sau khi cộng điểm kỹ năng
            lblLevel.Text = player.level.ToString();
            lblHealth.Text = $"{player.curHealth}/{player.maxHealth}";
            lblMana.Text = player.mana.ToString();
            lblDamage.Text = player.damage.ToString();
            lblArmor.Text = player.armor.ToString();
            if (player.attackSpeed < 1) lblAttackSpeed.Text = 1;
            else lblAttackSpeed.Text = player.attackSpeed.ToString();
            lblStatPoints.Text = player.statPoints.ToString();
        }

        private void HideBtnIncrease(Player player)
        {
            if (player.statPoints == 0)
            {
                btnIncreaseHealth.Enabled = false;
                btnIncreaseDamege.Enabled = false;
                btnIncreaseAttackSpeed.Enabled = false;
                btnIncreaseArmor.Enabled = false;
            }
            else
            {
                btnIncreaseHealth.Enabled = true;
                btnIncreaseDamege.Enabled = true;
                btnIncreaseAttackSpeed.Enabled = true;
                btnIncreaseArmor.Enabled = true;
            }
        }
        private void btnIncreaseHealth_Click(object sender, EventArgs e)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            playerController.IncreaseHealth(selectedPlayer);
            // Ẩn nút tăng stat khi hết điểm
            HideBtnIncrease(selectedPlayer);
            // Cập nhật thông tin người chơi
            UpdatePlayerInfo(selectedPlayer);
        }

        private void btnIncreaseDamege_Click(object sender, EventArgs e)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            playerController.IncreaseDamage(selectedPlayer);
            // Ẩn nút tăng stat khi hết điểm
            HideBtnIncrease(selectedPlayer);
            // Cập nhật thông tin người chơi
            UpdatePlayerInfo(selectedPlayer);
        }

        private void btnIncreaseAttackSpeed_Click(object sender, EventArgs e)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            playerController.IncreaseAttackSpeed(selectedPlayer);
            // Ẩn nút tăng stat khi hết điểm
            HideBtnIncrease(selectedPlayer);
            // Cập nhật thông tin người chơi
            UpdatePlayerInfo(selectedPlayer);
        }

        private void btnIncreaseArmor_Click(object sender, EventArgs e)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            playerController.IncreaseArmor(selectedPlayer);
            // Ẩn nút tăng stat khi hết điểm
            HideBtnIncrease(selectedPlayer);
            // Cập nhật thông tin người chơi
            UpdatePlayerInfo(selectedPlayer);
        }

        private void btnUndoIncreaseStat_Click(object sender, EventArgs e)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            playerController.ResetStatPoint(selectedPlayer);
            // Ẩn nút tăng stat khi hết điểm
            HideBtnIncrease(selectedPlayer);
            // Cập nhật thông tin người chơi
            UpdatePlayerInfo(selectedPlayer);
        }
        private void EquipmentSlot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Equipment)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void EquipmentSlot_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Equipment)))
            {
                Equipment equipment = (Equipment)e.Data.GetData(typeof(Equipment));
                Panel panel = (Panel)sender;
                var selectedPlayer = players[playerListBox.SelectedIndex];
                // Xử lý việc thả trang bị vào Panel
                EquipItem(panel, equipment);

                // Cập nhật thông tin người chơi
                UpdatePlayerStats();

                // Cập nhật hiển thị trên CharacterForm
                RefreshCharacterForm();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pictureBox = (PictureBox)sender;
                var panel = (Panel)pictureBox.Parent; // Lấy Panel chứa PictureBox
                pictureBox.ContextMenuStrip = new ContextMenuStrip();
                pictureBox.ContextMenuStrip.Items.Add("Tháo Đồ", null, (s, args) =>
                {
                    UnequipItem(panel);
                });
                return;
            }
        }

        private void UnequipItem(Panel panel)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];

            if (panel == pnlWeapon && selectedPlayer.Weapon != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Weapon;

                UnequipItem(equipment, panel, selectedPlayer);

                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Weapon = null;
            }
            else if (panel == pnlSecondaryWeapon && selectedPlayer.SecondaryWeapon != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.SecondaryWeapon;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.SecondaryWeapon = null;
            }
            else if (panel == pnlHelmet && selectedPlayer.Helmet != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Helmet;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Helmet = null;
            }
            else if (panel == pnlChestArmor && selectedPlayer.ChestArmor != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.ChestArmor;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.ChestArmor = null;
            }
            else if (panel == pnlArmArmor && selectedPlayer.ArmArmor != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.ArmArmor;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.ArmArmor = null;
            }
            else if (panel == pnlGlove && selectedPlayer.Glove != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Glove;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Glove = null;
            }
            else if (panel == pnlBelt && selectedPlayer.Belt != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Belt;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Belt = null;
            }
            else if (panel == pnlPants && selectedPlayer.Pants != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Pants;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Pants = null;
            }
            else if (panel == pnlBoots && selectedPlayer.Boots != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Boots;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Boots = null;
            }
            else if (panel == pnlRing && selectedPlayer.Ring != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Ring;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Ring = null;
            }
            else if (panel == pnlBracelet && selectedPlayer.Bracelet != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Bracelet;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Bracelet = null;
            }
            else if (panel == pnlNecklace && selectedPlayer.Necklace != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Necklace;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Necklace = null;
            }
            else if (panel == pnlArtifact && selectedPlayer.Artifact != null)
            {
                // Lấy trang bị hiện tại từ panel
                var equipment = selectedPlayer.Artifact;

                UnequipItem(equipment, panel, selectedPlayer);
                // Thiết lập lại trang bị của người chơi
                selectedPlayer.Artifact = null;
            }
        }

        private void UnequipItem(Equipment equipment, Panel panel, Player player)
        {
            // Xóa trang bị khỏi panel
            panel.Controls.Clear();

            // Thêm trang bị vào InventoryForm
            items.Add(equipment);
            inventoryForm = new InventoryForm(items, players);
            inventoryForm.UpdateItems(items);

            // Giảm chỉ số theo trang bị
            DecreasePlayerStats(player, equipment);

            UpdatePlayerStats();

            RefreshCharacterForm();

        }

        public void EquipItem(Panel panel, Equipment equipment)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];

            if (panel == pnlWeapon && equipment.Type.Equals("Weapon"))
            {
                selectedPlayer.Weapon = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlSecondaryWeapon && equipment.Type.Equals("Secondary Weapon"))
            {
                selectedPlayer.SecondaryWeapon = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlHelmet && equipment.Type.Equals("Helmet"))
            {
                selectedPlayer.Helmet = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlChestArmor && equipment.Type.Equals("Chest Armor"))
            {
                selectedPlayer.ChestArmor = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlArmArmor && equipment.Type.Equals("Arm Armor"))
            {
                selectedPlayer.ArmArmor = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlGlove && equipment.Type.Equals("Glove"))
            {
                selectedPlayer.Glove = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlBelt && equipment.Type.Equals("Belt"))
            {
                selectedPlayer.Belt = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlPants && equipment.Type.Equals("Pants"))
            {
                selectedPlayer.Pants = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlBoots && equipment.Type.Equals("Boots"))
            {
                selectedPlayer.Boots = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlNecklace && equipment.Type.Equals("Necklace"))
            {
                selectedPlayer.Necklace = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlRing && equipment.Type.Equals("Ring"))
            {
                selectedPlayer.Ring = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlBracelet && equipment.Type.Equals("Ring"))
            {
                selectedPlayer.Bracelet = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            else if (panel == pnlArtifact && equipment.Type.Equals("Artifact"))
            {
                selectedPlayer.Artifact = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
            }
            UpdatePlayerStats();
            RefreshCharacterForm();
        }
        public Equipment EquipItemByButton(Equipment equipment, Player selectedPlayer)
        {
            if (equipment.Type.Equals("Weapon"))
            {
                if (selectedPlayer.Weapon == null)
                {
                    selectedPlayer.Weapon = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Weapon;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Weapon = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Secondary Weapon"))
            {
                if (selectedPlayer.SecondaryWeapon == null)
                {
                    selectedPlayer.SecondaryWeapon = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.SecondaryWeapon;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.SecondaryWeapon = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Helmet"))
            {
                if (pnlHelmet.Controls.Count == 0)
                {
                    selectedPlayer.Helmet = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Helmet;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Helmet = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Chest Armor"))
            {
                if (pnlChestArmor.Controls.Count == 0)
                {
                    selectedPlayer.ChestArmor = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.ChestArmor;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.ChestArmor = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Arm Armor"))
            {
                if (pnlArmArmor.Controls.Count == 0)
                {
                    selectedPlayer.ArmArmor = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.ArmArmor;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.ArmArmor = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Glove"))
            {
                if (pnlGlove.Controls.Count == 0)
                {
                    selectedPlayer.Glove = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Glove;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Glove = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Belt"))
            {
                if (pnlBelt.Controls.Count == 0)
                {
                    selectedPlayer.Belt = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Belt;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Belt = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Pants"))
            {
                if (pnlPants.Controls.Count == 0)
                {
                    selectedPlayer.Pants = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Pants;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Pants = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Boots"))
            {
                if (pnlBoots.Controls.Count == 0)
                {
                    selectedPlayer.Boots = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Boots;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Boots = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Necklace"))
            {
                if (pnlNecklace.Controls.Count == 0)
                {
                    selectedPlayer.Necklace = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Necklace;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Necklace = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Ring"))
            {
                if (pnlRing.Controls.Count == 0)
                {
                    selectedPlayer.Ring = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Ring;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Ring = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Bracelet"))
            {
                if (pnlBracelet.Controls.Count == 0)
                {
                    selectedPlayer.Bracelet = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Bracelet;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Bracelet = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Artifact"))
            {
                if (pnlArtifact.Controls.Count == 0)
                {
                    selectedPlayer.Artifact = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Artifact;
                    DecreasePlayerStats(selectedPlayer, returnEquipment);
                    selectedPlayer.Artifact = equipment;
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return returnEquipment;
                }
            }
            return null;
        }

        private void IncreasePlayerStats(Player player, Equipment item)
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;

                player.curHealth += equipment.HP;
                player.maxHealth += equipment.HP;
                player.damage += equipment.Damage;
                float attackspeed = equipment.AttackSpeed;
                player.attackSpeed -= (attackspeed / 100);
                player.armor += equipment.Armor;


                // Cập nhật các chỉ số khác tùy thuộc vào trang bị
            }
        }

        private void DecreasePlayerStats(Player player, Item item)
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;

                player.curHealth -= equipment.HP;
                player.maxHealth -= equipment.HP;
                player.damage -= equipment.Damage;
                float attackspeed = equipment.AttackSpeed;
                player.attackSpeed += (attackspeed / 100);
                player.armor -= equipment.Armor;


                // Cập nhật các chỉ số khác tùy thuộc vào trang bị
            }
        }

        private void UpdatePlayerStats()
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];

            // Cập nhật các chỉ số khác của người chơi tại đây

            UpdatePlayerInfo(selectedPlayer);
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e, Equipment equipment)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Panel cell = (Panel)pictureBox.Parent;
            Item item = equipment;

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
            System.Windows.Forms.Label tooltipLabel = new System.Windows.Forms.Label();
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

        private void GetBackColor(Equipment equipment, PictureBox pictureBox)
        {
                if (equipment.Quality.Equals("Common")) pictureBox.BackColor = Color.White;
                else if (equipment.Quality.Equals("Rare")) pictureBox.BackColor = Color.Aqua;
                else if (equipment.Quality.Equals("Elite")) pictureBox.BackColor = Color.Violet;
                else if (equipment.Quality.Equals("Legendary")) pictureBox.BackColor = Color.Orange;
        }

        private void RefreshCharacterForm()
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = "";
            // Cập nhật hiển thị trên CharacterForm tại đây
            if (selectedPlayer.Weapon != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Weapon.Image));
                if (File.Exists(imagePath))
                {
                    ptbWeapon.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Weapon, ptbWeapon);
                    ptbWeapon.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Weapon);
                    ptbWeapon.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbWeapon.Image = null;
            }
            if (selectedPlayer.SecondaryWeapon != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.SecondaryWeapon.Image));
                if (File.Exists(imagePath))
                {
                    ptbSecondaryWeapon.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.SecondaryWeapon, ptbSecondaryWeapon);
                    ptbSecondaryWeapon.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.SecondaryWeapon);
                    ptbSecondaryWeapon.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbSecondaryWeapon.Image = null;
            }
            if (selectedPlayer.Helmet != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Helmet.Image));
                if (File.Exists(imagePath))
                {
                    ptbHelmet.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Helmet, ptbHelmet);
                    ptbHelmet.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Helmet);
                    ptbHelmet.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbHelmet.Image = null;
            }
            if (selectedPlayer.ChestArmor != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.ChestArmor.Image));
                if (File.Exists(imagePath))
                {
                    ptbChestArmor.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.ChestArmor, ptbChestArmor);
                    ptbChestArmor.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.ChestArmor);
                    ptbChestArmor.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbChestArmor.Image = null;
            }
            if (selectedPlayer.ArmArmor != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.ArmArmor.Image));
                if (File.Exists(imagePath))
                {
                    ptbArmArmor.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.ArmArmor, ptbArmArmor);
                    ptbArmArmor.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.ArmArmor);
                    ptbArmArmor.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbArmArmor.Image = null;
            }
            if (selectedPlayer.Glove != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Glove.Image));
                if (File.Exists(imagePath))
                {
                    ptbGlove.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Glove, ptbGlove);
                    ptbGlove.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Glove);
                    ptbGlove.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbGlove.Image = null;
            }
            if (selectedPlayer.Belt != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Belt.Image));
                if (File.Exists(imagePath))
                {
                    ptbBelt.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Belt, ptbBelt);
                    ptbBelt.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Belt);
                    ptbBelt.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbBelt.Image = null;
            }
            if (selectedPlayer.Pants != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Pants.Image));
                if (File.Exists(imagePath))
                {
                    ptbPants.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Pants, ptbPants);
                    ptbPants.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Pants);
                    ptbPants.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbPants.Image = null;
            }
            if (selectedPlayer.Boots != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Boots.Image));
                if (File.Exists(imagePath))
                {
                    ptbBoots.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Boots, ptbBoots);
                    ptbBoots.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Boots);
                    ptbBoots.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbBoots.Image = null;
            }
            if (selectedPlayer.Ring != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Ring.Image));
                if (File.Exists(imagePath))
                {
                    ptbRing.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Ring, ptbRing);
                    ptbRing.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Ring);
                    ptbRing.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbRing.Image = null;
            }
            if (selectedPlayer.Bracelet != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Bracelet.Image));
                if (File.Exists(imagePath))
                {
                    ptbBracelet.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Bracelet, ptbBracelet);
                    ptbBracelet.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Bracelet);
                    ptbBracelet.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbBracelet.Image = null;
            }
            if (selectedPlayer.Necklace != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Necklace.Image));
                if (File.Exists(imagePath))
                {
                    ptbNecklace.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Necklace, ptbNecklace);
                    ptbNecklace.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Necklace);
                    ptbNecklace.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbNecklace.Image = null;
            }
            if (selectedPlayer.Artifact != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Artifact.Image));
                if (File.Exists(imagePath))
                {
                    ptbArtifact.Image = Image.FromFile(imagePath);
                    GetBackColor(selectedPlayer.Artifact, ptbArtifact);
                    ptbArtifact.MouseHover += (sender, e) => PictureBox_MouseEnter(sender, e, selectedPlayer.Artifact);
                    ptbArtifact.MouseLeave += PictureBox_MouseLeave;
                }
            }
            else
            {
                ptbArtifact.Image = null;
            }

        }
    }
}
