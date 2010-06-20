
------------------Begin lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSTDTheoMaNV')
drop proc sp_layDSTDTheoMaNV
Go
--lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên bất kỳ qua các kỳ thi.
--Input: mã nhân viên
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layDSTDTheoMaNV
@maNV int
as
begin
	select * from tiendo
	where maNV = @maNV
end

------------------end lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên-----------------------


------------------Begin lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layDSTDTheoMaNVVaThoiGian')
drop proc sp_layDSTDTheoMaNVVaThoiGian
Go
--lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên bất kỳ qua các kỳ thi.
--Input: mã nhân viên,khoảng thời gian cần lấy thông tin
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layDSTDTheoMaNVVaThoiGian
@maNV int, @startDay datetime, @endDay datetime
as
begin
	select * from tiendo
	where maNV = @maNV
	and datediff(dd,ngaybatdauquydinh,@startDay) > 0
	and datediff(dd,ngayketthucquydinh, @endDay) > 0
end

------------------end lấy danh sách tiến độ theo dõi công việc được phân công cho nhân viên-----------------------

------------------Begin lấy danh sách tiến độ đã hoàn thành------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDaHoanThanh')
drop proc sp_layTDDaHoanThanh
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đã hoàn thành.
--Input: Không có.
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDaHoanThanh
as
begin
	select * from tiendo
	where ngayketthucthucte is not null
end

------------------End lấy danh sách tiến độ đã hoàn thành------------------------------------------------------

------------------Begin lấy danh sách tiến độ đã hoàn thành của một đợt thi------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDaHoanThanhCuaMotDotThi')
drop proc sp_layTDDaHoanThanhCuaMotDotThi
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đã hoàn thành trong một đợt thi bất kỳ.
--Input: Mã đợt thi
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDaHoanThanhCuaMotDotThi
@maDT int
as
begin
	select * from tiendo
	where ngayketthucthucte is not null
	and maDT = @maDT
end

------------------End lấy danh sách tiến độ đã hoàn thành của một đợt thi------------------------------------------------------

------------------Begin lấy danh sách tiến độ đã hoàn thành của một nhân viên------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDaHoanThanhCuaMotNhanVien')
drop proc sp_layTDDaHoanThanhCuaMotNhanVien
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đã hoàn thành của một nhân viên
--Input: Mã nhân viên
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDaHoanThanhCuaMotNhanVien
@maNV int
as
begin
	select * from tiendo
	where ngayketthucthucte is not null
	and maNV = @maNV
end

------------------End lấy danh sách tiến độ đã hoàn thành của một nhân vien------------------------------------------------------

------------------Begin lấy danh sách tiến độ đang diễn ra của tất cả các đợt thi------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDangDienRa')
drop proc sp_layTDDangDienRa
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đang diễn ra của tất cả các đợt thi
--Input: Không có.
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDangDienRa
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is not null
end

------------------End lấy danh sách tiến độ đang diễn ra của tất cả các đợt thi------------------------------------------------------

------------------Begin lấy danh sách tiến độ đang diễn ra của một đợt thi------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDangDienRa')
drop proc sp_layTDDangDienRa
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đang
--Input: Không có
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDangDienRa
@maDT int
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is not null
end

------------------End lấy danh sách tiến độ đang diễn ra của một đợt thi------------------------------------------------------

------------------Begin lấy danh sách tiến độ đang diễn ra của công việc phân công cho một nhân viên----------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDDangDienRaCuaMotNhanVien')
drop proc sp_layTDDangDienRaCuaMotNhanVien
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc đang diễn ra và được phân công cho một nhân viên bất kỳ
--Input: mã nhân viên.
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDDangDienRaCuaMotNhanVien
@maNV int
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is not null
	and maNV = @maNV
end

------------------Begin lấy danh sách tiến độ đang diễn ra của công việc phân công cho một nhân viên----------------------------


------------------Begin lấy danh sách tiến độ sắp diễn ra------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDSapDienRa')
drop proc sp_layTDSapDienRa
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc sắp diễn ra
--Input: Không có
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDSapDienRa
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is  null
end

------------------End lấy danh sách tiến độ của các công việc sắp diễn ra------------------------------------------------------


------------------Begin lấy danh sách tiến độ sắp diễn ra của một đợt thi------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDSapDienRaCuaMotDotThi')
drop proc sp_layTDSapDienRaCuaMotDotThi
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc sắp diễn ra của một đợt thi cụ thể
--Input: mã đợt thi
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDSapDienRaCuaMotDotThi
@maDT int
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is  null
	and maDT = @maDT
end

------------------End lấy danh sách tiến độ của các công việc sắp diễn ra  của một đợt thi cụ thể------------------------------------------------------


------------------Begin lấy danh sách tiến độ sắp diễn ra của các công việc phân công cho một nhân viên------------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_layTDSapDienRaCuaMotNhanVien')
drop proc sp_layTDSapDienRaCuaMotNhanVien
Go
--lấy toàn bộ thông tin theo dõi tiến độ của các công việc được phân công cho một nhân viên
-- và chưa diễn ra.
--Input: mã nhân viên
--Output: danh sách thể hiện tiến độ phù hợp
create proc sp_layTDSapDienRaCuaMotNhanVien
@maNV int
as
begin
	select * from tiendo
	where ngayketthucthucte is  null
	and ngaybatdauthucte is  null
	and maNV = @maNV
end

------------------Begin lấy danh sách tiến độ sắp diễn ra của các công việc phân công cho một nhân viên------------------------------------------------------

------------------Begin Bắt đầu một công việc-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_batDauCongViec')
drop proc sp_batDauCongViec
Go
--Bắt đầu thực hiện một công việc
--Input: 
--Output: 
create proc sp_batDauCongViec
@maTD int
as
begin
	if(not exists(select * from tiendo where maTD = @maTD))
		return;
	update tiendo
	set ngayBatDauThucTe = getdate(),
	khoiLuongCVHT = 0
	where maTD = @maTD
end

------------------end bắt đầu một công việc-----------------------

------------------Begin kết thúc một công việc-----------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_ketThucCongViec')
drop proc sp_ketThucCongViec
Go
--Kết thúc việc thực hiện một công việc
--Input: 
--Output: 
create proc sp_ketThucCongViec
@maTD int
as
begin
	if(not exists(select * from tiendo where maTD = @maTD))
		return;
	update tiendo
	set ngayKetThucThucTe = getdate(),
	khoiLuongCVHT = tongKhoiLuongCV
	where maTD = @maTD
end

------------------end kết thúc một công việc-----------------------
