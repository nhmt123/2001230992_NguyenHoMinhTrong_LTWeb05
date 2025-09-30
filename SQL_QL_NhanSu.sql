create database QL_NhanSu
use QL_NhanSu

create table Department
(
	DeptId int not null,
	Name nvarchar(50),
	constraint pk_d primary key (DeptId)
)

create table Employee
(
	Id int not null,
	Name nvarchar(50),
	Gender nvarchar(5),
	City nvarchar(50),
	DeptId int,
	constraint pk_e primary key (Id),
	constraint fk_e_d foreign key (DeptId) references Department (DeptId)
)

insert into Department values
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo')

insert into Employee values
(1, N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', 1),
(2, N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', 1),
(3, N'Đinh Duy Minh', N'Nam', N'Thái Bình', 2),
(4, N'Ngô Thị Nguyệt', N'Nữ', N'Long An', 2),
(5, N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', 3),
(14, N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre', 3),
(15, N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM', 4),
(16, N'Le Thanh Liêm', N'Nam', N'TP.HCM', 4)

select * from Department