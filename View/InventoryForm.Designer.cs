namespace View
{
    partial class InventoryForm
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
            components = new System.ComponentModel.Container();
            ttlItemInfo = new ToolTip(components);
            tlpInventory = new TableLayoutPanel();
            SuspendLayout();
            // 
            // tlpInventory
            // 
            tlpInventory.BackColor = SystemColors.Window;
            tlpInventory.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpInventory.ColumnCount = 10;
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlpInventory.Location = new Point(10, 44);
            tlpInventory.Margin = new Padding(3, 4, 3, 4);
            tlpInventory.Name = "tlpInventory";
            tlpInventory.RowCount = 5;
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tlpInventory.Size = new Size(901, 521);
            tlpInventory.TabIndex = 0;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(923, 578);
            Controls.Add(tlpInventory);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InventoryForm";
            Text = "Kho Đồ";
            ResumeLayout(false);
        }

        #endregion
        private ToolTip ttlItemInfo;
        private TableLayoutPanel tlpInventory;
    }
}