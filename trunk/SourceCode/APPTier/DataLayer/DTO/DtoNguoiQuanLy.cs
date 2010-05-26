
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoNguoiQuanLy
{

	public DtoNguoiQuanLy()
	{
	}
	private string mtenDangNhap ;


	public string TENDANGNHAP 

	{
		get { return mtenDangNhap ; }

		set { mtenDangNhap = value ; }
	}

	private string mmatKhau ;


	public string MATKHAU 

	{
		get { return mmatKhau ; }

		set { mmatKhau = value ; }
	}

	private int mSALT ;


	public int SALT 

	{
		get { return mSALT ; }

		set { mSALT = value ; }
	}

	private string memail ;


	public string EMAIL 

	{
		get { return memail ; }

		set { memail = value ; }
	}

}

}
