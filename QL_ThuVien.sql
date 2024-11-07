
--====================Tạo cơ sở dữ liệu====================
Create Database QL_ThuVien
Go

Use QL_ThuVien
Go

--====================Tạo các bảng====================

--1. Bảng đọc giả
Create Table DocGia (
	maDocGia varchar(10) Primary Key,
	hoTen Nvarchar(50) Not Null, 
	ho Nvarchar(10) Not Null,
	hoLot Nvarchar(20) Not Null,
	ten Nvarchar(10) Not Null,
	ngaySinh Date Not Null,
	gioiTinh Nvarchar(10) Check (gioiTinh In (N'Nam', N'Nữ', N'Khác')),
	diaChiChiTiet Nvarchar(255),
	tenDuong Nvarchar(100),
	phuongXa Nvarchar(100),
	quanHuyen Nvarchar(100),
	tinhThanhPho Nvarchar(100),
	soDienThoai Varchar(10) CHECK (LEN(soDienThoai) = 10),
	email Varchar(50) UNIQUE,
	ngayDangKy Date Not Null Default Getdate()
)
Go

--2. Bảng thể loại
Create Table TheLoai (
	maTheLoai varchar(10) Primary Key,
	tenTheLoai Nvarchar(50) Not Null Unique
)
Go

--3. Bảng tác giả
Create Table TacGia(
	maTacGia varchar(10) Primary Key,
	tenTacGia Nvarchar(50) Not Null,
	ngaySinh Date
)
Go

--4.Bảng nhà xuất bản
Create Table NhaXuatBan(
	maNhaXuatBan varchar(10) Primary Key,
	tenNhaXuatBan Nvarchar(50) Not Null Unique,
	diaChiChiTiet Nvarchar(255),
	tenDuong Nvarchar(100),
	phuongXa Nvarchar(100),
	quanHuyen Nvarchar(100),
	tinhThanhPho Nvarchar(100)
)
Go

--5.Bảng Sách
Create Table Sach(
	maSach varchar(10) Primary Key,
	tenSach Nvarchar(50) Not Null,
	biaSach Varchar(100),
	ISBN Varchar(20) Unique,
	namXuatBan Int Not Null,
	soLuong Int Not Null,
	giaBan Decimal(10,2) Not Null,
	maTheLoai varchar(10) Not Null,
	maTacGia varchar(10) Not Null,
	maNhaXuatBan varchar(10) Not Null,
	viTri Varchar(50) Not Null
)
Go

--6. Bảng nhân viên
Create Table NhanVien(
	maNhanVien varchar(10) Primary Key,
	hoTenNhanVien Nvarchar(50) Not Null,
	ho Nvarchar(10) Not Null,
	hoLot Nvarchar(20) Not Null,
	ten Nvarchar(10) Not Null,
	ngaySinh Date Not Null,
	gioiTinh Nvarchar(10) Check (gioiTinh In (N'Nam', N'Nữ', N'Khác')),
	soDienThoai Varchar(10) Check (Len(soDienThoai) = 10),
	email Varchar(50) Unique,
	chucVu Bit, --0 admin , 1 staff 
	ngayLamViec Date Not Null Default Getdate(),
	diaChiChiTiet Nvarchar(255),
	tenDuong Nvarchar(100),
	phuongXa Nvarchar(100),
	quanHuyen Nvarchar(100),
	tinhThanhPho Nvarchar(100)
)
Go

--7. Bảng tài khoản
Create Table TaiKhoan(
	maTaiKhoan varchar(10) Primary Key,
	tenDangNhap Varchar(50) Not Null Unique,
	matKhau Varchar(50) Not Null,
	maNhanVien varchar(10) Not Null,
	trangThai Bit Default 1, --0. Khóa, --1. Hoạt động
	ngayTao Date Not Null Default Getdate()
)
Go

--8. Bảng phiếu mượn
Create Table PhieuMuon(
	maPhieuMuon varchar(10) Primary Key,
	maDocGia varchar(10) Not Null,
	maNhanVien varchar(10) Not Null,
	ngayMuon Date Not Null Default Getdate(),
	ngayHetHan Date Not Null,
	Check (ngayHetHan >= ngayMuon)
)
Go

