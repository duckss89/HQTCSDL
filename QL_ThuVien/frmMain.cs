using CustomBox.RJControls;
using QL_ThuVien.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            UCTrangChu uc = new UCTrangChu();  
            addUserControl(uc);
        }


        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Size formSize;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void CollapseMenu()
        {
            if (this.pnlMenu.Width > 200)
            {
                pnlMenu.Width = 100;
                prtBLogo.Visible = false;
                lblLogo.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in pnlMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                pnlMenu.Width = 230;
                prtBLogo.Visible = true;
                lblLogo.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in pnlMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void Open_DropdownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev) => DropdowMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }

        private void DropdowMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                    ctrl.BackColor = Color.FromArgb(250, 224, 199);
                else
                    ctrl.BackColor = Color.FromArgb(250, 245, 224);
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            UCTrangChu uc = new UCTrangChu();
            addUserControl(uc);
            lblTitle.Text = "TRANG CHỦ";
        }

        private void btnKSL_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddmSach, sender);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void tsmThongTinSach_Click(object sender, EventArgs e)
        {
            UCThongTinSach uc = new UCThongTinSach();
            addUserControl(uc);

            lblTitle.Text = "THÔNG TIN SÁCH";
        }

        private void tsmTacGia_Click(object sender, EventArgs e)
        {
            UCTacGiaTheLoai uc = new UCTacGiaTheLoai();
            addUserControl(uc);
            lblTitle.Text = "TÁC GIẢ & THỂ LOẠI";
        }

        private void tsmNhaXuatBan_Click(object sender, EventArgs e)
        {
            UCNhaXuatBan uc = new UCNhaXuatBan();
            addUserControl(uc);
            lblTitle.Text = "NHÀ XUẤT BẢN";
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            UCDocGia uc = new UCDocGia();
            addUserControl(uc);
            lblTitle.Text = "ĐỌC GIẢ";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddmNhanVien, sender);
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddmMuonTra, sender);
        }

        private void btnNhapXuat_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddmNhapXuat, sender);
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCMuonSach uc = new UCMuonSach();
            addUserControl(uc);
            lblTitle.Text = "MƯỢN SÁCH";
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCTraSach uc = new UCTraSach();
            addUserControl(uc);
            lblTitle.Text = "TRẢ SÁCH";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddmThongKe, sender);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UCNhapSach uc = new UCNhapSach();
            addUserControl(uc);
            lblTitle.Text = "NHẬP SÁCH";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UCXuatSach uc = new UCXuatSach();
            addUserControl(uc);
            lblTitle.Text = "XUẤT SÁCH";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UCNhanVien uc = new UCNhanVien();
            addUserControl(uc);
            lblTitle.Text = "DANH SÁCH NHÂN VIÊN";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UCTaiKhoan uc = new UCTaiKhoan();
            addUserControl(uc);
            lblTitle.Text = "TÀI KHOẢN NHÂN VIÊN";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            UCThongKeSach uc = new UCThongKeSach();
            addUserControl(uc);
            lblTitle.Text = "THỐNG KÊ SÁCH";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            UCThongKeDocGia uc = new UCThongKeDocGia();
            addUserControl(uc);
            lblTitle.Text = "THỐNG KÊ ĐỌC GIẢ";
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCThongKeMuonTra uc = new UCThongKeMuonTra();
            addUserControl(uc);
            lblTitle.Text = "THỐNG KÊ MƯỢN TRẢ";
        }
    }
}
