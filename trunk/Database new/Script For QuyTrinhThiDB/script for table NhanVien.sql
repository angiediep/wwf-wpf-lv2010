---------------------------Begin lay danh sach nhan vien đã hoàn thành công việc--------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSNVHoanThanhCongViec')
drop proc sp_layDSNVHoanThanhCongViec
go
--Lấy danh sách nhân viên đã hoàn thành công việc theo các tiêu chí khác nhau.
--Input: 
----@maDT:
------@maDT = 0: xét trên tất cả các đợt thi.
------@maDT > 0: xét trên một đợt thi cụ thể.
----@tinhTrang:
------@tinhTrang = 0: xét công việc hoàn thành đúng hạn
------@tinhTrang = -1: xét công việc hoàn thành sớm hạn
------@tinhTrang = 1: xét công việc hoàn thành trễ hạn
----@tuNgay, @denNgay = null: không giới hạn thời gian.
----@tuNgay, @denngay != null: chỉ xét các công việc được hoàn thành trong khoảng thời gian này.
--Output: danh sách thể hiện NhanVienThuaHanh phù hợp.

create proc sp_layDSNVHoanThanhCongViec
@maDT int, @tinhTrang int, @tuNgay datetime, @denNgay datetime
as
begin
	if(@maDT < 0) 
		return;--đợt thi k tồn tại.
	if((@tuNgay = null and @denNgay != null) or(@tuNgay != null and @denngay = null))
		return;	--@tuNgay, @denNgay không đồng thời bằng null hoặc khác null.
	if(@tuNgay != null and (datediff(dd,@tuNgay,@denNgay)< 0 or datediff(dd,@tuNgay,getdate()) < 0))
		return;--@tuNgay vượt quá ngày hiện tại hoặc @denNgay.
	if(@denngay != null and datediff(dd,@denNgay,getdate()) < 0)
		return; --@denngay vượt quá ngày hiện tại.
	declare @query nvarchar(4000)
	set @query = '';
	set @query = @query + 'select NV.* from NhanVienThuaHanh as NV, tienDo as TD	
						where NV.maNV = TD.maNV
						and ngayKetThucThucTe is not null '
	
	--Không giới hạn thời gian/có giới hạn?
	if(@tuNgay is not null)
		set @query = @query +' and datediff(dd,''' + cast(@tuNgay as nvarchar(100))+ ''' ,ngayketthucthucte) >= 0
								 and datediff(dd,''' + cast(@denNgay as nvarchar(100))+ ''', ngayketthucthucte)<= 0 '
	--xét mọi đợt thi/xét một đợt thi cụ thể.?
	if(@maDT > 0)
		set @query = @query + ' and TD.maDT = ' + cast(@maDT as varchar(2))
	--đúng hạn/sớm hạn/trễ hạn.?
	if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) = 0 '
	else
		if(@tinhTrang = -1)
			set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) < 0 '
		else
			set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) > 0 '
	exec (@query)
end
---------------------------End lấy danh sách công việc đã hoàn thành công việc-----------------------------------------

---------------------------Begin lay danh sach nhan vien đã bắt đầu công việc--------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_layDSNVBatDauCongViec')
drop proc sp_layDSNVBatDauCongViec
go
--Lấy danh sách nhân viên đã bắt đầu công việc theo các tiêu chí khác nhau.
--Input: 
----@maDT:
------@maDT = 0: xét trên tất cả các đợt thi.
------@maDT > 0: xét trên một đợt thi cụ thể.
----@tinhTrang:
------@tinhTrang = 0: xét công việc bắt đầu đúng hạn
------@tinhTrang = -1: xét công việc bắt đầu sớm hạn
------@tinhTrang = 1: xét công việc bắt đầu trễ hạn
----@tuNgay, @denNgay = null: không giới hạn thời gian.
----@tuNgay, @denngay != null: chỉ xét các công việc được bắt đầu trong khoảng thời gian này.
--Output: danh sách thể hiện NhanVienThuaHanh phù hợp.

create proc sp_layDSNVBatDauCongViec
@maDT int, @tinhTrang int, @tuNgay datetime, @denNgay datetime
as
begin
	if(@maDT < 0) 
		return;--đợt thi k tồn tại.
	if((@tuNgay = null and @denNgay != null) or(@tuNgay != null and @denngay = null))
		return;	--@tuNgay, @denNgay không đồng thời bằng null hoặc khác null.
	if(@tuNgay != null and (datediff(dd,@tuNgay,@denNgay)< 0 or datediff(dd,@tuNgay,getdate()) < 0))
		return;--@tuNgay vượt quá ngày hiện tại hoặc @denNgay.
	if(@denngay != null and datediff(dd,@denNgay,getdate()) < 0)
		return; --@denngay vượt quá ngày hiện tại.
		declare @query nvarchar(4000)
	set @query = '';
	set @query = @query + 'select NV.* from NhanVienThuaHanh as NV, tienDo as TD	
						where NV.maNV = TD.maNV
						and ngayBatDauThucTe is not null '
	
	--Không giới hạn thời gian/có giới hạn?
	if(@tuNgay is not null)
		set @query = @query +' and datediff(dd,''' + cast(@tuNgay as nvarchar(100))+ ''' ,ngayBatDauThucTe) >= 0
								 and datediff(dd,''' + cast(@denNgay as nvarchar(100))+ ''', ngayBatDauThucTe)<= 0 '
	--xét mọi đợt thi/xét một đợt thi cụ thể.?
	if(@maDT > 0)
		set @query = @query + ' and TD.maDT = ' + cast(@maDT as varchar(2))
	--đúng hạn/sớm hạn/trễ hạn.?
	if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) = 0 '
	else
		if(@tinhTrang = -1)
			set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) < 0 '
		else
			set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) > 0 '
	exec (@query)
end
---------------------------End lấy danh sách công việc đã bắt đầu công việc-----------------------------------------

---------------------------Begin lấy số lần hoàn thành công việc--------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_laySoLanHoanThanhCongViec')
drop proc sp_laySoLanHoanThanhCongViec
go
--Lấy số lần hoàn thành công việc của một nhân viên theo các tiêu chí khác nhau.
--Input: 
----@maNV: nhân viên hoàn thành công việc.
------@maNV = 0: xét bất kỳ nhân viên nào.
------@maNV > 0: chỉ xét các công việc do một nhân viên cụ thể thực hiện
----@maDT:
------@maDT = 0: xét trên tất cả các đợt thi.
------@maDT > 0: xét trên một đợt thi cụ thể.
----@maCV: 
---------@maCV = 0: bất kỳ công việc nào
---------@maCV > 0: xét trên một công việc cụ thể.
----@tinhTrang:
------@tinhTrang = 0: xét công việc kết thúc đúng hạn
------@tinhTrang = -1: xét công việc kết thúcsớm hạn
------@tinhTrang = 1: xét công việc kết thúc trễ hạn
----@tuNgay, @denNgay = null: không giới hạn thời gian.
----@tuNgay, @denngay != null: chỉ xét các công việc được bắt đầu trong khoảng thời gian này.

--Output: danh sách thể hiện NhanVienThuaHanh phù hợp.
create proc sp_laySoLanHoanThanhCongViec
@maNV int ,@maDT int, @maCV int, @tinhTrang int, @tuNgay datetime, @denNgay datetime
as
begin
	if(@maDT < 0 or @maNV < 0 or @maCV < 0)
		return;
	if((@tuNgay = null and @denNgay != null) or(@tuNgay != null and @denngay = null))
		return;	--@tuNgay, @denNgay không đồng thời bằng null hoặc khác null.
	if(@tuNgay != null and (datediff(dd,@tuNgay,@denNgay)< 0 or datediff(dd,@tuNgay,getdate()) < 0))
		return;--@tuNgay vượt quá ngày hiện tại hoặc @denNgay.
	if(@denngay != null and datediff(dd,@denNgay,getdate()) < 0)
		return; --@denngay vượt quá ngày hiện tại.
	declare @query nvarchar(4000);
	set @query = '';
	set @query = 'select count(*) as Num from  tienDo as TD
					where ngayKetThucThucTe is not null '
	--Xét mọi nhân viên hay một nhân viên cụ thể?
	if(@maNV > 0 )
		set @query = @query + ' and TD.maNV= ' + cast(@maNV as varchar(10))			
	--xét mọi công việc/một công việc cụ thể.
	if(@maDT > 0)
		set @query = @query + ' and TD.maCV = ' + cast(@maCV as varchar(10))

	--xét mọi đợt thi/xét một đợt thi cụ thể.?
	if(@maDT > 0)
		set @query = @query + ' and TD.maDT = ' + cast(@maDT as varchar(10))

	--Không giới hạn thời gian/có giới hạn?
	if(@tuNgay is not null)
		set @query = @query +' and datediff(dd,''' + cast(@tuNgay as nvarchar(100))+ ''' ,ngayketthucthucte) >= 0
								 and datediff(dd,''' + cast(@denNgay as nvarchar(100))+ ''', ngayketthucthucte)<= 0 '
	--đúng hạn/sớm hạn/trễ hạn.?
	if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) = 0 '
	else
		if(@tinhTrang = -1)
			set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) < 0 '
		else
			set @query = @query + ' and datediff(dd,ngayketthucquydinh, ngayketthucthucte) > 0 '
	exec (@query)
end
---------------------------End lấy số lần hoàn thành công việc-----------------------------------------


---------------------------Begin lấy số lần bắt đầu công việc --------------------------------
go
if exists(select * from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' and name = 'sp_laySoLanBatDauCongViec')
drop proc sp_laySoLanBatDauCongViec
go
--Lấy số lần bắt đầu công việc của một nhân viên theo các tiêu chí khác nhau.
--Input: 
----@maNV: nhân viên bắt đầu công việc.
------@maNV = 0: xét bất kỳ nhân viên nào.
------@maNV > 0: chỉ xét các công việc do một nhân viên cụ thể thực hiện
----@maDT:
------@maDT = 0: xét trên tất cả các đợt thi.
------@maDT > 0: xét trên một đợt thi cụ thể.
----@maCV: 
---------@maCV = 0: bất kỳ công việc nào
---------@maCV > 0: xét trên một công việc cụ thể.
----@tinhTrang:
------@tinhTrang = 0: xét công việc bắt đầu đúng hạn
------@tinhTrang = -1: xét công việc bắt đầu sớm hạn
------@tinhTrang = 1: xét công việc bắt đầu trễ hạn
----@tuNgay, @denNgay = null: không giới hạn thời gian.
----@tuNgay, @denngay != null: chỉ xét các công việc được bắt đầu trong khoảng thời gian này.

--Output: danh sách thể hiện NhanVienThuaHanh phù hợp.
create proc sp_laySoLanBatDauCongViec
@maNV int ,@maDT int, @maCV int, @tinhTrang int, @tuNgay datetime, @denNgay datetime
as
begin
	if(@maDT < 0 or @maNV <= 0 or @maCV < 0)
		return;
	if((@tuNgay = null and @denNgay != null) or(@tuNgay != null and @denngay = null))
		return;	--@tuNgay, @denNgay không đồng thời bằng null hoặc khác null.
	if(@tuNgay != null and (datediff(dd,@tuNgay,@denNgay)< 0 or datediff(dd,@tuNgay,getdate()) < 0))
		return;--@tuNgay vượt quá ngày hiện tại hoặc @denNgay.
	if(@denngay != null and datediff(dd,@denNgay,getdate()) < 0)
		return; --@denngay vượt quá ngày hiện tại.
	declare @query nvarchar(4000);
	set @query = '';
	set @query = 'select count(*) as Num from  tienDo as TD
					where ngayBatDauThucTe is not null'
	--Xét mọi nhân viên hay một nhân viên cụ thể?
	if(@maNV > 0 )
		set @query = @query + ' and TD.maNV= ' + cast(@maNV as varchar(10))
	--xét mọi công việc/một công việc cụ thể.
	if(@maDT > 0)
		set @query = @query + ' and TD.maCV = ' + cast(@maCV as varchar(2))

	--xét mọi đợt thi/xét một đợt thi cụ thể.?
	if(@maDT > 0)
		set @query = @query + ' and TD.maDT = ' + cast(@maDT as varchar(2))

	--Không giới hạn thời gian/có giới hạn?
	if(@tuNgay is not null)
		set @query = @query +' and datediff(dd,''' + cast(@tuNgay as nvarchar(100))+ ''' ,ngayBatDauThucTe) >= 0
								 and datediff(dd,''' + cast(@denNgay as nvarchar(100))+ ''', ngayBatDauThucTe)<= 0 '
	--đúng hạn/sớm hạn/trễ hạn.?
	if(@tinhTrang = 0)
		set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) = 0 '
	else
		if(@tinhTrang = -1)
			set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) < 0 '
		else
			set @query = @query + ' and datediff(dd,ngaybatdauquydinh, ngayBatDauThucTe) > 0 '
	exec (@query)


end
---------------------------End lấy số lần bắt đầu công việc-----------------------------------------