--9. Bảng chi tiết phiếu mượn
Create Table ChiTietPhieuMuon(
	maCtPhieuMuon varchar(10) Primary Key,
	maPhieuMuon varchar(10) Not Null,
	maSach varchar(10) Not Null,
	soLuong Int Not Null Default 0,
	tinhTrangSach Nvarchar(50) Not null Check (tinhTrangSach In (N'Mới', N'Bình thường', N'Cũ')),
    ghiChu Nvarchar(255) Null
)
Go

--10. Bảng phiếu trả
Create Table PhieuTra(
	maPhieuTra varchar(10) Primary Key,
	maPhieuMuon varchar(10) Not Null,
	maNhanVien varchar(10) Not Null, -- 
	ngayTra Date Not Null Default Getdate(),
	trangThai Nvarchar(50) Not Null Check (trangThai In (N'Đúng hạn', N'Trễ'))
)
Go

--11. Bảng chi tiết phiếu trả
Create Table ChiTietPhieuTra(
	maCtPhieuTra varchar(10) Primary Key,
	maPhieuTra varchar(10) Not Null,
	maSach varchar(10) Not Null,
	phiPhatSinh Decimal(10,2) Default 0,
	tinhTrangSach Nvarchar(100) Check (tinhTrangSach In (N'Bình thường', N'Hư hỏng', N'Mất')),
	ghiChu Nvarchar(255) null
)
Go

--12. Bảng nhập sách
Create Table NhapSach(
	maNhapSach varchar(10) Primary Key,
	maNhanVien varchar(10) Not Null,
    ngayNhap Date Not Null Default Getdate(),
    nguonNhap Nvarchar(100),
    soDienThoai Varchar(10) Check (Len(soDienThoai) = 10),
    email Varchar(50) Unique,
    diaChiChiTiet Nvarchar(255), -- Địa chỉ của nguồn nhập nếu có
    tenDuong Nvarchar(100),
    phuongXa Nvarchar(100),
    quanHuyen Nvarchar(100),
    tinhThanhPho Nvarchar(100),
    tongTien Decimal(10,2) Default 0
	--Thêm nhân viên nhập
)
Go

--13. Bảng chi tiết nhập
Create Table ChiTietNhapSach (
    maChiTietNhap varchar(10) Primary Key,
    maNhapSach varchar(10) Not Null,
    maSach varchar(10) Not Null,
    soLuongNhap Int Not Null,
    giaNhap Decimal(10,2) Not Null -- Giá nhập cho từng cuốn sách
)
Go

--14. Bảng xuất sách
Create Table XuatSach(
	maXuatSach varchar(10) Primary Key,
	maNhanVien varchar(10) Not Null,
	ngayXuat Date Not Null Default Getdate(),
	tongGiaBan Decimal(10,2) Default 0
)
Go

--15. Bảng chi tiết xuất sách
Create Table ChiTietXuatSach (
    maChiTietXuat varchar(10) Primary Key,
    maXuatSach varchar(10) Not Null,
    maSach varchar(10) Not Null,
    soLuongXuat Int Not Null Default 1,
    giaBan Decimal(10,2) Default 0,
    lyDoXuat Nvarchar(100) Check (lyDoXuat In (N'Bán', N'Mất'))
)
Go

--====================Tạo các ràng buộc cho các bảng====================

-- Bảng đọc giả
Alter Table DocGia
Add Constraint CK_DiaChi Check (
        (diaChiChiTiet Is Not Null And tenDuong Is Not Null And phuongXa Is Not Null And quanHuyen Is Not Null And tinhThanhPho Is Not Null) 
        Or (diaChiChiTiet Is Null And tenDuong Is Null And phuongXa Is Null And quanHuyen Is Null And tinhThanhPho Is Null)
)
Go


-- Bảng sách
Alter Table Sach 
Add Constraint FK_Sach_TheLoai Foreign Key (maTheLoai)  References TheLoai(maTheLoai),
	Constraint FK_Sach_TacGia Foreign Key (maTacGia)  References TacGia(maTacGia),
	Constraint FK_Sach_NhaXuatBan Foreign Key (maNhaXuatBan)  References NhaXuatBan(maNhaXuatBan)
Go


-- Bảng nhân viên
Alter Table NhanVien
Add Constraint CK_DiaChi_NhanVien Check (
        (diaChiChiTiet Is Not Null And tenDuong Is Not Null And phuongXa Is Not Null And quanHuyen Is Not Null And tinhThanhPho Is Not Null) 
        Or (diaChiChiTiet Is Null And tenDuong Is Null And phuongXa Is Null And quanHuyen Is Null And tinhThanhPho Is Null)
)
Go

