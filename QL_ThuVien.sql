﻿
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
	maNhanVien varchar(10) Not Null Unique,
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
    email Varchar(50),
    diaChiChiTiet Nvarchar(255),
    tenDuong Nvarchar(100),
    phuongXa Nvarchar(100),
    quanHuyen Nvarchar(100),
    tinhThanhPho Nvarchar(100),
    tongTien Decimal(10,2) Default 0
)
Go

--13. Bảng chi tiết nhập
Create Table ChiTietNhapSach (
    maChiTietNhap varchar(255) Primary Key,
    maNhapSach varchar(10) Not Null,
    maSach varchar(10) Not Null,
    soLuongNhap Int Not Null,
    giaNhap Decimal(10,2) Not Null
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
('S003', N'Tiểu thuyết', N'Bìa mềm', '978-3-16-148410-2', 2020, 10, 150000, 'TL001', 'TG001', 'NXB001', N'Kệ A1'),
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
    ('TK001', 'tk01', '1', 'NV001', 1),
    ('TK002', 'tk02', '2', 'NV002', 1)
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
INSERT INTO XuatSach (maXuatSach, maNhanVien, ngayXuat, tongGiaBan) 
VALUES 
('XS001', 'NV001', GETDATE(), 1000000),
('XS002', 'NV002', GETDATE(), 500000)
GO

-- 15. Bảng Chi Tiết Xuất Sách
INSERT INTO ChiTietXuatSach (maChiTietXuat, maXuatSach, maSach, soLuongXuat, giaBan, lyDoXuat)
VALUES
    ('CTXS001', 'XS001', 'S001', 2, 90000, N'Bán'),
    ('CTXS002', 'XS001', 'S002', 1, 85000, N'Bán'),
    ('CTXS003', 'XS002', 'S002', 1, 120000, N'Mất')
GO

--Đọc giả=============================================================================================================================================================

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

-- Thêm đọc giả
CREATE PROCEDURE sp_ThemDocGia
    @ho NVARCHAR(10),
    @hoLot NVARCHAR(20) = NULL,
    @ten NVARCHAR(10),
    @ngaySinh DATE,
    @gioiTinh NVARCHAR(10),
    @tenDuong NVARCHAR(100),
    @phuongXa NVARCHAR(100),
    @quanHuyen NVARCHAR(100),
    @tinhThanhPho NVARCHAR(100),
    @soDienThoai VARCHAR(10),
    @email VARCHAR(50)
AS
BEGIN
    DECLARE @maxID INT;

    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maDocGia, 3, LEN(maDocGia) - 2) AS INT)), 0) + 1 
    FROM DocGia;

    DECLARE @newMaDocGia VARCHAR(10);
    SET @newMaDocGia = 'DG' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

    DECLARE @hoTen NVARCHAR(50);
    SET @hoTen = @ho + ISNULL(' ' + @hoLot, '') + ' ' + @ten;

    INSERT INTO DocGia (
        [maDocGia], [hoTen], [ho], [hoLot], [ten], [ngaySinh], [gioiTinh], 
        [diaChiChiTiet], [tenDuong], [phuongXa], [quanHuyen], 
        [tinhThanhPho], [soDienThoai], [email], [ngayDangKy]
    )
    VALUES (
        @newMaDocGia, @hoTen, @ho, @hoLot, @ten,
        @ngaySinh, @gioiTinh, 
        @tenDuong + ', ' + @phuongXa + ', ' + @quanHuyen + ', ' + @tinhThanhPho, 
        @tenDuong, @phuongXa, @quanHuyen, 
        @tinhThanhPho, @soDienThoai, @email, GETDATE()
    )

    IF @@ROWCOUNT > 0 
        RETURN 1
    ELSE 
        RETURN 0;
END
GO

-- Lấy thông tin đọc giả theo mã đọc giả
CREATE PROCEDURE sp_LayThongTinDocGiaTheoMa
	@maDocGia varchar(10)
AS
BEGIN
    SELECT 
		maDocGia,
        hoTen,
        ho,
        hoLot,
        ten,
        ngaySinh, 
        gioiTinh, 
        diaChiChiTiet, 
        tenDuong,
        phuongXa,
        quanHuyen,
        tinhThanhPho,
        soDienThoai, 
        email,
        ngayDangKy
    FROM 
        DocGia
	WHERE maDocGia = @maDocGia
END
GO


--Sửa thông tin đọc giả
CREATE PROC sp_SuaThongTinDocGia
    @MaDocGia VARCHAR(10),
    @Ho Nvarchar(10),
    @HoLot Nvarchar(20) = null,
    @Ten Nvarchar(10),
    @NgaySinh Date,
    @GioiTinh Nvarchar(10),
    @TenDuong Nvarchar(100),
    @PhuongXa Nvarchar(100),
    @QuanHuyen Nvarchar(100),
    @TinhThanhPho Nvarchar(100),
    @SoDienThoai VARCHAR(10),
    @Email VARCHAR(50)
AS
BEGIN
    UPDATE DocGia
    SET
		hoTen = @ho + ISNULL(' ' + @hoLot, '') + ' ' + @ten,
        ho = @Ho,
        hoLot = @HoLot,
        ten = @Ten,
        ngaySinh = @NgaySinh,
        gioiTinh = @GioiTinh,
        diaChiChiTiet =  @tenDuong + ', ' + @phuongXa + ', ' + @quanHuyen + ', ' + @tinhThanhPho, 
        tenDuong = @TenDuong,
        phuongXa = @PhuongXa,
        quanHuyen = @QuanHuyen,
        tinhThanhPho = @TinhThanhPho,
        soDienThoai = @SoDienThoai,
        email = @Email
    WHERE MaDocGia = @MaDocGia;

    IF @@ROWCOUNT > 0
        RETURN 1;
    ELSE
        RETURN 0;
