
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using DataLayer.DAO;
using DataLayer.DTO;
namespace BUSLayer
{
public class BusNhanVienThuaHanh
{

	public BusNhanVienThuaHanh()
	{
	}
	#region "ExportFile" 
    /// <summary>
    /// đăng nhập hệ thống cho đối tượng nhân viên thừa hành.
    /// </summary>
    /// <param name="strUsername">tên đăng nhập</param>
    /// <param name="strPassword">mật khẩu đăng nhập</param>
    /// <returns>true:  đăng nhập thành công.
    ///         false: đăng nhập thất bại.</returns>
    public bool login(String strUsername, String strPassword)
    {
        if (null == strUsername || null == strPassword)
            return false;
        if (0 == strUsername.Trim().Length || 0 == strPassword.Trim().Length)
            return false;
        //remove the SQL Injection.
        strUsername.Replace('\'', ' ');
        strPassword.Replace('\'', ' ');

        DaoNhanVienThuaHanh daoNhanVienThuaHanh = new DaoNhanVienThuaHanh();
        return daoNhanVienThuaHanh.login(strUsername, strPassword);
    }
    /// <summary>
    /// lấy thông tin nhân viên thừa hành với mã nhân viên cho trước
    /// </summary>
    /// <param name="Id">mã nhân viên thừa hành</param>
    /// <returns></returns>
	public DtoNhanVienThuaHanh getDataById(int Id)
	{
		DtoNhanVienThuaHanh data = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			data = dNhanVienThuaHanh.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
    /// <summary>
    /// lấy thông tin nhân viên thừa hành khi biết tên đăng nhập
    /// </summary>
    /// <param name="tenDangNhap">tên đăng nhập hệ thống</param>
    /// <returns></returns>
	public List<DtoNhanVienThuaHanh> getListDataBytenDangNhap(string tenDangNhap)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenDangNhap(tenDangNhap);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy thông tin nhân viên thừa hành khi biết email.
    /// </summary>
    /// <param name="email">địa chỉ email</param>
    /// <returns></returns>
	public List<DtoNhanVienThuaHanh> getListDataByemail(string email)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataByemail(email);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy thông tin nhân viên thừa hành khi biết họ tên nhân viên thừa hành.
    /// </summary>
    /// <param name="tenNV">họ và tên nhân viên thừa hành</param>
    /// <returns></returns>
	public List<DtoNhanVienThuaHanh> getListDataBytenNV(string tenNV)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenNV(tenNV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ nhân viên thừa hành.
    /// </summary>
    /// <returns></returns>
	public List<DtoNhanVienThuaHanh> getDataList()
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ nhân viên thừa hành có sắp xếp.
    /// </summary>
    /// <param name="col">thứ tự cột cần sắp xếp</param>
    /// <param name="flag">true: sắp tăng
    /// false: sắp giảm.</param>
    /// <returns></returns>
	public List<DtoNhanVienThuaHanh> getDataListSortBy(string col, bool flag)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// Thêm mới một nhân viên thừa hành.
    /// </summary>
    /// <param name="data">Đối tượng chứa thông tin nhân viên cần đăng ký</param>
    /// <returns>Id > 0: thêm thành công.
    ///         ID == -1: tên đăng nhập đã tồn tại trong hệ thống.
    ///         ID == -2: Địa chỉ email đã tồn tại trong hệ thống.
    ///         ID == 0: Thêm không thành công, lỗi không xác định.</returns>
    public int insertData(DtoNhanVienThuaHanh data)
    {
        //Kiểm tra sự tồn tại của tên đăng nhập trong hệ thống:
        BusQuanLy busQuanLy = new BusQuanLy();
        List<DtoNhanVienThuaHanh> users = getListDataBytenDangNhap(data.TENDANGNHAP);
        List<DtoQuanLy> quanlys = busQuanLy.getDataList();
        if (users.Count != 0)
        {
            return -1;
        }
        if (quanlys.Count > 0 && quanlys[0].TENDANGNHAP.Equals(data.TENDANGNHAP))
            return -1;
        //Kiểm tra sự tồn tại của địa chỉ email trong hệ thống:
        users = getListDataByemail(data.EMAIL);
        if (users.Count != 0)
        {
            return -2;
        }
        if (quanlys.Count > 0 && quanlys[0].EMAIL.Equals(data.EMAIL))
            return -2;
        try
        {
            DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
            return dNhanVienThuaHanh.insertData(data);
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Xóa nhân viên
    /// </summary>
    /// <param name="data">Nhân viên cần xóa</param>
    /// <returns>0: Xóa không thành công. Lỗi k xác định.
    /// 1: Xóa thành công.
    /// -1:Xóa không thành công. Nhân viên cần xóa có tham gia vào các đợt thi nào đó.</returns>
    public int deleteData(DtoNhanVienThuaHanh data)
    {
        DaoPhanCong daoPhanCong = new DaoPhanCong();
        List<DtoPhanCong> lst = daoPhanCong.getListDataBymaNV(data.MANV);
        if (lst.Count > 0)
            return -1;
        try
        {
            DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
            dNhanVienThuaHanh.deleteData(data);
        }
        catch
        {
            return 0;
        }
        return 1;
    }
    /// <summary>
    /// xóa nhân viên thừa hành khi biết tên đăng nhập
    /// </summary>
    /// <param name="tenDangNhap">tên đăng nhập</param>
    /// <returns></returns>
    public bool deleteDataBytenDangNhap(string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenDangNhap(tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa nhân viên thừa hành khi biết email.
    /// </summary>
    /// <param name="email">địa chỉ email</param>
    /// <returns></returns>
	public bool deleteDataByemail(string email)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataByemail(email);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// Cập nhật thông tin nhân viên thừa hành.
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <returns></returns>
	public bool updateData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin nhân viên thừa hành với mã nhân viên cho trước.
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <param name="maNV">mã nhân viên</param>
    /// <returns></returns>
	public bool updateDataBymaNV(DtoNhanVienThuaHanh data,int maNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymaNV(data,maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin nhân viên thừa hành khi biết tên đăng nhập
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="tenDangNhap">tên đăng nhập</param>
    /// <returns></returns>
	public bool updateDataBytenDangNhap(DtoNhanVienThuaHanh data,string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenDangNhap(data,tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin nhân viên thừa hành khi biết địa chỉ email.
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="email">địa chỉ email.</param>
    /// <returns></returns>
    public bool updateDataByemail(DtoNhanVienThuaHanh data,string email)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataByemail(data,email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	
	#endregion
}

}
