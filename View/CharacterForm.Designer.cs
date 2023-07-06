namespace View
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            playerListBox = new ListBox();
            pnlHelmet = new Panel();
            ptbHelmet = new PictureBox();
            pnlChestArmor = new Panel();
            ptbChestArmor = new PictureBox();
            pnlBelt = new Panel();
            ptbBelt = new PictureBox();
            pnlPants = new Panel();
            ptbPants = new PictureBox();
            pnlBoots = new Panel();
            ptbBoots = new PictureBox();
            pnlGlove = new Panel();
            ptbGlove = new PictureBox();
            pnlArmArmor = new Panel();
            ptbArmArmor = new PictureBox();
            pnlWeapon = new Panel();
            ptbWeapon = new PictureBox();
            pnlSecondaryWeapon = new Panel();
            ptbSecondaryWeapon = new PictureBox();
            pnlRing = new Panel();
            ptbRing = new PictureBox();
            pnlBracelet = new Panel();
            ptbBracelet = new PictureBox();
            pnlArtifact = new Panel();
            ptbArtifact = new PictureBox();
            pnlNecklace = new Panel();
            ptbNecklace = new PictureBox();
            lblDamage = new Label();
            lblAttackSpeed = new Label();
            lblArmor = new Label();
            lblMana = new Label();
            lblHealth = new Label();
            panel14 = new Panel();
            lblNecessaryGold = new Label();
            btnLevelUp = new Button();
            btnUndoIncreaseStat = new Button();
            btnIncreaseArmor = new Button();
            btnIncreaseAttackSpeed = new Button();
            btnIncreaseHealth = new Button();
            btnIncreaseDamege = new Button();
            lblStatPoints = new Label();
            label = new Label();
            lblLevel = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            lblMessage = new Label();
            pnlHelmet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbHelmet).BeginInit();
            pnlChestArmor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbChestArmor).BeginInit();
            pnlBelt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBelt).BeginInit();
            pnlPants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbPants).BeginInit();
            pnlBoots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBoots).BeginInit();
            pnlGlove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbGlove).BeginInit();
            pnlArmArmor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbArmArmor).BeginInit();
            pnlWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbWeapon).BeginInit();
            pnlSecondaryWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbSecondaryWeapon).BeginInit();
            pnlRing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbRing).BeginInit();
            pnlBracelet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBracelet).BeginInit();
            pnlArtifact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbArtifact).BeginInit();
            pnlNecklace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbNecklace).BeginInit();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // playerListBox
            // 
            playerListBox.FormattingEnabled = true;
            playerListBox.ItemHeight = 15;
            playerListBox.Location = new Point(12, 27);
            playerListBox.Name = "playerListBox";
            playerListBox.Size = new Size(120, 379);
            playerListBox.TabIndex = 0;
            playerListBox.SelectedIndexChanged += playerListBox_SelectedIndexChanged;
            // 
            // pnlHelmet
            // 
            pnlHelmet.AllowDrop = true;
            pnlHelmet.BackColor = SystemColors.Window;
            pnlHelmet.BorderStyle = BorderStyle.FixedSingle;
            pnlHelmet.Controls.Add(ptbHelmet);
            pnlHelmet.Location = new Point(318, 37);
            pnlHelmet.Name = "pnlHelmet";
            pnlHelmet.Size = new Size(63, 59);
            pnlHelmet.TabIndex = 9;
            pnlHelmet.DragDrop += EquipmentSlot_DragDrop;
            pnlHelmet.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbHelmet
            // 
            ptbHelmet.Location = new Point(3, 2);
            ptbHelmet.Margin = new Padding(3, 2, 3, 2);
            ptbHelmet.Name = "ptbHelmet";
            ptbHelmet.Size = new Size(56, 52);
            ptbHelmet.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbHelmet.TabIndex = 28;
            ptbHelmet.TabStop = false;
            ptbHelmet.MouseUp += PictureBox_MouseUp;
            // 
            // pnlChestArmor
            // 
            pnlChestArmor.AllowDrop = true;
            pnlChestArmor.BackColor = SystemColors.Window;
            pnlChestArmor.BorderStyle = BorderStyle.FixedSingle;
            pnlChestArmor.Controls.Add(ptbChestArmor);
            pnlChestArmor.Location = new Point(306, 102);
            pnlChestArmor.Name = "pnlChestArmor";
            pnlChestArmor.Size = new Size(84, 119);
            pnlChestArmor.TabIndex = 10;
            pnlChestArmor.DragDrop += EquipmentSlot_DragDrop;
            pnlChestArmor.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbChestArmor
            // 
            ptbChestArmor.Location = new Point(3, 2);
            ptbChestArmor.Margin = new Padding(3, 2, 3, 2);
            ptbChestArmor.Name = "ptbChestArmor";
            ptbChestArmor.Size = new Size(77, 112);
            ptbChestArmor.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbChestArmor.TabIndex = 26;
            ptbChestArmor.TabStop = false;
            ptbChestArmor.MouseUp += PictureBox_MouseUp;
            // 
            // pnlBelt
            // 
            pnlBelt.AllowDrop = true;
            pnlBelt.BackColor = SystemColors.Window;
            pnlBelt.BorderStyle = BorderStyle.FixedSingle;
            pnlBelt.Controls.Add(ptbBelt);
            pnlBelt.Location = new Point(306, 228);
            pnlBelt.Name = "pnlBelt";
            pnlBelt.Size = new Size(84, 25);
            pnlBelt.TabIndex = 11;
            pnlBelt.DragDrop += EquipmentSlot_DragDrop;
            pnlBelt.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbBelt
            // 
            ptbBelt.Location = new Point(3, 2);
            ptbBelt.Margin = new Padding(3, 2, 3, 2);
            ptbBelt.Name = "ptbBelt";
            ptbBelt.Size = new Size(77, 19);
            ptbBelt.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBelt.TabIndex = 28;
            ptbBelt.TabStop = false;
            ptbBelt.MouseUp += PictureBox_MouseUp;
            // 
            // pnlPants
            // 
            pnlPants.AllowDrop = true;
            pnlPants.BackColor = SystemColors.Window;
            pnlPants.BorderStyle = BorderStyle.FixedSingle;
            pnlPants.Controls.Add(ptbPants);
            pnlPants.Location = new Point(318, 259);
            pnlPants.Name = "pnlPants";
            pnlPants.Size = new Size(63, 75);
            pnlPants.TabIndex = 12;
            pnlPants.DragDrop += EquipmentSlot_DragDrop;
            pnlPants.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbPants
            // 
            ptbPants.Location = new Point(3, 2);
            ptbPants.Margin = new Padding(3, 2, 3, 2);
            ptbPants.Name = "ptbPants";
            ptbPants.Size = new Size(56, 68);
            ptbPants.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbPants.TabIndex = 27;
            ptbPants.TabStop = false;
            ptbPants.MouseUp += PictureBox_MouseUp;
            // 
            // pnlBoots
            // 
            pnlBoots.AllowDrop = true;
            pnlBoots.BackColor = SystemColors.Window;
            pnlBoots.BorderStyle = BorderStyle.FixedSingle;
            pnlBoots.Controls.Add(ptbBoots);
            pnlBoots.Location = new Point(318, 340);
            pnlBoots.Name = "pnlBoots";
            pnlBoots.Size = new Size(63, 75);
            pnlBoots.TabIndex = 13;
            pnlBoots.DragDrop += EquipmentSlot_DragDrop;
            pnlBoots.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbBoots
            // 
            ptbBoots.Location = new Point(3, 2);
            ptbBoots.Margin = new Padding(3, 2, 3, 2);
            ptbBoots.Name = "ptbBoots";
            ptbBoots.Size = new Size(56, 66);
            ptbBoots.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBoots.TabIndex = 26;
            ptbBoots.TabStop = false;
            ptbBoots.MouseUp += PictureBox_MouseUp;
            // 
            // pnlGlove
            // 
            pnlGlove.AllowDrop = true;
            pnlGlove.BackColor = SystemColors.Window;
            pnlGlove.BorderStyle = BorderStyle.FixedSingle;
            pnlGlove.Controls.Add(ptbGlove);
            pnlGlove.Location = new Point(212, 146);
            pnlGlove.Name = "pnlGlove";
            pnlGlove.Size = new Size(63, 75);
            pnlGlove.TabIndex = 14;
            pnlGlove.DragDrop += EquipmentSlot_DragDrop;
            pnlGlove.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbGlove
            // 
            ptbGlove.Location = new Point(3, 2);
            ptbGlove.Margin = new Padding(3, 2, 3, 2);
            ptbGlove.Name = "ptbGlove";
            ptbGlove.Size = new Size(56, 68);
            ptbGlove.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbGlove.TabIndex = 27;
            ptbGlove.TabStop = false;
            ptbGlove.MouseUp += PictureBox_MouseUp;
            // 
            // pnlArmArmor
            // 
            pnlArmArmor.AllowDrop = true;
            pnlArmArmor.BackColor = SystemColors.Window;
            pnlArmArmor.BorderStyle = BorderStyle.FixedSingle;
            pnlArmArmor.Controls.Add(ptbArmArmor);
            pnlArmArmor.Location = new Point(420, 146);
            pnlArmArmor.Name = "pnlArmArmor";
            pnlArmArmor.Size = new Size(63, 75);
            pnlArmArmor.TabIndex = 15;
            pnlArmArmor.DragDrop += EquipmentSlot_DragDrop;
            pnlArmArmor.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbArmArmor
            // 
            ptbArmArmor.Location = new Point(3, 2);
            ptbArmArmor.Margin = new Padding(3, 2, 3, 2);
            ptbArmArmor.Name = "ptbArmArmor";
            ptbArmArmor.Size = new Size(56, 68);
            ptbArmArmor.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbArmArmor.TabIndex = 26;
            ptbArmArmor.TabStop = false;
            ptbArmArmor.MouseUp += PictureBox_MouseUp;
            // 
            // pnlWeapon
            // 
            pnlWeapon.AllowDrop = true;
            pnlWeapon.BackColor = SystemColors.Window;
            pnlWeapon.BorderStyle = BorderStyle.FixedSingle;
            pnlWeapon.Controls.Add(ptbWeapon);
            pnlWeapon.Location = new Point(212, 302);
            pnlWeapon.Name = "pnlWeapon";
            pnlWeapon.Size = new Size(63, 96);
            pnlWeapon.TabIndex = 16;
            pnlWeapon.DragDrop += EquipmentSlot_DragDrop;
            pnlWeapon.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbWeapon
            // 
            ptbWeapon.Location = new Point(3, 2);
            ptbWeapon.Margin = new Padding(3, 2, 3, 2);
            ptbWeapon.Name = "ptbWeapon";
            ptbWeapon.Size = new Size(56, 89);
            ptbWeapon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbWeapon.TabIndex = 26;
            ptbWeapon.TabStop = false;
            ptbWeapon.MouseUp += PictureBox_MouseUp;
            // 
            // pnlSecondaryWeapon
            // 
            pnlSecondaryWeapon.AllowDrop = true;
            pnlSecondaryWeapon.BackColor = SystemColors.Window;
            pnlSecondaryWeapon.BorderStyle = BorderStyle.FixedSingle;
            pnlSecondaryWeapon.Controls.Add(ptbSecondaryWeapon);
            pnlSecondaryWeapon.Location = new Point(420, 302);
            pnlSecondaryWeapon.Name = "pnlSecondaryWeapon";
            pnlSecondaryWeapon.Size = new Size(63, 96);
            pnlSecondaryWeapon.TabIndex = 17;
            pnlSecondaryWeapon.DragDrop += EquipmentSlot_DragDrop;
            pnlSecondaryWeapon.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbSecondaryWeapon
            // 
            ptbSecondaryWeapon.Location = new Point(3, 2);
            ptbSecondaryWeapon.Margin = new Padding(3, 2, 3, 2);
            ptbSecondaryWeapon.Name = "ptbSecondaryWeapon";
            ptbSecondaryWeapon.Size = new Size(56, 89);
            ptbSecondaryWeapon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbSecondaryWeapon.TabIndex = 25;
            ptbSecondaryWeapon.TabStop = false;
            ptbSecondaryWeapon.MouseUp += PictureBox_MouseUp;
            // 
            // pnlRing
            // 
            pnlRing.AllowDrop = true;
            pnlRing.BackColor = SystemColors.Window;
            pnlRing.BorderStyle = BorderStyle.FixedSingle;
            pnlRing.Controls.Add(ptbRing);
            pnlRing.Location = new Point(226, 243);
            pnlRing.Name = "pnlRing";
            pnlRing.Size = new Size(39, 34);
            pnlRing.TabIndex = 18;
            pnlRing.DragDrop += EquipmentSlot_DragDrop;
            pnlRing.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbRing
            // 
            ptbRing.Location = new Point(3, 2);
            ptbRing.Margin = new Padding(3, 2, 3, 2);
            ptbRing.Name = "ptbRing";
            ptbRing.Size = new Size(32, 28);
            ptbRing.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbRing.TabIndex = 30;
            ptbRing.TabStop = false;
            ptbRing.MouseUp += PictureBox_MouseUp;
            // 
            // pnlBracelet
            // 
            pnlBracelet.AllowDrop = true;
            pnlBracelet.BackColor = SystemColors.Window;
            pnlBracelet.BorderStyle = BorderStyle.FixedSingle;
            pnlBracelet.Controls.Add(ptbBracelet);
            pnlBracelet.Location = new Point(432, 243);
            pnlBracelet.Name = "pnlBracelet";
            pnlBracelet.Size = new Size(39, 34);
            pnlBracelet.TabIndex = 19;
            pnlBracelet.DragDrop += EquipmentSlot_DragDrop;
            pnlBracelet.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbBracelet
            // 
            ptbBracelet.Location = new Point(3, 2);
            ptbBracelet.Margin = new Padding(3, 2, 3, 2);
            ptbBracelet.Name = "ptbBracelet";
            ptbBracelet.Size = new Size(32, 28);
            ptbBracelet.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBracelet.TabIndex = 29;
            ptbBracelet.TabStop = false;
            ptbBracelet.MouseUp += PictureBox_MouseUp;
            // 
            // pnlArtifact
            // 
            pnlArtifact.AllowDrop = true;
            pnlArtifact.BackColor = SystemColors.Window;
            pnlArtifact.BorderStyle = BorderStyle.FixedSingle;
            pnlArtifact.Controls.Add(ptbArtifact);
            pnlArtifact.Location = new Point(226, 49);
            pnlArtifact.Name = "pnlArtifact";
            pnlArtifact.Size = new Size(63, 75);
            pnlArtifact.TabIndex = 20;
            pnlArtifact.DragDrop += EquipmentSlot_DragDrop;
            pnlArtifact.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbArtifact
            // 
            ptbArtifact.Location = new Point(3, 2);
            ptbArtifact.Margin = new Padding(3, 2, 3, 2);
            ptbArtifact.Name = "ptbArtifact";
            ptbArtifact.Size = new Size(56, 68);
            ptbArtifact.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbArtifact.TabIndex = 28;
            ptbArtifact.TabStop = false;
            ptbArtifact.MouseUp += PictureBox_MouseUp;
            // 
            // pnlNecklace
            // 
            pnlNecklace.AllowDrop = true;
            pnlNecklace.BackColor = SystemColors.Window;
            pnlNecklace.BorderStyle = BorderStyle.FixedSingle;
            pnlNecklace.Controls.Add(ptbNecklace);
            pnlNecklace.Location = new Point(411, 73);
            pnlNecklace.Name = "pnlNecklace";
            pnlNecklace.Size = new Size(48, 42);
            pnlNecklace.TabIndex = 21;
            pnlNecklace.DragDrop += EquipmentSlot_DragDrop;
            pnlNecklace.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbNecklace
            // 
            ptbNecklace.Location = new Point(3, 2);
            ptbNecklace.Margin = new Padding(3, 2, 3, 2);
            ptbNecklace.Name = "ptbNecklace";
            ptbNecklace.Size = new Size(41, 35);
            ptbNecklace.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbNecklace.TabIndex = 30;
            ptbNecklace.TabStop = false;
            ptbNecklace.MouseUp += PictureBox_MouseUp;
            // 
            // lblDamage
            // 
            lblDamage.AutoSize = true;
            lblDamage.Location = new Point(83, 85);
            lblDamage.Name = "lblDamage";
            lblDamage.Size = new Size(38, 15);
            lblDamage.TabIndex = 8;
            lblDamage.Text = "label7";
            // 
            // lblAttackSpeed
            // 
            lblAttackSpeed.AutoSize = true;
            lblAttackSpeed.Location = new Point(83, 107);
            lblAttackSpeed.Name = "lblAttackSpeed";
            lblAttackSpeed.Size = new Size(38, 15);
            lblAttackSpeed.TabIndex = 7;
            lblAttackSpeed.Text = "label7";
            // 
            // lblArmor
            // 
            lblArmor.AutoSize = true;
            lblArmor.Location = new Point(83, 131);
            lblArmor.Name = "lblArmor";
            lblArmor.Size = new Size(38, 15);
            lblArmor.TabIndex = 6;
            lblArmor.Text = "label6";
            // 
            // lblMana
            // 
            lblMana.AutoSize = true;
            lblMana.Location = new Point(83, 62);
            lblMana.Name = "lblMana";
            lblMana.Size = new Size(38, 15);
            lblMana.TabIndex = 23;
            lblMana.Text = "label1";
            // 
            // lblHealth
            // 
            lblHealth.AutoSize = true;
            lblHealth.Location = new Point(83, 38);
            lblHealth.Name = "lblHealth";
            lblHealth.Size = new Size(38, 15);
            lblHealth.TabIndex = 5;
            lblHealth.Text = "label5";
            // 
            // panel14
            // 
            panel14.BackColor = SystemColors.Window;
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.Controls.Add(lblNecessaryGold);
            panel14.Controls.Add(btnLevelUp);
            panel14.Controls.Add(btnUndoIncreaseStat);
            panel14.Controls.Add(btnIncreaseArmor);
            panel14.Controls.Add(btnIncreaseAttackSpeed);
            panel14.Controls.Add(btnIncreaseHealth);
            panel14.Controls.Add(btnIncreaseDamege);
            panel14.Controls.Add(lblStatPoints);
            panel14.Controls.Add(label);
            panel14.Controls.Add(lblLevel);
            panel14.Controls.Add(label6);
            panel14.Controls.Add(label5);
            panel14.Controls.Add(lblHealth);
            panel14.Controls.Add(label3);
            panel14.Controls.Add(label4);
            panel14.Controls.Add(lblMana);
            panel14.Controls.Add(lblArmor);
            panel14.Controls.Add(label1);
            panel14.Controls.Add(label2);
            panel14.Controls.Add(lblDamage);
            panel14.Controls.Add(lblAttackSpeed);
            panel14.Location = new Point(559, 27);
            panel14.Name = "panel14";
            panel14.Size = new Size(200, 223);
            panel14.TabIndex = 24;
            // 
            // lblNecessaryGold
            // 
            lblNecessaryGold.AutoSize = true;
            lblNecessaryGold.Location = new Point(83, 190);
            lblNecessaryGold.Name = "lblNecessaryGold";
            lblNecessaryGold.Size = new Size(38, 15);
            lblNecessaryGold.TabIndex = 30;
            lblNecessaryGold.Text = "label7";
            // 
            // btnLevelUp
            // 
            btnLevelUp.Location = new Point(14, 186);
            btnLevelUp.Name = "btnLevelUp";
            btnLevelUp.Size = new Size(64, 23);
            btnLevelUp.TabIndex = 27;
            btnLevelUp.Text = "Level Up";
            btnLevelUp.UseVisualStyleBackColor = true;
            btnLevelUp.Click += btnLevelUp_Click;
            // 
            // btnUndoIncreaseStat
            // 
            btnUndoIncreaseStat.Location = new Point(127, 152);
            btnUndoIncreaseStat.Name = "btnUndoIncreaseStat";
            btnUndoIncreaseStat.Size = new Size(52, 23);
            btnUndoIncreaseStat.TabIndex = 29;
            btnUndoIncreaseStat.Text = "Reset";
            btnUndoIncreaseStat.UseVisualStyleBackColor = true;
            btnUndoIncreaseStat.Click += btnUndoIncreaseStat_Click;
            // 
            // btnIncreaseArmor
            // 
            btnIncreaseArmor.Location = new Point(143, 127);
            btnIncreaseArmor.Name = "btnIncreaseArmor";
            btnIncreaseArmor.Size = new Size(23, 23);
            btnIncreaseArmor.TabIndex = 28;
            btnIncreaseArmor.Text = "+";
            btnIncreaseArmor.UseVisualStyleBackColor = true;
            btnIncreaseArmor.Click += btnIncreaseArmor_Click;
            // 
            // btnIncreaseAttackSpeed
            // 
            btnIncreaseAttackSpeed.Location = new Point(143, 103);
            btnIncreaseAttackSpeed.Name = "btnIncreaseAttackSpeed";
            btnIncreaseAttackSpeed.Size = new Size(23, 23);
            btnIncreaseAttackSpeed.TabIndex = 29;
            btnIncreaseAttackSpeed.Text = "+";
            btnIncreaseAttackSpeed.UseVisualStyleBackColor = true;
            btnIncreaseAttackSpeed.Click += btnIncreaseAttackSpeed_Click;
            // 
            // btnIncreaseHealth
            // 
            btnIncreaseHealth.Location = new Point(143, 34);
            btnIncreaseHealth.Name = "btnIncreaseHealth";
            btnIncreaseHealth.Size = new Size(23, 23);
            btnIncreaseHealth.TabIndex = 26;
            btnIncreaseHealth.Text = "+";
            btnIncreaseHealth.UseVisualStyleBackColor = true;
            btnIncreaseHealth.Click += btnIncreaseHealth_Click;
            // 
            // btnIncreaseDamege
            // 
            btnIncreaseDamege.Location = new Point(143, 81);
            btnIncreaseDamege.Name = "btnIncreaseDamege";
            btnIncreaseDamege.Size = new Size(23, 23);
            btnIncreaseDamege.TabIndex = 25;
            btnIncreaseDamege.Text = "+";
            btnIncreaseDamege.UseVisualStyleBackColor = true;
            btnIncreaseDamege.Click += btnIncreaseDamege_Click;
            // 
            // lblStatPoints
            // 
            lblStatPoints.AutoSize = true;
            lblStatPoints.Location = new Point(83, 156);
            lblStatPoints.Name = "lblStatPoints";
            lblStatPoints.Size = new Size(38, 15);
            lblStatPoints.TabIndex = 25;
            lblStatPoints.Text = "label6";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(16, 156);
            label.Name = "label";
            label.Size = new Size(20, 15);
            label.TabIndex = 28;
            label.Text = "SP";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(83, 13);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(38, 15);
            lblLevel.TabIndex = 25;
            lblLevel.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 13);
            label6.Name = "label6";
            label6.Size = new Size(21, 15);
            label6.TabIndex = 27;
            label6.Text = "Lvl";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 131);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 29;
            label5.Text = "Armor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 107);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 27;
            label3.Text = "AS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 85);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 28;
            label4.Text = "Damage";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 62);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 25;
            label1.Text = "Mana";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 38);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 26;
            label2.Text = "HP";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(574, 259);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(38, 15);
            lblMessage.TabIndex = 25;
            lblMessage.Text = "label7";
            lblMessage.Visible = false;
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(panel14);
            Controls.Add(pnlNecklace);
            Controls.Add(pnlArtifact);
            Controls.Add(pnlBracelet);
            Controls.Add(pnlRing);
            Controls.Add(pnlSecondaryWeapon);
            Controls.Add(pnlWeapon);
            Controls.Add(pnlArmArmor);
            Controls.Add(pnlGlove);
            Controls.Add(pnlBoots);
            Controls.Add(pnlPants);
            Controls.Add(pnlBelt);
            Controls.Add(pnlChestArmor);
            Controls.Add(pnlHelmet);
            Controls.Add(playerListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CharacterForm";
            Text = "Nhân Vật";
            Load += CharacterForm_Load;
            DragDrop += EquipmentSlot_DragDrop;
            DragEnter += EquipmentSlot_DragEnter;
            pnlHelmet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbHelmet).EndInit();
            pnlChestArmor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbChestArmor).EndInit();
            pnlBelt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbBelt).EndInit();
            pnlPants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbPants).EndInit();
            pnlBoots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbBoots).EndInit();
            pnlGlove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbGlove).EndInit();
            pnlArmArmor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbArmArmor).EndInit();
            pnlWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbWeapon).EndInit();
            pnlSecondaryWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbSecondaryWeapon).EndInit();
            pnlRing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbRing).EndInit();
            pnlBracelet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbBracelet).EndInit();
            pnlArtifact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbArtifact).EndInit();
            pnlNecklace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbNecklace).EndInit();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox playerListBox;
        private Panel pnlHelmet;
        private Panel pnlChestArmor;
        private Panel pnlBelt;
        private Panel pnlPants;
        private Panel pnlBoots;
        private Panel pnlGlove;
        private Panel pnlArmArmor;
        private Panel pnlWeapon;
        private Panel pnlSecondaryWeapon;
        private Panel pnlRing;
        private Panel pnlBracelet;
        private Panel pnlArtifact;
        private Panel pnlNecklace;
        private Label lblDamage;
        private Label lblAttackSpeed;
        private Label lblArmor;
        private Label lblMana;
        private Label lblHealth;
        private Panel panel14;
        private Label label3;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label lblLevel;
        private Label label6;
        private Label lblStatPoints;
        private Label label;
        private Button btnIncreaseArmor;
        private Button btnIncreaseAttackSpeed;
        private Button btnIncreaseHealth;
        private Button btnIncreaseDamege;
        private Button btnUndoIncreaseStat;
        private PictureBox ptbHelmet;
        private PictureBox ptbChestArmor;
        private PictureBox ptbBelt;
        private PictureBox ptbPants;
        private PictureBox ptbBoots;
        private PictureBox ptbGlove;
        private PictureBox ptbArmArmor;
        private PictureBox ptbWeapon;
        private PictureBox ptbSecondaryWeapon;
        private PictureBox ptbRing;
        private PictureBox ptbBracelet;
        private PictureBox ptbArtifact;
        private PictureBox ptbNecklace;
        private Label lblNecessaryGold;
        private Button btnLevelUp;
        private Label lblMessage;
    }
}