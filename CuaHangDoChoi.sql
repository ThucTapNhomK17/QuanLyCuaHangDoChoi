USE [CuaHangDoChoi]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/27/2021 10:55:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[idKhachHang] [char](10) NOT NULL,
	[ten] [varchar](50) NULL,
	[soDT] [varchar](50) NULL,
	[diaChi] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuaSanPham]    Script Date: 6/27/2021 10:55:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuaSanPham](
	[idMua] [varchar](50) NOT NULL,
	[idKhachHang] [char](10) NULL,
	[idSanPham] [char](10) NULL,
	[soLuong] [int] NULL,
	[thanhTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/27/2021 10:55:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[idNhanVien] [char](20) NOT NULL,
	[ten] [varchar](50) NULL,
	[gioiTinh] [char](10) NULL,
	[chucVu] [char](10) NULL,
	[soDT] [char](20) NULL,
	[queQuan] [char](20) NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/27/2021 10:55:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[idSanPham] [char](10) NOT NULL,
	[ten] [varchar](50) NULL,
	[giaTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH01      ', N'Hoang Le Minh', N'0934690871', N'Ha Noi')
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH02      ', N'Nguyen Thu Thuy aaaa', N'0979966308', N'Nghe An')
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH03      ', N'Le Ngoc Lan', N'0912124663', N'Ha Noi')
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH04      ', N'Vu Hoang Long', N'0823543531', N'Hai Duong')
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH05      ', N'Le Thanh Nam', N'0867234234', N'Ha Noi')
INSERT [dbo].[KhachHang] ([idKhachHang], [ten], [soDT], [diaChi]) VALUES (N'KH06      ', N'Hoang Thuy', N'0913526466', N'Ha Noi')
GO
INSERT [dbo].[MuaSanPham] ([idMua], [idKhachHang], [idSanPham], [soLuong], [thanhTien]) VALUES (N'MSP01', N'KH01      ', N'SP10      ', 2, 300000)
INSERT [dbo].[MuaSanPham] ([idMua], [idKhachHang], [idSanPham], [soLuong], [thanhTien]) VALUES (N'MSP02', N'KH06      ', N'SP01      ', 1, 300000)
INSERT [dbo].[MuaSanPham] ([idMua], [idKhachHang], [idSanPham], [soLuong], [thanhTien]) VALUES (N'MSP03', N'KH05      ', N'SP04      ', 3, 300000)
GO
INSERT [dbo].[NhanVien] ([idNhanVien], [ten], [gioiTinh], [chucVu], [soDT], [queQuan], [username], [password]) VALUES (N'NV01                ', N'Hoang The Anh', N'Nam       ', N'Quan ly   ', N'0367026057          ', N'Ha Noi              ', N'theanh', N'theanh')
INSERT [dbo].[NhanVien] ([idNhanVien], [ten], [gioiTinh], [chucVu], [soDT], [queQuan], [username], [password]) VALUES (N'NV02                ', N'Nguyen Van Thuan aaa', N'Nam       ', N'Nhan vien ', N'0123527574          ', N'Ha Noi              ', N'thuan', N'thuan')
INSERT [dbo].[NhanVien] ([idNhanVien], [ten], [gioiTinh], [chucVu], [soDT], [queQuan], [username], [password]) VALUES (N'NV03                ', N'Vo Trung Quan', N'Nam       ', N'Nhan vien ', N'0958425861          ', N'Nghe An             ', N'quan', N'quan')
INSERT [dbo].[NhanVien] ([idNhanVien], [ten], [gioiTinh], [chucVu], [soDT], [queQuan], [username], [password]) VALUES (N'NV04                ', N'Vu Van Son', N'Nam       ', N'Nhan vien ', N'0934634423          ', N'Thuong Tin          ', N'son', N'son')
INSERT [dbo].[NhanVien] ([idNhanVien], [ten], [gioiTinh], [chucVu], [soDT], [queQuan], [username], [password]) VALUES (N'NV05                ', N'Nguyen Thi Lan', N'Nu        ', N'Nhan vien ', N'0954765218          ', N'Thanh Hoa           ', N'lan', N'lan')
GO
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP01      ', N'O to dieu khien tu xa', 300000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP02      ', N'Lego truc thang', 500000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP03      ', N'Mo hinh tau chien', 1000000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP04      ', N'Lego xe canh sat', 100000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP05      ', N'Bup be barbie', 70000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP06      ', N'Gau bong', 200000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP07      ', N'Lego tau ngam', 250000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP08      ', N'Mo hinh Batmobile', 1100000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP09      ', N'Truc thang dieu khien tu xa', 600000)
INSERT [dbo].[SanPham] ([idSanPham], [ten], [giaTien]) VALUES (N'SP10      ', N'Xe canh sat do choi', 120000)
GO
ALTER TABLE [dbo].[MuaSanPham]  WITH CHECK ADD FOREIGN KEY([idKhachHang])
REFERENCES [dbo].[KhachHang] ([idKhachHang])
GO
ALTER TABLE [dbo].[MuaSanPham]  WITH CHECK ADD FOREIGN KEY([idSanPham])
REFERENCES [dbo].[SanPham] ([idSanPham])
GO
