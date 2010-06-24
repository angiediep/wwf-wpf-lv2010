
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
    /// <summary>
    /// đối tượng dữ liệu  Nhân viên Quản Lý
    /// </summary>
public class DtoQuanLy
{
    /// <summary>
    /// tạo thể hiện nhân viên quản lý mới
    /// </summary>
	public DtoQuanLy()
	{
        TENDANGNHAP = "";
        EMAIL = "";
        MATKHAU = "";
        SALT = 0;
	}
	private string mtenDangNhap ;

    /// <summary>
    /// tên đăng nhập hệ thống.
    /// </summary>
	public string TENDANGNHAP 

	{
		get { return mtenDangNhap ; }

		set { mtenDangNhap = value ; }
	}

	private string mmatKhau ;

    /// <summary>
    /// Mật khẩu đăng nhập hệ thống.
    /// </summary>
	public string MATKHAU 

	{
		get { return mmatKhau ; }

		set { mmatKhau = value ; }
	}

	private int mSALT ;

    /// <summary>
    /// mã SALT dùng để mã hóa mật khẩu.
    /// </summary>
	public int SALT 

	{
		get { return mSALT ; }

		set { mSALT = value ; }
	}

	private string memail ;

    /// <summary>
    /// địa chỉ email
    /// </summary>
	public string EMAIL 

	{
		get { return memail ; }

		set { memail = value ; }
	}

}

}
