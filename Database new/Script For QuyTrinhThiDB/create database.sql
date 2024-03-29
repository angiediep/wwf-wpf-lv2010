USE [QuyTrinhThiDB]
GO
/****** Object:  ForeignKey [FK_DotThi_ChungChi_ChungChi]    Script Date: 06/13/2010 22:26:21 ******/
ALTER TABLE [dbo].[DotThi_ChungChi] DROP CONSTRAINT [FK_DotThi_ChungChi_ChungChi]
GO
/****** Object:  ForeignKey [FK_DotThi_ChungChi_DOTTHI]    Script Date: 06/13/2010 22:26:22 ******/
ALTER TABLE [dbo].[DotThi_ChungChi] DROP CONSTRAINT [FK_DotThi_ChungChi_DOTTHI]
GO
/****** Object:  ForeignKey [FK_GhiChu_TienDo]    Script Date: 06/13/2010 22:26:23 ******/
ALTER TABLE [dbo].[GhiChu] DROP CONSTRAINT [FK_GhiChu_TienDo]
GO
/****** Object:  ForeignKey [FK_PhanCong_CongViec]    Script Date: 06/13/2010 22:26:27 ******/
ALTER TABLE [dbo].[PhanCong] DROP CONSTRAINT [FK_PhanCong_CongViec]
GO
/****** Object:  ForeignKey [FK_PhanCong_NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:27 ******/
ALTER TABLE [dbo].[PhanCong] DROP CONSTRAINT [FK_PhanCong_NhanVienThuaHanh]
GO
/****** Object:  ForeignKey [FK_TienDo_CongViec]    Script Date: 06/13/2010 22:26:31 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [FK_TienDo_CongViec]
GO
/****** Object:  ForeignKey [FK_TienDo_DOTTHI]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [FK_TienDo_DOTTHI]
GO
/****** Object:  ForeignKey [FK_TienDo_NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [FK_TienDo_NhanVienThuaHanh]
GO
/****** Object:  ForeignKey [FK_ThongBao_TienDo]    Script Date: 06/13/2010 22:26:33 ******/
ALTER TABLE [dbo].[ThongBao] DROP CONSTRAINT [FK_ThongBao_TienDo]
GO
/****** Object:  Check [CK_DOTTHI]    Script Date: 06/13/2010 22:26:20 ******/
ALTER TABLE [dbo].[DotThi] DROP CONSTRAINT [CK_DOTTHI]
GO
/****** Object:  Check [CK_PHANCONG]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [CK_PHANCONG]
GO
/****** Object:  Check [CK_PHANCONG_1]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [CK_PHANCONG_1]
GO
/****** Object:  Check [CK_PHANCONG_2]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [CK_PHANCONG_2]
GO
/****** Object:  Check [CK_PHANCONG_3]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo] DROP CONSTRAINT [CK_PHANCONG_3]
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 06/13/2010 22:26:33 ******/
DROP TABLE [dbo].[ThongBao]
GO
/****** Object:  Table [dbo].[TienDo]    Script Date: 06/13/2010 22:26:31 ******/
DROP TABLE [dbo].[TienDo]
GO
/****** Object:  Table [dbo].[QuanLy]    Script Date: 06/13/2010 22:26:28 ******/
DROP TABLE [dbo].[QuanLy]
GO
/****** Object:  Table [dbo].[NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:25 ******/
DROP TABLE [dbo].[NhanVienThuaHanh]
GO
/****** Object:  Table [dbo].[CongViec]    Script Date: 06/13/2010 22:26:18 ******/
DROP TABLE [dbo].[CongViec]
GO
/****** Object:  Table [dbo].[DotThi]    Script Date: 06/13/2010 22:26:20 ******/
DROP TABLE [dbo].[DotThi]
GO
/****** Object:  Table [dbo].[ChungChi]    Script Date: 06/13/2010 22:26:19 ******/
DROP TABLE [dbo].[ChungChi]
GO
/****** Object:  Table [dbo].[DotThi_ChungChi]    Script Date: 06/13/2010 22:26:21 ******/
DROP TABLE [dbo].[DotThi_ChungChi]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 06/13/2010 22:26:27 ******/
DROP TABLE [dbo].[PhanCong]
GO
/****** Object:  Table [dbo].[GhiChu]    Script Date: 06/13/2010 22:26:23 ******/
DROP TABLE [dbo].[GhiChu]
GO
/****** Object:  Schema [tracking_profilereaderwriter]    Script Date: 06/13/2010 22:26:16 ******/
DROP SCHEMA [tracking_profilereaderwriter]
GO
/****** Object:  Schema [tracking_reader]    Script Date: 06/13/2010 22:26:16 ******/
DROP SCHEMA [tracking_reader]
GO
/****** Object:  Schema [tracking_writer]    Script Date: 06/13/2010 22:26:16 ******/
DROP SCHEMA [tracking_writer]
GO
/****** Object:  Schema [tracking_profilereaderwriter]    Script Date: 06/13/2010 22:26:16 ******/
CREATE SCHEMA [tracking_profilereaderwriter] AUTHORIZATION [tracking_profilereaderwriter]
GO
/****** Object:  Schema [tracking_reader]    Script Date: 06/13/2010 22:26:16 ******/
CREATE SCHEMA [tracking_reader] AUTHORIZATION [tracking_reader]
GO
/****** Object:  Schema [tracking_writer]    Script Date: 06/13/2010 22:26:16 ******/
CREATE SCHEMA [tracking_writer] AUTHORIZATION [tracking_writer]
GO
/****** Object:  Table [dbo].[DotThi]    Script Date: 06/13/2010 22:26:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DotThi](
	[maDT] [int] IDENTITY(1,1) NOT NULL,
	[tenDotThi] [nvarchar](250) NOT NULL,
	[ngayThi] [datetime] NOT NULL,
	[soLuongThiSinh] [int] NOT NULL,
	[workflowInstanceID] [nvarchar](250) NULL,
 CONSTRAINT [PK_DOTTHI] PRIMARY KEY NONCLUSTERED 
(
	[maDT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLy]    Script Date: 06/13/2010 22:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLy](
	[tenDangNhap] [nvarchar](50) NOT NULL,
	[matKhau] [nvarchar](250) NOT NULL,
	[SALT] [int] NULL,
	[email] [nvarchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVienThuaHanh](
	[maNV] [int] IDENTITY(1,1) NOT NULL,
	[tenDangNhap] [nvarchar](50) NOT NULL,
	[matKhau] [nvarchar](250) NOT NULL,
	[SALT] [int] NULL,
	[email] [varchar](100) NOT NULL,
	[tenNV] [nvarchar](50) NOT NULL,
	[dienThoai] [varchar](11) NULL,
 CONSTRAINT [PK_NhanVien_1] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uc_Email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uc_NhanVienThuaHanh] UNIQUE NONCLUSTERED 
(
	[tenDangNhap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CongViec]    Script Date: 06/13/2010 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CongViec](
	[maCV] [int] IDENTITY(1,1) NOT NULL,
	[tenCV] [varchar](100) NOT NULL,
	[ngayBatDau] [int] NOT NULL,
	[ngayKetThuc] [int] NOT NULL,
	[moTa] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TRACHNHIEM] PRIMARY KEY NONCLUSTERED 
(
	[maCV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChungChi]    Script Date: 06/13/2010 22:26:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungChi](
	[maCC] [int] IDENTITY(1,1) NOT NULL,
	[tenCC] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ChungChi] PRIMARY KEY CLUSTERED 
(
	[maCC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 06/13/2010 22:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[maTB] [int] IDENTITY(1,1) NOT NULL,
	[noiDung] [nvarchar](512) NOT NULL,
	[maTD] [int] NOT NULL,
	[trangThai] [int] NOT NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[maTB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GhiChu]    Script Date: 06/13/2010 22:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GhiChu](
	[maGC] [int] IDENTITY(1,1) NOT NULL,
	[GhiChu] [text] NOT NULL,
	[maTD] [int] NOT NULL,
 CONSTRAINT [PK_GhiChu] PRIMARY KEY CLUSTERED 
(
	[maGC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TienDo]    Script Date: 06/13/2010 22:26:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienDo](
	[maTD] [int] IDENTITY(1,1) NOT NULL,
	[tongKhoiLuongCV] [int] NULL,
	[khoiLuongCVHT] [int] NULL,
	[ngayBatDauQuyDinh] [datetime] NULL,
	[ngayKetThucQuyDinh] [datetime] NULL,
	[ngayBatDauThucTe] [datetime] NULL,
	[ngayKetThucThucTe] [datetime] NULL,
	[maDT] [int] NOT NULL,
	[maCV] [int] NOT NULL,
	[maNV] [int] NULL,
 CONSTRAINT [PK_TienDo] PRIMARY KEY CLUSTERED 
(
	[maTD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DotThi_ChungChi]    Script Date: 06/13/2010 22:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DotThi_ChungChi](
	[maDT] [int] NOT NULL,
	[maCC] [int] NOT NULL,
	[soLuongThiSinh] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 06/13/2010 22:26:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[maCV] [int] NOT NULL,
	[maNV] [int] NOT NULL,
	[ngayApDung] [datetime] NOT NULL,
	[ngayHetHan] [datetime] NULL,
 CONSTRAINT [PK_PhanCong_1] PRIMARY KEY CLUSTERED 
(
	[maCV] ASC,
	[maNV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Check [CK_DOTTHI]    Script Date: 06/13/2010 22:26:20 ******/
