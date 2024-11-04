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
    public partial class UCNhaXuatBan : UserControl
    {
        public UCNhaXuatBan()
        {
            InitializeComponent();
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            addControlDesktop();
            UCThemNhaXuatBan uc = new UCThemNhaXuatBan();
            addUserControl(uc);
        }

        private void txtSearch_Enter_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên nhà xuất bản cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên nhà xuất bản cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
    }
}