END
GO

--Nhập sách========================================================================================================

--Proc lấy danh sách nhập sách
CREATE PROCEDURE sp_LayDanhSachNhapSach
AS
BEGIN
    SELECT 
        ns.maNhapSach,
        (SELECT nv.hoTenNhanVien 
         FROM NhanVien nv 
         WHERE nv.maNhanVien = ns.maNhanVien) AS tenNhanVien,
        CONVERT(VARCHAR(10), ngayNhap, 103) AS ngayNhap,
        ns.nguonNhap,
        ns.soDienThoai,
        ns.email,
        ns.diaChiChiTiet,
        ns.tongTien
    FROM 
        NhapSach ns       
END
GO

-- Proc tìm kiếm nhập sách theo mã sách
CREATE PROCEDURE sp_TimKiemNhapSachTheoMaSach
    @maNhapSach NVARCHAR(10)
AS
BEGIN
    SELECT 
        ns.maNhapSach,
        (SELECT nv.hoTenNhanVien 
         FROM NhanVien nv 
         WHERE nv.maNhanVien = ns.maNhanVien) AS tenNhanVien,
         CONVERT(VARCHAR(10), ngayNhap, 103) AS ngayNhap,
        ns.nguonNhap,
        ns.soDienThoai,
        ns.email,
        ns.diaChiChiTiet,
        ns.tongTien
    FROM 
        NhapSach ns
    WHERE 
        dbo.fn_ConvertToUnsign(ns.maNhapSach) LIKE N'%' + dbo.fn_ConvertToUnsign(@maNhapSach) + '%';
END
GO

--Xóa thông tin trong bảng NhapSach
CREATE PROC sp_XoaNhapSachTheoMaNhapSach
    @maNhapSach VARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION;

		DELETE FROM ChiTietNhapSach
		WHERE maNhapSach = @maNhapSach;

		DELETE FROM NhapSach
		WHERE maNhapSach = @maNhapSach;

    COMMIT TRANSACTION;
END
GO

-- Thêm thông tin vào bảng NhapSach
CREATE PROCEDURE sp_ThemPhieuNhap
    @maNhanVien VARCHAR(10),
    @nguonNhap NVARCHAR(100),
    @soDienThoai VARCHAR(10),
    @email VARCHAR(50),
    @tenDuong NVARCHAR(100),
    @phuongXa NVARCHAR(100),
    @quanHuyen NVARCHAR(100),
    @tinhThanhPho NVARCHAR(100),
    @tongTien DECIMAL(10,2),
    @chiTietNhapSach NVARCHAR(255)
AS
BEGIN
    DECLARE @maxID INT;

    -- Lấy mã nhập sách mới
    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maNhapSach, 3, LEN(maNhapSach) - 2) AS INT)), 0) + 1 
    FROM NhapSach;

    DECLARE @MaNhapSach VARCHAR(10);
    SET @MaNhapSach = 'NS' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

    DECLARE @diaChiChiTiet NVARCHAR(50);
    SET @diaChiChiTiet = @tenDuong + ', ' + @phuongXa + ', ' + @quanHuyen + ', ' + @tinhThanhPho;

    SET NOCOUNT ON;

    -- Bước 1: Thêm vào bảng NhapSach
    INSERT INTO NhapSach (
        maNhapSach, maNhanVien, ngayNhap, nguonNhap, soDienThoai, email,
        diaChiChiTiet, tenDuong, phuongXa, quanHuyen, tinhThanhPho, tongTien
    )
    VALUES (
        @maNhapSach,
        @maNhanVien, GETDATE(), @nguonNhap, @soDienThoai, @email,
        @diaChiChiTiet, @tenDuong, @phuongXa, @quanHuyen, @tinhThanhPho, @tongTien
    );

    -- Bước 2: Xử lý dữ liệu chi tiết nhập sách (JSON -> bảng ChiTietNhapSach)
    DECLARE @json NVARCHAR(MAX) = @chiTietNhapSach;
    DECLARE @maSach VARCHAR(10), @soLuongNhap INT, @giaNhap DECIMAL(10,2);

    DECLARE @temp TABLE (
        maSach VARCHAR(10),
        soLuongNhap INT,
        giaNhap DECIMAL(10,2)
    );

    INSERT INTO @temp (maSach, soLuongNhap, giaNhap)
    SELECT 
        JSON_VALUE(value, '$.maSach'),
        JSON_VALUE(value, '$.soLuongNhap'),
        JSON_VALUE(value, '$.giaNhap')
    FROM OPENJSON(@json);

    -- Bước 3: Thêm chi tiết nhập sách vào bảng ChiTietNhapSach
    DECLARE cur CURSOR FOR
    SELECT maSach, soLuongNhap, giaNhap FROM @temp;

    OPEN cur;
    FETCH NEXT FROM cur INTO @maSach, @soLuongNhap, @giaNhap;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO ChiTietNhapSach (
            maChiTietNhap, maNhapSach, maSach, soLuongNhap, giaNhap
        )
        VALUES (
            NEWID(), @maNhapSach, @maSach, @soLuongNhap, @giaNhap
        );

        FETCH NEXT FROM cur INTO @maSach, @soLuongNhap, @giaNhap;
    END

    CLOSE cur;
    DEALLOCATE cur;

    IF @@ROWCOUNT > 0
        RETURN 1;
    ELSE
        RETURN 0;
