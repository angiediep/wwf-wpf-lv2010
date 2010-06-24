
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
/// Đối tượng dữ liệu Nhân viên thừa hành.
/// </summary>
public class DtoNhanVienThuaHanh
{
    /// <summary>
    /// tạo thể hiện nhân viên thừa hành mới.
    /// </summary>
	public DtoNhanVienThuaHanh()
	{
        TENNV = "";
        TENDANGNHAP = "";
        MATKHAU = "";
        SALT = 0;
        EMAIL = "";
        DIENTHOAI = "";
	}
	private int mmaNV ;

    /// <summary>
    /// mã nhân viên.
    /// </summary>
	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

	private string mtenDangNhap ;

    /// <summary>
    /// tên đăng nhập hệ thống
    /// </summary>
	public string TENDANGNHAP 

	{
		get { return mtenDangNhap ; }

		set { mtenDangNhap = value ; }
	}

	private string mmatKhau ;

    /// <summary>
    /// mật khẩu đăng nhập hệ thống.
    /// </summary>
	public string MATKHAU 

	{
		get { return mmatKhau ; }

		set { mmatKhau = value ; }
	}

	private int mSALT ;

    /// <summary>
    /// mã SALT dùng cho việc mã hóa mật khẩu.
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

	private string mtenNV ;

    /// <summary>
    /// tên đầy đủ của nhân viên thừa hành
    /// </summary>
	public string TENNV 

	{
		get { return mtenNV ; }

		set { mtenNV = value ; }
	}

	private string mdienThoai ;

    /// <summary>
    /// điện thoại liên lạc
    /// </summary>
	public string DIENTHOAI 

	{
		get { return mdienThoai ; }

		set { mdienThoai = value ; }
	}

}

}
