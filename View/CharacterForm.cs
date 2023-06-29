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
            lblAttackSpeed.Text = player.attackSpeed.ToString();
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
                // Lặp lại cho các panel khác tương tự như trên
                // ...
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
        }
        public Equipment EquipItemByButton(Equipment equipment, Player selectedPlayer)
        {
            if (equipment.Type.Equals("Weapon"))
            {
                if (pnlWeapon.Controls.Count == 0)
                {
                    selectedPlayer.Weapon = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.Weapon;
                    selectedPlayer.Weapon = equipment;
                    return returnEquipment;
                }
            }
            else if (equipment.Type.Equals("Secondary Weapon"))
            {
                if (pnlSecondaryWeapon.Controls.Count == 0)
                {
                    selectedPlayer.SecondaryWeapon = equipment;
                    // Tăng chỉ số theo trang bị
                    IncreasePlayerStats(selectedPlayer, equipment);
                    return null;
                }
                else
                {
                    Equipment returnEquipment = selectedPlayer.SecondaryWeapon;
                    selectedPlayer.SecondaryWeapon = equipment;
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
                    selectedPlayer.Helmet = equipment;
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
                    selectedPlayer.ChestArmor = equipment;
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
                    selectedPlayer.ArmArmor = equipment;
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
                    selectedPlayer.Glove = equipment;
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
                    selectedPlayer.Belt = equipment;
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
                    selectedPlayer.Pants = equipment;
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
                    selectedPlayer.Boots = equipment;
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
                    selectedPlayer.Necklace = equipment;
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
                    selectedPlayer.Ring = equipment;
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
                    selectedPlayer.Bracelet = equipment;
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
                    selectedPlayer.Artifact = equipment;
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
                player.attackSpeed -= (equipment.AttackSpeed / 100);
                player.armor += equipment.Armor;


                // Cập nhật các chỉ số khác tùy thuộc vào trang bị
            }
        }

        private void DecreasePlayerStats(Player player, Item item )
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;

                player.curHealth -= equipment.HP;
                player.maxHealth -= equipment.HP;
                player.damage -= equipment.Damage;
                player.attackSpeed += (equipment.AttackSpeed / 100);
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
                }
            }
            else
            {
                ptbArtifact.Image = null;
            }

        }


    }
}