-- Bảng phiếu mượn
Alter Table PhieuMuon
Add Constraint FK_PhieuMuon_DocGia Foreign Key (maDocGia)  References DocGia(maDocGia),
	Constraint FK_PhieuMuon_NhanVien Foreign Key (maNhanVien)  References NhanVien(maNhanVien)
Go

--Bảng tài khoản
Alter Table TaiKhoan
Add Constraint FK_TaiKhoan_NhanVien Foreign Key (maNhanVien) References NhanVien(maNhanVien)
Go

-- Bảng chi tiết phiếu mượn
Alter Table ChiTietPhieuMuon
Add Constraint FK_ChiTietPhieuMuon_PhieuMuon Foreign Key (maPhieuMuon) References PhieuMuon(maPhieuMuon),
	Constraint FK_ChiTietPhieuMuon_Sach Foreign Key (maSach) References Sach(maSach)
Go


-- Bảng phiếu trả
Alter Table PhieuTra
Add Constraint FK_PhieuTra_PhieuMuon Foreign Key (maPhieuMuon) References PhieuMuon(maPhieuMuon),
	Constraint FK_PhieuTra_PhieuTra Foreign Key (maNhanVien) References NhanVien(maNhanVien)
Go

-- Bảng chi tiết phiếu trả
Alter Table ChiTietPhieuTra
Add Constraint FK_ChiTietPhieuTra_PhieuTra Foreign Key (maPhieuTra) References PhieuTra(maPhieuTra),
	Constraint FK_ChiTietPhieuTra_Sach Foreign Key (maSach) References Sach(maSach)
Go

-- Bảng nhập sách
Alter Table NhapSach
Add Constraint CK_DiaChi_NhapSach Check (
        (diaChiChiTiet Is Not Null And tenDuong Is Not Null And phuongXa Is Not Null And quanHuyen Is Not Null And tinhThanhPho Is Not Null) 
        Or (diaChiChiTiet Is Null And tenDuong Is Null And phuongXa Is Null And quanHuyen Is Null And tinhThanhPho Is Null)),
	Constraint FK_NhapSach_NhanVien Foreign Key (maNhanVien)  References NhanVien(maNhanVien)
Go

-- Bảng chi tiết nhập sách
Alter Table ChiTietNhapSach
	Add Constraint FK_ChiTietNhapSach_Sach Foreign Key (maSach) References Sach(maSach),
		Constraint FK_ChiTietNhapSach_NhapSach Foreign Key (maNhapSach) References NhapSach(maNhapSach)
Go

-- Bảng xuất sách
Alter Table XuatSach
Add Constraint FK_XuatSach_NhanVien Foreign Key (maNhanVien)  References NhanVien(maNhanVien)

-- Bảng chi tiết xuất sách
Alter Table ChiTietXuatSach
Add Constraint FK_ChiTietXuatSach_Sach Foreign Key (maSach) References Sach(maSach),
	Constraint FK_ChiTietXuatSach_XuatSach Foreign Key (maXuatSach) References XuatSach(maXuatSach)
Go

--====================Thêm dữ liệu vào bảng====================

