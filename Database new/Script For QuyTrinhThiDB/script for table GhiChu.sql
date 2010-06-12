

----------------------------------------Begin Lấy danh sách Ghi chú----------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layGhiChuTheoMaTD')
drop proc sp_layGhiChuTheoMaTD
Go
--lấy thông tin theo dõi tiến độ của một công việc trong một đợt thi
--Input: maTD 
--Output: Danh sách ghi chú gồm tối đa 1 phần tử.
create proc sp_layGhiChuTheoMaTD
@maTD int
as
begin
	select * from GHICHU
	where matd = @maTD
end

go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layGhiChuTheoMaCVMaDT')
drop proc sp_layGhiChuTheoMaCVMaDT
Go
--lấy thông tin theo dõi tiến độ của một công việc trong một đợt thi
--Input: maTD 
--Output: Danh sách ghi chú gồm tối đa 1 phần tử.
create proc sp_layGhiChuTheoMaCVMaDT
@maCV int, @maDT int
as
begin
	select GC.* from GHICHU as GC, TienDo as TD
	where GC.maTD = TD.maTd
	and	TD.maCV = @maCV
	and TD.maDT = @maDT
end


----------------------------------------end  Lấy danh sách Ghi chú----------------------------------

