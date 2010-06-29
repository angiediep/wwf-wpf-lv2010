----------------------------------------Begin Thêm đợt thi mới --------------------------------------------------
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'sp_themDotThi')
drop proc sp_themDotThi
Go
--Thêm một đợt thi mới
--kết quả trả về:
--@kq = 0: thêm không thành công. Lỗi không xác định.
--@kq = -1:thêm không thành công. Lỗi ngày thi < ngày hiện hành
--@kq = -2: thêm thành công. Có một số phân công đã hết hạn.
--@id = 0: nếu thêm không thành công.
--@id > 0 : thêm thành công. id là khóa chính của đợt thi vừa thêm.
Create proc sp_themDotThi
@tenDotThi nvarchar(250) ,@ngayThi datetime, @soLuongThiSinh int , @workflowInstanceID nvarchar (250),@kq int out, @id int out
as 
begin
	--Kiem tra dau vao:
	if(@workflowInstanceID like '')
		set @workflowInstanceID = NULL
	declare @maNV int, @maCV int, @ngayApDung datetime, @ngayHetHan datetime, @maDT int
	set @kq = 1;
	insert into DotThi values(@tenDotThi,@ngayThi,@soLuongThiSinh,@workflowInstanceID);
	set @maDT = @@identity
	set @id = @maDT
	--Tạo dữ liệu Tiến độ theo dõi cho đợt thi:
	declare @csrPhanCong cursor;
	set @csrPhanCong = cursor for select * from PhanCong
	open @csrPhanCong
	fetch next from @csrPhanCong into @maCV,@maNV, @ngayApDung, @ngayHetHan
	while(@@fetch_status = 0)
	begin
		declare @ngayBatDauQuyDinh datetime, @ngayKetThucQuyDinh datetime
		set @ngayBatDauQuyDinh = (select @ngayThi + ngayBatDau from CongViec where maCV = @maCV)
		set @ngayKetThucQuyDinh = (select @ngayThi + ngayKetThuc from CongViec where maCV = @maCV)
		if(@ngayHetHan != null and @ngayHetHan <= getdate())
			begin
				insert into TienDo values(0,0,@ngayBatDauQuyDinh,@ngayKetThucQuyDinh,null,null,@maDT,@maCV,null)
				set @kq = -2
			end
		else
			insert into TienDo values(0,0,@ngayBatDauQuyDinh,@ngayKetThucQuyDinh,null,null,@maDT,@maCV,@maNV)
		fetch next from @csrPhanCong into @maCV,@maNV, @ngayApDung, @ngayHetHan
	end
	
End
go
----------------------------------------End Thêm đợt thi mới --------------------------------------------------


---------------------------Begin Lay Danh sach Dot Thi trong 1 khoan thoi gian--------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTTheoThoiGian')
drop proc sp_layDSDTTheoThoiGian
go
--Lấy danh sách đợt thi trong một khoảng thời gian cho trước
--Input: mốc thời gian cần lấy
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTTheoThoiGian
@startDay datetime, @endDay datetime
as
begin
	if(datediff(dd,@endDay,@startDay) > 0)
		return;
	select * from dotthi
	where datediff(	dd,@startDay, ngayThi) >= 0
	and datediff(dd,ngaythi, @endDay) >= 0
end
---------------------------End Lay Danh sach Dot Thi trong 1 khoan thoi gian-----------------------------------------

---------------------------Begin Lay Dot thi theo workflow instance ID-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTTheoWorkflowInstance')
drop proc sp_layDSDTTheoWorkflowInstance
go
--Lấy danh sách đợt thi dựa vào workflowInstanceID đã biết.
--Input: workflow instance id
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTTheoWorkflowInstance
@workflowInstanceID nvarchar(250) 
as
begin
	select * from dotthi
	where @workflowInstanceID like workflowInstanceID
end
---------------------------End Lay Dot thi theo workflow instance ID -------------------------------------------------


---------------------------Begin lay danh sach dot thi tre han-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTTreHan ')
drop proc sp_layDSDTTreHan 
go
--Lấy danh sách đợt thi bị trễ hạn cấp chứng chỉ so với quy định
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTTreHan 
as
begin
	if not exists (select * from congviec where tenCV like 'KyVaDongDau')
		return;
	select Dotthi.* from dotthi,tienDo,congViec
	where dotthi.maDT = tienDo.maDT
	and tienDo.maCV = congviec.macv
	and (datediff(dd,ngayketthucquydinh,ngayketthucthucte) > 0 
			or (datediff(dd,ngayketthucquydinh,getdate()) > 0 
				and ngayKetThucThucTe is null)
		)
	and congviec.tenCV like 'KyVaDongDau'

end
---------------------------End lay danh sach dot thi tre han-------------------------------------------------