-- 1. Bảng Đọc Giả
INSERT INTO DocGia (maDocGia, hoTen, ho, hoLot, ten, ngaySinh, gioiTinh, diaChiChiTiet, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email)
VALUES  
    (N'DG001', N'Nguyễn Văn An', N'Nguyễn', N'Văn', N'An', '2001-06-15', N'Nam', N'12 Hai Bà Trưng, Phường 6, Quận 1, TPHCM', N'12 Hai Bà Trưng', N'Phường 6', N'Quận 1', N'TPHCM', '0901234561', 'anan@example.com'),
    (N'DG002', N'Phạm Thị Minh Châu', N'Phạm', N'Thị Minh', N'Châu', '2002-07-20', N'Nữ', N'34 Điện Biên Phủ, Phường 7, Quận 10, TPHCM', N'34 Điện Biên Phủ', N'Phường 7', N'Quận 10', N'TPHCM', '0931234562', 'chaub@example.com'),
    (N'DG003', N'Lý Gia Huy', N'Lý', N'Gia', N'Huy', '2003-03-25', N'Nam', N'56 Cách Mạng Tháng Tám, Phường 9, Quận 3, TPHCM', N'56 Cách Mạng Tháng Tám', N'Phường 9', N'Quận 3', N'TPHCM', '0912345673', 'huyc@example.com'),
    (N'DG004', N'Trần Minh Khôi', N'Trần', N'Minh', N'Khôi', '2002-12-14', N'Nam', N'78 Nguyễn Văn Trỗi, Phường 12, Quận Phú Nhuận, TPHCM', N'78 Nguyễn Văn Trỗi', N'Phường 12', N'Quận Phú Nhuận', N'TPHCM', '0971234564', 'khoid@example.com'),
    (N'DG005', N'Đỗ Thị Kim Liên', N'Đỗ', N'Thị Kim', N'Liên', '2004-11-11', N'Nữ', N'90 Lý Tự Trọng, Phường 1, Quận Bình Thạnh, TPHCM', N'90 Lý Tự Trọng', N'Phường 1', N'Quận Bình Thạnh', N'TPHCM', '0961234565', 'liene@example.com'),
    (N'DG006', N'Ngô Quốc Khánh', N'Ngô', N'Quốc', N'Khánh', '2000-01-05', N'Nam', N'102 Nam Kỳ Khởi Nghĩa, Phường 8, Quận 3, TPHCM', N'102 Nam Kỳ Khởi Nghĩa', N'Phường 8', N'Quận 3', N'TPHCM', '0921234566', 'khanhf@example.com'),
    (N'DG007', N'Bùi Thị Lan Hương', N'Bùi', N'Thị Lan', N'Hương', '2001-04-09', N'Nữ', N'112 Hoàng Diệu, Phường 15, Quận 4, TPHCM', N'112 Hoàng Diệu', N'Phường 15', N'Quận 4', N'TPHCM', '0931234567', 'huongg@example.com'),
    (N'DG008', N'Võ Văn Hùng', N'Võ', N'Văn', N'Hùng', '1999-08-21', N'Nam', N'123 Trần Hưng Đạo, Phường 2, Quận 5, TPHCM', N'123 Trần Hưng Đạo', N'Phường 2', N'Quận 5', N'TPHCM', '0941234568', 'hungh@example.com'),
    (N'DG009', N'Đặng Minh Tâm', N'Đặng', N'Minh', N'Tâm', '2003-09-15', N'Nữ', N'234 Phạm Ngũ Lão, Phường 10, Quận Gò Vấp, TPHCM', N'234 Phạm Ngũ Lão', N'Phường 10', N'Quận Gò Vấp', N'TPHCM', '0951234569', 'tami@example.com'),
    (N'DG010', N'Thái Gia Bảo', N'Thái', N'Gia', N'Bảo', '2002-10-02', N'Nam', N'345 Nguyễn Thị Minh Khai, Phường 13, Quận 10, TPHCM', N'345 Nguyễn Thị Minh Khai', N'Phường 13', N'Quận 10', N'TPHCM', '0912345670', 'baoj@example.com');
GO


-- 2. Bảng Thể Loại
INSERT INTO TheLoai (maTheLoai, tenTheLoai) 
VALUES 
('TL001', N'Tiểu thuyết'),
('TL002', N'Tự truyện'),
('TL003', N'Khoa học'),
('TL004', N'Tâm lý'),
('TL005', N'Lịch sử')
GO

--3. Tác giả
INSERT INTO TacGia (maTacGia, tenTacGia, ngaySinh) 
VALUES 
('TG001', N'Nguyễn Nhật Ánh', '1955-05-27'),
('TG002', N'Mark Twain', '1835-11-30'),
('TG003', N'J.K. Rowling', '1965-07-31')
GO

--4. Nhà xuất bản
INSERT INTO NhaXuatBan (maNhaXuatBan, tenNhaXuatBan, diaChiChiTiet, tenDuong, phuongXa, quanHuyen, tinhThanhPho) 
VALUES 
('NXB001', N'Nhà Xuất Bản Trẻ', N'Số 123', N'Nguyễn Huệ', N'Phường 2', N'Quận 1', N'TP.HCM'),
('NXB002', N'Nhà Xuất Bản Kim Đồng', N'Số 456', N'Đinh Tiên Hoàng', N'Phường 3', N'Quận 2', N'TP.HCM')
Go

