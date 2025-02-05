﻿using System;
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
    public partial class UCThemNhaXuatBan : UserControl
    {
        public UCThemNhaXuatBan()
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UCNhaXuatBan uc = new UCNhaXuatBan();
            addUserControl(uc);
        }
    }
}
