namespace View
{
    partial class ShopForm
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
            flpEquipment = new FlowLayoutPanel();
            btnRefreshShop = new Button();
            lblGoldNesessaryToRefreshShop = new Label();
            SuspendLayout();
            // 
            // flpEquipment
            // 
            flpEquipment.Location = new Point(10, 50);
            flpEquipment.Name = "flpEquipment";
            flpEquipment.Size = new Size(944, 688);
            flpEquipment.TabIndex = 2;
            // 
            // btnRefreshShop
            // 
            btnRefreshShop.Location = new Point(12, 12);
            btnRefreshShop.Name = "btnRefreshShop";
            btnRefreshShop.Size = new Size(103, 32);
            btnRefreshShop.TabIndex = 3;
            btnRefreshShop.Text = "Đổi mới";
            btnRefreshShop.UseVisualStyleBackColor = true;
            btnRefreshShop.Click += btnRefreshShop_Click;
            // 
            // lblGoldNesessaryToRefreshShop
            // 
            lblGoldNesessaryToRefreshShop.AutoSize = true;
            lblGoldNesessaryToRefreshShop.Location = new Point(121, 18);
            lblGoldNesessaryToRefreshShop.Name = "lblGoldNesessaryToRefreshShop";
            lblGoldNesessaryToRefreshShop.Size = new Size(50, 20);
            lblGoldNesessaryToRefreshShop.TabIndex = 4;
            lblGoldNesessaryToRefreshShop.Text = "label1";
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 750);
            Controls.Add(lblGoldNesessaryToRefreshShop);
            Controls.Add(btnRefreshShop);
            Controls.Add(flpEquipment);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShopForm";
            Text = "Cửa Hàng";
            Load += ShopForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flpEquipment;
        private Button btnRefreshShop;
        private Label lblGoldNesessaryToRefreshShop;
    }
}