--5. Sách
INSERT INTO Sach (maSach, tenSach, biaSach, ISBN, namXuatBan, soLuong, giaBan, maTheLoai, maTacGia, maNhaXuatBan, viTri) 
VALUES 
('S001', N'Tiểu thuyết đầu lòng', N'Bìa mềm', '978-3-16-148410-0', 2020, 10, 150000, 'TL001', 'TG001', 'NXB001', N'Kệ A1'),
('S002', N'Tự truyện của tôi', N'Bìa cứng', '978-3-16-148410-1', 2019, 5, 200000, 'TL002', 'TG002', 'NXB002', N'Kệ B1')
Go

--6. Nhân Viên
INSERT INTO NhanVien (maNhanVien, hoTenNhanVien, ho, hoLot, ten, ngaySinh, gioiTinh, diaChiChiTiet, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email, chucVu)
VALUES  
    (N'NV001', N'Nguyễn Văn An', N'Nguyễn', N'Văn', N'An', '1985-03-12', N'Nam', N'Số 3, Phan Đình Phùng, Phường 4, Quận 5, TPHCM', N'Phan Đình Phùng', N'Phường 4', N'Quận 5', N'TPHCM', '0123456788', 'nguyenvana@example.com', 0),
    (N'NV002', N'Trần Thị Bích', N'Trần', N'Thị', N'Bích', '1990-08-20', N'Nữ', N'Số 4, Nguyễn Trãi, Phường 5, Quận 6, TPHCM', N'Nguyễn Trãi', N'Phường 5', N'Quận 6', N'TPHCM', '0987654320', 'tranbich@example.com', 1),
    (N'NV003', N'Võ Minh Tâm', N'Võ', N'Minh', N'Tâm', '1987-11-30', N'Nam', N'Số 5, Tôn Đức Thắng, Phường 6, Quận 7, TPHCM', N'Tôn Đức Thắng', N'Phường 6', N'Quận 7', N'TPHCM', '0123456789', 'votam@example.com', 1),
    (N'NV004', N'Phạm Thị Hương', N'Phạm', N'Thị', N'Hương', '1995-01-15', N'Nữ', N'Số 6, Nguyễn Văn Cừ, Phường 8, Quận 10, TPHCM', N'Nguyễn Văn Cừ', N'Phường 8', N'Quận 10', N'TPHCM', '0987654321', 'phamhuong@example.com', 0),
    (N'NV005', N'Lê Quốc Bảo', N'Lê', N'Quốc', N'Bảo', '1992-05-22', N'Nam', N'Số 7, Hòa Bình, Phường 1, Quận 10, TPHCM', N'Hòa Bình', N'Phường 1', N'Quận 10', N'TPHCM', '0123456780', 'lebao@example.com', 1),
    (N'NV006', N'Nguyễn Đình Khoa', N'Nguyễn', N'Đình', N'Khoa', '1989-02-18', N'Nam', N'Số 8, Lê Văn Sỹ, Phường 13, Quận 3, TPHCM', N'Lê Văn Sỹ', N'Phường 13', N'Quận 3', N'TPHCM', '0901234562', 'khoanguyen@example.com', 0),
    (N'NV007', N'Trần Quốc Tuấn', N'Trần', N'Quốc', N'Tuấn', '1994-04-10', N'Nam', N'Số 9, Nam Kỳ Khởi Nghĩa, Phường 11, Quận 1, TPHCM', N'Nam Kỳ Khởi Nghĩa', N'Phường 11', N'Quận 1', N'TPHCM', '0931234563', 'tuant@example.com', 1),
    (N'NV008', N'Đỗ Thị Ngọc', N'Đỗ', N'Thị', N'Ngọc', '1993-09-05', N'Nữ', N'Số 10, Trường Chinh, Phường 9, Quận Tân Bình, TPHCM', N'Trường Chinh', N'Phường 9', N'Quận Tân Bình', N'TPHCM', '0941234564', 'ngocdo@example.com', 0),
    (N'NV009', N'Lý Gia Huy', N'Lý', N'Gia', N'Huy', '2000-01-05', N'Nam', N'Số 11, Hòa Hưng, Phường 12, Quận 10, TPHCM', N'Hòa Hưng', N'Phường 12', N'Quận 10', N'TPHCM', '0951234565', 'huyg@example.com', 1),
    (N'NV010', N'Bùi Thị Phương', N'Bùi', N'Thị', N'Phương', '1998-03-28', N'Nữ', N'Số 12, Nguyễn Thị Nhỏ, Phường 14, Quận 4, TPHCM', N'Nguyễn Thị Nhỏ', N'Phường 14', N'Quận 4', N'TPHCM', '0961234566', 'phuongb@example.com', 0);
