use QuyTrinhThiDB
--NhanVienThuaHanh
delete from NhanVienThuaHanh
DBCC CHECKIDENT(NhanVienThuaHanh, RESEED, 0)

insert into NhanVienThuaHanh values('dhminh',	'x?v????W???a??\??j',	873021908,	'dhminh@gmail.com',	N'Đào Hoàng Minh',	'12345678')
insert into NhanVienThuaHanh values('dhyen',	'x?v????W???a??\??j',	873021908,	'dhyen@gmail.com',	N'Đỗ Hải Yến',	'12345678')
insert into NhanVienThuaHanh values('lvan',	'x?v????W???a??\??j',	873021908,	'lvan@gmail.com',	N'Lê Văn An',	'12345678')
insert into NhanVienThuaHanh values('nhai',	'x?v????W???a??\??j',	873021908,	'nhai@gmail.com',	N'nguyễn Hữu Ái',	'12345678')
insert into NhanVienThuaHanh values('dttan',	'x?v????W???a??\??j',	873021908,	'dttan@gmail.com',	N'Đào trọng tấn',	'12345678')
insert into NhanVienThuaHanh values('tvky',	'x?v????W???a??\??j',	873021908,	'tvky@gmail.com',	N'Trương Vĩnh Ký',	'12345678')
insert into NhanVienThuaHanh values('lvlang',	'x?v????W???a??\??j',	873021908,	'lvlang@gmail.com',	N'Lê Văn Lang',	'12345678')
insert into NhanVienThuaHanh values('tnga',	'x?v????W???a??\??j',	873021908,	'tnga@gmail.com',	N'Trần Ngà',	'12345678')
insert into NhanVienThuaHanh values('tdainghia',	'x?v????W???a??\??j',	873021908,	'tdnghia@gmail.com',	N'Trần Đại Nghĩa',	'12345678')
insert into NhanVienThuaHanh values('lthu',	'x?v????W???a??\??j',	873021908,	'lthu@gmail.com',	N'Lê Thu',	'12345678')
insert into NhanVienThuaHanh values('lnhi',	'x?v????W???a??\??j',	873021908,	'lnhi@gmail.com',	N'Lê Nhi',	'12345678')
insert into NhanVienThuaHanh values('nhnam1',	'x?v????W???a??\??j',	873021908,	'nhnam1@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam2',	'x?v????W???a??\??j',	873021908,	'nhnam2@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam3',	'x?v????W???a??\??j',	873021908,	'nhnam3@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam4',	'x?v????W???a??\??j',	873021908,	'nhnam4@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam5',	'x?v????W???a??\??j',	873021908,	'nhnam5@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam6',	'x?v????W???a??\??j',	873021908,	'nhnam6@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam7',	'x?v????W???a??\??j',	873021908,	'nhnam7@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam8',	'x?v????W???a??\??j',	873021908,	'nhnam8@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam9',	'x?v????W???a??\??j',	873021908,	'nhnam9@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam10',	'x?v????W???a??\??j',	873021908,	'nhnam10@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam11',	'x?v????W???a??\??j',	873021908,	'nhnam11@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam12',	'x?v????W???a??\??j',	873021908,	'nhnam12@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam13',	'x?v????W???a??\??j',	873021908,	'nhnam13@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
insert into NhanVienThuaHanh values('nhnam14',	'x?v????W???a??\??j',	873021908,	'nhnam14@gmail.com',	N'Nguyễn Hoàng Nam',	'12345678')
--QuanLy
delete from QuanLy
insert into QuanLy values('pnquan',	'x?v????W???a??\??j',	873021908,	'pnquan@gmail.com')




--CongViec
delete from CongViec
DBCC CHECKIDENT(CongViec, RESEED, 0)

Insert into CongViec values('NhanHoSo',-21,-4,N'Nhận hồ sơ')
Insert into CongViec values('PhanCongCoiThi',-7,-4,N'Phân công coi thi')
Insert into CongViec values('LapDanhSachThi',-21,-2,N'Lập danh sách thi')
Insert into CongViec values('ChuanBiDeThi',-7,-4,N'Chuẩn bị đề thi')
Insert into CongViec values('ChuanBiHoSoThi',-3,-2,N'Chuẩn bị hồ sơ thi')
Insert into CongViec values('PhanCongChamThi',-21,-4,N'Phân công chấm thi')
Insert into CongViec values('Thi',0,0,N'Thi')
Insert into CongViec values('ChamThi',1,7,N'Chấm thi')
Insert into CongViec values('KiemTraDiemThi',8,12,N'Kiểm tra điểm thi')
Insert into CongViec values('NopBangDiemGoc',12,12,N'Nộp bảng điểm gốc')
Insert into CongViec values('CongBoDiem',13,13,N'Công bố điểm')
Insert into CongViec values('NhanDangKyPhucKhao',13,17,N'Nhận đăng ký phúc khảo')
Insert into CongViec values('ChamPhucKhao',18,18,N'Chấm phúc khảo')
Insert into CongViec values('CongBoKetQuaPhucKhao',19,19,N'Công bố kết quả phúc khảo')
Insert into CongViec values('LapDanhSachCapCC',14,14,N'lập danh sách cấp chứng chỉ')
Insert into CongViec values('LapCongVanMuaPhoi',15,15,N'Lập Công văn mua phôi')
Insert into CongViec values('TrinhKy',16,19,N'Trình ký')
Insert into CongViec values('GuiCongVanRaBoGD',19,19,N'Gửi công văn ra bộ giáo dục')
Insert into CongViec values('ChoMuaPhoiCC',20,40,N'Chờ mua phôi chứng chỉ')
Insert into CongViec values('InChungChi',41,42,N'In chứng chỉ')
Insert into CongViec values('KyVaDongDau',43,45,N'Ký và đóng dấu')

--PhanCong
delete from PhanCong
insert into PhanCong values(1,2,'01/01/2008',Null)
insert into PhanCong values(2,1,'01/01/2008',Null)
insert into PhanCong values(3,3,'01/01/2008',Null)
insert into PhanCong values(4,4,'01/01/2008',Null)
insert into PhanCong values(5,5,'01/01/2008',Null)
insert into PhanCong values(6,6,'01/01/2008',Null)
insert into PhanCong values(7,7,'01/01/2008',Null)
insert into PhanCong values(8,8,'01/01/2008',Null)
insert into PhanCong values(9,9,'01/01/2008',Null)
insert into PhanCong values(10,10,'01/01/2008',Null)
insert into PhanCong values(11,11,'01/01/2008',Null)
insert into PhanCong values(12,1,'01/01/2008',Null)
insert into PhanCong values(13,2,'01/01/2008',Null)
insert into PhanCong values(14,3,'01/01/2008',Null)
insert into PhanCong values(15,4,'01/01/2008',Null)
insert into PhanCong values(16,5,'01/01/2008',Null)
insert into PhanCong values(17,6,'01/01/2008',Null)
insert into PhanCong values(18,7,'01/01/2008',Null)
insert into PhanCong values(19,8,'01/01/2008',Null)
insert into PhanCong values(20,9,'01/01/2008',Null)
insert into PhanCong values(21,10,'01/01/2008',Null)
insert into PhanCong values(5,10,'01/01/2008',Null)
insert into PhanCong values(4,1,'01/01/2008',Null)

--Chứng chỉ
delete from ChungChi
DBCC CHECKIDENT(ChungChi, RESEED, 0)

insert into ChungChi values(N'Tin học căn bản')
insert into ChungChi values(N'Tin học A Quốc Gia')
insert into ChungChi values(N'Tin học B Quốc Gia')
insert into ChungChi values(N'Tin học C Quốc Gia')
insert into ChungChi values(N'Mạng Căn bản')
insert into ChungChi values(N'CCAN')
insert into ChungChi values(N'Kỹ Thuật Viên')
insert into ChungChi values(N'Chuyên viên testing')
insert into ChungChi values(N'Lập trình Oracle')
insert into ChungChi values(N'Lập trình Microsoft')
insert into ChungChi values(N'CSDL Microsoft')
insert into ChungChi values(N'Chứng chỉ mạng Microsoft')
insert into ChungChi values(N'Chứng chỉ mạng Cisco')
insert into ChungChi values(N'Chứng chỉ NetMasters')

--Đợt thi
delete from DotThi
DBCC CHECKIDENT(DotThi, RESEED, 0)
delete from tiendo
DBCC Checkident(TIenDo,Reseed, 0)
declare @kq int 
declare @id int
exec sp_themDotThi N'Đợt thi hè 2000','01/01/2011','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2000','06/06/2000','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2000','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2000','10/11/2000','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2000','11/12/2000','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2001','02/01/2000','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2001','04/02/2001','275', NULL, @kq out, @id out


exec sp_themDotThi N'Đợt thi hè 2001','05/04/2001','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2001','06/06/2001','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2001','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2001','10/11/2001','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2001','11/12/2001','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2002','02/01/2001','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2002','04/02/2002','275', NULL, @kq out, @id out

exec sp_themDotThi N'Đợt thi hè 2002','05/04/2002','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2002','06/06/2002','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2002','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2002','10/11/2002','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2002','11/12/2002','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2003','02/01/2002','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2003','04/02/2003','275', NULL, @kq out, @id out

exec sp_themDotThi N'Đợt thi hè 2004','05/04/2004','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2004','06/06/2004','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2004','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2004','10/11/2004','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2004','11/12/2004','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2005','02/01/2004','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2005','04/02/2005','275', NULL, @kq out, @id out

exec sp_themDotThi N'Đợt thi hè 2009','05/04/2009','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2009','06/06/2009','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2009','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2009','10/11/2009','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2009','11/12/2009','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2010','02/01/2009','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2010','04/02/2010','275', NULL, @kq out, @id out


exec sp_themDotThi N'Đợt thi hè 2010','05/04/2010','1000', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi tin học A Quốc Gia 2010','06/06/2010','300', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên tin học và mạng máy tính','07/08/2010','178', NULL, @kq out, @id out
exec sp_themDotThi N'Lập trình viên quốc tế khóa 2, 2010','10/11/2010','200', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi phổ cập tin học cho công nhân 2010','11/12/2010','1180', NULL, @kq out, @id out
exec sp_themDotThi N'Đợt thi hướng nghiệp cho học sinh phổ thông 2011','02/01/2010','2000', NULL, @kq out, @id out
exec sp_themDotThi N'Chuyên viên mạng Cisco 2011','04/02/2011','275', NULL, @kq out, @id out

update dotthi set workflowInstanceID = ''

--DotThi-ChungChi
delete from DotThi_ChungChi
insert into DotThi_ChungChi values(1,1,100)
insert into DotThi_ChungChi values(1,2,500)
insert into DotThi_ChungChi values(1,3,300)
insert into DotThi_ChungChi values(1,4,100)
insert into DotThi_ChungChi values(2,2,300)
insert into DotThi_ChungChi values(3,5,100)
insert into DotThi_ChungChi values(3,7,78)
insert into DotThi_ChungChi values(4,7,30)
insert into DotThi_ChungChi values(4,8,80)
insert into DotThi_ChungChi values(4,10,90)
insert into DotThi_ChungChi values(5,1,708)
insert into DotThi_ChungChi values(5,5,300)
insert into DotThi_ChungChi values(5,2,100)
insert into DotThi_ChungChi values(6,1,2000)
insert into DotThi_ChungChi values(7,13,275)

insert into DotThi_ChungChi values(8,1,100)
insert into DotThi_ChungChi values(8,2,500)
insert into DotThi_ChungChi values(8,3,300)
insert into DotThi_ChungChi values(8,4,100)
insert into DotThi_ChungChi values(9,2,300)
insert into DotThi_ChungChi values(10,5,100)
insert into DotThi_ChungChi values(10,7,78)
insert into DotThi_ChungChi values(11,7,30)
insert into DotThi_ChungChi values(11,8,80)
insert into DotThi_ChungChi values(11,10,90)
insert into DotThi_ChungChi values(12,1,708)
insert into DotThi_ChungChi values(12,5,300)
insert into DotThi_ChungChi values(12,2,100)
insert into DotThi_ChungChi values(13,1,2000)
insert into DotThi_ChungChi values(14,13,275)

insert into DotThi_ChungChi values(15,1,100)
insert into DotThi_ChungChi values(15,2,500)
insert into DotThi_ChungChi values(15,3,300)
insert into DotThi_ChungChi values(15,4,100)
insert into DotThi_ChungChi values(16,2,300)
insert into DotThi_ChungChi values(17,5,100)
insert into DotThi_ChungChi values(17,7,78)
insert into DotThi_ChungChi values(18,7,30)
insert into DotThi_ChungChi values(18,8,80)
insert into DotThi_ChungChi values(18,10,90)
insert into DotThi_ChungChi values(19,1,708)
insert into DotThi_ChungChi values(19,5,300)
insert into DotThi_ChungChi values(19,2,100)
insert into DotThi_ChungChi values(20,1,2000)
insert into DotThi_ChungChi values(21,13,275)

insert into DotThi_ChungChi values(22,1,100)
insert into DotThi_ChungChi values(22,2,500)
insert into DotThi_ChungChi values(22,3,300)
insert into DotThi_ChungChi values(22,4,100)
insert into DotThi_ChungChi values(23,2,300)
insert into DotThi_ChungChi values(24,5,100)
insert into DotThi_ChungChi values(24,7,78)
insert into DotThi_ChungChi values(25,7,30)
insert into DotThi_ChungChi values(25,8,80)
insert into DotThi_ChungChi values(25,10,90)
insert into DotThi_ChungChi values(26,1,708)
insert into DotThi_ChungChi values(26,5,300)
insert into DotThi_ChungChi values(26,2,100)
insert into DotThi_ChungChi values(27,1,2000)
insert into DotThi_ChungChi values(28,13,275)

insert into DotThi_ChungChi values(29,1,100)
insert into DotThi_ChungChi values(29,2,500)
insert into DotThi_ChungChi values(29,3,300)
insert into DotThi_ChungChi values(29,4,100)
insert into DotThi_ChungChi values(30,2,300)
insert into DotThi_ChungChi values(31,5,100)
insert into DotThi_ChungChi values(31,7,78)
insert into DotThi_ChungChi values(32,7,30)
insert into DotThi_ChungChi values(32,8,80)
insert into DotThi_ChungChi values(32,10,90)
insert into DotThi_ChungChi values(33,1,708)
insert into DotThi_ChungChi values(33,5,300)
insert into DotThi_ChungChi values(33,2,100)
insert into DotThi_ChungChi values(34,1,2000)
insert into DotThi_ChungChi values(35,13,275)

insert into DotThi_ChungChi values(36,1,100)
insert into DotThi_ChungChi values(36,2,500)
insert into DotThi_ChungChi values(36,3,300)
insert into DotThi_ChungChi values(36,4,100)
insert into DotThi_ChungChi values(37,2,300)
insert into DotThi_ChungChi values(38,5,100)
insert into DotThi_ChungChi values(38,7,78)
insert into DotThi_ChungChi values(39,7,30)
insert into DotThi_ChungChi values(39,8,80)
insert into DotThi_ChungChi values(39,10,90)
insert into DotThi_ChungChi values(40,1,708)
insert into DotThi_ChungChi values(40,5,300)
insert into DotThi_ChungChi values(40,2,100)
insert into DotThi_ChungChi values(41,1,2000)



--TIến độ
update tiendo set ngayBatDauThucTe = ngayBatDauQuyDinh, 
				ngayKetthucThucTe = ngayKetThucQuyDinh,
				tongKhoiLuongCV = soLuongThiSinh,
				khoiluongCVHT = soLuongThiSinh
from dotthi
where tienDo.maDT = dotTHi.maDT



--GhiChu
delete from ghiChu
declare @i int 
declare @len int 
set @i = 1
set @len = (select count(*) from tiendo)
while (@i <= @len)
begin
	if((@i % 2) = 1)
		insert into GhiChu values(N'
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú 
Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú Ghi chú ', @i);
	set @i = @i + 1;
end

--Thongbao
delete from thongbao
DBCC CHECKIDENT(NhanVienThuaHanh, RESEED, 0)

declare @numOfTienDo int, @j int
set @numOfTienDo = (select count(*) from tiendo);
set @j = 1;
while (@j <= @numOfTienDo)
begin
	insert into ThongBao values(N'
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo 
Thông báo Thông báo Thông báo Thông báo Thông báo Thông báo ',
	@j,1);
	set @j = @j + 1;
end

select * from nhanvienthuahanh
select * from congviec
select * from phancong
select * from dotthi
select * from chungchi
select * from dotthi_chungchi
select * from tiendo
select * from ghichu
select * from thongbao
