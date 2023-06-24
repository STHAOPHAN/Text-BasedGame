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

namespace View
{
    public partial class CharacterForm : Form
    {
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
            lblHealth.Text = $"{selectedPlayer.curHealth}/{selectedPlayer.maxHealth}";
            lblMana.Text = selectedPlayer.mana.ToString();
            lblDamage.Text = selectedPlayer.damage.ToString();
            lblArmor.Text = selectedPlayer.armor.ToString();
            lblAttackSpeed.Text = selectedPlayer.attackSpeed.ToString();
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
    }
}
