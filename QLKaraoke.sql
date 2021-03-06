USE [master]
GO
/****** Object:  Database [QLKaraoke]    Script Date: 15/08/2020 4:05:39 SA ******/
CREATE DATABASE [QLKaraoke]
 CONTAINMENT = NONE
 
GO
ALTER DATABASE [QLKaraoke] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKaraoke].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKaraoke] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKaraoke] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKaraoke] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKaraoke] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKaraoke] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKaraoke] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLKaraoke] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLKaraoke] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKaraoke] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKaraoke] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKaraoke] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKaraoke] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKaraoke] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKaraoke] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKaraoke] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKaraoke] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKaraoke] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKaraoke] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKaraoke] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKaraoke] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKaraoke] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKaraoke] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKaraoke] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKaraoke] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKaraoke] SET  MULTI_USER 
GO
ALTER DATABASE [QLKaraoke] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKaraoke] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKaraoke] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKaraoke] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLKaraoke]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[IDHoaDon] [int] NOT NULL,
	[IDDichVu] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC,
	[IDDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](max) NULL,
	[DonViTinh] [nvarchar](max) NULL,
	[DonGia] [float] NULL,
	[IDLoaiDichVu] [int] NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [int] NULL,
	[IDPhong] [int] NULL,
	[NgayLap] [date] NULL,
	[GioVao] [datetime] NULL,
	[GioRa] [datetime] NULL,
	[GioHat] [nvarchar](max) NULL,
	[TienGio] [float] NULL,
	[TongTien] [float] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiDV] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiDichVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManHinh]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManHinh](
	[MaManHinh] [int] IDENTITY(1,1) NOT NULL,
	[TenManHinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_ManHinh] PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[UserName] [varchar](20) NOT NULL,
	[MatKhau] [varchar](50) NULL,
	[IDNhanVien] [int] NULL,
	[TrangThai] [bit] NULL,
	[PhanQuyen] [bit] NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NguoiDungNhomNguoiDung]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDungNhomNguoiDung](
	[UserName] [varchar](20) NOT NULL,
	[IDNhomNguoiDung] [int] NOT NULL,
 CONSTRAINT [PK_NguoiDungNhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[IDNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[SDT] [char](10) NULL,
	[NgaySinh] [date] NULL,
	[Email] [varchar](max) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhomNguoiDung]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomNguoiDung](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhomNguoiDung] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaNhomNguoiDung] [int] NOT NULL,
	[MaManHinh] [int] NOT NULL,
	[CoQuyen] [bit] NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaNhomNguoiDung] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phong]    Script Date: 15/08/2020 4:05:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](max) NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [nvarchar](max) NULL,
	[GiaPhongTheoGio] [float] NULL,
	[IDLoaiPhong] [int] NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (1, N'Nước suối Aquafina', N'Chai', 10000, 1)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (2, N'Nước suối Lavie', N'Chai', 10000, 1)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (3, N'Coca', N'Lon', 12000, 2)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (4, N'Pepsi', N'Lon', 12000, 2)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (5, N'Sting', N'Lon', 12000, 2)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (6, N'Bia heiniken', N'Lon', 18000, 3)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (7, N'Tiger bạc', N'Lon', 17000, 3)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (8, N'Tiger nâu', N'Lon', 16000, 3)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (9, N'Sài Gòn special', N'Lon', 15000, 3)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (10, N'Trái cây thường', N'Đĩa', 100000, 4)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (11, N'Trái cây VIP', N'Đĩa', 150000, 4)
INSERT [dbo].[DichVu] ([ID], [TenDichVu], [DonViTinh], [DonGia], [IDLoaiDichVu]) VALUES (12, N'Khăn lạnh', N'Cái', 5000, 5)
SET IDENTITY_INSERT [dbo].[DichVu] OFF
SET IDENTITY_INSERT [dbo].[LoaiDichVu] ON 

INSERT [dbo].[LoaiDichVu] ([ID], [TenLoaiDV]) VALUES (1, N'Nước suối')
INSERT [dbo].[LoaiDichVu] ([ID], [TenLoaiDV]) VALUES (2, N'Nước ngọt')
INSERT [dbo].[LoaiDichVu] ([ID], [TenLoaiDV]) VALUES (3, N'Bia')
INSERT [dbo].[LoaiDichVu] ([ID], [TenLoaiDV]) VALUES (4, N'Trái cây')
INSERT [dbo].[LoaiDichVu] ([ID], [TenLoaiDV]) VALUES (5, N'Khác')
SET IDENTITY_INSERT [dbo].[LoaiDichVu] OFF
SET IDENTITY_INSERT [dbo].[LoaiPhong] ON 

