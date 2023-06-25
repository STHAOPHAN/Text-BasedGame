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
            lblHelmet = new Label();
            lblChestplate = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            lblDamage = new Label();
            lblAttackSpeed = new Label();
            lblArmor = new Label();
            lblMana = new Label();
            lblHealth = new Label();
            panel14 = new Panel();
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
            btnUndoIncreaseStat = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            // lblHelmet
            // 
            lblHelmet.AutoSize = true;
            lblHelmet.Location = new Point(3, 21);
            lblHelmet.Name = "lblHelmet";
            lblHelmet.Size = new Size(38, 15);
            lblHelmet.TabIndex = 2;
            lblHelmet.Text = "label2";
            // 
            // lblChestplate
            // 
            lblChestplate.AutoSize = true;
            lblChestplate.Location = new Point(15, 56);
            lblChestplate.Name = "lblChestplate";
            lblChestplate.Size = new Size(38, 15);
            lblChestplate.TabIndex = 3;
            lblChestplate.Text = "label3";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblHelmet);
            panel1.Location = new Point(318, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(63, 59);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblChestplate);
            panel2.Location = new Point(306, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(84, 119);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(306, 228);
            panel3.Name = "panel3";
            panel3.Size = new Size(84, 25);
            panel3.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(318, 259);
            panel4.Name = "panel4";
            panel4.Size = new Size(63, 75);
            panel4.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Location = new Point(318, 340);
            panel5.Name = "panel5";
            panel5.Size = new Size(63, 75);
            panel5.TabIndex = 13;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Location = new Point(212, 146);
            panel6.Name = "panel6";
            panel6.Size = new Size(63, 75);
            panel6.TabIndex = 14;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(420, 146);
            panel7.Name = "panel7";
            panel7.Size = new Size(63, 75);
            panel7.TabIndex = 15;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(212, 296);
            panel8.Name = "panel8";
            panel8.Size = new Size(63, 119);
            panel8.TabIndex = 16;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Location = new Point(420, 296);
            panel9.Name = "panel9";
            panel9.Size = new Size(63, 119);
            panel9.TabIndex = 17;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Location = new Point(226, 243);
            panel10.Name = "panel10";
            panel10.Size = new Size(39, 34);
            panel10.TabIndex = 18;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Location = new Point(432, 243);
            panel11.Name = "panel11";
            panel11.Size = new Size(39, 34);
            panel11.TabIndex = 19;
            // 
            // panel12
            // 
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Location = new Point(226, 49);
            panel12.Name = "panel12";
            panel12.Size = new Size(63, 75);
            panel12.TabIndex = 20;
            // 
            // panel13
            // 
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Location = new Point(411, 73);
            panel13.Name = "panel13";
            panel13.Size = new Size(48, 42);
            panel13.TabIndex = 21;
            // 
            // lblDamage
            // 
            lblDamage.AutoSize = true;
            lblDamage.Location = new Point(73, 85);
            lblDamage.Name = "lblDamage";
            lblDamage.Size = new Size(38, 15);
            lblDamage.TabIndex = 8;
            lblDamage.Text = "label7";
            // 
            // lblAttackSpeed
            // 
            lblAttackSpeed.AutoSize = true;
            lblAttackSpeed.Location = new Point(73, 107);
            lblAttackSpeed.Name = "lblAttackSpeed";
            lblAttackSpeed.Size = new Size(38, 15);
            lblAttackSpeed.TabIndex = 7;
            lblAttackSpeed.Text = "label7";
            // 
            // lblArmor
            // 
            lblArmor.AutoSize = true;
            lblArmor.Location = new Point(73, 131);
            lblArmor.Name = "lblArmor";
            lblArmor.Size = new Size(38, 15);
            lblArmor.TabIndex = 6;
            lblArmor.Text = "label6";
            // 
            // lblMana
            // 
            lblMana.AutoSize = true;
            lblMana.Location = new Point(73, 62);
            lblMana.Name = "lblMana";
            lblMana.Size = new Size(38, 15);
            lblMana.TabIndex = 23;
            lblMana.Text = "label1";
            // 
            // lblHealth
            // 
            lblHealth.AutoSize = true;
            lblHealth.Location = new Point(73, 38);
            lblHealth.Name = "lblHealth";
            lblHealth.Size = new Size(38, 15);
            lblHealth.TabIndex = 5;
            lblHealth.Text = "label5";
            // 
            // panel14
            // 
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
            panel14.Location = new Point(559, 27);
            panel14.Name = "panel14";
            panel14.Size = new Size(200, 194);
            panel14.TabIndex = 24;
            // 
            // btnIncreaseArmor
            // 
            btnIncreaseArmor.Location = new Point(133, 127);
            btnIncreaseArmor.Name = "btnIncreaseArmor";
            btnIncreaseArmor.Size = new Size(23, 23);
            btnIncreaseArmor.TabIndex = 28;
            btnIncreaseArmor.Text = "+";
            btnIncreaseArmor.UseVisualStyleBackColor = true;
            btnIncreaseArmor.Click += btnIncreaseArmor_Click;
            // 
            // btnIncreaseAttackSpeed
            // 
            btnIncreaseAttackSpeed.Location = new Point(133, 103);
            btnIncreaseAttackSpeed.Name = "btnIncreaseAttackSpeed";
            btnIncreaseAttackSpeed.Size = new Size(23, 23);
            btnIncreaseAttackSpeed.TabIndex = 29;
            btnIncreaseAttackSpeed.Text = "+";
            btnIncreaseAttackSpeed.UseVisualStyleBackColor = true;
            btnIncreaseAttackSpeed.Click += btnIncreaseAttackSpeed_Click;
            // 
            // btnIncreaseHealth
            // 
            btnIncreaseHealth.Location = new Point(133, 34);
            btnIncreaseHealth.Name = "btnIncreaseHealth";
            btnIncreaseHealth.Size = new Size(23, 23);
            btnIncreaseHealth.TabIndex = 26;
            btnIncreaseHealth.Text = "+";
            btnIncreaseHealth.UseVisualStyleBackColor = true;
            btnIncreaseHealth.Click += btnIncreaseHealth_Click;
            // 
            // btnIncreaseDamege
            // 
            btnIncreaseDamege.Location = new Point(133, 81);
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
            lblStatPoints.Location = new Point(73, 156);
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
            lblLevel.Location = new Point(73, 13);
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
            label4.Text = "Damege";
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
            // btnUndoIncreaseStat
            // 
            btnUndoIncreaseStat.Location = new Point(117, 152);
            btnUndoIncreaseStat.Name = "btnUndoIncreaseStat";
            btnUndoIncreaseStat.Size = new Size(52, 23);
            btnUndoIncreaseStat.TabIndex = 29;
            btnUndoIncreaseStat.Text = "Reset";
            btnUndoIncreaseStat.UseVisualStyleBackColor = true;
            btnUndoIncreaseStat.Click += btnUndoIncreaseStat_Click;
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel14);
            Controls.Add(panel13);
            Controls.Add(panel12);
            Controls.Add(panel11);
            Controls.Add(panel10);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(playerListBox);
            Name = "CharacterForm";
            Text = "Nhân Vật";
            Load += CharacterForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox playerListBox;
        private Label lblHelmet;
        private Label lblChestplate;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
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
    }
}