GO

-- 7. Bảng Tài Khoản
INSERT INTO TaiKhoan (maTaiKhoan, tenDangNhap, matKhau, maNhanVien, trangThai)
VALUES
    ('TK001', 'nguyenvana', 'password1', 'NV001', 1),
    ('TK002', 'tranbich', 'password2', 'NV002', 1),
    ('TK003', 'vominh', 'password3', 'NV003', 1),
    ('TK004', 'phamhuong', 'password4', 'NV004', 1),
    ('TK005', 'lekhoa', 'password5', 'NV005', 1)
GO

-- 8. Bảng Phiếu Mượn
INSERT INTO PhieuMuon (maPhieuMuon, maDocGia, maNhanVien, ngayMuon, ngayHetHan) 
VALUES 
('PM001', 'DG001', 'NV001', GETDATE(), DATEADD(DAY, 30, GETDATE())),
('PM002', 'DG002', 'NV002', GETDATE(), DATEADD(DAY, 30, GETDATE()))
GO

-- 9. Bảng Chi Tiết Phiếu Mượn
INSERT INTO ChiTietPhieuMuon (maCtPhieuMuon, maPhieuMuon, maSach, soLuong, tinhTrangSach, ghiChu) 
VALUES 
('CTPM001', 'PM001', 'S001', 1, N'Mới', N''),
('CTPM002', 'PM002', 'S002', 1, N'Bình thường', N'')
GO

--10. Bảng phiếu trả
INSERT INTO PhieuTra (maPhieuTra, maPhieuMuon, maNhanVien, ngayTra, trangThai) 
VALUES 
('PT001', 'PM001', 'NV001', GETDATE(), N'Đúng hạn'),
('PT002', 'PM002', 'NV002', GETDATE(), N'Trễ')
GO

--11. Bảng chi tiết phiếu trả
INSERT INTO ChiTietPhieuTra (maCtPhieuTra, maPhieuTra, maSach, phiPhatSinh, tinhTrangSach, ghiChu) 
VALUES 
('CTPT001', 'PT001', 'S001', 0, N'Bình thường', N''),
('CTPT002', 'PT002', 'S002', 50.00, N'Hư hỏng', N'Vỡ bìa')
GO

-- 12. Bảng Nhập Sách
INSERT INTO NhapSach (maNhapSach, maNhanVien, ngayNhap, nguonNhap, soDienThoai, email, diaChiChiTiet, tenDuong, phuongXa, quanHuyen, tinhThanhPho, tongTien) 
VALUES 
('NS001', 'NV001', GETDATE(), N'Nhà sách FAHASHA', '0123456788', 'nguyenvanc@example.com', N'Số 5, Lê Văn Sĩ, Phường 6, Quận 7, TPHCM', N'Lê Văn Sĩ', N'Phường 6', N'Quận 7', N'TP.HCM', 1000000),
('NS002', 'NV002', GETDATE(), N'Nhà sách ABC', '0987654320', 'tranthid@example.com', N'Số 10, Hồ Văn Huê, Phường 7, Quận 8, TPHCM', N'Hồ Văn Huê', N'Phường 7', N'Quận 8', N'TP.HCM', 500000)
GO

-- 13. Bảng Chi Tiết Nhập Sách
INSERT INTO ChiTietNhapSach (maChiTietNhap, maNhapSach, maSach, soLuongNhap, giaNhap) 
VALUES 
('CTNS001', 'NS001', 'S001', 10, 120000),
('CTNS002', 'NS002', 'S002', 5, 180000)
GO

-- 14. Bảng Xuất Sách
INSERT INTO XuatSach (maXuatSach, maNhanVien, tongGiaBan) 
VALUES 
('XS001', 'NV001', 1000000),
('XS002', 'NV002', 500000)
GO

-- 15. Bảng Chi Tiết Xuất Sách
INSERT INTO ChiTietXuatSach (maChiTietXuat, maXuatSach, maSach, soLuongXuat, giaBan, lyDoXuat)
VALUES
    ('CTXS001', 'XS001', 'S001', 2, 90000, N'Bán'),
    ('CTXS002', 'XS001', 'S002', 1, 85000, N'Bán'),
    ('CTXS003', 'XS002', 'S002', 1, 120000, N'Mất')
