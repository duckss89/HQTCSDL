﻿namespace QL_ThuVien.UserControls
{
    partial class UCXuatSach
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNgayLamViec = new System.Windows.Forms.Label();
            this.lsvChiTietMuon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimViTri = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemove = new FontAwesome.Sharp.IconButton();
            this.pnlRemove = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlAdd = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvNhapSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTool = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlThongTinMuon = new System.Windows.Forms.Panel();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.pnlRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapSach)).BeginInit();
            this.pnlTool.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlThongTinMuon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Controls.Add(this.panel1);
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(0, 0);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(920, 556);
            this.pnlDesktop.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(140, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "Trần Đinh Hải Nguyên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.label9.Location = new System.Drawing.Point(13, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 49;
            this.label9.Text = "Nhân viên xuất :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(140, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "1.000.000 vnđ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.label7.Location = new System.Drawing.Point(49, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "Tổng tiền :";
            // 
            // lblNgayLamViec
            // 
            this.lblNgayLamViec.AutoSize = true;
            this.lblNgayLamViec.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLamViec.ForeColor = System.Drawing.Color.Black;
            this.lblNgayLamViec.Location = new System.Drawing.Point(140, 182);
            this.lblNgayLamViec.Name = "lblNgayLamViec";
            this.lblNgayLamViec.Size = new System.Drawing.Size(75, 16);
            this.lblNgayLamViec.TabIndex = 42;
            this.lblNgayLamViec.Text = "25/9/2004";
            // 
            // lsvChiTietMuon
            // 
            this.lsvChiTietMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.lsvChiTietMuon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvChiTietMuon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvChiTietMuon.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lsvChiTietMuon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvChiTietMuon.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvChiTietMuon.FullRowSelect = true;
            this.lsvChiTietMuon.GridLines = true;
            this.lsvChiTietMuon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvChiTietMuon.HideSelection = false;
            this.lsvChiTietMuon.Location = new System.Drawing.Point(0, 262);
            this.lsvChiTietMuon.Name = "lsvChiTietMuon";
            this.lsvChiTietMuon.Size = new System.Drawing.Size(327, 263);
            this.lsvChiTietMuon.TabIndex = 31;
            this.lsvChiTietMuon.UseCompatibleStateImageBehavior = false;
            this.lsvChiTietMuon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sách";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá xuất";
            this.columnHeader3.Width = 113;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 100;
            this.iconPictureBox2.Location = new System.Drawing.Point(118, 24);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(100, 100);
            this.iconPictureBox2.TabIndex = 30;
            this.iconPictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.label6.Location = new System.Drawing.Point(42, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Ngày nhập :";
            // 
            // btnTimViTri
            // 
            this.btnTimViTri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnTimViTri.BorderThickness = 1;
            this.btnTimViTri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimViTri.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimViTri.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimViTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimViTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimViTri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTimViTri.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnTimViTri.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimViTri.ForeColor = System.Drawing.Color.White;
            this.btnTimViTri.Location = new System.Drawing.Point(0, 525);
            this.btnTimViTri.Name = "btnTimViTri";
            this.btnTimViTri.Size = new System.Drawing.Size(327, 31);
            this.btnTimViTri.TabIndex = 29;
            this.btnTimViTri.Text = "Sửa thông tin";
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnRemove.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemove.IconSize = 35;
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 60);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // pnlRemove
            // 
            this.pnlRemove.BackColor = System.Drawing.Color.Transparent;
            this.pnlRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.pnlRemove.BorderRadius = 10;
            this.pnlRemove.BorderThickness = 2;
            this.pnlRemove.Controls.Add(this.btnRemove);
            this.pnlRemove.Location = new System.Drawing.Point(519, 24);
            this.pnlRemove.Name = "pnlRemove";
            this.pnlRemove.Size = new System.Drawing.Size(60, 60);
            this.pnlRemove.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 35;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 60);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(36, 39);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "Nhập mã xuất sách cần tìm";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.txtSearch.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.txtSearch.Location = new System.Drawing.Point(27, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(401, 36);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TextOffset = new System.Drawing.Point(45, 0);
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.pnlAdd.BorderRadius = 10;
            this.pnlAdd.BorderThickness = 2;
            this.pnlAdd.Controls.Add(this.btnAdd);
            this.pnlAdd.Location = new System.Drawing.Point(446, 24);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(60, 60);
            this.pnlAdd.TabIndex = 18;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvNhapSach);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 107);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(593, 449);
            this.pnlDataGridView.TabIndex = 6;
            // 
            // dgvNhapSach
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvNhapSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhapSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvNhapSach.ColumnHeadersHeight = 4;
            this.dgvNhapSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhapSach.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvNhapSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhapSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhapSach.Location = new System.Drawing.Point(0, 0);
            this.dgvNhapSach.Name = "dgvNhapSach";
            this.dgvNhapSach.RowHeadersVisible = false;
            this.dgvNhapSach.Size = new System.Drawing.Size(593, 449);
            this.dgvNhapSach.TabIndex = 0;
            this.dgvNhapSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhapSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhapSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNhapSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNhapSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNhapSach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhapSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhapSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvNhapSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhapSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNhapSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhapSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvNhapSach.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvNhapSach.ThemeStyle.ReadOnly = false;
            this.dgvNhapSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhapSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhapSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNhapSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhapSach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvNhapSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhapSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.White;
            this.pnlTool.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.pnlTool.Controls.Add(this.iconPictureBox1);
            this.pnlTool.Controls.Add(this.txtSearch);
            this.pnlTool.Controls.Add(this.pnlAdd);
            this.pnlTool.Controls.Add(this.pnlRemove);
            this.pnlTool.CustomBorderThickness = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(593, 107);
            this.pnlTool.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlDataGridView);
            this.panel1.Controls.Add(this.pnlTool);
            this.panel1.Controls.Add(this.pnlThongTinMuon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 556);
            this.panel1.TabIndex = 1;
            // 
            // pnlThongTinMuon
            // 
            this.pnlThongTinMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.pnlThongTinMuon.Controls.Add(this.label8);
            this.pnlThongTinMuon.Controls.Add(this.label9);
            this.pnlThongTinMuon.Controls.Add(this.label5);
            this.pnlThongTinMuon.Controls.Add(this.label7);
            this.pnlThongTinMuon.Controls.Add(this.lblNgayLamViec);
            this.pnlThongTinMuon.Controls.Add(this.label6);
            this.pnlThongTinMuon.Controls.Add(this.lsvChiTietMuon);
            this.pnlThongTinMuon.Controls.Add(this.iconPictureBox2);
            this.pnlThongTinMuon.Controls.Add(this.btnTimViTri);
            this.pnlThongTinMuon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThongTinMuon.Location = new System.Drawing.Point(593, 0);
            this.pnlThongTinMuon.Name = "pnlThongTinMuon";
            this.pnlThongTinMuon.Size = new System.Drawing.Size(327, 556);
            this.pnlThongTinMuon.TabIndex = 2;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lý do";
            // 
            // UCXuatSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlDesktop);
            this.Name = "UCXuatSach";
            this.Size = new System.Drawing.Size(920, 556);
            this.pnlDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.pnlRemove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapSach)).EndInit();
            this.pnlTool.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlThongTinMuon.ResumeLayout(false);
            this.pnlThongTinMuon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDataGridView;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhapSach;
        private Guna.UI2.WinForms.Guna2Panel pnlTool;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlAdd;
        private FontAwesome.Sharp.IconButton btnAdd;
        private Guna.UI2.WinForms.Guna2Panel pnlRemove;
        private FontAwesome.Sharp.IconButton btnRemove;
        private System.Windows.Forms.Panel pnlThongTinMuon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNgayLamViec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lsvChiTietMuon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnTimViTri;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}