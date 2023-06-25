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

namespace View
{
    public partial class CharacterForm : Form
    {
        private PlayerController playerController = new PlayerController();
        private List<Player> players;

        public CharacterForm(List<Player> players)
        {
            InitializeComponent();
            this.players = players;

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

            // Hiển thị thông tin trang bị
            //lblWeapon.Text = selectedPlayer.Weapon != null ? selectedPlayer.Weapon.Name : "No Weapon";
            lblHelmet.Text = selectedPlayer.Helmet != null ? selectedPlayer.Helmet.Name : "No Helmet";
            lblChestplate.Text = selectedPlayer.ChestArmor != null ? selectedPlayer.ChestArmor.Name : "No Chest Armor";
            // Hiển thị các thuộc tính khác của trang bị

            // Hiển thị chỉ số của nhân vật
            UpdatePlayerInfo(selectedPlayer);
            // Hiển thị các chỉ số khác của nhân vật
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
    }
}
