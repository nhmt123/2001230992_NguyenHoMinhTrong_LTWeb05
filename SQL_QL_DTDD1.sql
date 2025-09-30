create database QL_DTDD1
use QL_DTDD1

create table Loai
(
	MaLoai int not null,
	TenLoai nvarchar(50),
	constraint pk_L primary key (MaLoai)
)

create table SanPham
(
	MaSP int not null,
	TenSP nvarchar(50),
	DuongDan nvarchar(50),
	Gia float,
	MoTa nvarchar(50),
	MaLoai int,
	constraint pk_SP primary key (MaSP),
	constraint fk_SP_L foreign key (MaLoai) references Loai(MaLoai)
)

create table KhachHang
(
	MaKH int not null,
	HoTen nvarchar(50),
	DienThoai decimal,
	GioiTinh nvarchar(5),
	SoThich nvarchar(50),
	Email nvarchar(50),
	MatKhau nvarchar(50),
	constraint pk_KH primary key (MaKH)
)

create table GioHang
(
	MaGH int not null,
	MaKH int,
	MaSP int,
	SoLuong int,
	Ngay Date,
	constraint pk_GH primary key (MaGH),
	constraint fk_GH_KH foreign key (MaKH) references KhachHang(MaKH),
	constraint fk_GH_SP foreign key (MaSP) references SanPham(MaSP)
)


insert into Loai values
(1, N'Nokia'),
(2, N'SamSung'),
(3, N'Motorola'),
(4, N'LG'),
(5, N'Oppo'),
(6, N'Iphone'),
(7, N'BPhone')

insert into SanPham values
(1, N'N701', N'Iphone.jpg', 2000000, N'Nâng cấp BN', 1),
(2, N'N72', N'Iphone.jpg', 2100000, N'Nâng cấp BN, 2 màu Đen, Xám', 1),
(3, N'N6030', N'Iphone.jpg', 3000000, N'Nâng cấp BN, Gấp', 1),
(4, N'N6200', N'Iphone.jpg', 3200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 1),
(5, N'GalaxyA6', N'Iphone.jpg', 5200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(6, N'GalaxyA9', N'Iphone.jpg', 5500000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(7, N'GalaxyJ5', N'Iphone.jpg', 6000000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(16, N'MotoE5', N'Iphone.jpg', 2300000, N'Unlimited Extra', 3),
(17, N'MotoG7', N'Iphone.jpg', 8000000, N'Unlimited Extra', 3),
(24, N'Iphone4S', N'Iphone.jpg', 3000000, N'Không nâng cấp', 6),
(25, N'Iphone5S', N'Iphone.jpg', 5000000, N'Không nâng cấp', 6),
(26, N'Iphone6p', N'Iphone.jpg', 10000000, N'Không nâng cấp', 6),
(27, N'Iphone7', N'Iphone.jpg', 15000000, N'Không nâng cấp', 6),
(28, N'Iphone8p', N'Iphone.jpg', 20000000, N'Không nâng cấp', 6)

drop table GioHang
drop table SanPham
drop table KhachHang
drop table Loai