END
GO

--Chi tiết nhập sách========================================================================================================

--Lấy chi tiết nhập sách theo mã nhập
CREATE PROC sp_LayChiTietNhapSachTheoMaNhapSach
@maNhapSach VARCHAR(10)
AS
BEGIN
	SELECT
		(SELECT tenSach FROM Sach WHERE Sach.maSach = ChiTietNhapSach.maSach) AS tenSach,
		soLuongNhap,
		giaNhap
	FROM ChiTietNhapSach
	WHERE maNhapSach = @maNhapSach
END
GO

--Xuất sách=======================================================================================================

--Proc lấy danh sách xuất sách
CREATE PROCEDURE sp_LayDanhSachXuatSach
AS
BEGIN
    SELECT 
        xs.maXuatSach,
        (SELECT nv.hoTenNhanVien 
         FROM NhanVien nv 
         WHERE nv.maNhanVien = xs.maNhanVien) AS hoTenNhanVien,
        CONVERT(VARCHAR(10), xs.ngayXuat, 103) AS ngayXuat,
        xs.tongGiaBan
    FROM 
        XuatSach xs
END
GO


-- Proc tìm kiếm xuất sách theo mã sách gần đúng
CREATE PROCEDURE sp_TimKiemXuatSachTheoMaXuat
    @maXuatSach VARCHAR(10)
AS
BEGIN
    SELECT 
        xs.maXuatSach, 
        (SELECT nv.hoTenNhanVien 
         FROM NhanVien nv 
         WHERE nv.maNhanVien = xs.maNhanVien) AS hoTenNhanVien,  
        CONVERT(VARCHAR(10), xs.ngayXuat, 103) AS ngayXuat, 
        xs.tongGiaBan
    FROM 
        XuatSach xs
    WHERE
        dbo.fn_ConvertToUnsign(xs.maXuatSach) LIKE N'%' + dbo.fn_ConvertToUnsign(@maXuatSach) + '%';
END
GO

-- Thêm thông tin vào bảng XuatSach
CREATE PROCEDURE sp_ThemXuatSach
    @maXuatSach VARCHAR(10),
    @maNhanVien VARCHAR(10),
    @tongGiaBan DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO XuatSach (
        maXuatSach, 
        maNhanVien, 
        ngayXuat, 
        tongGiaBan
    )
    VALUES (
        @maXuatSach, 
        @maNhanVien, 
        GETDATE(),
        @tongGiaBan
    );

    IF @@ROWCOUNT > 0
        RETURN 1;
    ELSE
        RETURN 0;
END
GO
-- Chi tiết xuất sách =======================================================================================================

--Thêm chi tiết xuất sách
CREATE PROCEDURE sp_ThemChiTietXuatSach
    @maChiTietXuat VARCHAR(10),
    @maXuatSach VARCHAR(10),
    @maSach VARCHAR(10),
    @soLuongXuat INT,
    @giaBan DECIMAL(10, 2),
    @lyDoXuat NVARCHAR(100)
AS
BEGIN
    INSERT INTO ChiTietXuatSach (
        maChiTietXuat, 
        maXuatSach, 
        maSach, 
        soLuongXuat, 
        giaBan, 
        lyDoXuat
    )
    VALUES (
        @maChiTietXuat, 
        @maXuatSach, 
        @maSach, 
        @soLuongXuat, 
        @giaBan, 
        @lyDoXuat
    );

    IF @@ROWCOUNT > 0
        RETURN 1;
    ELSE
        RETURN 0;
END
GO

--Lấy chi tiết xuất sách theo mã xuất
CREATE PROC sp_LayChiTietXuatSachTheoMaXuatSach
@maXuatSach VARCHAR(10)
AS
BEGIN
	SELECT
		(SELECT tenSach FROM Sach WHERE Sach.maSach = ChiTietXuatSach.maSach) AS tenSach,
		soLuongXuat,
		giaBan,
		lyDoXuat
	FROM ChiTietXuatSach
	WHERE maXuatSach = @maXuatSach
END
GO

--Nhân viên====================================================================================================

-- Lấy danh sách nhân viên
CREATE PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
SELECT 
	[maNhanVien],
	[hoTenNhanVien],
	CASE
	WHEN chucVu = 0 THEN 'Admin'
	ELSE 'Staff'
	END  AS  chucVu,
	CONVERT(VARCHAR(10), ngaySinh, 103) AS ngaySinh, 
	[gioiTinh],
	[soDienThoai],
	[email],
	CONVERT(VARCHAR(10), ngayLamViec, 103) AS ngayLamViec, 
	[diaChiChiTiet]
FROM NhanVien
END
GO

 --Proc tìm kiếm nhan vien  theo tên gần đúng
CREATE PROCEDURE sp_TimKiemNhanVienTheoTen
@tenNhanVien NVARCHAR(50)
AS
BEGIN
SELECT
	[maNhanVien],
	[hoTenNhanVien],
	CASE
	WHEN chucVu = 0 THEN 'Admin'
	ELSE 'Staff'
	END  AS  chucVu,
	CONVERT(VARCHAR(10), ngayLamViec, 103) AS ngayLamViec, 
	[ngaySinh],
	[gioiTinh],
	[soDienThoai],
	[email],
	[diaChiChiTiet]
FROM NhanVien
WHERE 
        dbo.fn_ConvertToUnsign(hoTenNhanVien) LIKE N'%' + dbo.fn_ConvertToUnsign(@tenNhanVien) + '%';
END
GO

