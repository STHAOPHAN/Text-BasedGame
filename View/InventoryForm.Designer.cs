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
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpInventory.Location = new Point(12, 50);
            tlpInventory.Name = "tlpInventory";
            tlpInventory.RowCount = 5;
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tlpInventory.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tlpInventory.Size = new Size(783, 388);
            tlpInventory.TabIndex = 0;
            tlpInventory.DragDrop += CharacterForm_DragDrop;
            tlpInventory.DragEnter += CharacterForm_DragEnter;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(808, 450);
            Controls.Add(tlpInventory);
            Name = "InventoryForm";
            Text = "Kho Đồ";
            ResumeLayout(false);
        }

        #endregion
        private ToolTip ttlItemInfo;
        private TableLayoutPanel tlpInventory;
    }
}