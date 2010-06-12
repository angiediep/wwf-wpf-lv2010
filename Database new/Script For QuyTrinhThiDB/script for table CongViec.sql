
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
