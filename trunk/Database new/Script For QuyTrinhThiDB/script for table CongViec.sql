
----------------------------------------Begin Lấy danh sách Công việc trễ hạn, sớm hạn----------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSCongViecTreHan')
drop proc sp_layDSCongViecTreHan
Go
--lấy danh sách công việc bị trễ hạn của một đợt thi cho trước
--Input: maDT 
--Output: Danh sách tiến độ trễ hạn.
create proc sp_layDSCongViecTreHan
@maDT int
as
begin
	select * from tienDo
	where maDT = @maDT
	and datediff(dd,ngayKetThucQuyDinh, ngayKetThucThucTe) >= 1
end

go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSCongViecSomHan')
drop proc sp_layDSCongViecSomHan
Go
--lấy danh sách công việc sớm hạn của một đợt thi cho trước
--Input: maDT 
--Output: Danh sách tiến độ sớm hạn.
create proc sp_layDSCongViecSomHan
@maDT int
as
begin
	select * from tienDo
	where maDT = @maDT
	and datediff(dd,ngayKetThucQuyDinh, ngayKetThucThucTe) <= 1
end
----------------------------------------end Lấy danh sách Công việc trễ/sớm hạn----------------------------------

----------------------------------------Begin số lần trễ hạn của một công việc----------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_laySoLanCongViecTreHan')
drop proc sp_laySoLanCongViecTreHan
Go
--lấy số lần trễ hạn của một công việc
--Input: mã công việc
--Output: Số lần trễ hạn
create proc sp_laySoLanCongViecTreHan
@maCV int , @soLanTreHan int out
as
begin
	set @soLanTreHan = (
						select count (*)
						from tiendo
						where maCV = @maCV
						and datediff(dd, ngayketthucquydinh, ngayKetThucThucTe) > 0
						)
end

----------------------------------------end  Lấy số lần trễ hạn của một công việc-------------------


----------------------------------------Begin số lần sớm hạn của một công việc----------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_laySoLanCongViecSomHan')
drop proc sp_laySoLanCongViecSomHan
Go
--lấy số lần sớm hạn của một công việc
--Input: mã công việc
--Output: Số lần sớm hạn
create proc sp_laySoLanCongViecSomHan
@maCV int , @soLanSomHan int out
as
begin
	set @soLanSomHan = (
						select count (*)
						from tiendo
						where maCV = @maCV
						and datediff(dd, ngayketthucquydinh, ngayKetThucThucTe)< 0
						)
end

----------------------------------------end  Lấy số lần sớm hạn của một công việc-------------------


----------------------------------------Begin số lần thực hiện của một công việc----------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_laySoLanThucHienCongViec')
drop proc sp_laySoLanThucHienCongViec
Go
--lấy số lần trễ hạn của một công việc
--Input: mã công việc
--Output: Số lần trễ hạn
create proc sp_laySoLanThucHienCongViec
@maCV int , @soLanThucHien int out
as
begin
	set @soLanThucHien = (
							select count (*)
							from tiendo
							where maCV = @maCV
							)
end

----------------------------------------end  Lấy số lần thực hiện của một công việc-------------------


------------------Begin lấy danh sách công việc được phân công cho một nhân viên bất kỳ-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSCVTheoMaNV')
drop proc sp_layDSCVTheoMaNV
Go
--lấy danh sách công việc được phân công cho một nhân viên bất kỳ
--Input: mã nhân viên
--Output: danh sách thể hiện công việc phù hợp
create proc sp_layDSCVTheoMaNV
@maNV int
as
begin
	select * from congviec
	where exists(
		select * from tiendo 
		where tiendo.maCV = congviec.maCV
		and manv = @maNV
	)
end

------------------end lấy danh sách công việc được phân công cho một nhân viên bất kỳ-----------------------




