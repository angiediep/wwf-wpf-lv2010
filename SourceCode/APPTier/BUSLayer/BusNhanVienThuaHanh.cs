
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
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
    /// This method provides function 'login' for NhanVienThuaHanh.
    /// </summary>
    /// <param name="strUsername">the login name.</param>
    /// <param name="strPassword">the password</param>
    /// <returns>true:  login success.
    ///         false: login fail.</returns>
    public bool login(String strUsername, String strPassword)
    {
        if (null == strUsername || null == strPassword)
            return false;
        if (0 == strUsername.Trim().Length || 0 == strPassword.Trim().Length)
            return false;
        //remove the SQL Injection.
        strUsername.Replace('\'',' ');
        strPassword.Replace('\'', ' ');

        DaoNhanVienThuaHanh daoNhanVienThuaHanh = new DaoNhanVienThuaHanh();
        return daoNhanVienThuaHanh.login(strUsername, strPassword);
    }
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
	public List<DtoNhanVienThuaHanh> getListDataBymatKhau(string matKhau)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBySALT(int SALT)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
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
        if (users.Count != 0 || quanlys.Count != 0)
        {
            return -1;
        }
        //Kiểm tra sự tồn tại của địa chỉ email trong hệ thống:
        users = getListDataByemail(data.EMAIL);
        quanlys = busQuanLy.getDataList();
        if (users.Count != 0 || quanlys.Count != 0)
        {
            return -2;
        }

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
	public bool deleteData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
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
	public bool deleteDataBymatKhau(string matKhau)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBymatKhau(matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBySALT(int SALT)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBySALT(SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
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
	public bool deleteDataBytenNV(string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenNV(tenNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBydienThoai(string dienThoai)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBydienThoai(dienThoai);
		}
		catch
		{
			return false;
		}
		return true;
	}
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
	public bool updateDataBymatKhau(DtoNhanVienThuaHanh data,string matKhau)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoNhanVienThuaHanh data,int SALT)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBySALT(data,SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
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
	public bool updateDataBytenNV(DtoNhanVienThuaHanh data,string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenNV(data,tenNV);
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