ALTER TABLE [dbo].[DotThi]  WITH CHECK ADD  CONSTRAINT [CK_DOTTHI] CHECK  (([soLuongThiSinh]>=(0)))
GO
ALTER TABLE [dbo].[DotThi] CHECK CONSTRAINT [CK_DOTTHI]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DotThi', @level2type=N'CONSTRAINT',@level2name=N'CK_DOTTHI'
GO
/****** Object:  Check [CK_PHANCONG]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [CK_PHANCONG] CHECK  (([ngayBatDauThucTe]<=[ngayKetThucThucTe]))
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [CK_PHANCONG]
GO
/****** Object:  Check [CK_PHANCONG_1]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [CK_PHANCONG_1] CHECK  (([khoiLuongCVHT]>=(0)))
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [CK_PHANCONG_1]
GO
/****** Object:  Check [CK_PHANCONG_2]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [CK_PHANCONG_2] CHECK  (([tongKhoiLuongCV]>=(0)))
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [CK_PHANCONG_2]
GO
/****** Object:  Check [CK_PHANCONG_3]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [CK_PHANCONG_3] CHECK  (([khoiLuongCVHT]<=[tongKhoiLuongCV]))
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [CK_PHANCONG_3]
GO
/****** Object:  ForeignKey [FK_DotThi_ChungChi_ChungChi]    Script Date: 06/13/2010 22:26:21 ******/
ALTER TABLE [dbo].[DotThi_ChungChi]  WITH CHECK ADD  CONSTRAINT [FK_DotThi_ChungChi_ChungChi] FOREIGN KEY([maCC])
REFERENCES [dbo].[ChungChi] ([maCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DotThi_ChungChi] CHECK CONSTRAINT [FK_DotThi_ChungChi_ChungChi]
GO
/****** Object:  ForeignKey [FK_DotThi_ChungChi_DOTTHI]    Script Date: 06/13/2010 22:26:22 ******/
ALTER TABLE [dbo].[DotThi_ChungChi]  WITH CHECK ADD  CONSTRAINT [FK_DotThi_ChungChi_DOTTHI] FOREIGN KEY([maDT])
REFERENCES [dbo].[DotThi] ([maDT])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DotThi_ChungChi] CHECK CONSTRAINT [FK_DotThi_ChungChi_DOTTHI]
GO
/****** Object:  ForeignKey [FK_GhiChu_TienDo]    Script Date: 06/13/2010 22:26:23 ******/
ALTER TABLE [dbo].[GhiChu]  WITH CHECK ADD  CONSTRAINT [FK_GhiChu_TienDo] FOREIGN KEY([maTD])
REFERENCES [dbo].[TienDo] ([maTD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GhiChu] CHECK CONSTRAINT [FK_GhiChu_TienDo]
GO
/****** Object:  ForeignKey [FK_PhanCong_CongViec]    Script Date: 06/13/2010 22:26:27 ******/
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_CongViec] FOREIGN KEY([maCV])
REFERENCES [dbo].[CongViec] ([maCV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_CongViec]
GO
/****** Object:  ForeignKey [FK_PhanCong_NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:27 ******/
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_NhanVienThuaHanh] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVienThuaHanh] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_NhanVienThuaHanh]
GO
/****** Object:  ForeignKey [FK_TienDo_CongViec]    Script Date: 06/13/2010 22:26:31 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [FK_TienDo_CongViec] FOREIGN KEY([maCV])
REFERENCES [dbo].[CongViec] ([maCV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [FK_TienDo_CongViec]
GO
/****** Object:  ForeignKey [FK_TienDo_DOTTHI]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [FK_TienDo_DOTTHI] FOREIGN KEY([maDT])
REFERENCES [dbo].[DotThi] ([maDT])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [FK_TienDo_DOTTHI]
GO
/****** Object:  ForeignKey [FK_TienDo_NhanVienThuaHanh]    Script Date: 06/13/2010 22:26:32 ******/
ALTER TABLE [dbo].[TienDo]  WITH CHECK ADD  CONSTRAINT [FK_TienDo_NhanVienThuaHanh] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVienThuaHanh] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TienDo] CHECK CONSTRAINT [FK_TienDo_NhanVienThuaHanh]
GO
/****** Object:  ForeignKey [FK_ThongBao_TienDo]    Script Date: 06/13/2010 22:26:33 ******/
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_TienDo] FOREIGN KEY([maTD])
REFERENCES [dbo].[TienDo] ([maTD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_TienDo]
GO