GO

--======================================================================================================================================================================

--Proc lấy danh sách đọc giả
CREATE PROCEDURE sp_LayDanhSacDocGia
AS
BEGIN
    SELECT 
        maDocGia,
        hoTen,
        ho,
        hoLot,
        ten,
        CONVERT(VARCHAR(10), ngaySinh, 103) AS ngaySinh, 
        gioiTinh, 
        diaChiChiTiet, 
        tenDuong,
        phuongXa,
        quanHuyen,
        tinhThanhPho,
        soDienThoai, 
        email,
        CONVERT(VARCHAR(10), ngayDangKy, 103) AS ngayDangKy
    FROM 
        DocGia
END
GO

--Function chuẩn hóa văn bản
CREATE FUNCTION fn_ConvertToUnsign
(
    @strInput NVARCHAR(4000)
) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
    IF @strInput IS NULL 
        RETURN @strInput; 
    
    IF @strInput = '' 
        RETURN @strInput; 
    
    DECLARE @RT NVARCHAR(4000); 
    DECLARE @SIGN_CHARS NCHAR(136); 
    DECLARE @UNSIGN_CHARS NCHAR(136); 

    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế' +
                      N'ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý' +
                      N'ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾ' +
                      N'ÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + 
                      NCHAR(272) + NCHAR(208);

    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyy' +
                        N'AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII' + 
                        N'OOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD';

    DECLARE @COUNTER INT;
    DECLARE @COUNTER1 INT;
    SET @COUNTER = 1;

    WHILE (@COUNTER <= LEN(@strInput)) 
    BEGIN
        SET @COUNTER1 = 1;

        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1) 
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1, 1)) = UNICODE(SUBSTRING(@strInput, @COUNTER, 1)) 
            BEGIN
                IF @COUNTER = 1 
                    SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER + 1, LEN(@strInput) - 1);
                ELSE 
                    SET @strInput = SUBSTRING(@strInput, 1, @COUNTER - 1) + SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER + 1, LEN(@strInput) - @COUNTER);

                BREAK;
            END

            SET @COUNTER1 = @COUNTER1 + 1;
        END

        SET @COUNTER = @COUNTER + 1;
    END

    SET @strInput = REPLACE(@strInput, ' ', '-');

    RETURN @strInput;
END
GO

-- Proc tìm kiếm đọc giả theo tên gần đúng
CREATE PROCEDURE sp_TimKiemDocGiaTheoTen
    @tenDocGia NVARCHAR(50)
AS
BEGIN
    SELECT 
        maDocGia, 
        hoTen,
        ho,
        hoLot,
        ten,
		ngaySinh,
        --CONVERT(VARCHAR(10), ngaySinh, 103) AS ngaySinh, 
        gioiTinh, 
        diaChiChiTiet, 
        tenDuong,
        phuongXa,
        quanHuyen,
        tinhThanhPho,
        soDienThoai, 
        email,
		ngayDangKy
        --CONVERT(VARCHAR(10), ngayDangKy, 103) AS ngayDangKy
    FROM 
        DocGia
    WHERE 
        dbo.fn_ConvertToUnsign(hoTen) LIKE N'%' + dbo.fn_ConvertToUnsign(@tenDocGia) + '%';
END
GO

CREATE PROCEDURE sp_LayDanhSachNhapSach
AS
BEGIN
    SELECT 
        NhapSach.maNhapSach,             -- Chỉ định bảng NhapSach
        NhanVien.hoTenNhanVien,                  -- Lấy tên nhân viên từ bảng NhanVien
        CONVERT(VARCHAR(10), NhapSach.ngayNhap, 103) AS ngayNhap,  -- Chuyển đổi ngày nhập sang định dạng dd/MM/yyyy
        NhapSach.nguonNhap,              -- Chỉ định bảng NhapSach
        NhapSach.soDienThoai,            -- Chỉ định bảng NhapSach
        NhapSach.email,                  -- Chỉ định bảng NhapSach
        NhapSach.diaChiChiTiet,           -- Chỉ định bảng NhapSach
		NhapSach.tongTien
    FROM 
        NhapSach, NhanVien               -- Kết nối hai bảng NhapSach và NhanVien
    WHERE 
        NhapSach.maNhanVien = NhanVien.maNhanVien  -- Điều kiện kết nối
END
GO

drop PROCEDURE sp_LayDanhSachNhapSach