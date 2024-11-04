using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien.UserControls
{
    public partial class UCThongTinSach : UserControl
    {
        public UCThongTinSach()
        {
            InitializeComponent();
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            pnlAdd.BorderColor = Color.FromArgb(141,110,99);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            pnlAdd.BorderColor = Color.FromArgb(250, 243, 224);
        }

        private void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            pnlRemove.BorderColor = Color.FromArgb(141, 110, 99);
        }

        private void btnRemove_MouseLeave(object sender, EventArgs e)
        {
            pnlRemove.BorderColor = Color.FromArgb(250, 243, 224);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên sách cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên sách cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        void addControlDesktop()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinSach);
            this.pnlDesktop.Controls.Add(this.pnlDataGridView);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addControlDesktop();
            UCThemSach uc = new UCThemSach();
            addUserControl(uc);
        }
    }
}
