
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
    /// đối tượng dữ liệu Ghi Chú.
    /// Một thể hiện ghi chú ứng với một thể hiện tiến độ nào đó.
    /// </summary>
public class DtoGhiChu
{
    /// <summary>
    /// tạo thể hiện ghi chú mới.
    /// </summary>
	public DtoGhiChu()
	{
        GHICHU = "";
	}
	private int mmaGC ;

    /// <summary>
    /// mã ghi chú.
    /// </summary>
	public int MAGC 

	{
		get { return mmaGC ; }

		set { mmaGC = value ; }
	}

	private string mGhiChu ;

    /// <summary>
    /// Nội dung ghi chú.
    /// </summary>
	public string GHICHU 

	{
		get { return mGhiChu ; }

		set { mGhiChu = value ; }
	}

	private int mmaTD ;

    /// <summary>
    /// mã tiến độ.
    /// </summary>
	public int MATD 

	{
		get { return mmaTD ; }

		set { mmaTD = value ; }
	}

}

}
