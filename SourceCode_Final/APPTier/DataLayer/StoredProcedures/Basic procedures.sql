USE [QUYTRINHTHIDB]
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataPhanCong]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataPhanCong]
@maCV int
AS
    Select *
    From PhanCong
Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataPhanCong]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataPhanCong]
AS
    Select *
    From PhanCong
 /****** Object:  StoredProcedure [dbo].[spGetListDataPhanCongSortBy]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataPhanCongSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from PhanCong order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from PhanCong order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataPhanCongBymaNV]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataPhanCongBymaNV]
@maNV int
AS
    Select *
    From PhanCong
Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataPhanCongByngayApDung]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataPhanCongByngayApDung]
@ngayApDung datetime
AS
    Select *
    From PhanCong
Where ngayApDung=@ngayApDung
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataPhanCongByngayHetHan]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataPhanCongByngayHetHan]
@ngayHetHan datetime
AS
    Select *
    From PhanCong
Where ngayHetHan=@ngayHetHan
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataPhanCong]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataPhanCong]
	@maNV int,
	@ngayApDung datetime,
	@ngayHetHan datetime
AS
	Insert Into PhanCong(maNV,ngayApDung,ngayHetHan)
	 Values(@maNV,@ngayApDung,@ngayHetHan)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataPhanCong]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataPhanCong]
@maCV int
AS
    Delete 
    From PhanCong
Where maCV=@maCV
GO
 
 /****** Object:  StoredProcedure [dbo].[spDelDataPhanCongBymaNV]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataPhanCongBymaNV]
@maNV int
AS
    Delete 
    From PhanCong
Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataPhanCongByngayApDung]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataPhanCongByngayApDung]
@ngayApDung datetime
AS
    Delete 
    From PhanCong
Where ngayApDung=@ngayApDung
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataPhanCongByngayHetHan]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataPhanCongByngayHetHan]
@ngayHetHan datetime
AS
    Delete 
    From PhanCong
Where ngayHetHan=@ngayHetHan
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataPhanCong]    Script Date: 5/29/2010 1:50:15 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataPhanCong]
	@maCV int,
	@maNV int,
	@ngayApDung datetime,
	@ngayHetHan datetime
AS
	Update PhanCong
	 Set maNV = @maNV,ngayApDung = @ngayApDung,ngayHetHan = @ngayHetHan
	 Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataPhanCongBymaNV]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataPhanCongBymaNV]
	@maNV int,
	@ngayApDung datetime,
	@ngayHetHan datetime
AS
	Update PhanCong
	 Set ngayApDung = @ngayApDung,ngayHetHan = @ngayHetHan
	 Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataPhanCongByngayApDung]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataPhanCongByngayApDung]
	@maNV int,
	@ngayApDung datetime,
	@ngayHetHan datetime
AS
	Update PhanCong
	 Set maNV = @maNV,ngayHetHan = @ngayHetHan
	 Where ngayApDung=@ngayApDung
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataPhanCongByngayHetHan]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataPhanCongByngayHetHan]
	@maNV int,
	@ngayApDung datetime,
	@ngayHetHan datetime
AS
	Update PhanCong
	 Set maNV = @maNV,ngayApDung = @ngayApDung
	 Where ngayHetHan=@ngayHetHan
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataDotThi_ChungChi]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataDotThi_ChungChi]
@maDT int
AS
    Select *
    From DotThi_ChungChi
Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataDotThi_ChungChi]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDotThi_ChungChi]
AS
    Select *
    From DotThi_ChungChi
 /****** Object:  StoredProcedure [dbo].[spGetListDataDotThi_ChungChiSortBy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDotThi_ChungChiSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from DotThi_ChungChi order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from DotThi_ChungChi order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataDotThi_ChungChiBymaCC]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDotThi_ChungChiBymaCC]
@maCC int
AS
    Select *
    From DotThi_ChungChi
Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataDotThi_ChungChi]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataDotThi_ChungChi]
	@maCC int
AS
	Insert Into DotThi_ChungChi(maCC)
	 Values(@maCC)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataDotThi_ChungChi]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDotThi_ChungChi]
@maDT int
AS
    Delete 
    From DotThi_ChungChi
Where maDT=@maDT
GO

 /****** Object:  StoredProcedure [dbo].[spDelDataDotThi_ChungChiBymaCC]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDotThi_ChungChiBymaCC]
@maCC int
AS
    Delete 
    From DotThi_ChungChi
Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDotThi_ChungChi]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDotThi_ChungChi]
	@maDT int,
	@maCC int
AS
	Update DotThi_ChungChi
	 Set maCC = @maCC
	 Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDotThi_ChungChiBymaDT]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDotThi_ChungChiBymaDT]
	@maDT int,
	@maCC int
AS
	Update DotThi_ChungChi
	 Set maCC = @maCC
	 Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDotThi_ChungChiBymaCC]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDotThi_ChungChiBymaCC]
	@maDT int,
	@maCC int
AS
	Update DotThi_ChungChi
	 Set maDT = @maDT
	 Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataQuanLy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataQuanLy]
@tenDangNhap nvarchar(50)
AS
    Select *
    From QuanLy
Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataQuanLy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataQuanLy]
AS
    Select *
    From QuanLy
 /****** Object:  StoredProcedure [dbo].[spGetListDataQuanLySortBy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataQuanLySortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from QuanLy order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from QuanLy order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataQuanLyBymatKhau]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataQuanLyBymatKhau]
@matKhau nvarchar(250)
AS
    Select *
    From QuanLy
Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataQuanLyBySALT]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataQuanLyBySALT]
@SALT int
AS
    Select *
    From QuanLy
Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataQuanLyByemail]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataQuanLyByemail]
@email nvarchar(250)
AS
    Select *
    From QuanLy
Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataQuanLy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataQuanLy]
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Insert Into QuanLy(matKhau,SALT,email)
	 Values(@matKhau,@SALT,@email)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataQuanLy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataQuanLy]
@tenDangNhap nvarchar(50)
AS
    Delete 
    From QuanLy
Where tenDangNhap=@tenDangNhap
GO
 
 /****** Object:  StoredProcedure [dbo].[spDelDataQuanLyBymatKhau]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataQuanLyBymatKhau]
@matKhau nvarchar(250)
AS
    Delete 
    From QuanLy
Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataQuanLyBySALT]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataQuanLyBySALT]
@SALT int
AS
    Delete 
    From QuanLy
Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataQuanLyByemail]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataQuanLyByemail]
@email nvarchar(250)
AS
    Delete 
    From QuanLy
Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataQuanLy]    Script Date: 5/29/2010 1:50:17 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataQuanLy]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Update QuanLy
	 Set matKhau = @matKhau,SALT = @SALT,email = @email
	 Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataQuanLyBytenDangNhap]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataQuanLyBytenDangNhap]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Update QuanLy
	 Set matKhau = @matKhau,SALT = @SALT,email = @email
	 Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataQuanLyBymatKhau]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataQuanLyBymatKhau]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Update QuanLy
	 Set tenDangNhap = @tenDangNhap,SALT = @SALT,email = @email
	 Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataQuanLyBySALT]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataQuanLyBySALT]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Update QuanLy
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,email = @email
	 Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataQuanLyByemail]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataQuanLyByemail]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email nvarchar(250)
AS
	Update QuanLy
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,SALT = @SALT
	 Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataCongViec]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataCongViec]
@maCV int
AS
    Select *
    From CongViec
Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViec]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViec]
AS
    Select *
    From CongViec
 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViecSortBy]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViecSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from CongViec order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from CongViec order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViecBytenCV]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViecBytenCV]
@tenCV varchar(100)
AS
    Select *
    From CongViec
Where tenCV=@tenCV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViecByngayBatDau]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViecByngayBatDau]
@ngayBatDau int
AS
    Select *
    From CongViec
Where ngayBatDau=@ngayBatDau
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViecByngayKetThuc]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViecByngayKetThuc]
@ngayKetThuc int
AS
    Select *
    From CongViec
Where ngayKetThuc=@ngayKetThuc
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataCongViecBymoTa]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataCongViecBymoTa]
@moTa nvarchar(250)
AS
    Select *
    From CongViec
Where moTa=@moTa
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataCongViec]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataCongViec]
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Insert Into CongViec(tenCV,ngayBatDau,ngayKetThuc,moTa)
	 Values(@tenCV,@ngayBatDau,@ngayKetThuc,@moTa)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataCongViec]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataCongViec]
@maCV int
AS
    Delete 
    From CongViec
Where maCV=@maCV
GO

 /****** Object:  StoredProcedure [dbo].[spDelDataCongViecBytenCV]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataCongViecBytenCV]
@tenCV varchar(100)
AS
    Delete 
    From CongViec
Where tenCV=@tenCV
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataCongViecByngayBatDau]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataCongViecByngayBatDau]
@ngayBatDau int
AS
    Delete 
    From CongViec
Where ngayBatDau=@ngayBatDau
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataCongViecByngayKetThuc]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataCongViecByngayKetThuc]
@ngayKetThuc int
AS
    Delete 
    From CongViec
Where ngayKetThuc=@ngayKetThuc
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataCongViecBymoTa]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataCongViecBymoTa]
@moTa nvarchar(250)
AS
    Delete 
    From CongViec
Where moTa=@moTa
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataCongViec]    Script Date: 5/29/2010 1:50:18 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataCongViec]
	@maCV int,
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Update CongViec
	 Set tenCV = @tenCV,ngayBatDau = @ngayBatDau,ngayKetThuc = @ngayKetThuc,moTa = @moTa
	 Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataCongViecBytenCV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataCongViecBytenCV]
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Update CongViec
	 Set ngayBatDau = @ngayBatDau,ngayKetThuc = @ngayKetThuc,moTa = @moTa
	 Where tenCV=@tenCV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataCongViecByngayBatDau]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataCongViecByngayBatDau]
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Update CongViec
	 Set tenCV = @tenCV,ngayKetThuc = @ngayKetThuc,moTa = @moTa
	 Where ngayBatDau=@ngayBatDau
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataCongViecByngayKetThuc]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataCongViecByngayKetThuc]
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Update CongViec
	 Set tenCV = @tenCV,ngayBatDau = @ngayBatDau,moTa = @moTa
	 Where ngayKetThuc=@ngayKetThuc
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataCongViecBymoTa]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataCongViecBymoTa]
	@tenCV varchar(100),
	@ngayBatDau int,
	@ngayKetThuc int,
	@moTa nvarchar(250)
AS
	Update CongViec
	 Set tenCV = @tenCV,ngayBatDau = @ngayBatDau,ngayKetThuc = @ngayKetThuc
	 Where moTa=@moTa
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataDOTTHI]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataDOTTHI]
@maDT int
AS
    Select *
    From DOTTHI
Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataDOTTHI]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDOTTHI]
AS
    Select *
    From DOTTHI
 /****** Object:  StoredProcedure [dbo].[spGetListDataDOTTHISortBy]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDOTTHISortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from DOTTHI order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from DOTTHI order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataDOTTHIBytenDT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDOTTHIBytenDT]
@tenDT nvarchar(250)
AS
    Select *
    From DOTTHI
Where tenDT=@tenDT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataDOTTHIByngayThi]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDOTTHIByngayThi]
@ngayThi datetime
AS
    Select *
    From DOTTHI
Where ngayThi=@ngayThi
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataDOTTHIBysoLuongThiSinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataDOTTHIBysoLuongThiSinh]
@soLuongThiSinh int
AS
    Select *
    From DOTTHI
Where soLuongThiSinh=@soLuongThiSinh
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataDOTTHI]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataDOTTHI]
	@tenDT nvarchar(250),
	@ngayThi datetime,
	@soLuongThiSinh int
AS
	Insert Into DOTTHI(tenDT,ngayThi,soLuongThiSinh)
	 Values(@tenDT,@ngayThi,@soLuongThiSinh)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataDOTTHI]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDOTTHI]
@maDT int
AS
    Delete 
    From DOTTHI
Where maDT=@maDT
GO

 /****** Object:  StoredProcedure [dbo].[spDelDataDOTTHIBytenDT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDOTTHIBytenDT]
@tenDT nvarchar(250)
AS
    Delete 
    From DOTTHI
Where tenDT=@tenDT
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataDOTTHIByngayThi]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDOTTHIByngayThi]
@ngayThi datetime
AS
    Delete 
    From DOTTHI
Where ngayThi=@ngayThi
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataDOTTHIBysoLuongThiSinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataDOTTHIBysoLuongThiSinh]
@soLuongThiSinh int
AS
    Delete 
    From DOTTHI
Where soLuongThiSinh=@soLuongThiSinh
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDOTTHI]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDOTTHI]
	@maDT int,
	@tenDT nvarchar(250),
	@ngayThi datetime,
	@soLuongThiSinh int
AS
	Update DOTTHI
	 Set tenDT = @tenDT,ngayThi = @ngayThi,soLuongThiSinh = @soLuongThiSinh
	 Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDOTTHIBytenDT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDOTTHIBytenDT]
	@tenDT nvarchar(250),
	@ngayThi datetime,
	@soLuongThiSinh int
AS
	Update DOTTHI
	 Set ngayThi = @ngayThi,soLuongThiSinh = @soLuongThiSinh
	 Where tenDT=@tenDT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDOTTHIByngayThi]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDOTTHIByngayThi]
	@tenDT nvarchar(250),
	@ngayThi datetime,
	@soLuongThiSinh int
AS
	Update DOTTHI
	 Set tenDT = @tenDT,soLuongThiSinh = @soLuongThiSinh
	 Where ngayThi=@ngayThi
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataDOTTHIBysoLuongThiSinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataDOTTHIBysoLuongThiSinh]
	@tenDT nvarchar(250),
	@ngayThi datetime,
	@soLuongThiSinh int
AS
	Update DOTTHI
	 Set tenDT = @tenDT,ngayThi = @ngayThi
	 Where soLuongThiSinh=@soLuongThiSinh
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataTienDo]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataTienDo]
@maTD int
AS
    Select *
    From TienDo
Where maTD=@maTD
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDo]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDo]
AS
    Select *
    From TienDo
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoSortBy]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from TienDo order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from TienDo order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoBytongKhoiLuongCV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoBytongKhoiLuongCV]
@tongKhoiLuongCV int
AS
    Select *
    From TienDo
Where tongKhoiLuongCV=@tongKhoiLuongCV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoBykhoiLuongCVHT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoBykhoiLuongCVHT]
@khoiLuongCVHT int
AS
    Select *
    From TienDo
Where khoiLuongCVHT=@khoiLuongCVHT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoByngayBatDauQuyDinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoByngayBatDauQuyDinh]
@ngayBatDauQuyDinh datetime
AS
    Select *
    From TienDo
Where ngayBatDauQuyDinh=@ngayBatDauQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoByngayKetThucQuyDinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoByngayKetThucQuyDinh]
@ngayKetThucQuyDinh datetime
AS
    Select *
    From TienDo
Where ngayKetThucQuyDinh=@ngayKetThucQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoByngayBatDauThucTe]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoByngayBatDauThucTe]
@ngayBatDauThucTe datetime
AS
    Select *
    From TienDo
Where ngayBatDauThucTe=@ngayBatDauThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoByngayKetThucThucTe]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoByngayKetThucThucTe]
@ngayKetThucThucTe datetime
AS
    Select *
    From TienDo
Where ngayKetThucThucTe=@ngayKetThucThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoBymaDT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoBymaDT]
@maDT int
AS
    Select *
    From TienDo
Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoBymaCV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoBymaCV]
@maCV int
AS
    Select *
    From TienDo
Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataTienDoBymaNV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataTienDoBymaNV]
@maNV int
AS
    Select *
    From TienDo
Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataTienDo]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataTienDo]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Insert Into TienDo(tongKhoiLuongCV,khoiLuongCVHT,ngayBatDauQuyDinh,ngayKetThucQuyDinh,ngayBatDauThucTe,ngayKetThucThucTe,maDT,maCV,maNV)
	 Values(@tongKhoiLuongCV,@khoiLuongCVHT,@ngayBatDauQuyDinh,@ngayKetThucQuyDinh,@ngayBatDauThucTe,@ngayKetThucThucTe,@maDT,@maCV,@maNV)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDo]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDo]
@maTD int
AS
    Delete 
    From TienDo
Where maTD=@maTD
GO
 
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoBytongKhoiLuongCV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoBytongKhoiLuongCV]
@tongKhoiLuongCV int
AS
    Delete 
    From TienDo
Where tongKhoiLuongCV=@tongKhoiLuongCV
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoBykhoiLuongCVHT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoBykhoiLuongCVHT]
@khoiLuongCVHT int
AS
    Delete 
    From TienDo
Where khoiLuongCVHT=@khoiLuongCVHT
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoByngayBatDauQuyDinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoByngayBatDauQuyDinh]
@ngayBatDauQuyDinh datetime
AS
    Delete 
    From TienDo
Where ngayBatDauQuyDinh=@ngayBatDauQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoByngayKetThucQuyDinh]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoByngayKetThucQuyDinh]
@ngayKetThucQuyDinh datetime
AS
    Delete 
    From TienDo
Where ngayKetThucQuyDinh=@ngayKetThucQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoByngayBatDauThucTe]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoByngayBatDauThucTe]
@ngayBatDauThucTe datetime
AS
    Delete 
    From TienDo
Where ngayBatDauThucTe=@ngayBatDauThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoByngayKetThucThucTe]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoByngayKetThucThucTe]
@ngayKetThucThucTe datetime
AS
    Delete 
    From TienDo
Where ngayKetThucThucTe=@ngayKetThucThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoBymaDT]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoBymaDT]
@maDT int
AS
    Delete 
    From TienDo
Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoBymaCV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoBymaCV]
@maCV int
AS
    Delete 
    From TienDo
Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataTienDoBymaNV]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataTienDoBymaNV]
@maNV int
AS
    Delete 
    From TienDo
Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDo]    Script Date: 5/29/2010 1:50:19 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDo]
	@maTD int,
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where maTD=@maTD
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoBytongKhoiLuongCV]    Script Date: 5/29/2010 1:50:20 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoBytongKhoiLuongCV]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where tongKhoiLuongCV=@tongKhoiLuongCV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoBykhoiLuongCVHT]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoBykhoiLuongCVHT]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where khoiLuongCVHT=@khoiLuongCVHT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoByngayBatDauQuyDinh]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoByngayBatDauQuyDinh]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where ngayBatDauQuyDinh=@ngayBatDauQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoByngayKetThucQuyDinh]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoByngayKetThucQuyDinh]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where ngayKetThucQuyDinh=@ngayKetThucQuyDinh
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoByngayBatDauThucTe]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoByngayBatDauThucTe]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where ngayBatDauThucTe=@ngayBatDauThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoByngayKetThucThucTe]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoByngayKetThucThucTe]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,maDT = @maDT,maCV = @maCV,maNV = @maNV
	 Where ngayKetThucThucTe=@ngayKetThucThucTe
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoBymaDT]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoBymaDT]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maCV = @maCV,maNV = @maNV
	 Where maDT=@maDT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoBymaCV]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoBymaCV]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maNV = @maNV
	 Where maCV=@maCV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataTienDoBymaNV]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataTienDoBymaNV]
	@tongKhoiLuongCV int,
	@khoiLuongCVHT int,
	@ngayBatDauQuyDinh datetime,
	@ngayKetThucQuyDinh datetime,
	@ngayBatDauThucTe datetime,
	@ngayKetThucThucTe datetime,
	@maDT int,
	@maCV int,
	@maNV int
AS
	Update TienDo
	 Set tongKhoiLuongCV = @tongKhoiLuongCV,khoiLuongCVHT = @khoiLuongCVHT,ngayBatDauQuyDinh = @ngayBatDauQuyDinh,ngayKetThucQuyDinh = @ngayKetThucQuyDinh,ngayBatDauThucTe = @ngayBatDauThucTe,ngayKetThucThucTe = @ngayKetThucThucTe,maDT = @maDT,maCV = @maCV
	 Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataChungChi]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataChungChi]
@maCC int
AS
    Select *
    From ChungChi
Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataChungChi]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataChungChi]
AS
    Select *
    From ChungChi
 /****** Object:  StoredProcedure [dbo].[spGetListDataChungChiSortBy]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataChungChiSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from ChungChi order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from ChungChi order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataChungChiBytenCC]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataChungChiBytenCC]
@tenCC nvarchar(250)
AS
    Select *
    From ChungChi
Where tenCC=@tenCC
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataChungChi]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataChungChi]
	@tenCC nvarchar(250)
AS
	Insert Into ChungChi(tenCC)
	 Values(@tenCC)
	 SELECT @@IDENTITY AS 'Identity'
GO
 
 /****** Object:  StoredProcedure [dbo].[spDelDataChungChi]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataChungChi]
@maCC int
AS
    Delete 
    From ChungChi
Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataChungChiBytenCC]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataChungChiBytenCC]
@tenCC nvarchar(250)
AS
    Delete 
    From ChungChi
Where tenCC=@tenCC
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataChungChi]    Script Date: 5/29/2010 1:50:21 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataChungChi]
	@maCC int,
	@tenCC nvarchar(250)
AS
	Update ChungChi
	 Set tenCC = @tenCC
	 Where maCC=@maCC
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataChungChiBytenCC]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataChungChiBytenCC]
	@tenCC nvarchar(250)
AS
	return
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataGhiChu]
@maGC int
AS
    Select *
    From GhiChu
Where maGC=@maGC
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataGhiChu]
AS
    Select *
    From GhiChu
 /****** Object:  StoredProcedure [dbo].[spGetListDataGhiChuSortBy]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataGhiChuSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from GhiChu order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from GhiChu order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataGhiChuByGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataGhiChuByGhiChu]
@GhiChu text
AS
    Select *
    From GhiChu
Where GhiChu LIKE @GhiChu
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataGhiChuBymaTD]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataGhiChuBymaTD]
@maTD int
AS
    Select *
    From GhiChu
Where maTD=@maTD
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataGhiChu]
	@GhiChu text,
	@maTD int
AS
	Insert Into GhiChu(GhiChu,maTD)
	 Values(@GhiChu,@maTD)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataGhiChu]
@maGC int
AS
    Delete 
    From GhiChu
Where maGC=@maGC
GO
 
 /****** Object:  StoredProcedure [dbo].[spDelDataGhiChuByGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataGhiChuByGhiChu]
@GhiChu text
AS
    Delete 
    From GhiChu
Where GhiChu like @GhiChu
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataGhiChuBymaTD]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataGhiChuBymaTD]
@maTD int
AS
    Delete 
    From GhiChu
Where maTD=@maTD
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataGhiChu]    Script Date: 5/29/2010 1:50:22 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataGhiChu]
	@maGC int,
	@GhiChu text,
	@maTD int
AS
	Update GhiChu
	 Set GhiChu = @GhiChu,maTD = @maTD
	 Where maGC=@maGC
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataGhiChuByGhiChu]    Script Date: 5/29/2010 1:50:23 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataGhiChuByGhiChu]
	@GhiChu text,
	@maTD int
AS
	Update GhiChu
	 Set maTD = @maTD
	 Where GhiChu like @GhiChu
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataGhiChuBymaTD]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataGhiChuBymaTD]
	@GhiChu text,
	@maTD int
AS
	Update GhiChu
	 Set GhiChu = @GhiChu
	 Where maTD=@maTD
GO
 /****** Object:  StoredProcedure [dbo].[spGetDataNhanVienThuaHanh]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataNhanVienThuaHanh]
@maNV int
AS
    Select *
    From NhanVienThuaHanh
Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanh]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanh]
AS
    Select *
    From NhanVienThuaHanh
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhSortBy]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhSortBy]
	@flag bit,
	@col nvarchar(50)
AS
    if(@flag = 'True')
	begin
		Exec('select * from NhanVienThuaHanh order by ' + @col + ' asc') 
	end
	else
	begin
		Exec('select * from NhanVienThuaHanh order by ' + @col + ' desc') 
	end


 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhBytenDangNhap]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhBytenDangNhap]
@tenDangNhap nvarchar(50)
AS
    Select *
    From NhanVienThuaHanh
Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhBymatKhau]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhBymatKhau]
@matKhau nvarchar(250)
AS
    Select *
    From NhanVienThuaHanh
Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhBySALT]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhBySALT]
@SALT int
AS
    Select *
    From NhanVienThuaHanh
Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhByemail]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhByemail]
@email varchar(100)
AS
    Select *
    From NhanVienThuaHanh
Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhBytenNV]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhBytenNV]
@tenNV varchar(50)
AS
    Select *
    From NhanVienThuaHanh
Where tenNV=@tenNV
GO
 /****** Object:  StoredProcedure [dbo].[spGetListDataNhanVienThuaHanhBydienThoai]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetListDataNhanVienThuaHanhBydienThoai]
@dienThoai varchar(11)
AS
    Select *
    From NhanVienThuaHanh
Where dienThoai=@dienThoai
GO
 /****** Object:  StoredProcedure [dbo].[spInsertDataNhanVienThuaHanh]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDataNhanVienThuaHanh]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Insert Into NhanVienThuaHanh(tenDangNhap,matKhau,SALT,email,tenNV,dienThoai)
	 Values(@tenDangNhap,@matKhau,@SALT,@email,@tenNV,@dienThoai)
	 SELECT @@IDENTITY AS 'Identity'
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanh]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanh]
@maNV int
AS
    Delete 
    From NhanVienThuaHanh
Where maNV=@maNV
GO

 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhBytenDangNhap]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhBytenDangNhap]
@tenDangNhap nvarchar(50)
AS
    Delete 
    From NhanVienThuaHanh
Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhBymatKhau]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhBymatKhau]
@matKhau nvarchar(250)
AS
    Delete 
    From NhanVienThuaHanh
Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhBySALT]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhBySALT]
@SALT int
AS
    Delete 
    From NhanVienThuaHanh
Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhByemail]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhByemail]
@email varchar(100)
AS
    Delete 
    From NhanVienThuaHanh
Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhBytenNV]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhBytenNV]
@tenNV varchar(50)
AS
    Delete 
    From NhanVienThuaHanh
Where tenNV=@tenNV
GO
 /****** Object:  StoredProcedure [dbo].[spDelDataNhanVienThuaHanhBydienThoai]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelDataNhanVienThuaHanhBydienThoai]
@dienThoai varchar(11)
AS
    Delete 
    From NhanVienThuaHanh
Where dienThoai=@dienThoai
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanh]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanh]
	@maNV int,
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,SALT = @SALT,email = @email,tenNV = @tenNV,dienThoai = @dienThoai
	 Where maNV=@maNV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhBytenDangNhap]    Script Date: 5/29/2010 1:50:24 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhBytenDangNhap]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set matKhau = @matKhau,SALT = @SALT,email = @email,tenNV = @tenNV,dienThoai = @dienThoai
	 Where tenDangNhap=@tenDangNhap
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhBymatKhau]    Script Date: 5/29/2010 1:50:25 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhBymatKhau]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,SALT = @SALT,email = @email,tenNV = @tenNV,dienThoai = @dienThoai
	 Where matKhau=@matKhau
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhBySALT]    Script Date: 5/29/2010 1:50:25 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhBySALT]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,email = @email,tenNV = @tenNV,dienThoai = @dienThoai
	 Where SALT=@SALT
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhByemail]    Script Date: 5/29/2010 1:50:25 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhByemail]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,SALT = @SALT,tenNV = @tenNV,dienThoai = @dienThoai
	 Where email=@email
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhBytenNV]    Script Date: 5/29/2010 1:50:25 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhBytenNV]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,SALT = @SALT,email = @email,dienThoai = @dienThoai
	 Where tenNV=@tenNV
GO
 /****** Object:  StoredProcedure [dbo].[spUpdateDataNhanVienThuaHanhBydienThoai]    Script Date: 5/29/2010 1:50:25 PM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateDataNhanVienThuaHanhBydienThoai]
	@tenDangNhap nvarchar(50),
	@matKhau nvarchar(250),
	@SALT int,
	@email varchar(100),
	@tenNV varchar(50),
	@dienThoai varchar(11)
AS
	Update NhanVienThuaHanh
	 Set tenDangNhap = @tenDangNhap,matKhau = @matKhau,SALT = @SALT,email = @email,tenNV = @tenNV
	 Where dienThoai=@dienThoai
GO
