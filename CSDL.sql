CREATE DATABASE QLNS
USE [QLNS]
GO
/****** Object:  Table [dbo].[tb_BANGLUONG]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_BANGLUONG](
	[MaLuong] [char](10) NOT NULL,
	[LCB] [int] NULL,
	[PCChucVu] [int] NULL,
	[NgayNhap] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblBangLuongCTy] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_BOPHAN]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_BOPHAN](
	[MaBoPhan] [char](10) NOT NULL,
	[TenBoPhan] [nchar](10) NULL,
	[NgayThanhLap] [datetime] NULL,
	[GhiChu] [nchar](10) NULL,
 CONSTRAINT [PK_TblBoPhan] PRIMARY KEY CLUSTERED 
(
	[MaBoPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_CONGTY]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CONGTY](
	[MACTY] [nvarchar](50) NOT NULL,
	[TENCTY] [nvarchar](255) NULL,
 CONSTRAINT [PK_tb_CONGTY] PRIMARY KEY CLUSTERED 
(
	[MACTY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HOPDONG]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HOPDONG](
	[SOHD] [nvarchar](50) NOT NULL,
	[NGAYBATDAU] [date] NULL,
	[NGAYKETHUC] [date] NULL,
	[NGAYKY] [date] NULL,
	[NOIDUNG] [nvarchar](max) NULL,
	[LANKY] [int] NULL,
	[THOIHAN] [nvarchar](50) NULL,
	[HESOLUONG] [float] NULL,
	[MANV] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_HOPDONG] PRIMARY KEY CLUSTERED 
(
	[SOHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KYCONG]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KYCONG](
	[MAKYCONG] [int] NOT NULL,
	[THANG] [int] NULL,
	[NAM] [int] NULL,
	[NGAYTINHCONG] [datetime] NULL,
	[NGAYCONGTRONGTHANG] [float] NULL,
	[MACTY] [int] NULL,
	[KHOA] [bit] NULL,
	[TRANGTHAI] [bit] NULL,
 CONSTRAINT [PK_tb_KYCONG] PRIMARY KEY CLUSTERED 
(
	[MAKYCONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KYCONGCHITIET]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KYCONGCHITIET](
	[MAKYCONG] [int] NOT NULL,
	[MANV] [nvarchar](50) NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[MACTY] [int] NULL,
	[D1] [nvarchar](10) NULL,
	[D2] [nvarchar](10) NULL,
	[D3] [nvarchar](10) NULL,
	[D4] [nvarchar](10) NULL,
	[D5] [nvarchar](10) NULL,
	[D6] [nvarchar](10) NULL,
	[D7] [nvarchar](10) NULL,
	[D8] [nvarchar](10) NULL,
	[D9] [nvarchar](10) NULL,
	[D10] [nvarchar](10) NULL,
	[D11] [nvarchar](10) NULL,
	[D12] [nvarchar](10) NULL,
	[D13] [nvarchar](10) NULL,
	[D14] [nvarchar](10) NULL,
	[D15] [nvarchar](10) NULL,
	[D16] [nvarchar](10) NULL,
	[D17] [nvarchar](10) NULL,
	[D18] [nvarchar](10) NULL,
	[D19] [nvarchar](10) NULL,
	[D20] [nvarchar](10) NULL,
	[D21] [nvarchar](10) NULL,
	[D22] [nvarchar](10) NULL,
	[D23] [nvarchar](10) NULL,
	[D24] [nvarchar](10) NULL,
	[D25] [nvarchar](10) NULL,
	[D26] [nvarchar](10) NULL,
	[D27] [nvarchar](10) NULL,
	[D28] [nvarchar](10) NULL,
	[D29] [nvarchar](10) NULL,
	[D30] [nvarchar](10) NULL,
	[D31] [nvarchar](10) NULL,
	[NGAYCONG] [float] NULL,
	[NGAYPHEP] [float] NULL,
	[NGHIKHONGPHEP] [float] NULL,
	[CONGNGAYLE] [float] NULL,
	[CONGCHUNHAT] [float] NULL,
	[TONGNGAYCONG] [float] NULL,
	[CREATED_BY] [int] NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_BY] [int] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_KYCONGCHITIET_1] PRIMARY KEY CLUSTERED 
(
	[MAKYCONG] ASC,
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KYLUAT]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KYLUAT](
	[SOQDKL] [nvarchar](50) NOT NULL,
	[MANV] [nvarchar](50) NULL,
	[LYDO] [nvarchar](255) NULL,
	[NOIDUNG] [nvarchar](255) NULL,
	[TIENKYLUAT] [int] NULL,
	[NGAYKYLUAT] [date] NULL,
 CONSTRAINT [PK_tb_KYLUAT] PRIMARY KEY CLUSTERED 
(
	[SOQDKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KHENTHUONG]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KHENTHUONG](
	[SOQDKT] [nvarchar](50) NOT NULL,
	[MANV] [nvarchar](50) NULL,
	[LYDO] [nvarchar](255) NULL,
	[NOIDUNG] [nvarchar](255) NULL,
	[TIENKHENTHUONG] [int] NULL,
	[NGAYKHENTHUONG] [date] NULL,
 CONSTRAINT [PK_tb_KHENTHUONG] PRIMARY KEY CLUSTERED 
(
	[SOQDKT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_LUONGNV]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_LUONGNV](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
	[MaLuong] [char](10) NULL,
	[LCB] [int] NULL,
	[PCChucVu] [int] NULL,
	[Thuong] [nvarchar](50) NULL,
	[KyLuat] [nvarchar](50) NULL,
	[Thang] [char](10) NULL,
	[Nam] [char](19) NULL,
	[SoNgayCongThang] [int] NULL,
	[SoNgayNghi] [int] NULL,
	[SoGioLamThem] [int] NULL,
	[Luong] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_LUONGNV] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NGHIVIEC]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NGHIVIEC](
	[HoTen] [nvarchar](50) NULL,
	[CMTND] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblNVThoiViec] PRIMARY KEY CLUSTERED 
(
	[CMTND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NHANVIEN]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NHANVIEN](
	[MaBoPhan] [char](10) NOT NULL,
	[MaPhong] [char](10) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[MaLuong] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[TTHonNhan] [nvarchar](50) NULL,
	[CMTND] [nvarchar](50) NULL,
	[NoiCap] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[LoaiHD] [nvarchar](50) NULL,
	[ThoiGian] [nvarchar](10) NULL,
	[NgayKy] [date] NULL,
	[NgayHetHan] [date] NULL,
	[GhiChu] [nvarchar](100) NULL,
	[MACTY] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblTTNVCoBan] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PHONGBAN]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PHONGBAN](
	[MaBoPhan] [char](10) NOT NULL,
	[MaPhong] [char](10) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[NgayThanhLap] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblPhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TAIKHOAN]    Script Date: 6/23/2022 12:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TAIKHOAN](
	[TAIKHOAN] [nvarchar](50) NOT NULL,
	[MATKHAU] [nvarchar](50) NULL,
	[QUYEN] [nvarchar](50) NULL,
	[TENTHAT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbtaikhoan] PRIMARY KEY CLUSTERED 
(
	[TAIKHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_KHENTHUONG]  WITH CHECK ADD  CONSTRAINT [FK_tb_KHENTHUONG_tb_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[tb_NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[tb_KHENTHUONG] CHECK CONSTRAINT [FK_tb_KHENTHUONG_tb_NHANVIEN]
GO
ALTER TABLE [dbo].[tb_LUONGNV]  WITH CHECK ADD  CONSTRAINT [FK_TblCongKhoiDieuHanh_TblBangLuongCTy] FOREIGN KEY([MaLuong])
REFERENCES [dbo].[tb_BANGLUONG] ([MaLuong])
GO
ALTER TABLE [dbo].[tb_LUONGNV] CHECK CONSTRAINT [FK_TblCongKhoiDieuHanh_TblBangLuongCTy]
GO
ALTER TABLE [dbo].[tb_NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_tb_NHANVIEN_tb_CONGTY] FOREIGN KEY([MACTY])
REFERENCES [dbo].[tb_CONGTY] ([MACTY])
GO
ALTER TABLE [dbo].[tb_NHANVIEN] CHECK CONSTRAINT [FK_tb_NHANVIEN_tb_CONGTY]
GO
ALTER TABLE [dbo].[tb_NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_TblTTNVCoBan_TblPhongBan] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[tb_PHONGBAN] ([MaPhong])
GO
ALTER TABLE [dbo].[tb_NHANVIEN] CHECK CONSTRAINT [FK_TblTTNVCoBan_TblPhongBan]
GO
ALTER TABLE [dbo].[tb_PHONGBAN]  WITH CHECK ADD  CONSTRAINT [FK_TblPhongBan_TblBoPhan] FOREIGN KEY([MaBoPhan])
REFERENCES [dbo].[tb_BOPHAN] ([MaBoPhan])
GO
ALTER TABLE [dbo].[tb_PHONGBAN] CHECK CONSTRAINT [FK_TblPhongBan_TblBoPhan]
GO
