using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private List<Equipment> equipmentInventory;
        private InventoryForm inventoryForm;

        public CharacterForm(List<Player> players, List<Equipment> equipmentInventory)
        {
            InitializeComponent();
            this.players = players;

            // Hiển thị danh sách người chơi
            foreach (var player in players)
            {
                playerListBox.Items.Add(player.name);
            }

            this.equipmentInventory = equipmentInventory;
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

                // Xử lý việc thả trang bị vào Panel
                bool rs = EquipItem(panel, equipment);
/*                if (rs)
                {
                    list<item> inventory = inventoryform.inventory;
                    inventory.remove(equipment);

                    tablelayoutpanel tlpinventory = inventoryform.inventorytablelayoutpanel; // lấy đối tượng tlpinventory
                                                                                             // cập nhật giao diện nếu cần thiết
                    tlpinventory.refresh(); // cập nhật lại giao diện để hiển thị thay đổi

                }
*/
                // Cập nhật thông tin người chơi
                UpdatePlayerStats();

                // Cập nhật hiển thị trên CharacterForm
                RefreshCharacterForm();
            }
        }

        private bool EquipItem(Panel panel, Equipment equipment)
        {
            var selectedPlayer = players[playerListBox.SelectedIndex];

            if (panel == pnlWeapon && equipment.Type.Equals("Weapon"))
            {
                selectedPlayer.Weapon = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlSecondaryWeapon && equipment.Type.Equals("Secondary Weapon"))
            {
                selectedPlayer.SecondaryWeapon = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlHelmet && equipment.Type.Equals("Helmet"))
            {
                selectedPlayer.Helmet = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlChestArmor && equipment.Type.Equals("Chest Armor"))
            {
                selectedPlayer.ChestArmor = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlArmChest && equipment.Type.Equals("Arm Armor"))
            {
                selectedPlayer.ArmArmor = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlGlove && equipment.Type.Equals("Glove"))
            {
                selectedPlayer.Glove = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlBelt && equipment.Type.Equals("Belt"))
            {
                selectedPlayer.Belt = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlPants && equipment.Type.Equals("Pants"))
            {
                selectedPlayer.Pants = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlBoots && equipment.Type.Equals("Boots"))
            {
                selectedPlayer.Boots = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlNecklace && equipment.Type.Equals("Necklace"))
            {
                selectedPlayer.Necklace = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlRing1 && equipment.Type.Equals("Ring"))
            {
                selectedPlayer.Ring1 = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlRing2 && equipment.Type.Equals("Ring"))
            {
                selectedPlayer.Ring2 = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            else if (panel == pnlArtifact && equipment.Type.Equals("Artifact"))
            {
                selectedPlayer.Artifact = equipment;
                // Tăng chỉ số theo trang bị
                IncreasePlayerStats(selectedPlayer, equipment);
                return true;
            }
            return false;
        }

        private void IncreasePlayerStats(Player player, Item item)
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
            if (selectedPlayer.Ring1 != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Ring1.Image));
                if (File.Exists(imagePath))
                {
                    ptbRing1.Image = Image.FromFile(imagePath);
                }
            }
            else
            {
                ptbRing1.Image = null;
            }
            if (selectedPlayer.Ring2 != null)
            {
                imagePath = Path.GetFullPath(Path.Combine(currentDirectory, selectedPlayer.Ring2.Image));
                if (File.Exists(imagePath))
                {
                    ptbRing2.Image = Image.FromFile(imagePath);
                }
            }
            else
            {
                ptbRing2.Image = null;
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
