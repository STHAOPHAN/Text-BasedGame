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
            components = new System.ComponentModel.Container();
            lblPlayerName1 = new Label();
            playerHealthProgressBar1 = new ProgressBar();
            playerTimerBar1 = new ProgressBar();
            pnlPlayer1 = new Panel();
            lblPlayerHealth1 = new Label();
            pnlEnemy1 = new Panel();
            lblEnemyHealth1 = new Label();
            enemyTimerBar1 = new ProgressBar();
            enemyHealthProgressBar1 = new ProgressBar();
            lblEnemyName1 = new Label();
            bottomMenuPanel = new Panel();
            btnDungeon = new Button();
            btnClose = new Button();
            btnSettings = new Button();
            btnSkill = new Button();
            btnInventory = new Button();
            btnCharacter = new Button();
            pnlPlayer2 = new Panel();
            lblPlayerHealth2 = new Label();
            lblPlayerName2 = new Label();
            playerHealthProgressBar2 = new ProgressBar();
            playerTimerBar2 = new ProgressBar();
            pnlPlayer3 = new Panel();
            lblPlayerHealth3 = new Label();
            lblPlayerName3 = new Label();
            playerHealthProgressBar3 = new ProgressBar();
            playerTimerBar3 = new ProgressBar();
            pnlPlayer5 = new Panel();
            lblPlayerHealth5 = new Label();
            lblPlayerName5 = new Label();
            playerHealthProgressBar5 = new ProgressBar();
            playerTimerBar5 = new ProgressBar();
            pnlPlayer4 = new Panel();
            lblPlayerHealth4 = new Label();
            lblPlayerName4 = new Label();
            playerHealthProgressBar4 = new ProgressBar();
            playerTimerBar4 = new ProgressBar();
            pnlEnemy2 = new Panel();
            lblEnemyHealth2 = new Label();
            enemyTimerBar2 = new ProgressBar();
            enemyHealthProgressBar2 = new ProgressBar();
            lblEnemyName2 = new Label();
            pnlEnemy3 = new Panel();
            lblEnemyHealth3 = new Label();
            enemyTimerBar3 = new ProgressBar();
            enemyHealthProgressBar3 = new ProgressBar();
            lblEnemyName3 = new Label();
            pnlEnemy5 = new Panel();
            lblEnemyHealth5 = new Label();
            enemyTimerBar5 = new ProgressBar();
            enemyHealthProgressBar5 = new ProgressBar();
            lblEnemyName5 = new Label();
            pnlEnemy4 = new Panel();
            lblEnemyHealth4 = new Label();
            enemyTimerBar4 = new ProgressBar();
            enemyHealthProgressBar4 = new ProgressBar();
            lblEnemyName4 = new Label();
            lblMessage = new Label();
            messageTimer = new System.Windows.Forms.Timer(components);
            lblTurnCount = new Label();
            pnlPlayer1.SuspendLayout();
            pnlEnemy1.SuspendLayout();
            bottomMenuPanel.SuspendLayout();
            pnlPlayer2.SuspendLayout();
            pnlPlayer3.SuspendLayout();
            pnlPlayer5.SuspendLayout();
            pnlPlayer4.SuspendLayout();
            pnlEnemy2.SuspendLayout();
            pnlEnemy3.SuspendLayout();
            pnlEnemy5.SuspendLayout();
            pnlEnemy4.SuspendLayout();
            SuspendLayout();
            // 
            // lblPlayerName1
            // 
            lblPlayerName1.AutoSize = true;
            lblPlayerName1.Location = new Point(29, 5);
            lblPlayerName1.Name = "lblPlayerName1";
            lblPlayerName1.Size = new Size(38, 15);
            lblPlayerName1.TabIndex = 0;
            lblPlayerName1.Text = "label1";
            // 
            // playerHealthProgressBar1
            // 
            playerHealthProgressBar1.Location = new Point(0, 23);
            playerHealthProgressBar1.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar1.Name = "playerHealthProgressBar1";
            playerHealthProgressBar1.Size = new Size(174, 15);
            playerHealthProgressBar1.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar1.TabIndex = 6;
            // 
            // playerTimerBar1
            // 
            playerTimerBar1.Location = new Point(0, 42);
            playerTimerBar1.Maximum = 6000;
            playerTimerBar1.Name = "playerTimerBar1";
            playerTimerBar1.Size = new Size(174, 15);
            playerTimerBar1.TabIndex = 7;
            // 
            // pnlPlayer1
            // 
            pnlPlayer1.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer1.Controls.Add(lblPlayerHealth1);
            pnlPlayer1.Controls.Add(lblPlayerName1);
            pnlPlayer1.Controls.Add(playerHealthProgressBar1);
            pnlPlayer1.Controls.Add(playerTimerBar1);
            pnlPlayer1.Location = new Point(541, 100);
            pnlPlayer1.Name = "pnlPlayer1";
            pnlPlayer1.Size = new Size(175, 76);
            pnlPlayer1.TabIndex = 8;
            // 
            // lblPlayerHealth1
            // 
            lblPlayerHealth1.AutoSize = true;
            lblPlayerHealth1.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth1.Location = new Point(66, 24);
            lblPlayerHealth1.Name = "lblPlayerHealth1";
            lblPlayerHealth1.Size = new Size(38, 15);
            lblPlayerHealth1.TabIndex = 10;
            lblPlayerHealth1.Text = "label1";
            // 
            // pnlEnemy1
            // 
            pnlEnemy1.BorderStyle = BorderStyle.FixedSingle;
            pnlEnemy1.Controls.Add(lblEnemyHealth1);
            pnlEnemy1.Controls.Add(enemyTimerBar1);
            pnlEnemy1.Controls.Add(enemyHealthProgressBar1);
            pnlEnemy1.Controls.Add(lblEnemyName1);
            pnlEnemy1.Location = new Point(888, 100);
            pnlEnemy1.Name = "pnlEnemy1";
            pnlEnemy1.Size = new Size(175, 76);
            pnlEnemy1.TabIndex = 9;
            // 
            // lblEnemyHealth1
            // 
            lblEnemyHealth1.AutoSize = true;
            lblEnemyHealth1.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth1.Location = new Point(67, 25);
            lblEnemyHealth1.Name = "lblEnemyHealth1";
            lblEnemyHealth1.Size = new Size(38, 15);
            lblEnemyHealth1.TabIndex = 11;
            lblEnemyHealth1.Text = "label1";
            // 
            // enemyTimerBar1
            // 
            enemyTimerBar1.Location = new Point(0, 42);
            enemyTimerBar1.Maximum = 6000;
            enemyTimerBar1.Name = "enemyTimerBar1";
            enemyTimerBar1.Size = new Size(174, 15);
            enemyTimerBar1.TabIndex = 10;
            // 
            // enemyHealthProgressBar1
            // 
            enemyHealthProgressBar1.Location = new Point(0, 23);
            enemyHealthProgressBar1.Name = "enemyHealthProgressBar1";
            enemyHealthProgressBar1.Size = new Size(174, 15);
            enemyHealthProgressBar1.TabIndex = 6;
            // 
            // lblEnemyName1
            // 
            lblEnemyName1.AutoSize = true;
            lblEnemyName1.Location = new Point(30, 5);
            lblEnemyName1.Name = "lblEnemyName1";
            lblEnemyName1.Size = new Size(38, 15);
            lblEnemyName1.TabIndex = 1;
            lblEnemyName1.Text = "label1";
            // 
            // bottomMenuPanel
            // 
            bottomMenuPanel.BorderStyle = BorderStyle.FixedSingle;
            bottomMenuPanel.Controls.Add(btnDungeon);
            bottomMenuPanel.Controls.Add(btnClose);
            bottomMenuPanel.Controls.Add(btnSettings);
            bottomMenuPanel.Controls.Add(btnSkill);
            bottomMenuPanel.Controls.Add(btnInventory);
            bottomMenuPanel.Controls.Add(btnCharacter);
            bottomMenuPanel.Location = new Point(12, 668);
            bottomMenuPanel.Name = "bottomMenuPanel";
            bottomMenuPanel.Size = new Size(1560, 181);
            bottomMenuPanel.TabIndex = 10;
            // 
            // btnDungeon
            // 
            btnDungeon.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDungeon.Location = new Point(806, 22);
            btnDungeon.Name = "btnDungeon";
            btnDungeon.Size = new Size(202, 137);
            btnDungeon.TabIndex = 13;
            btnDungeon.Text = "Phó bản";
            btnDungeon.UseVisualStyleBackColor = true;
            btnDungeon.Click += btnDungeon_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.Location = new Point(1322, 22);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(202, 137);
            btnClose.TabIndex = 12;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSettings
            // 
            btnSettings.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSettings.Location = new Point(1064, 22);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(202, 137);
            btnSettings.TabIndex = 12;
            btnSettings.Text = "Cài Đặt";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSkill
            // 
            btnSkill.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSkill.Location = new Point(549, 22);
            btnSkill.Name = "btnSkill";
            btnSkill.Size = new Size(202, 137);
            btnSkill.TabIndex = 12;
            btnSkill.Text = "Kĩ Năng";
            btnSkill.UseVisualStyleBackColor = true;
            btnSkill.Click += btnSkill_Click;
            // 
            // btnInventory
            // 
            btnInventory.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnInventory.Location = new Point(290, 22);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(202, 137);
            btnInventory.TabIndex = 12;
            btnInventory.Text = "Kho Đồ";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnCharacter
            // 
            btnCharacter.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCharacter.Location = new Point(35, 22);
            btnCharacter.Name = "btnCharacter";
            btnCharacter.Size = new Size(202, 137);
            btnCharacter.TabIndex = 11;
            btnCharacter.Text = "Nhân Vật";
            btnCharacter.UseVisualStyleBackColor = true;
            btnCharacter.Click += btnCharacter_Click;
            // 
            // pnlPlayer2
            // 
            pnlPlayer2.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer2.Controls.Add(lblPlayerHealth2);
            pnlPlayer2.Controls.Add(lblPlayerName2);
            pnlPlayer2.Controls.Add(playerHealthProgressBar2);
            pnlPlayer2.Controls.Add(playerTimerBar2);
            pnlPlayer2.Location = new Point(541, 194);
            pnlPlayer2.Name = "pnlPlayer2";
            pnlPlayer2.Size = new Size(175, 76);
            pnlPlayer2.TabIndex = 11;
            // 
            // lblPlayerHealth2
            // 
            lblPlayerHealth2.AutoSize = true;
            lblPlayerHealth2.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth2.Location = new Point(66, 24);
            lblPlayerHealth2.Name = "lblPlayerHealth2";
            lblPlayerHealth2.Size = new Size(38, 15);
            lblPlayerHealth2.TabIndex = 10;
            lblPlayerHealth2.Text = "label1";
            // 
            // lblPlayerName2
            // 
            lblPlayerName2.AutoSize = true;
            lblPlayerName2.Location = new Point(29, 5);
            lblPlayerName2.Name = "lblPlayerName2";
            lblPlayerName2.Size = new Size(38, 15);
            lblPlayerName2.TabIndex = 0;
            lblPlayerName2.Text = "label1";
            // 
            // playerHealthProgressBar2
            // 
            playerHealthProgressBar2.Location = new Point(0, 23);
            playerHealthProgressBar2.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar2.Name = "playerHealthProgressBar2";
            playerHealthProgressBar2.Size = new Size(174, 15);
            playerHealthProgressBar2.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar2.TabIndex = 6;
            // 
            // playerTimerBar2
            // 
            playerTimerBar2.Location = new Point(0, 42);
            playerTimerBar2.Maximum = 6000;
            playerTimerBar2.Name = "playerTimerBar2";
            playerTimerBar2.Size = new Size(174, 15);
            playerTimerBar2.TabIndex = 7;
            // 
            // pnlPlayer3
            // 
            pnlPlayer3.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer3.Controls.Add(lblPlayerHealth3);
            pnlPlayer3.Controls.Add(lblPlayerName3);
            pnlPlayer3.Controls.Add(playerHealthProgressBar3);
            pnlPlayer3.Controls.Add(playerTimerBar3);
            pnlPlayer3.Location = new Point(541, 294);
            pnlPlayer3.Name = "pnlPlayer3";
            pnlPlayer3.Size = new Size(175, 76);
            pnlPlayer3.TabIndex = 12;
            // 
            // lblPlayerHealth3
            // 
            lblPlayerHealth3.AutoSize = true;
            lblPlayerHealth3.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth3.Location = new Point(66, 24);
            lblPlayerHealth3.Name = "lblPlayerHealth3";
            lblPlayerHealth3.Size = new Size(38, 15);
            lblPlayerHealth3.TabIndex = 10;
            lblPlayerHealth3.Text = "label1";
            // 
            // lblPlayerName3
            // 
            lblPlayerName3.AutoSize = true;
            lblPlayerName3.Location = new Point(29, 5);
            lblPlayerName3.Name = "lblPlayerName3";
            lblPlayerName3.Size = new Size(38, 15);
            lblPlayerName3.TabIndex = 0;
            lblPlayerName3.Text = "label1";
            // 
            // playerHealthProgressBar3
            // 
            playerHealthProgressBar3.Location = new Point(0, 23);
            playerHealthProgressBar3.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar3.Name = "playerHealthProgressBar3";
            playerHealthProgressBar3.Size = new Size(174, 15);
            playerHealthProgressBar3.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar3.TabIndex = 6;
            // 
            // playerTimerBar3
            // 
            playerTimerBar3.Location = new Point(0, 42);
            playerTimerBar3.Maximum = 6000;
            playerTimerBar3.Name = "playerTimerBar3";
            playerTimerBar3.Size = new Size(174, 15);
            playerTimerBar3.TabIndex = 7;
            // 
            // pnlPlayer5
            // 
            pnlPlayer5.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer5.Controls.Add(lblPlayerHealth5);
            pnlPlayer5.Controls.Add(lblPlayerName5);
            pnlPlayer5.Controls.Add(playerHealthProgressBar5);
            pnlPlayer5.Controls.Add(playerTimerBar5);
            pnlPlayer5.Location = new Point(293, 259);
            pnlPlayer5.Name = "pnlPlayer5";
            pnlPlayer5.Size = new Size(175, 76);
            pnlPlayer5.TabIndex = 13;
            // 
            // lblPlayerHealth5
            // 
            lblPlayerHealth5.AutoSize = true;
            lblPlayerHealth5.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth5.Location = new Point(67, 25);
            lblPlayerHealth5.Name = "lblPlayerHealth5";
            lblPlayerHealth5.Size = new Size(38, 15);
            lblPlayerHealth5.TabIndex = 10;
            lblPlayerHealth5.Text = "label1";
            // 
            // lblPlayerName5
            // 
            lblPlayerName5.AutoSize = true;
            lblPlayerName5.Location = new Point(26, 6);
            lblPlayerName5.Name = "lblPlayerName5";
            lblPlayerName5.Size = new Size(38, 15);
            lblPlayerName5.TabIndex = 0;
            lblPlayerName5.Text = "label1";
            // 
            // playerHealthProgressBar5
            // 
            playerHealthProgressBar5.Location = new Point(0, 23);
            playerHealthProgressBar5.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar5.Name = "playerHealthProgressBar5";
            playerHealthProgressBar5.Size = new Size(174, 15);
            playerHealthProgressBar5.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar5.TabIndex = 6;
            // 
            // playerTimerBar5
            // 
            playerTimerBar5.Location = new Point(0, 42);
            playerTimerBar5.Maximum = 6000;
            playerTimerBar5.Name = "playerTimerBar5";
            playerTimerBar5.Size = new Size(174, 15);
            playerTimerBar5.TabIndex = 7;
            // 
            // pnlPlayer4
            // 
            pnlPlayer4.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer4.Controls.Add(lblPlayerHealth4);
            pnlPlayer4.Controls.Add(lblPlayerName4);
            pnlPlayer4.Controls.Add(playerHealthProgressBar4);
            pnlPlayer4.Controls.Add(playerTimerBar4);
            pnlPlayer4.Location = new Point(294, 159);
            pnlPlayer4.Name = "pnlPlayer4";
            pnlPlayer4.Size = new Size(175, 76);
            pnlPlayer4.TabIndex = 13;
            // 
            // lblPlayerHealth4
            // 
            lblPlayerHealth4.AutoSize = true;
            lblPlayerHealth4.BackColor = SystemColors.ActiveBorder;
            lblPlayerHealth4.Location = new Point(66, 24);
            lblPlayerHealth4.Name = "lblPlayerHealth4";
            lblPlayerHealth4.Size = new Size(38, 15);
            lblPlayerHealth4.TabIndex = 10;
            lblPlayerHealth4.Text = "label1";
            // 
            // lblPlayerName4
            // 
            lblPlayerName4.AutoSize = true;
            lblPlayerName4.Location = new Point(25, 5);
            lblPlayerName4.Name = "lblPlayerName4";
            lblPlayerName4.Size = new Size(38, 15);
            lblPlayerName4.TabIndex = 0;
            lblPlayerName4.Text = "label1";
            // 
            // playerHealthProgressBar4
            // 
            playerHealthProgressBar4.Location = new Point(0, 23);
            playerHealthProgressBar4.MarqueeAnimationSpeed = 0;
            playerHealthProgressBar4.Name = "playerHealthProgressBar4";
            playerHealthProgressBar4.Size = new Size(174, 15);
            playerHealthProgressBar4.Style = ProgressBarStyle.Continuous;
            playerHealthProgressBar4.TabIndex = 6;
            // 
            // playerTimerBar4
            // 
            playerTimerBar4.Location = new Point(0, 42);
            playerTimerBar4.Maximum = 6000;
            playerTimerBar4.Name = "playerTimerBar4";
            playerTimerBar4.Size = new Size(174, 15);
            playerTimerBar4.TabIndex = 7;
            // 
            // pnlEnemy2
            // 
            pnlEnemy2.BorderStyle = BorderStyle.FixedSingle;
            pnlEnemy2.Controls.Add(lblEnemyHealth2);
            pnlEnemy2.Controls.Add(enemyTimerBar2);
            pnlEnemy2.Controls.Add(enemyHealthProgressBar2);
            pnlEnemy2.Controls.Add(lblEnemyName2);
            pnlEnemy2.Location = new Point(889, 194);
            pnlEnemy2.Name = "pnlEnemy2";
            pnlEnemy2.Size = new Size(175, 76);
            pnlEnemy2.TabIndex = 14;
            // 
            // lblEnemyHealth2
            // 
            lblEnemyHealth2.AutoSize = true;
            lblEnemyHealth2.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth2.Location = new Point(66, 25);
            lblEnemyHealth2.Name = "lblEnemyHealth2";
            lblEnemyHealth2.Size = new Size(38, 15);
            lblEnemyHealth2.TabIndex = 11;
            lblEnemyHealth2.Text = "label1";
            // 
            // enemyTimerBar2
            // 
            enemyTimerBar2.Location = new Point(0, 42);
            enemyTimerBar2.Maximum = 6000;
            enemyTimerBar2.Name = "enemyTimerBar2";
            enemyTimerBar2.Size = new Size(174, 15);
            enemyTimerBar2.TabIndex = 10;
            // 
            // enemyHealthProgressBar2
            // 
            enemyHealthProgressBar2.Location = new Point(0, 23);
            enemyHealthProgressBar2.Name = "enemyHealthProgressBar2";
            enemyHealthProgressBar2.Size = new Size(174, 15);
            enemyHealthProgressBar2.TabIndex = 6;
            // 
            // lblEnemyName2
            // 
            lblEnemyName2.AutoSize = true;
            lblEnemyName2.Location = new Point(29, 5);
            lblEnemyName2.Name = "lblEnemyName2";
            lblEnemyName2.Size = new Size(38, 15);
            lblEnemyName2.TabIndex = 1;
            lblEnemyName2.Text = "label1";
            // 
            // pnlEnemy3
            // 
            pnlEnemy3.BorderStyle = BorderStyle.FixedSingle;
            pnlEnemy3.Controls.Add(lblEnemyHealth3);
            pnlEnemy3.Controls.Add(enemyTimerBar3);
            pnlEnemy3.Controls.Add(enemyHealthProgressBar3);
            pnlEnemy3.Controls.Add(lblEnemyName3);
            pnlEnemy3.Location = new Point(889, 294);
            pnlEnemy3.Name = "pnlEnemy3";
            pnlEnemy3.Size = new Size(175, 76);
            pnlEnemy3.TabIndex = 15;
            // 
            // lblEnemyHealth3
            // 
            lblEnemyHealth3.AutoSize = true;
            lblEnemyHealth3.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth3.Location = new Point(66, 25);
            lblEnemyHealth3.Name = "lblEnemyHealth3";
            lblEnemyHealth3.Size = new Size(38, 15);
            lblEnemyHealth3.TabIndex = 11;
            lblEnemyHealth3.Text = "label1";
            // 
            // enemyTimerBar3
            // 
            enemyTimerBar3.Location = new Point(0, 42);
            enemyTimerBar3.Maximum = 6000;
            enemyTimerBar3.Name = "enemyTimerBar3";
            enemyTimerBar3.Size = new Size(174, 15);
            enemyTimerBar3.TabIndex = 10;
            // 
            // enemyHealthProgressBar3
            // 
            enemyHealthProgressBar3.Location = new Point(0, 23);
            enemyHealthProgressBar3.Name = "enemyHealthProgressBar3";
            enemyHealthProgressBar3.Size = new Size(174, 15);
            enemyHealthProgressBar3.TabIndex = 6;
            // 
            // lblEnemyName3
            // 
            lblEnemyName3.AutoSize = true;
            lblEnemyName3.Location = new Point(29, 7);
            lblEnemyName3.Name = "lblEnemyName3";
            lblEnemyName3.Size = new Size(38, 15);
            lblEnemyName3.TabIndex = 1;
            lblEnemyName3.Text = "label1";
            // 
            // pnlEnemy5
            // 
            pnlEnemy5.BorderStyle = BorderStyle.FixedSingle;
            pnlEnemy5.Controls.Add(lblEnemyHealth5);
            pnlEnemy5.Controls.Add(enemyTimerBar5);
            pnlEnemy5.Controls.Add(enemyHealthProgressBar5);
            pnlEnemy5.Controls.Add(lblEnemyName5);
            pnlEnemy5.Location = new Point(1137, 242);
            pnlEnemy5.Name = "pnlEnemy5";
            pnlEnemy5.Size = new Size(175, 76);
            pnlEnemy5.TabIndex = 16;
            // 
            // lblEnemyHealth5
            // 
            lblEnemyHealth5.AutoSize = true;
            lblEnemyHealth5.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth5.Location = new Point(67, 25);
            lblEnemyHealth5.Name = "lblEnemyHealth5";
            lblEnemyHealth5.Size = new Size(38, 15);
            lblEnemyHealth5.TabIndex = 11;
            lblEnemyHealth5.Text = "label1";
            // 
            // enemyTimerBar5
            // 
            enemyTimerBar5.Location = new Point(0, 42);
            enemyTimerBar5.Maximum = 6000;
            enemyTimerBar5.Name = "enemyTimerBar5";
            enemyTimerBar5.Size = new Size(174, 15);
            enemyTimerBar5.TabIndex = 10;
            // 
            // enemyHealthProgressBar5
            // 
            enemyHealthProgressBar5.Location = new Point(0, 23);
            enemyHealthProgressBar5.Name = "enemyHealthProgressBar5";
            enemyHealthProgressBar5.Size = new Size(174, 15);
            enemyHealthProgressBar5.TabIndex = 6;
            // 
            // lblEnemyName5
            // 
            lblEnemyName5.AutoSize = true;
            lblEnemyName5.Location = new Point(27, 5);
            lblEnemyName5.Name = "lblEnemyName5";
            lblEnemyName5.Size = new Size(38, 15);
            lblEnemyName5.TabIndex = 1;
            lblEnemyName5.Text = "label1";
            // 
            // pnlEnemy4
            // 
            pnlEnemy4.BorderStyle = BorderStyle.FixedSingle;
            pnlEnemy4.Controls.Add(lblEnemyHealth4);
            pnlEnemy4.Controls.Add(enemyTimerBar4);
            pnlEnemy4.Controls.Add(enemyHealthProgressBar4);
            pnlEnemy4.Controls.Add(lblEnemyName4);
            pnlEnemy4.Location = new Point(1137, 142);
            pnlEnemy4.Name = "pnlEnemy4";
            pnlEnemy4.Size = new Size(175, 76);
            pnlEnemy4.TabIndex = 17;
            // 
            // lblEnemyHealth4
            // 
            lblEnemyHealth4.AutoSize = true;
            lblEnemyHealth4.BackColor = SystemColors.ActiveBorder;
            lblEnemyHealth4.Location = new Point(67, 25);
            lblEnemyHealth4.Name = "lblEnemyHealth4";
            lblEnemyHealth4.Size = new Size(38, 15);
            lblEnemyHealth4.TabIndex = 11;
            lblEnemyHealth4.Text = "label1";
            // 
            // enemyTimerBar4
            // 
            enemyTimerBar4.Location = new Point(0, 42);
            enemyTimerBar4.Maximum = 6000;
            enemyTimerBar4.Name = "enemyTimerBar4";
            enemyTimerBar4.Size = new Size(174, 15);
            enemyTimerBar4.TabIndex = 10;
            // 
            // enemyHealthProgressBar4
            // 
            enemyHealthProgressBar4.Location = new Point(0, 23);
            enemyHealthProgressBar4.Name = "enemyHealthProgressBar4";
            enemyHealthProgressBar4.Size = new Size(174, 15);
            enemyHealthProgressBar4.TabIndex = 6;
            // 
            // lblEnemyName4
            // 
            lblEnemyName4.AutoSize = true;
            lblEnemyName4.Location = new Point(27, 5);
            lblEnemyName4.Name = "lblEnemyName4";
            lblEnemyName4.Size = new Size(38, 15);
            lblEnemyName4.TabIndex = 1;
            lblEnemyName4.Text = "label1";
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = Color.Yellow;
            lblMessage.Location = new Point(562, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(122, 30);
            lblMessage.TabIndex = 18;
            lblMessage.Text = "lblMessage";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // lblTurnCount
            // 
            lblTurnCount.AutoSize = true;
            lblTurnCount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblTurnCount.Location = new Point(1458, 20);
            lblTurnCount.Name = "lblTurnCount";
            lblTurnCount.Size = new Size(76, 32);
            lblTurnCount.TabIndex = 19;
            lblTurnCount.Tag = "";
            lblTurnCount.Text = "1 / 10";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1584, 861);
            Controls.Add(lblTurnCount);
            Controls.Add(lblMessage);
            Controls.Add(pnlEnemy4);
            Controls.Add(pnlEnemy5);
            Controls.Add(pnlEnemy3);
            Controls.Add(pnlEnemy2);
            Controls.Add(pnlPlayer4);
            Controls.Add(pnlPlayer5);
            Controls.Add(pnlPlayer3);
            Controls.Add(pnlPlayer2);
            Controls.Add(bottomMenuPanel);
            Controls.Add(pnlEnemy1);
            Controls.Add(pnlPlayer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Text-Based Game";
            Load += MainForm_Load;
            pnlPlayer1.ResumeLayout(false);
            pnlPlayer1.PerformLayout();
            pnlEnemy1.ResumeLayout(false);
            pnlEnemy1.PerformLayout();
            bottomMenuPanel.ResumeLayout(false);
            pnlPlayer2.ResumeLayout(false);
            pnlPlayer2.PerformLayout();
            pnlPlayer3.ResumeLayout(false);
            pnlPlayer3.PerformLayout();
            pnlPlayer5.ResumeLayout(false);
            pnlPlayer5.PerformLayout();
            pnlPlayer4.ResumeLayout(false);
            pnlPlayer4.PerformLayout();
            pnlEnemy2.ResumeLayout(false);
            pnlEnemy2.PerformLayout();
            pnlEnemy3.ResumeLayout(false);
            pnlEnemy3.PerformLayout();
            pnlEnemy5.ResumeLayout(false);
            pnlEnemy5.PerformLayout();
            pnlEnemy4.ResumeLayout(false);
            pnlEnemy4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerName1;
        private ProgressBar playerHealthProgressBar1;
        private ProgressBar playerTimerBar1;
        private Panel pnlPlayer1;
        private Panel pnlEnemy1;
        private ProgressBar enemyHealthProgressBar1;
        private ProgressBar enemyTimerBar1;
        private Label lblEnemyName1;
        private Label lblPlayerHealth1;
        private Label lblEnemyHealth1;
        private Panel bottomMenuPanel;
        private Button btnClose;
        private Button btnSettings;
        private Button btnSkill;
        private Button btnInventory;
        private Button btnCharacter;
        private Panel pnlPlayer2;
        private Label lblPlayerHealth2;
        private Label lblPlayerName2;
        private ProgressBar playerHealthProgressBar2;
        private ProgressBar playerTimerBar2;
        private Panel pnlPlayer3;
        private Label lblPlayerHealth3;
        private Label lblPlayerName3;
        private ProgressBar playerHealthProgressBar3;
        private ProgressBar playerTimerBar3;
        private Panel pnlPlayer5;
        private Label lblPlayerHealth5;
        private Label lblPlayerName5;
        private ProgressBar playerHealthProgressBar5;
        private ProgressBar playerTimerBar5;
        private Panel pnlPlayer4;
        private Label lblPlayerHealth4;
        private Label lblPlayerName4;
        private ProgressBar playerHealthProgressBar4;
        private ProgressBar playerTimerBar4;
        private Panel pnlEnemy2;
        private Label lblEnemyHealth2;
        private ProgressBar enemyTimerBar2;
        private ProgressBar enemyHealthProgressBar2;
        private Label lblEnemyName2;
        private Panel pnlEnemy3;
        private Label lblEnemyHealth3;
        private ProgressBar enemyTimerBar3;
        private ProgressBar enemyHealthProgressBar3;
        private Label lblEnemyName3;
        private Panel pnlEnemy5;
        private Label lblEnemyHealth5;
        private ProgressBar enemyTimerBar5;
        private ProgressBar enemyHealthProgressBar5;
        private Label lblEnemyName5;
        private Panel pnlEnemy4;
        private Label lblEnemyHealth4;
        private ProgressBar enemyTimerBar4;
        private ProgressBar enemyHealthProgressBar4;
        private Label lblEnemyName4;
        private Label lblMessage;
        private System.Windows.Forms.Timer messageTimer;
        private Button btnDungeon;
        private Label lblTurnCount;
    }
}