namespace View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPlayerName = new Label();
            playerHealthProgressBar = new ProgressBar();
            playerTimerBar = new ProgressBar();
            panel1 = new Panel();
            lblPlayerHealth = new Label();
            panel2 = new Panel();
            lblEnemyHealth = new Label();
            enemyTimerBar = new ProgressBar();
            enemyHealthProgressBar = new ProgressBar();
            lblEnemyName = new Label();
            bottomMenuPanel = new Panel();
            btnCharacter = new Button();
            btnInventory = new Button();
            btnSkill = new Button();
            btnSettings = new Button();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            bottomMenuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(55, 5);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(38, 15);
            lblPlayerName.TabIndex = 0;
            lblPlayerName.Text = "label1";
            // 
            // playerHealthProgressBar
            // 
            playerHealthProgressBar.Location = new Point(0, 23);
            playerHealthProgressBar.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar.Name = "playerHealthProgressBar";
            playerHealthProgressBar.Size = new Size(146, 15);
            playerHealthProgressBar.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar.TabIndex = 6;
            // 
            // playerTimerBar
            // 
            playerTimerBar.Location = new Point(0, 42);
            playerTimerBar.Maximum = 6000;
            playerTimerBar.Name = "playerTimerBar";
            playerTimerBar.Size = new Size(146, 15);
            playerTimerBar.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblPlayerHealth);
            panel1.Controls.Add(lblPlayerName);
            panel1.Controls.Add(playerHealthProgressBar);
            panel1.Controls.Add(playerTimerBar);
            panel1.Location = new Point(144, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(146, 60);
            panel1.TabIndex = 8;
            // 
            // lblPlayerHealth
            // 
            lblPlayerHealth.AutoSize = true;
            lblPlayerHealth.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth.Location = new Point(55, 24);
            lblPlayerHealth.Name = "lblPlayerHealth";
            lblPlayerHealth.Size = new Size(38, 15);
            lblPlayerHealth.TabIndex = 10;
            lblPlayerHealth.Text = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblEnemyHealth);
            panel2.Controls.Add(enemyTimerBar);
            panel2.Controls.Add(enemyHealthProgressBar);
            panel2.Controls.Add(lblEnemyName);
            panel2.Location = new Point(515, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(146, 60);
            panel2.TabIndex = 9;
            // 
            // lblEnemyHealth
            // 
            lblEnemyHealth.AutoSize = true;
            lblEnemyHealth.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth.Location = new Point(57, 25);
            lblEnemyHealth.Name = "lblEnemyHealth";
            lblEnemyHealth.Size = new Size(38, 15);
            lblEnemyHealth.TabIndex = 11;
            lblEnemyHealth.Text = "label1";
            // 
            // enemyTimerBar
            // 
            enemyTimerBar.Location = new Point(0, 42);
            enemyTimerBar.Maximum = 6000;
            enemyTimerBar.Name = "enemyTimerBar";
            enemyTimerBar.Size = new Size(146, 15);
            enemyTimerBar.TabIndex = 10;
            // 
            // enemyHealthProgressBar
            // 
            enemyHealthProgressBar.Location = new Point(0, 23);
            enemyHealthProgressBar.Name = "enemyHealthProgressBar";
            enemyHealthProgressBar.Size = new Size(146, 15);
            enemyHealthProgressBar.TabIndex = 6;
            // 
            // lblEnemyName
            // 
            lblEnemyName.AutoSize = true;
            lblEnemyName.Location = new Point(57, 5);
            lblEnemyName.Name = "lblEnemyName";
            lblEnemyName.Size = new Size(38, 15);
            lblEnemyName.TabIndex = 1;
            lblEnemyName.Text = "label1";
            // 
            // bottomMenuPanel
            // 
            bottomMenuPanel.BorderStyle = BorderStyle.FixedSingle;
            bottomMenuPanel.Controls.Add(btnClose);
            bottomMenuPanel.Controls.Add(btnSettings);
            bottomMenuPanel.Controls.Add(btnSkill);
            bottomMenuPanel.Controls.Add(btnInventory);
            bottomMenuPanel.Controls.Add(btnCharacter);
            bottomMenuPanel.Location = new Point(2, 388);
            bottomMenuPanel.Name = "bottomMenuPanel";
            bottomMenuPanel.Size = new Size(797, 100);
            bottomMenuPanel.TabIndex = 10;
            // 
            // btnCharacter
            // 
            btnCharacter.Location = new Point(22, 17);
            btnCharacter.Name = "btnCharacter";
            btnCharacter.Size = new Size(128, 71);
            btnCharacter.TabIndex = 11;
            btnCharacter.Text = "Nhân Vật";
            btnCharacter.UseVisualStyleBackColor = true;
            btnCharacter.Click += btnCharacter_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(179, 17);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(128, 71);
            btnInventory.TabIndex = 12;
            btnInventory.Text = "Kho Đồ";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnSkill
            // 
            btnSkill.Location = new Point(333, 17);
            btnSkill.Name = "btnSkill";
            btnSkill.Size = new Size(128, 71);
            btnSkill.TabIndex = 12;
            btnSkill.Text = "Kĩ Năng";
            btnSkill.UseVisualStyleBackColor = true;
            btnSkill.Click += btnSkill_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(488, 17);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(128, 71);
            btnSettings.TabIndex = 12;
            btnSettings.Text = "Cài Đặt";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(648, 17);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 71);
            btnClose.TabIndex = 12;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 489);
            Controls.Add(bottomMenuPanel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "Text-Based Game";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            bottomMenuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblPlayerName;
        private ProgressBar playerHealthProgressBar;
        private ProgressBar playerTimerBar;
        private Panel panel1;
        private Panel panel2;
        private ProgressBar enemyHealthProgressBar;
        private ProgressBar enemyTimerBar;
        private Label lblEnemyName;
        private Label lblPlayerHealth;
        private Label lblEnemyHealth;
        private Panel bottomMenuPanel;
        private Button btnClose;
        private Button btnSettings;
        private Button btnSkill;
        private Button btnInventory;
        private Button btnCharacter;
    }
}