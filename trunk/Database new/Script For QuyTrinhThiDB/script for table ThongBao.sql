
---------------------------Begin lay danh sach thông báo của một nhân viên-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSTBCuaMotNhanVien ')
drop proc sp_layDSTBCuaMotNhanVien 
go
--Lấy danh sách thông báo của một nhân viên
--Input: mã nhân viên
--Output: danh sách thể hiện Thông báo phù hợp.
create proc sp_layDSTBCuaMotNhanVien 
@maNV int 
as
begin
	select thongbao.* from thongbao, tiendo
	where thongbao.maTD = tiendo.maTD
	and	tiendo.maNV = @maNV
end
---------------------------end lay danh sach thông báo của một nhân viên-------------------------------------------------



---------------------------Begin Tạo thông báo cho những công việc sắp tới-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_taoThongBaoNhacViecSapToi ')
drop proc sp_taoThongBaoNhacViecSapToi 
go
--Tạo các thông báo cho các công việc sắp tới.
--Input: 
--Output: danh sách thể hiện Thông báo phù hợp.
create proc sp_taoThongBaoNhacViecSapToi 
@strMess nvarchar(512), @numOfUpcomingDay int ,@numMessCreated int out
as
begin
	declare @cursor cursor
	set @cursor = cursor for	(select maTD from tiendo 
								where datediff(dd,getdate(),ngaybatdauquydinh) <= @numOfUpcomingDay
								and ngayBatDauThucTe is null															
								)
	open @cursor;
	declare @maTD int;
	fetch next from @cursor into @maTD;
	while(@@fetch_status = 0)
	begin
		insert into ThongBao values (
			@strMess,@maTD,1
		)
		fetch next from @cursor into @maTD;
	end
	set @numMessCreated = (select count(maTD) from tiendo 
								where datediff(dd,getdate(),ngaybatdauquydinh) <= @numOfUpcomingDay
								and ngayBatDauThucTe is null															
								)
end
---------------------------end Tạo thông báo cho những công việc sắp tới-------------------------------------------------



---------------------------Begin Tạo thông báo nhắc hoàn thành công việc-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_taoThongBaoNhacHoanThanhCongViec ')
drop proc sp_taoThongBaoNhacHoanThanhCongViec 
go
--Tạo các thông báo nhắc hoàn thành các công việc đang làm.
--Input: 
--Output: danh sách thể hiện Thông báo phù hợp.
create proc sp_taoThongBaoNhacHoanThanhCongViec 
@strMess nvarchar(512), @numOfUpcomingDay int ,@numMessCreated int out
as
begin
	declare @cursor cursor
	set @cursor = cursor for	(select maTD from tiendo 
								where datediff(dd,getdate(),ngayKetThucQuyDinh) <= @numOfUpcomingDay
								and ngayKetThucThucTe is null															
								)
	open @cursor;
	declare @maTD int;
	fetch next from @cursor into @maTD;
	while(@@fetch_status = 0)
	begin
		insert into ThongBao values (
			@strMess,@maTD,1
		)
		fetch next from @cursor into @maTD;
	end
	set @numMessCreated = (select count(maTD) from tiendo 
								where datediff(dd,getdate(),ngayKetThucQuyDinh) <= @numOfUpcomingDay
								and ngayKetThucThucTe is null															
								)
end
---------------------------end Tạo thông báo kết thúc các công việc đang làm-------------------------------------------------



---------------------------Begin Tạo thông báo nhắc bắt đầu cho một công việc-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_taoThongBaoNhacBatDauMotCongViec ')
drop proc sp_taoThongBaoNhacBatDauMotCongViec 
go
--Tạo các thông báo nhắc nhở bắt đầu cho một công việc cụ thể.
--Input: 
--Output: danh sách thể hiện Thông báo phù hợp.
create proc sp_taoThongBaoNhacBatDauMotCongViec 
@strMess nvarchar(512),@maCV int, @numOfUpcomingDay int ,@numMessCreated int out
as
begin
	declare @cursor cursor
	set @cursor = cursor for	(select maTD from tiendo 
								where datediff(dd,getdate(),ngaybatdauquydinh) <= @numOfUpcomingDay
								and ngayBatDauThucTe is null
								and maCV = @maCV															
								)
	open @cursor;
	declare @maTD int;
	fetch next from @cursor into @maTD;
	while(@@fetch_status = 0)
	begin
		insert into ThongBao values (
			@strMess,@maTD,1
		)
		fetch next from @cursor into @maTD;
	end
	set @numMessCreated = (select count(maTD) from tiendo 
								where datediff(dd,getdate(),ngaybatdauquydinh) <= @numOfUpcomingDay
								and ngayBatDauThucTe is null	
								and maCV = @maCV														
								)
end
---------------------------end Tạo thông báo cho những công việc sắp tới-------------------------------------------------


---------------------------Begin Tạo thông báo nhắc hoàn thành một công việc-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_taoThongBaoNhacHoanThanhMotCongViec ')
drop proc sp_taoThongBaoNhacHoanThanhMotCongViec 
go
--Tạo các thông báo nhắc hoàn thành các công việc đang làm.
--Input: 
--Output: danh sách thể hiện Thông báo phù hợp.
create proc sp_taoThongBaoNhacHoanThanhMotCongViec 
@strMess nvarchar(512),@maCV int, @numOfUpcomingDay int ,@numMessCreated int out
as
begin
	declare @cursor cursor
	set @cursor = cursor for	(select maTD from tiendo 
								where datediff(dd,getdate(),ngayKetThucQuyDinh) <= @numOfUpcomingDay
								and ngayKetThucThucTe is null
								and maCV = @maCV															
								)
	open @cursor;
	declare @maTD int;
	fetch next from @cursor into @maTD;
	while(@@fetch_status = 0)
	begin
		insert into ThongBao values (
			@strMess,@maTD,1
		)
		fetch next from @cursor into @maTD;
	end
	set @numMessCreated = (select count(maTD) from tiendo 
								where datediff(dd,getdate(),ngayKetThucQuyDinh) <= @numOfUpcomingDay
								and ngayKetThucThucTe is null		
								and maCV = @maCV													
								)
end
---------------------------end Tạo thông báo kết thúc các công việc đang làm-------------------------------------------------