------------------Begin lấy danh sách công việc hoàn thành-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSCVHoanThanh')
drop proc sp_layDSCVHoanThanh
Go
--lấy danh sách công việc hoàn thành theo các tiêu chí khác nhau
--Input: 
----@maDT: mã đợt thi
---------@maDT = 0: xét tất cả các đợt thi
---------@maDT > 0: xét một đợt thi cụ thể
----@maNV: mã nhân viên
---------@maNV = 0: xét công việc được phân công cho bất kỳ nhân viên nào
---------@maNV > 0: xét công việc được phân công cho một nhân viên cụ thể
----@tinhTrang : tình trạng hoàn thành công việc
---------@tinhTrang = 1: trễ hạn
---------@tinhTrang = 0: đúng hạn
---------@tinhTrang = 1: sớm hạn
----@fromDate,@toDate: giới hạn thời gian thực tế công việc được thực thi.
---------@fromDate,@toDate = null: không giới hạn thời gian
---------@fromDate,@toDate != null: chỉ xét các công việc diễn ra trong thời gian này.
--Output: danh sách thể hiện công việc phù hợp
create proc sp_layDSCVHoanThanh
@maDT int, @maNV int,@tinhTrang int,@fromDate datetime, @toDate datetime
as
begin
	if(@maDT < 0 or @maNV < 0 or @tinhTrang < -1 or @tinhTrang > 1)
		return;
	if(@fromDate = null and @toDate != null)
		return;
	if(@fromDate != null and @toDate = null)
		return;
	declare @query nvarchar(4000)
	set @query = 'select CV.* from CongViec as CV, TienDo as TD
					where CV.maCV = TD.TD 
					and ngayketthucthucte is not null '
	--Đợt thi:
	if(@maDT > 0)
		set @query = @query + ' and maDT = ' + cast(@maDT as nvarchar(10))
	--Nhân viên
	if(@maNV > 0)
		set @query = @query + ' and maNV = ' + cast(@maNV as nvarchar(10))
	--tinhTrang
	if(@tinhTrang = 1)
		set @query = @query + ' and datediff(dd,ngayketthucquydinh,ngayketthucthucte) > 0 '
	else if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngayketthucquydinh,ngayketthucthucte) = 0 '
	else
		set @query = @query + ' and datediff(dd,ngayketthucquydinh,ngayketthucthucte) < 0 '	
	--ThoiGian:
	if(@fromDate is not null)
		set @query = @query +' and datediff(dd,''' + cast(@fromDate as nvarchar(100))+ ''' ,ngayketthucthucte) >= 0
								 and datediff(dd,''' + cast(@toDate as nvarchar(100))+ ''', ngayketthucthucte)<= 0 '
	exec (@query)
end

------------------end lấy danh sách công việc hoàn thành-----------------------





------------------Begin lấy danh sách công việc đã bắt dầu-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSCVBatDau')
drop proc sp_layDSCVBatDau
Go
--lấy danh sách công việc bắt dầu theo các tiêu chí khác nhau
--Input: 
----@maDT: mã đợt thi
---------@maDT = 0: xét tất cả các đợt thi
---------@maDT > 0: xét một đợt thi cụ thể
----@maNV: mã nhân viên
---------@maNV = 0: xét công việc được phân công cho bất kỳ nhân viên nào
---------@maNV > 0: xét công việc được phân công cho một nhân viên cụ thể
----@tinhTrang : tình trạng bắt dầu công việc
---------@tinhTrang = 1: trễ hạn
---------@tinhTrang = 0: đúng hạn
---------@tinhTrang = 1: sớm hạn
----@fromDate,@toDate: giới hạn thời gian thực tế công việc được thực thi.
---------@fromDate,@toDate = null: không giới hạn thời gian
---------@fromDate,@toDate != null: chỉ xét các công việc diễn ra trong thời gian này.
--Output: danh sách thể hiện công việc phù hợp
create proc sp_layDSCVBatDau
@maDT int, @maNV int,@tinhTrang int,@fromDate datetime, @toDate datetime
as
begin
	if(@maDT < 0 or @maNV < 0 or @tinhTrang < -1 or @tinhTrang > 1)
		return;
	if(@fromDate = null and @toDate != null)
		return;
	if(@fromDate != null and @toDate = null)
		return;
	declare @query nvarchar(4000)
	set @query = 'select CV.* from CongViec as CV, TienDo as TD
					where CV.maCV = TD.TD 
					and ngaybatdauthucte is not null '
	--Đợt thi:
	if(@maDT > 0)
		set @query = @query + ' and maDT = ' + cast(@maDT as nvarchar(10))
	--Nhân viên
	if(@maNV > 0)
		set @query = @query + ' and maNV = ' + cast(@maNV as nvarchar(10))
	--tinhTrang
	if(@tinhTrang = 1)
		set @query = @query + ' and datediff(dd,ngaybatdauquydinh,ngaybatdauthucte) > 0 '
	else if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngaybatdauquydinh,ngaybatdauthucte) = 0 '
	else
		set @query = @query + ' and datediff(dd,ngaybatdauquydinh,ngaybatdauthucte) < 0 '	
	--ThoiGian:
	if(@fromDate is not null)
		set @query = @query +' and datediff(dd,''' + cast(@fromDate as nvarchar(100))+ ''' ,ngaybatdauthucte) >= 0
								 and datediff(dd,''' + cast(@toDate as nvarchar(100))+ ''', ngaybatdauthucte)<= 0 '
	exec (@query)
end

------------------end lấy danh sách công việc đã bắt đầu-----------------------