--Thêm nhân viên
CREATE PROCEDURE sp_ThemNhanVien
    @ho NVARCHAR(10),
    @hoLot NVARCHAR(20) = NULL,
    @ten NVARCHAR(10),
    @ngaySinh DATE,
    @gioiTinh NVARCHAR(10),
    @tenDuong NVARCHAR(100),
    @phuongXa NVARCHAR(100),
    @quanHuyen NVARCHAR(100),
    @tinhThanhPho NVARCHAR(100),
    @soDienThoai VARCHAR(10),
    @email VARCHAR(50),
	@chucVu BIT
AS
BEGIN
    DECLARE @maxID INT;

    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maNhanVien, 3, LEN(maNhanVien) - 2) AS INT)), 0) + 1 
    FROM NhanVien;

    DECLARE @maNhanVien VARCHAR(10);
    SET @maNhanVien = 'NV' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

    DECLARE @hoTen NVARCHAR(50);
    SET @hoTen = @ho + ISNULL(' ' + @hoLot, '') + ' ' + @ten;

	DECLARE @diaChiChiTiet NVARCHAR(150);
	SET @diaChiChiTiet = @tenDuong + ', ' + @phuongXa + ', ' + @quanHuyen + ', ' + @tinhThanhPho;

    INSERT INTO NhanVien 
	(
       [maNhanVien], [hoTenNhanVien], [ho], [hoLot], [ten], [ngaySinh], [gioiTinh], [soDienThoai], [email], [chucVu], [ngayLamViec], [diaChiChiTiet], [tenDuong], [phuongXa], [quanHuyen], [tinhThanhPho]
    )
    VALUES 
	(
        @maNhanVien, @hoTen, @ho, @hoLot, @ten, @ngaySinh, @gioiTinh, @soDienThoai, @email, @chucVu, GETDATE(), @diaChiChiTiet, @tenDuong, @phuongXa, @quanHuyen, @tinhThanhPho
    )

    IF @@ROWCOUNT > 0 
        RETURN 1
    ELSE 
        RETURN 0;
END
GO

-- Lấy thông tin nhân viên theo mã nhân viên
CREATE PROCEDURE sp_LayThongTinNhanVienTheoMa
	@maNhanVien varchar(10)
AS
BEGIN
    SELECT 
		[maNhanVien], 
		[hoTenNhanVien], 
		[ho], 
		[hoLot], 
		[ten], 
		[ngaySinh], 
		[gioiTinh], 
		[soDienThoai], 
		[email], 
		[chucVu], 
		[ngayLamViec], 
		[diaChiChiTiet], 
		[tenDuong],
		[phuongXa],
		[quanHuyen], 
		[tinhThanhPho]
    FROM 
        NhanVien
	WHERE maNhanVien = @maNhanVien
END
GO

-- Sửa nhân viên
CREATE PROCEDURE sp_SuaNhanVien
	@maNhanVien VARCHAR(10),
    @ho NVARCHAR(10),
    @hoLot NVARCHAR(20) = NULL,
    @ten NVARCHAR(10),
    @ngaySinh DATE,
    @gioiTinh NVARCHAR(10),
    @tenDuong NVARCHAR(100),
    @phuongXa NVARCHAR(100),
    @quanHuyen NVARCHAR(100),
    @tinhThanhPho NVARCHAR(100),
    @soDienThoai VARCHAR(10),
    @email VARCHAR(50),
	@chucVu BIT
AS
BEGIN
	UPDATE NhanVien
    SET
		hoTenNhanVien = @ho + ISNULL(' ' + @hoLot, '') + ' ' + @ten,
        ho = @Ho,
        hoLot = @HoLot,
        ten = @Ten,
        ngaySinh = @NgaySinh,
        gioiTinh = @GioiTinh,
        diaChiChiTiet =  @tenDuong + ', ' + @phuongXa + ', ' + @quanHuyen + ', ' + @tinhThanhPho, 
        tenDuong = @TenDuong,
        phuongXa = @PhuongXa,
        quanHuyen = @QuanHuyen,
        tinhThanhPho = @TinhThanhPho,
        soDienThoai = @SoDienThoai,
        email = @Email,
		chucVu = @chucVu
    WHERE maNhanVien = @maNhanVien;

    IF @@ROWCOUNT > 0 
        RETURN 1
    ELSE 
        RETURN 0;
END
GO

--Tài khoản====================================================================================================

--Lấy danh sách tài khoản
CREATE PROCEDURE sp_LayDanhSachTaiKhoan
AS
BEGIN
SELECT
	[maTaiKhoan],
	[tenDangNhap], 
	[matKhau], 
	 (SELECT nv.hoTenNhanVien 
         FROM NhanVien nv 
         WHERE nv.maNhanVien = TaiKhoan.maNhanVien) AS hoTenNhanVien,
	CASE
	WHEN trangThai = 0 THEN N'Khóa'
	ELSE N'Hoạt động'
	END  AS  trangThai,
	CONVERT(VARCHAR(10), ngayTao, 103) AS ngayTao
FROM TaiKhoan
END
GO

--Tìm kiếm tài khoản theo tên nhân viên
CREATE PROCEDURE sp_TimKiemTaiKhoanTheoTen
    @tenNhanVien NVARCHAR(50)
AS
BEGIN
    SELECT
        [maTaiKhoan],
        [tenDangNhap], 
        [matKhau], 
        nv.hoTenNhanVien AS hoTenNhanVien,
        CASE
            WHEN trangThai = 0 THEN N'Khóa'
            ELSE N'Hoạt động'
        END AS trangThai,
        CONVERT(VARCHAR(10), ngayTao, 103) AS ngayTao
    FROM 
        TaiKhoan tk
    JOIN 
        NhanVien nv ON tk.maNhanVien = nv.maNhanVien
    WHERE 
        dbo.fn_ConvertToUnsign(nv.hoTenNhanVien) LIKE N'%' + dbo.fn_ConvertToUnsign(@tenNhanVien) + '%';
