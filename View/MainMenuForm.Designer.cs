namespace View
{
    partial class MainMenuForm
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
            label1 = new Label();
            panel1 = new Panel();
            btnExit = new Button();
            btnSettings = new Button();
            btnLoad = new Button();
            btnStart = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Adobe Caslon Pro Bold", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(25, 48);
            label1.Name = "label1";
            label1.Size = new Size(414, 82);
            label1.TabIndex = 0;
            label1.Text = "Rectangle Rampage";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(btnStart);
            panel1.Location = new Point(75, 174);
            panel1.Name = "panel1";
            panel1.Size = new Size(313, 453);
            panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(43, 302);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(229, 62);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(43, 211);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(229, 62);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(43, 119);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(229, 62);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(43, 34);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(229, 62);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 681);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainMenuForm";
            Text = "Rectangle Rampage";
            FormClosing += MainMenu_FormClosing;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnExit;
        private Button btnSettings;
        private Button btnLoad;
        private Button btnStart;
    }
}