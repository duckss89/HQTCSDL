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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvXuatSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTool = new Guna.UI2.WinForms.Guna2Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlAdd = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.pnlRemove = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new FontAwesome.Sharp.IconButton();
            this.pnlThongTinMuon = new System.Windows.Forms.Panel();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTongGiaBan = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lsvChiTietXuat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.btnTimViTri = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDesktop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatSach)).BeginInit();
            this.pnlTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.pnlRemove.SuspendLayout();
            this.pnlThongTinMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
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
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvXuatSach);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 107);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(593, 449);
            this.pnlDataGridView.TabIndex = 6;
            // 
            // dgvXuatSach
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvXuatSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvXuatSach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvXuatSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvXuatSach.ColumnHeadersHeight = 30;
            this.dgvXuatSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvXuatSach.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvXuatSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXuatSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvXuatSach.Location = new System.Drawing.Point(0, 0);
            this.dgvXuatSach.Name = "dgvXuatSach";
            this.dgvXuatSach.RowHeadersVisible = false;
            this.dgvXuatSach.RowHeadersWidth = 62;
            this.dgvXuatSach.Size = new System.Drawing.Size(593, 449);
            this.dgvXuatSach.TabIndex = 0;
            this.dgvXuatSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvXuatSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvXuatSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvXuatSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvXuatSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvXuatSach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvXuatSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvXuatSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvXuatSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvXuatSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvXuatSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvXuatSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvXuatSach.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvXuatSach.ThemeStyle.ReadOnly = false;
            this.dgvXuatSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvXuatSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvXuatSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvXuatSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvXuatSach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvXuatSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvXuatSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvXuatSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXuatSach_CellClick);
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
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(377, 38);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
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
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(342, 36);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TextOffset = new System.Drawing.Point(5, 0);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
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
            // pnlThongTinMuon
            // 
            this.pnlThongTinMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.pnlThongTinMuon.Controls.Add(this.lblTenNV);
            this.pnlThongTinMuon.Controls.Add(this.label9);
            this.pnlThongTinMuon.Controls.Add(this.lblTongGiaBan);
            this.pnlThongTinMuon.Controls.Add(this.label7);
            this.pnlThongTinMuon.Controls.Add(this.lblNgayXuat);
            this.pnlThongTinMuon.Controls.Add(this.label6);
            this.pnlThongTinMuon.Controls.Add(this.lsvChiTietXuat);
            this.pnlThongTinMuon.Controls.Add(this.iconPictureBox2);
            this.pnlThongTinMuon.Controls.Add(this.btnTimViTri);
            this.pnlThongTinMuon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThongTinMuon.Location = new System.Drawing.Point(593, 0);
            this.pnlThongTinMuon.Name = "pnlThongTinMuon";
            this.pnlThongTinMuon.Size = new System.Drawing.Size(327, 556);
            this.pnlThongTinMuon.TabIndex = 2;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.ForeColor = System.Drawing.Color.Black;
            this.lblTenNV.Location = new System.Drawing.Point(140, 143);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(148, 16);
            this.lblTenNV.TabIndex = 50;
            this.lblTenNV.Text = "Trần Đinh Hải Nguyên";
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
            // lblTongGiaBan
            // 
            this.lblTongGiaBan.AutoSize = true;
            this.lblTongGiaBan.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiaBan.ForeColor = System.Drawing.Color.Black;
            this.lblTongGiaBan.Location = new System.Drawing.Point(140, 224);
            this.lblTongGiaBan.Name = "lblTongGiaBan";
            this.lblTongGiaBan.Size = new System.Drawing.Size(105, 16);
            this.lblTongGiaBan.TabIndex = 48;
            this.lblTongGiaBan.Text = "1.000.000 VND";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.label7.Location = new System.Drawing.Point(26, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "Tổng giá bán :";
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.ForeColor = System.Drawing.Color.Black;
            this.lblNgayXuat.Location = new System.Drawing.Point(140, 182);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(75, 16);
            this.lblNgayXuat.TabIndex = 42;
            this.lblNgayXuat.Text = "25/9/2004";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.label6.Location = new System.Drawing.Point(42, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Ngày xuất :";
            // 
            // lsvChiTietXuat
            // 
            this.lsvChiTietXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(199)))));
            this.lsvChiTietXuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvChiTietXuat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvChiTietXuat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lsvChiTietXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvChiTietXuat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvChiTietXuat.FullRowSelect = true;
            this.lsvChiTietXuat.GridLines = true;
            this.lsvChiTietXuat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvChiTietXuat.HideSelection = false;
            this.lsvChiTietXuat.Location = new System.Drawing.Point(0, 262);
            this.lsvChiTietXuat.Name = "lsvChiTietXuat";
            this.lsvChiTietXuat.Size = new System.Drawing.Size(327, 263);
            this.lsvChiTietXuat.TabIndex = 31;
            this.lsvChiTietXuat.UseCompatibleStateImageBehavior = false;
            this.lsvChiTietXuat.View = System.Windows.Forms.View.Details;
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lý do";
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
            // UCXuatSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlDesktop);
            this.Name = "UCXuatSach";
            this.Size = new System.Drawing.Size(920, 556);
            this.pnlDesktop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatSach)).EndInit();
            this.pnlTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlRemove.ResumeLayout(false);
            this.pnlThongTinMuon.ResumeLayout(false);
            this.pnlThongTinMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDataGridView;
        private Guna.UI2.WinForms.Guna2DataGridView dgvXuatSach;
        private Guna.UI2.WinForms.Guna2Panel pnlTool;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlAdd;
        private FontAwesome.Sharp.IconButton btnAdd;
        private Guna.UI2.WinForms.Guna2Panel pnlRemove;
        private FontAwesome.Sharp.IconButton btnRemove;
        private System.Windows.Forms.Panel pnlThongTinMuon;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTongGiaBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lsvChiTietXuat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnTimViTri;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