END
GO

--Hàm kiểm tra nhân viên đã có tài khoản chưa
CREATE FUNCTION fn_KiemTraTaiKhoan (@maNhanVien VARCHAR(10))
RETURNS BIT
AS
BEGIN
    DECLARE @result BIT;
    
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE maNhanVien = @maNhanVien)
        SET @result = 1;
    ELSE
        SET @result = 0;
        
    RETURN @result;
END
GO

--Thêm tài khoản
CREATE PROCEDURE sp_ThemTaiKhoan
    @tenDangNhap VARCHAR(50),
    @matKhau VARCHAR(50),
    @maNhanVien VARCHAR(10),
    @trangThai BIT = 1, 
	@ngayTao Date
AS
BEGIN
	DECLARE @maxID INT;

    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maTaiKhoan, 3, LEN(maTaiKhoan) - 2) AS INT)), 0) + 1 
    FROM TaiKhoan;

    DECLARE @maTaiKhoan VARCHAR(10);
    SET @maTaiKhoan = 'TK' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

	INSERT INTO TaiKhoan([maTaiKhoan], [tenDangNhap], [matKhau], [maNhanVien], [trangThai], [ngayTao])
	VALUES (@maTaiKhoan, @tenDangNhap, @matKhau, @maNhanVien, @trangThai, @ngayTao)
END
GO


--Lấy thông tin tài khoản bằng mã tài khoản
CREATE PROC sp_LayThongTinTaiKhoanTheoMaTaiKhoan
@maTaiKhoan VARCHAR(10)
AS
BEGIN
    SELECT 
		[maTaiKhoan], [tenDangNhap], [matKhau], [maNhanVien], [trangThai], [ngayTao]
    FROM 
        TaiKhoan
	WHERE maTaiKhoan = @maTaiKhoan
END
GO

--Sửa tài khoản
CREATE PROCEDURE sp_SuaTaiKhoan
    @maTaiKhoan VARCHAR(10),
    @tenDangNhap VARCHAR(50),
    @matKhau VARCHAR(50),
    @maNhanVien VARCHAR(10),
    @trangThai BIT
AS
BEGIN
    UPDATE TaiKhoan
    SET
        tenDangNhap = @tenDangNhap,
        matKhau = @matKhau,
        maNhanVien = @maNhanVien,
        trangThai = @trangThai
    WHERE maTaiKhoan = @maTaiKhoan;

    IF @@ROWCOUNT > 0 
        RETURN 1
    ELSE 
        RETURN 0;
END

--- proc ngày dky(tkdg)
CREATE PROCEDURE sp_ThongKeNgayDangKyMoi
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SELECT 
        ngayDangKy,
        COUNT(*) AS SoLuongDocGia
    FROM DocGia
    WHERE ngayDangKy BETWEEN @TuNgay AND @DenNgay
    GROUP BY ngayDangKy
    ORDER BY ngayDangKy;
END;
GO
 drop PROCEDURE sp_ThongKeNgayDangKyMoi
EXEC sp_ThongKeNgayDangKyMoi @TuNgay = '2024-01-01', @DenNgay = '2024-11-27';

--- proc độ tuổi (tkdg)
CREATE PROCEDURE sp_ThongKeDoTuoi
AS
BEGIN
    SELECT 
        CASE 
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) < 18 THEN N'Dưới 18 tuổi'
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) BETWEEN 18 AND 30 THEN N'Từ 18 đến 30 tuổi'
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) BETWEEN 31 AND 50 THEN N'Từ 31 đến 50 tuổi'
            ELSE N'Trên 50 tuổi'
        END AS NhomTuoi,
        COUNT(*) AS SoLuongDocGia
    FROM DocGia
    GROUP BY 
        CASE 
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) < 18 THEN N'Dưới 18 tuổi'
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) BETWEEN 18 AND 30 THEN N'Từ 18 đến 30 tuổi'
            WHEN DATEDIFF(YEAR, ngaySinh, GETDATE()) BETWEEN 31 AND 50 THEN N'Từ 31 đến 50 tuổi'
            ELSE N'Trên 50 tuổi'
        END;
END;
EXEC sp_ThongKeDoTuoi;
GO
--- proc giới tính (tkdg)
CREATE PROCEDURE sp_ThongKeGioiTinh
    @GioiTinh NVARCHAR(10) = NULL  
AS
BEGIN
    SELECT gioiTinh, COUNT(*) AS SoLuong
    FROM DocGia
    WHERE (@GioiTinh IS NULL OR gioiTinh = @GioiTinh)
    GROUP BY gioiTinh;
END;

GO
EXEC sp_ThongKeGioiTinh;
 drop proc sp_ThongKeGioiTinh;
 --- Proc tổng số sách( tkts)
 CREATE PROCEDURE sp_TongSoSach
AS
BEGIN
    SELECT COUNT(*) AS TongSoSach FROM Sach;
END;
GO
EXEC sp_TongSoSach;
-- tổng số sachs chưa đưọc mượn 
CREATE PROCEDURE sp_TongSoSachChuaDuocMuon
AS
BEGIN
    -- Lấy danh sách tên sách và số lượng sách chưa từng được mượn
    SELECT 
        tenSach AS TenSach, 
        soLuong AS SoLuong
    FROM Sach
    WHERE maSach NOT IN (
        SELECT DISTINCT maSach 
        FROM ChiTietPhieuMuon
    );