INSERT [dbo].[LoaiPhong] ([ID], [TenLoai]) VALUES (1, N'Phòng thường')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoai]) VALUES (2, N'Phòng VIP')
SET IDENTITY_INSERT [dbo].[LoaiPhong] OFF
SET IDENTITY_INSERT [dbo].[ManHinh] ON 

INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (1, N'Quản lý')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[ManHinh] OFF
INSERT [dbo].[NguoiDung] ([UserName], [MatKhau], [IDNhanVien], [TrangThai], [PhanQuyen]) VALUES (N'huy', N'123456789', 1, 0, 1)
INSERT [dbo].[NguoiDung] ([UserName], [MatKhau], [IDNhanVien], [TrangThai], [PhanQuyen]) VALUES (N'thai', N'123', 2, 1, 1)
INSERT [dbo].[NguoiDung] ([UserName], [MatKhau], [IDNhanVien], [TrangThai], [PhanQuyen]) VALUES (N'thai1', N'123', 2, 0, 0)
INSERT [dbo].[NguoiDungNhomNguoiDung] ([UserName], [IDNhomNguoiDung]) VALUES (N'huy', 1)
INSERT [dbo].[NguoiDungNhomNguoiDung] ([UserName], [IDNhomNguoiDung]) VALUES (N'thai', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [HoTen], [DiaChi], [GioiTinh], [SDT], [NgaySinh], [Email]) VALUES (1, N'Hoàng Vĩnh Huy', N'TP HCM', N'Nam', N'0838080808', CAST(0x9A220B00 AS Date), N'huy@gmail.com')
INSERT [dbo].[NhanVien] ([ID], [HoTen], [DiaChi], [GioiTinh], [SDT], [NgaySinh], [Email]) VALUES (2, N'Trương Quốc Thái', N'An Giang', N'Nam', N'0833232323', CAST(0xC2230B00 AS Date), N'thai@gmail.com')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhomNguoiDung] ON 

INSERT [dbo].[NhomNguoiDung] ([ID], [TenNhomNguoiDung]) VALUES (1, N'Quản lý')
INSERT [dbo].[NhomNguoiDung] ([ID], [TenNhomNguoiDung]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[NhomNguoiDung] OFF
INSERT [dbo].[PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[Phong] ON 

INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (1, N'Phòng 01', 20, N'Trống', 100000, 1)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (2, N'Phòng 02', 20, N'Trống', 100000, 1)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (3, N'Phòng 03', 30, N'Trống', 150000, 1)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (4, N'Phòng 04', 30, N'Trống', 150000, 1)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (5, N'Phòng 05', 20, N'Trống', 120000, 1)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (6, N'Phòng VIP 01', 30, N'Trống', 200000, 2)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (7, N'Phòng VIP 02', 30, N'Trống', 200000, 2)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (8, N'Phòng VIP 03', 30, N'Trống', 200000, 2)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (9, N'Phòng VIP 04', 40, N'Trống', 250000, 2)
INSERT [dbo].[Phong] ([ID], [TenPhong], [SoLuong], [TrangThai], [GiaPhongTheoGio], [IDLoaiPhong]) VALUES (10, N'Phòng VIP 05', 40, N'Trống', 250000, 2)
SET IDENTITY_INSERT [dbo].[Phong] OFF
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_DichVu] FOREIGN KEY([IDDichVu])
REFERENCES [dbo].[DichVu] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_DichVu]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_LoaiDichVu] FOREIGN KEY([IDLoaiDichVu])
REFERENCES [dbo].[LoaiDichVu] ([ID])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DichVu_LoaiDichVu]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Phong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Phong]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_NhanVien]
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDungNhomNguoiDung_NguoiDung] FOREIGN KEY([UserName])
REFERENCES [dbo].[NguoiDung] ([UserName])
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_NguoiDungNhomNguoiDung_NguoiDung]
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDungNhomNguoiDung_NhomNguoiDung] FOREIGN KEY([IDNhomNguoiDung])
REFERENCES [dbo].[NhomNguoiDung] ([ID])
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_NguoiDungNhomNguoiDung_NhomNguoiDung]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_ManHinh] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_ManHinh]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NhomNguoiDung] ([ID])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_NhomNguoiDung]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([IDLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([ID])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
USE [master]
GO
ALTER DATABASE [QLKaraoke] SET  READ_WRITE 
GO
