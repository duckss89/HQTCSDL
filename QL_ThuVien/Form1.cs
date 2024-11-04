using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChkViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkViewPass.Checked)
            {
                txtPass.PasswordChar = '\0';
            }    
            else
            {
                txtPass.PasswordChar = '●';
            }    
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            txtUsername.FillColor = Color.White;
            pnlUsername.BackColor = Color.White;
            pnlPass.BackColor = SystemColors.Control;
            txtPass.BackColor = SystemColors.Control;
            txtPass.FillColor = SystemColors.Control;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = SystemColors.Control;
            txtUsername.FillColor = SystemColors.Control;
            pnlUsername.BackColor = SystemColors.Control;
            pnlPass.BackColor = Color.White;
            txtPass.BackColor = Color.White;
            txtPass.FillColor = Color.White;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Size formSize;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
            this.Close();
        }
    }
}