END;
GO

EXEC sp_TongSoSachChuaDuocMuon;
drop PROCEDURE sp_TongSoSachChuaDuocMuon;
---- proc thể loại 
CREATE PROCEDURE sp_ThongKeTheoTheLoai
AS
BEGIN
    SELECT 
        t.tenTheLoai,
        COUNT(s.maSach) AS SoLuongSach
    FROM Sach s
    JOIN TheLoai t ON s.maTheLoai = t.maTheLoai
    GROUP BY t.tenTheLoai
    ORDER BY SoLuongSach DESC;
END;
GO
EXEC sp_ThongKeTheoTheLoai;

-------------Sách------------------------

-------------Lấy Danh Sách--------------------

CREATE PROCEDURE sp_LayDanhSachThongTinSach
AS
BEGIN
    SELECT 
        S.[maSach], 
        S.[tenSach], 
        S.[biaSach], 
        S.[ISBN], 
        S.[namXuatBan], 
        S.[soLuong], 
        S.[giaBan], 
        TL.[tenTheLoai], 
        TG.[tenTacGia], 
        NXB.[tenNhaXuatBan], 
        S.[viTri]
    FROM 
        Sach S, TheLoai TL, TacGia TG, NhaXuatBan NXB
    WHERE 
        S.maTheLoai = TL.maTheLoai
        AND S.maTacGia = TG.maTacGia
        AND S.maNhaXuatBan = NXB.maNhaXuatBan
END
GO
EXEC sp_LayDanhSachThongTinSach;
---------------------Tìm Kiếm----------------------------

CREATE PROCEDURE sp_TimKiemThongTinSachTheoTen
    @tenSach NVARCHAR(50)
AS
BEGIN
    SELECT 
        S.[maSach],
        S.[tenSach],
        S.[biaSach],
        S.[ISBN],
        S.[namXuatBan],
        S.[soLuong],
        S.[giaBan],
        TL.[tenTheLoai],
        TG.[tenTacGia],
        NXB.[tenNhaXuatBan],
        S.[viTri]
    FROM 
        Sach S, TheLoai TL, TacGia TG, NhaXuatBan NXB
    WHERE 
        S.maTheLoai = TL.maTheLoai
        AND S.maTacGia = TG.maTacGia
        AND S.maNhaXuatBan = NXB.maNhaXuatBan
        AND dbo.fn_ConvertToUnsign(S.tenSach) LIKE N'%' + dbo.fn_ConvertToUnsign(@tenSach) + '%';
END
GO
EXEC sp_TimKiemThongTinSachTheoTen @tenSach = N'Tiểu thuyết';

CREATE PROCEDURE sp_ThemSach
    @tenSach NVARCHAR(50),
    @biaSach VARCHAR(100) = NULL,
    @ISBN VARCHAR(20),
    @namXuatBan INT,
    @soLuong INT,
    @giaBan DECIMAL(10, 2),
    @maTheLoai VARCHAR(10),
    @maTacGia VARCHAR(10),
    @maNhaXuatBan VARCHAR(10),
    @viTri VARCHAR(50)
AS
BEGIN
    DECLARE @maxID INT;

    -- Generate the next ID based on the current max ID in the Sach table
    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maSach, 3, LEN(maSach) - 2) AS INT)), 0) + 1 
    FROM Sach;

    DECLARE @maSach VARCHAR(10);
    SET @maSach = 'SA' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

    -- Insert the new book information into the Sach table
    INSERT INTO Sach (
        maSach, tenSach, biaSach, ISBN, namXuatBan, soLuong, giaBan, maTheLoai, maTacGia, maNhaXuatBan, viTri
    )
    VALUES (
        @maSach, @tenSach, @biaSach, @ISBN, @namXuatBan, @soLuong, @giaBan, @maTheLoai, @maTacGia, @maNhaXuatBan, @viTri
    );

    IF @@ROWCOUNT > 0 
        RETURN 1;
    ELSE 
        RETURN 0;
END
GO
EXEC sp_ThemSach 
    @tenSach = N'Tên sách mẫu', 
    @biaSach = 'duong_dan_bia_sach.jpg', 
    @ISBN = '1234567890123', 
    @namXuatBan = 2024, 
    @soLuong = 100, 
    @giaBan = 199.99, 
    @maTheLoai = 'TL001', 
    @maTacGia = 'TG001', 
    @maNhaXuatBan = 'NXB001', 
    @viTri = 'Kệ A1';

--=======================================================================
--Phiếu mượn
--Proc lấy danh sách phiếu mượn
CREATE PROCEDURE sp_LayDanhSachPhieuMuon
AS
BEGIN
    SELECT 
		maPhieuMuon
        maDocGia,
        maNhanVien,
        CONVERT(VARCHAR(10), ngayMuon, 103) AS ngayMuon, 
        CONVERT(VARCHAR(10), ngayHetHan, 103) AS ngayHetHan
        
    FROM 
        PhieuMuon
END
GO

select *from PhieuTra