---------------------------Begin lay danh sach dot thi có công việc tre han-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTCoCongViecTreHan ')
drop proc sp_layDSDTCoCongViecTreHan 
go
--Lấy danh sách đợt thi bị trễ hạn cấp chứng chỉ so với quy định
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTCoCongViecTreHan 
as
begin
	select * from dotthi
	where maDT in(
		select distinct dotthi.maDT from tiendo, dotthi
		where dotthi.madt = tiendo.madt
	and (datediff(dd,ngayketthucquydinh,ngayketthucthucte) > 0 
			or (datediff(dd,ngayketthucquydinh,getdate()) > 0 
				and ngayKetThucThucTe is null)
		)	)
end
---------------------------End lay danh sach dot thi có công việc tre han-------------------------------------------------

---------------------------Begin lay danh sach dot thi som han-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTSomHan ')
drop proc sp_layDSDTSomHan 
go
--Lấy danh sách đợt thi bị trễ hạn cấp chứng chỉ so với quy định
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTSomHan 
as
begin
	if not exists (select * from congviec where tenCV like 'KyVaDongDau')
		return;
	select Dotthi.* from dotthi,tienDo,congViec
	where dotthi.maDT = tienDo.maDT
	and tienDo.maCV = congviec.macv
	and datediff(dd,ngayketthucquydinh,ngayketthucthucte) < 0
	and congviec.tenCV like 'KyVaDongDau'

end
---------------------------End lay danh sach dot thi som han-------------------------------------------------

---------------------------Begin lay danh sach dot thi có công việc sớm han-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTCoCongViecSomHan ')
drop proc sp_layDSDTCoCongViecSomHan 
go
--Lấy danh sách đợt thi bị trễ hạn cấp chứng chỉ so với quy định
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTCoCongViecSomHan 
as
begin
	select * from dotthi
	where maDT in(
		select distinct dotthi.maDT from tiendo, dotthi
		where dotthi.madt = tiendo.madt
		and datediff(dd,ngayketthucquydinh, ngayketthucthucte) < 0
	)
end
---------------------------End lay danh sach dot thi có công việc sớm han-------------------------------------------------
exec sp_layDSDTDangDienRa

---------------------------Begin lay danh sach dot thi đang diễn ra-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTDangDienRa ')
drop proc sp_layDSDTDangDienRa 
go
--Lấy danh sách đợt thi đang diễn ra
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTDangDienRa 
as
begin
	select * from dotthi
	where --có ít nhất 1 công việc đã được bắt đầu làm 
		exists(select congviec.* from congviec,tiendo 
				where tiendo.maDT = dotthi.maDT
				and tiendo.maCV = congviec.maCV
				and ngaybatdauthucte is not null)
	and --có ít nhất 1 công việc chưa kết thúc.
		exists(select congviec.* from congviec,tiendo
				where tiendo.maDT = dotthi.maDT
				and tiendo.maCV = congviec.maCV
				and ngayketthucthucte is null)
	order by maDT asc
end
---------------------------End lay danh sach dot thi đang diễn ra-------------------------------------------------

---------------------------Begin lay danh sach dot thi đã hoàn thành-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTDaHoanThanh ')
drop proc sp_layDSDTDaHoanThanh 
go
--Lấy danh sách đợt thi đã hoàn thành
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTDaHoanThanh 
as
begin
	select * from dotthi
	where 
		--không còn công việc nào chưa hoàn thành
		not exists(select congviec.* from congviec,tiendo
				where tiendo.maDT = dotthi.maDT
				and tiendo.maCV = congviec.maCV
				and ngayketthucthucte is null)
	order by maDT asc
end
---------------------------End lay danh sach dot thi đã hoàn thành-------------------------------------------------

---------------------------Begin lay danh sach dot thi chưa diễn ra-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTChuaDienRa ')
drop proc sp_layDSDTChuaDienRa 
go
--Lấy danh sách đợt thi chưa diễn ra
--Input: Không có
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTChuaDienRa 
as
begin
	select * from dotthi 
	where 
		--không có công việc nào được bắt đầu
		not exists(select congviec.* from congviec,tiendo
				where tiendo.maDT = dotthi.maDT
				and tiendo.maCV = congviec.maCV
				and ngaybatdauthucte is not null)
	order by maDT asc
end
---------------------------End lay danh sach dot thi chưa diễn ra-------------------------------------------------


---------------------------Begin lay danh sach dot thi theo mã nhân viên-------------------------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSDTTheoMaNV ')
drop proc sp_layDSDTTheoMaNV 

go
--Lấy danh sách đợt thi mà nhân viên có mã @maNV được phân công.
--Input: mã nhân viên
--Output: danh sách thể hiện DotThi phù hợp.
create proc sp_layDSDTTheoMaNV 
@maNV int
as
begin
	select * from dotthi 
	where exists(
		select * from tiendo
		where tiendo.maDT = dotthi.maDT
		and manv = @maNV
	)

end
---------------------------End lay danh sach dot thi theo mã nv-------------------------------------------------
