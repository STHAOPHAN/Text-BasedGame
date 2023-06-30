using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class SettingsForm : Form
    {
        private SaveForm saveForm;
        private LoadForm LoadForm;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveForm == null || saveForm.IsDisposed)
            {
                saveForm = new SaveForm();
            }

            // Hiển thị InventoryForm
            saveForm.BringToFront();
            saveForm.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (LoadForm == null || LoadForm.IsDisposed)
            {
                LoadForm = new LoadForm();
            }

            // Hiển thị InventoryForm
            LoadForm.BringToFront();
            LoadForm.Show();
        }
    }
}