--Proc thêm phiếu mượn mới
-- Thêm thông tin vào bảng PhieuMuon
CREATE PROCEDURE sp_ThemPhieuMuon
    @maDocGia VARCHAR(10),
    @maNhanVien VARCHAR(10),
    @ngayMuon DATE,
    @ngayHetHan DATE,
    @chiTietPhieuMuon NVARCHAR(MAX)  -- JSON containing chi tiết phiếu mượn
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy mã mượn sách mới
    DECLARE @maxID INT;
    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maPhieuMuon, 3, LEN(maPhieuMuon) - 2) AS INT)), 0) + 1 
    FROM PhieuMuon;

    DECLARE @maPhieuMuon VARCHAR(10);
    SET @maPhieuMuon = 'PM' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

     -- Bước 1: Thêm vào bảng MuonSach
    INSERT INTO PhieuMuon (
        maPhieuMuon, maDocGia, maNhanVien, ngayMuon, ngayHetHan
    )
    VALUES (
        @maPhieuMuon, @maDocGia, @maNhanVien, @ngayMuon, @ngayHetHan
    );

     -- Bước 2: Xử lý dữ liệu chi tiết mượn sách (JSON -> bảng ChiTietMuonSach)
    DECLARE @json NVARCHAR(MAX) = @chiTietPhieuMuon;

    DECLARE @temp TABLE (
        maSach VARCHAR(10),
        soLuong INT,
        tinhTrangSach NVARCHAR(50),
        ghiChu NVARCHAR(255)
    );

    INSERT INTO @temp (maSach, soLuong, tinhTrangSach, ghiChu)
    SELECT 
        JSON_VALUE(value, '$.maSach'),
        JSON_VALUE(value, '$.soLuong'),
        JSON_VALUE(value, '$.tinhTrangSach'),
        JSON_VALUE(value, '$.ghiChu')
    FROM OPENJSON(@json);

    -- Bước 3: Thêm chi tiết nhập sách vào bảng ChiTietMuonSach
    DECLARE @currentID INT = (
        SELECT COALESCE(MAX(CAST(SUBSTRING(maCtPhieuMuon, 5, LEN(maCtPhieuMuon) - 4) AS INT)), 0) 
        FROM ChiTietPhieuMuon
    );

    INSERT INTO ChiTietPhieuMuon (
        maCtPhieuMuon, maPhieuMuon, maSach, soLuong, tinhTrangSach, ghiChu
    )
    SELECT 
        'CTPM' + RIGHT('000' + CAST(ROW_NUMBER() OVER (ORDER BY maSach) + @currentID AS VARCHAR(3)), 3),
        @maPhieuMuon, 
        maSach, 
        soLuong, 
        tinhTrangSach, 
        ghiChu
    FROM @temp;
END;

drop proc dbo.sp_ThemPhieuMuon

-- Proc Tìm kiếm phiếu mượn theo tên sách hoặc mã đọc giả
CREATE PROCEDURE sp_LayDSPMTheoSachHoacDocGia
    @SearchText NVARCHAR(50),
    @SearchType NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'SELECT pm.maPhieuMuon, pm.maDocGia, nv.maNhanVien, pm.ngayMuon, pm.ngayHetHan
                FROM PhieuMuon pm
                JOIN DocGia dg ON pm.maDocGia = dg.maDocGia
                JOIN NhanVien nv ON pm.maNhanVien = nv.maNhanVien';

    IF @SearchType = 'TenSach'
    BEGIN
        SET @SQL = @SQL + '
        JOIN ChiTietPhieuMuon ctpm ON pm.maPhieuMuon = ctpm.maPhieuMuon
        JOIN Sach s ON ctpm.maSach = s.maSach
        WHERE LOWER(s.tenSach) LIKE LOWER(N''%' + @SearchText + '%'')';;
    END
    ELSE IF @SearchType = 'TenDocGia'
    BEGIN
        SET @SQL = @SQL + '
        WHERE LOWER(dg.hoTen) LIKE LOWER(N''%' + @SearchText + '%'')';
    END

    EXEC sp_executesql @SQL, N'@SearchText NVARCHAR(50)', @SearchText;
END

drop proc sp_LayDSPMTheoSachHoacDocGia

-- proc xóa phiếu mượn
CREATE PROCEDURE sp_XoaPhieuMuon
    @maPhieuMuon NVARCHAR(50)
AS
BEGIN
     -- Bắt đầu một transaction để đảm bảo tính toàn vẹn của dữ liệu
    BEGIN TRANSACTION

    BEGIN TRY
         -- Xóa từ bảng ChiTietPhieuTra, dựa vào mã Phiếu Trả (maPhieuTra) liên kết với Phiếu Mượn
        DELETE FROM ChiTietPhieuTra
        WHERE maPhieuTra = (SELECT maPhieuTra FROM PhieuTra WHERE maPhieuMuon = @maPhieuMuon);

        -- Xóa từ bảng PhieuTra với điều kiện mã Phiếu Mượn
        DELETE FROM PhieuTra
        WHERE maPhieuMuon = @maPhieuMuon;

        -- Xóa từ bảng ChiTietPhieuMuon, nơi chứa thông tin chi tiết về Phiếu Mượn
        DELETE FROM ChiTietPhieuMuon
        WHERE maPhieuMuon = @maPhieuMuon;

        -- Xóa từ bảng PhieuMuon dựa trên mã Phiếu Mượn
        DELETE FROM PhieuMuon
        WHERE maPhieuMuon = @maPhieuMuon;

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
         -- Lùi lại nếu có lỗi xảy ra
        ROLLBACK TRANSACTION
        --ném lại thông báo lỗi hoặc ghi lại log lỗi ở đây
        THROW;
    END CATCH
END

--===========================================================================
--Phiếu Trả
--Proc lấy danh sách phiếu trả
CREATE PROCEDURE sp_LayDanhSachPhieuTra
AS
BEGIN
    SELECT 
		maPhieuTra,
        maPhieuMuon,
        maNhanVien,
        CONVERT(VARCHAR(10), ngayTra, 103) AS ngayMuon,
		trangThai
    FROM 
        PhieuTra
