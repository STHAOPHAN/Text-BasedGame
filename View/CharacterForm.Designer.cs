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
            pnlArmChest = new Panel();
            ptbArmArmor = new PictureBox();
            pnlWeapon = new Panel();
            ptbWeapon = new PictureBox();
            pnlSecondaryWeapon = new Panel();
            ptbSecondaryWeapon = new PictureBox();
            pnlRing1 = new Panel();
            ptbRing1 = new PictureBox();
            pnlRing2 = new Panel();
            ptbRing2 = new PictureBox();
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
            pnlArmChest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbArmArmor).BeginInit();
            pnlWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbWeapon).BeginInit();
            pnlSecondaryWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbSecondaryWeapon).BeginInit();
            pnlRing1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbRing1).BeginInit();
            pnlRing2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbRing2).BeginInit();
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
            playerListBox.ItemHeight = 20;
            playerListBox.Location = new Point(14, 36);
            playerListBox.Margin = new Padding(3, 4, 3, 4);
            playerListBox.Name = "playerListBox";
            playerListBox.Size = new Size(137, 504);
            playerListBox.TabIndex = 0;
            playerListBox.SelectedIndexChanged += playerListBox_SelectedIndexChanged;
            // 
            // pnlHelmet
            // 
            pnlHelmet.AllowDrop = true;
            pnlHelmet.BackColor = SystemColors.Window;
            pnlHelmet.BorderStyle = BorderStyle.FixedSingle;
            pnlHelmet.Controls.Add(ptbHelmet);
            pnlHelmet.Location = new Point(363, 49);
            pnlHelmet.Margin = new Padding(3, 4, 3, 4);
            pnlHelmet.Name = "pnlHelmet";
            pnlHelmet.Size = new Size(72, 78);
            pnlHelmet.TabIndex = 9;
            pnlHelmet.DragDrop += EquipmentSlot_DragDrop;
            pnlHelmet.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbHelmet
            // 
            ptbHelmet.Location = new Point(3, 3);
            ptbHelmet.Name = "ptbHelmet";
            ptbHelmet.Size = new Size(64, 70);
            ptbHelmet.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbHelmet.TabIndex = 28;
            ptbHelmet.TabStop = false;
            // 
            // pnlChestArmor
            // 
            pnlChestArmor.AllowDrop = true;
            pnlChestArmor.BackColor = SystemColors.Window;
            pnlChestArmor.BorderStyle = BorderStyle.FixedSingle;
            pnlChestArmor.Controls.Add(ptbChestArmor);
            pnlChestArmor.Location = new Point(350, 136);
            pnlChestArmor.Margin = new Padding(3, 4, 3, 4);
            pnlChestArmor.Name = "pnlChestArmor";
            pnlChestArmor.Size = new Size(96, 158);
            pnlChestArmor.TabIndex = 10;
            pnlChestArmor.DragDrop += EquipmentSlot_DragDrop;
            pnlChestArmor.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbChestArmor
            // 
            ptbChestArmor.Location = new Point(3, 3);
            ptbChestArmor.Name = "ptbChestArmor";
            ptbChestArmor.Size = new Size(88, 150);
            ptbChestArmor.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbChestArmor.TabIndex = 26;
            ptbChestArmor.TabStop = false;
            // 
            // pnlBelt
            // 
            pnlBelt.AllowDrop = true;
            pnlBelt.BackColor = SystemColors.Window;
            pnlBelt.BorderStyle = BorderStyle.FixedSingle;
            pnlBelt.Controls.Add(ptbBelt);
            pnlBelt.Location = new Point(350, 304);
            pnlBelt.Margin = new Padding(3, 4, 3, 4);
            pnlBelt.Name = "pnlBelt";
            pnlBelt.Size = new Size(96, 33);
            pnlBelt.TabIndex = 11;
            pnlBelt.DragDrop += EquipmentSlot_DragDrop;
            pnlBelt.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbBelt
            // 
            ptbBelt.Location = new Point(3, 3);
            ptbBelt.Name = "ptbBelt";
            ptbBelt.Size = new Size(88, 25);
            ptbBelt.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBelt.TabIndex = 28;
            ptbBelt.TabStop = false;
            // 
            // pnlPants
            // 
            pnlPants.AllowDrop = true;
            pnlPants.BackColor = SystemColors.Window;
            pnlPants.BorderStyle = BorderStyle.FixedSingle;
            pnlPants.Controls.Add(ptbPants);
            pnlPants.Location = new Point(363, 345);
            pnlPants.Margin = new Padding(3, 4, 3, 4);
            pnlPants.Name = "pnlPants";
            pnlPants.Size = new Size(72, 99);
            pnlPants.TabIndex = 12;
            pnlPants.DragDrop += EquipmentSlot_DragDrop;
            pnlPants.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbPants
            // 
            ptbPants.Location = new Point(3, 3);
            ptbPants.Name = "ptbPants";
            ptbPants.Size = new Size(64, 91);
            ptbPants.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbPants.TabIndex = 27;
            ptbPants.TabStop = false;
            // 
            // pnlBoots
            // 
            pnlBoots.AllowDrop = true;
            pnlBoots.BackColor = SystemColors.Window;
            pnlBoots.BorderStyle = BorderStyle.FixedSingle;
            pnlBoots.Controls.Add(ptbBoots);
            pnlBoots.Location = new Point(363, 453);
            pnlBoots.Margin = new Padding(3, 4, 3, 4);
            pnlBoots.Name = "pnlBoots";
            pnlBoots.Size = new Size(72, 99);
            pnlBoots.TabIndex = 13;
            pnlBoots.DragDrop += EquipmentSlot_DragDrop;
            pnlBoots.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbBoots
            // 
            ptbBoots.Location = new Point(3, 3);
            ptbBoots.Name = "ptbBoots";
            ptbBoots.Size = new Size(64, 88);
            ptbBoots.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBoots.TabIndex = 26;
            ptbBoots.TabStop = false;
            // 
            // pnlGlove
            // 
            pnlGlove.AllowDrop = true;
            pnlGlove.BackColor = SystemColors.Window;
            pnlGlove.BorderStyle = BorderStyle.FixedSingle;
            pnlGlove.Controls.Add(ptbGlove);
            pnlGlove.Location = new Point(242, 195);
            pnlGlove.Margin = new Padding(3, 4, 3, 4);
            pnlGlove.Name = "pnlGlove";
            pnlGlove.Size = new Size(72, 99);
            pnlGlove.TabIndex = 14;
            pnlGlove.DragDrop += EquipmentSlot_DragDrop;
            pnlGlove.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbGlove
            // 
            ptbGlove.Location = new Point(3, 3);
            ptbGlove.Name = "ptbGlove";
            ptbGlove.Size = new Size(64, 91);
            ptbGlove.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbGlove.TabIndex = 27;
            ptbGlove.TabStop = false;
            // 
            // pnlArmChest
            // 
            pnlArmChest.AllowDrop = true;
            pnlArmChest.BackColor = SystemColors.Window;
            pnlArmChest.BorderStyle = BorderStyle.FixedSingle;
            pnlArmChest.Controls.Add(ptbArmArmor);
            pnlArmChest.Location = new Point(480, 195);
            pnlArmChest.Margin = new Padding(3, 4, 3, 4);
            pnlArmChest.Name = "pnlArmChest";
            pnlArmChest.Size = new Size(72, 99);
            pnlArmChest.TabIndex = 15;
            pnlArmChest.DragDrop += EquipmentSlot_DragDrop;
            pnlArmChest.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbArmArmor
            // 
            ptbArmArmor.Location = new Point(3, 3);
            ptbArmArmor.Name = "ptbArmArmor";
            ptbArmArmor.Size = new Size(64, 91);
            ptbArmArmor.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbArmArmor.TabIndex = 26;
            ptbArmArmor.TabStop = false;
            // 
            // pnlWeapon
            // 
            pnlWeapon.AllowDrop = true;
            pnlWeapon.BackColor = SystemColors.Window;
            pnlWeapon.BorderStyle = BorderStyle.FixedSingle;
            pnlWeapon.Controls.Add(ptbWeapon);
            pnlWeapon.Location = new Point(242, 402);
            pnlWeapon.Margin = new Padding(3, 4, 3, 4);
            pnlWeapon.Name = "pnlWeapon";
            pnlWeapon.Size = new Size(72, 127);
            pnlWeapon.TabIndex = 16;
            pnlWeapon.DragDrop += EquipmentSlot_DragDrop;
            pnlWeapon.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbWeapon
            // 
            ptbWeapon.Location = new Point(3, 3);
            ptbWeapon.Name = "ptbWeapon";
            ptbWeapon.Size = new Size(64, 119);
            ptbWeapon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbWeapon.TabIndex = 26;
            ptbWeapon.TabStop = false;
            // 
            // pnlSecondaryWeapon
            // 
            pnlSecondaryWeapon.AllowDrop = true;
            pnlSecondaryWeapon.BackColor = SystemColors.Window;
            pnlSecondaryWeapon.BorderStyle = BorderStyle.FixedSingle;
            pnlSecondaryWeapon.Controls.Add(ptbSecondaryWeapon);
            pnlSecondaryWeapon.Location = new Point(480, 402);
            pnlSecondaryWeapon.Margin = new Padding(3, 4, 3, 4);
            pnlSecondaryWeapon.Name = "pnlSecondaryWeapon";
            pnlSecondaryWeapon.Size = new Size(72, 127);
            pnlSecondaryWeapon.TabIndex = 17;
            pnlSecondaryWeapon.DragDrop += EquipmentSlot_DragDrop;
            pnlSecondaryWeapon.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbSecondaryWeapon
            // 
            ptbSecondaryWeapon.Location = new Point(3, 3);
            ptbSecondaryWeapon.Name = "ptbSecondaryWeapon";
            ptbSecondaryWeapon.Size = new Size(64, 119);
            ptbSecondaryWeapon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbSecondaryWeapon.TabIndex = 25;
            ptbSecondaryWeapon.TabStop = false;
            // 
            // pnlRing1
            // 
            pnlRing1.AllowDrop = true;
            pnlRing1.BackColor = SystemColors.Window;
            pnlRing1.BorderStyle = BorderStyle.FixedSingle;
            pnlRing1.Controls.Add(ptbRing1);
            pnlRing1.Location = new Point(258, 324);
            pnlRing1.Margin = new Padding(3, 4, 3, 4);
            pnlRing1.Name = "pnlRing1";
            pnlRing1.Size = new Size(44, 45);
            pnlRing1.TabIndex = 18;
            pnlRing1.DragDrop += EquipmentSlot_DragDrop;
            pnlRing1.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbRing1
            // 
            ptbRing1.Location = new Point(3, 3);
            ptbRing1.Name = "ptbRing1";
            ptbRing1.Size = new Size(36, 37);
            ptbRing1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbRing1.TabIndex = 30;
            ptbRing1.TabStop = false;
            // 
            // pnlRing2
            // 
            pnlRing2.AllowDrop = true;
            pnlRing2.BackColor = SystemColors.Window;
            pnlRing2.BorderStyle = BorderStyle.FixedSingle;
            pnlRing2.Controls.Add(ptbRing2);
            pnlRing2.Location = new Point(494, 324);
            pnlRing2.Margin = new Padding(3, 4, 3, 4);
            pnlRing2.Name = "pnlRing2";
            pnlRing2.Size = new Size(44, 45);
            pnlRing2.TabIndex = 19;
            pnlRing2.DragDrop += EquipmentSlot_DragDrop;
            pnlRing2.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbRing2
            // 
            ptbRing2.Location = new Point(3, 3);
            ptbRing2.Name = "ptbRing2";
            ptbRing2.Size = new Size(36, 37);
            ptbRing2.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbRing2.TabIndex = 29;
            ptbRing2.TabStop = false;
            // 
            // pnlArtifact
            // 
            pnlArtifact.AllowDrop = true;
            pnlArtifact.BackColor = SystemColors.Window;
            pnlArtifact.BorderStyle = BorderStyle.FixedSingle;
            pnlArtifact.Controls.Add(ptbArtifact);
            pnlArtifact.Location = new Point(258, 65);
            pnlArtifact.Margin = new Padding(3, 4, 3, 4);
            pnlArtifact.Name = "pnlArtifact";
            pnlArtifact.Size = new Size(72, 99);
            pnlArtifact.TabIndex = 20;
            pnlArtifact.DragDrop += EquipmentSlot_DragDrop;
            pnlArtifact.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbArtifact
            // 
            ptbArtifact.Location = new Point(3, 3);
            ptbArtifact.Name = "ptbArtifact";
            ptbArtifact.Size = new Size(64, 91);
            ptbArtifact.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbArtifact.TabIndex = 28;
            ptbArtifact.TabStop = false;
            // 
            // pnlNecklace
            // 
            pnlNecklace.AllowDrop = true;
            pnlNecklace.BackColor = SystemColors.Window;
            pnlNecklace.BorderStyle = BorderStyle.FixedSingle;
            pnlNecklace.Controls.Add(ptbNecklace);
            pnlNecklace.Location = new Point(470, 97);
            pnlNecklace.Margin = new Padding(3, 4, 3, 4);
            pnlNecklace.Name = "pnlNecklace";
            pnlNecklace.Size = new Size(55, 55);
            pnlNecklace.TabIndex = 21;
            pnlNecklace.DragDrop += EquipmentSlot_DragDrop;
            pnlNecklace.DragEnter += EquipmentSlot_DragEnter;
            // 
            // ptbNecklace
            // 
            ptbNecklace.Location = new Point(3, 3);
            ptbNecklace.Name = "ptbNecklace";
            ptbNecklace.Size = new Size(47, 47);
            ptbNecklace.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbNecklace.TabIndex = 30;
            ptbNecklace.TabStop = false;
            // 
            // lblDamage
            // 
            lblDamage.AutoSize = true;
            lblDamage.Location = new Point(83, 113);
            lblDamage.Name = "lblDamage";
            lblDamage.Size = new Size(50, 20);
            lblDamage.TabIndex = 8;
            lblDamage.Text = "label7";
            // 
            // lblAttackSpeed
            // 
            lblAttackSpeed.AutoSize = true;
            lblAttackSpeed.Location = new Point(83, 143);
            lblAttackSpeed.Name = "lblAttackSpeed";
            lblAttackSpeed.Size = new Size(50, 20);
            lblAttackSpeed.TabIndex = 7;
            lblAttackSpeed.Text = "label7";
            // 
            // lblArmor
            // 
            lblArmor.AutoSize = true;
            lblArmor.Location = new Point(83, 175);
            lblArmor.Name = "lblArmor";
            lblArmor.Size = new Size(50, 20);
            lblArmor.TabIndex = 6;
            lblArmor.Text = "label6";
            // 
            // lblMana
            // 
            lblMana.AutoSize = true;
            lblMana.Location = new Point(83, 83);
            lblMana.Name = "lblMana";
            lblMana.Size = new Size(50, 20);
            lblMana.TabIndex = 23;
            lblMana.Text = "label1";
            // 
            // lblHealth
            // 
            lblHealth.AutoSize = true;
            lblHealth.Location = new Point(83, 51);
            lblHealth.Name = "lblHealth";
            lblHealth.Size = new Size(50, 20);
            lblHealth.TabIndex = 5;
            lblHealth.Text = "label5";
            // 
            // panel14
            // 
            panel14.BackColor = SystemColors.Window;
            panel14.BorderStyle = BorderStyle.FixedSingle;
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
            panel14.Location = new Point(639, 36);
            panel14.Margin = new Padding(3, 4, 3, 4);
            panel14.Name = "panel14";
            panel14.Size = new Size(228, 258);
            panel14.TabIndex = 24;
            // 
            // btnUndoIncreaseStat
            // 
            btnUndoIncreaseStat.Location = new Point(134, 203);
            btnUndoIncreaseStat.Margin = new Padding(3, 4, 3, 4);
            btnUndoIncreaseStat.Name = "btnUndoIncreaseStat";
            btnUndoIncreaseStat.Size = new Size(59, 31);
            btnUndoIncreaseStat.TabIndex = 29;
            btnUndoIncreaseStat.Text = "Reset";
            btnUndoIncreaseStat.UseVisualStyleBackColor = true;
            btnUndoIncreaseStat.Click += btnUndoIncreaseStat_Click;
            // 
            // btnIncreaseArmor
            // 
            btnIncreaseArmor.Location = new Point(152, 169);
            btnIncreaseArmor.Margin = new Padding(3, 4, 3, 4);
            btnIncreaseArmor.Name = "btnIncreaseArmor";
            btnIncreaseArmor.Size = new Size(26, 31);
            btnIncreaseArmor.TabIndex = 28;
            btnIncreaseArmor.Text = "+";
            btnIncreaseArmor.UseVisualStyleBackColor = true;
            btnIncreaseArmor.Click += btnIncreaseArmor_Click;
            // 
            // btnIncreaseAttackSpeed
            // 
            btnIncreaseAttackSpeed.Location = new Point(152, 137);
            btnIncreaseAttackSpeed.Margin = new Padding(3, 4, 3, 4);
            btnIncreaseAttackSpeed.Name = "btnIncreaseAttackSpeed";
            btnIncreaseAttackSpeed.Size = new Size(26, 31);
            btnIncreaseAttackSpeed.TabIndex = 29;
            btnIncreaseAttackSpeed.Text = "+";
            btnIncreaseAttackSpeed.UseVisualStyleBackColor = true;
            btnIncreaseAttackSpeed.Click += btnIncreaseAttackSpeed_Click;
            // 
            // btnIncreaseHealth
            // 
            btnIncreaseHealth.Location = new Point(152, 45);
            btnIncreaseHealth.Margin = new Padding(3, 4, 3, 4);
            btnIncreaseHealth.Name = "btnIncreaseHealth";
            btnIncreaseHealth.Size = new Size(26, 31);
            btnIncreaseHealth.TabIndex = 26;
            btnIncreaseHealth.Text = "+";
            btnIncreaseHealth.UseVisualStyleBackColor = true;
            btnIncreaseHealth.Click += btnIncreaseHealth_Click;
            // 
            // btnIncreaseDamege
            // 
            btnIncreaseDamege.Location = new Point(152, 108);
            btnIncreaseDamege.Margin = new Padding(3, 4, 3, 4);
            btnIncreaseDamege.Name = "btnIncreaseDamege";
            btnIncreaseDamege.Size = new Size(26, 31);
            btnIncreaseDamege.TabIndex = 25;
            btnIncreaseDamege.Text = "+";
            btnIncreaseDamege.UseVisualStyleBackColor = true;
            btnIncreaseDamege.Click += btnIncreaseDamege_Click;
            // 
            // lblStatPoints
            // 
            lblStatPoints.AutoSize = true;
            lblStatPoints.Location = new Point(83, 208);
            lblStatPoints.Name = "lblStatPoints";
            lblStatPoints.Size = new Size(50, 20);
            lblStatPoints.TabIndex = 25;
            lblStatPoints.Text = "label6";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(18, 208);
            label.Name = "label";
            label.Size = new Size(25, 20);
            label.TabIndex = 28;
            label.Text = "SP";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(83, 17);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(50, 20);
            lblLevel.TabIndex = 25;
            lblLevel.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 17);
            label6.Name = "label6";
            label6.Size = new Size(26, 20);
            label6.TabIndex = 27;
            label6.Text = "Lvl";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 175);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 29;
            label5.Text = "Armor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 143);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 27;
            label3.Text = "AS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 113);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 28;
            label4.Text = "Damage";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 83);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 25;
            label1.Text = "Mana";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 51);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 26;
            label2.Text = "HP";
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(914, 600);
            Controls.Add(panel14);
            Controls.Add(pnlNecklace);
            Controls.Add(pnlArtifact);
            Controls.Add(pnlRing2);
            Controls.Add(pnlRing1);
            Controls.Add(pnlSecondaryWeapon);
            Controls.Add(pnlWeapon);
            Controls.Add(pnlArmChest);
            Controls.Add(pnlGlove);
            Controls.Add(pnlBoots);
            Controls.Add(pnlPants);
            Controls.Add(pnlBelt);
            Controls.Add(pnlChestArmor);
            Controls.Add(pnlHelmet);
            Controls.Add(playerListBox);
            Margin = new Padding(3, 4, 3, 4);
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
            pnlArmChest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbArmArmor).EndInit();
            pnlWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbWeapon).EndInit();
            pnlSecondaryWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbSecondaryWeapon).EndInit();
            pnlRing1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbRing1).EndInit();
            pnlRing2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbRing2).EndInit();
            pnlArtifact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbArtifact).EndInit();
            pnlNecklace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbNecklace).EndInit();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox playerListBox;
        private Panel pnlHelmet;
        private Panel pnlChestArmor;
        private Panel pnlBelt;
        private Panel pnlPants;
        private Panel pnlBoots;
        private Panel pnlGlove;
        private Panel pnlArmChest;
        private Panel pnlWeapon;
        private Panel pnlSecondaryWeapon;
        private Panel pnlRing1;
        private Panel pnlRing2;
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
        private PictureBox ptbRing1;
        private PictureBox ptbRing2;
        private PictureBox ptbArtifact;
        private PictureBox ptbNecklace;
    }
}