
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoTrachNhiem
{

	public DtoTrachNhiem()
	{
	}
	private int mmaTN ;


	public int MATN 

	{
		get { return mmaTN ; }

		set { mmaTN = value ; }
	}

	private string mtenTN ;


	public string TENTN 

	{
		get { return mtenTN ; }

		set { mtenTN = value ; }
	}

	private int mthuTuCongViec ;


	public int THUTUCONGVIEC 

	{
		get { return mthuTuCongViec ; }

		set { mthuTuCongViec = value ; }
	}

	private int mngayBatDauQuyDinh ;


	public int NGAYBATDAUQUYDINH 

	{
		get { return mngayBatDauQuyDinh ; }

		set { mngayBatDauQuyDinh = value ; }
	}

	private int mngayKetThucQuyDinh ;


	public int NGAYKETTHUCQUYDINH 

	{
		get { return mngayKetThucQuyDinh ; }

		set { mngayKetThucQuyDinh = value ; }
	}

}

}