END;

--Proc thêm phiếu trả mới
-- Thêm thông tin vào bảng PhieuTra
CREATE PROCEDURE sp_ThemPhieuTra
    @maPhieuMuon VARCHAR(10),
    @maNhanVien VARCHAR(10),
    @ngayTra DATE,
    @trangThai NVARCHAR(50),
    @chiTietPhieuTra NVARCHAR(MAX)  -- JSON containing chi tiết phiếu trả
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy mã trả sách mới
    DECLARE @maxID INT;
    SELECT @maxID = COALESCE(MAX(CAST(SUBSTRING(maPhieuTra, 3, LEN(maPhieuTra) - 2) AS INT)), 0) + 1 
    FROM PhieuTra;

    DECLARE @maPhieuTra VARCHAR(10);
    SET @maPhieuTra = 'PT' + RIGHT('000' + CAST(@maxID AS VARCHAR(3)), 3);

	-- Bước 1: Thêm vào bảng TraSach
    INSERT INTO PhieuTra (
        maPhieuTra, maPhieuMuon, maNhanVien, ngayTra, trangThai
    )
    VALUES (
        @maPhieuTra, @maPhieuMuon, @maNhanVien, @ngayTra, @trangThai
    );

    -- Bước 2: Xử lý dữ liệu chi tiết trả sách (JSON -> bảng ChiTietTraSach)
    DECLARE @json NVARCHAR(MAX) = @chiTietPhieuTra;

    DECLARE @temp TABLE (
        maSach VARCHAR(10),
        phiPhatSinh DECIMAL(10,2),
        tinhTrangSach NVARCHAR(50),
        ghiChu NVARCHAR(255)
    );

    INSERT INTO @temp (maSach, phiPhatSinh, tinhTrangSach, ghiChu)
    SELECT 
        JSON_VALUE(value, '$.maSach'),
        JSON_VALUE(value, '$.phiPhatSinh'),
        JSON_VALUE(value, '$.tinhTrangSach'),
        JSON_VALUE(value, '$.ghiChu')
    FROM OPENJSON(@json);

-- Bước 3: Thêm chi tiết nhập sách vào bảng ChiTietTraSach
    DECLARE @currentID INT = (
        SELECT COALESCE(MAX(CAST(SUBSTRING(maCtPhieuTra, 5, LEN(maCtPhieuTra) - 4) AS INT)), 0) 
        FROM ChiTietPhieuTra
    );

    INSERT INTO ChiTietPhieuTra (
        maCtPhieuTra, maPhieuTra, maSach, phiPhatSinh, tinhTrangSach, ghiChu
    )
    SELECT 
        'CTPT' + RIGHT('000' + CAST(ROW_NUMBER() OVER (ORDER BY maSach) + @currentID AS VARCHAR(3)), 3),
        @maPhieuTra, 
        maSach, 
        phiPhatSinh, 
        tinhTrangSach, 
        ghiChu
    FROM @temp;
END;

drop proc dbo.sp_ThemPhieuTra

-- Proc Tìm kiếm phiếu trả theo tên sách hoặc mã đọc giả
CREATE PROCEDURE sp_LayDSPTTheoSachHoacDocGia
    @SearchText NVARCHAR(50),
    @SearchType NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'SELECT DISTINCT(pt.maPhieuTra), pt.maPhieuMuon, dg.hoTen AS hoTenDocGia, nv.maNhanVien, pt.ngayTra, pt.trangThai
                FROM PhieuTra pt
				JOIN PhieuMuon pm ON pm.maPhieuMuon = pt.maPhieuMuon
                JOIN DocGia dg ON pm.maDocGia = dg.maDocGia
                JOIN NhanVien nv ON pt.maNhanVien = nv.maNhanVien';

    IF @SearchType = 'TenSach'
    BEGIN
        SET @SQL = @SQL + '
        JOIN ChiTietPhieuTra ctp ON pt.maPhieuTra = ctp.maPhieuTra
        JOIN Sach s ON ctp.maSach = s.maSach
        WHERE LOWER(s.tenSach) LIKE LOWER(N''%' + @SearchText + '%'')';
    END
    ELSE IF @SearchType = 'TenDocGia'
    BEGIN
        SET @SQL = @SQL + '
        WHERE LOWER(dg.hoTen) LIKE LOWER(N''%' + @SearchText + '%'')';
    END

    EXEC sp_executesql @SQL, N'@SearchText NVARCHAR(50)', @SearchText;
END

drop proc sp_LayDSPTTheoSachHoacDocGia

--proc xóa phieu tra
CREATE PROCEDURE sp_XoaPhieuTra
    @maPhieuTra NVARCHAR(50)
AS
BEGIN
    -- Bắt đầu một transaction để đảm bảo tính toàn vẹn của dữ liệu
    BEGIN TRANSACTION

    BEGIN TRY
        -- Xóa từ bảng ChiTietPhieuTra, dựa vào mã Phiếu Trả (maPhieuTra)
        DELETE FROM ChiTietPhieuTra
        WHERE maPhieuTra = @maPhieuTra;

        -- Xóa từ bảng PhieuTra với điều kiện mã Phiếu Trả
        DELETE FROM PhieuTra
        WHERE maPhieuTra = @maPhieuTra;

        -- Commit transaction nếu mọi thứ đều thành công
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        -- Lùi lại transaction nếu có lỗi xảy ra
        ROLLBACK TRANSACTION
        -- Ném lại thông báo lỗi hoặc ghi lại log lỗi ở đây
        THROW;
    END CATCH
END

drop proc sp_XoaPhieuTra



