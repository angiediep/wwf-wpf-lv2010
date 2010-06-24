
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
    /// Đối tượng dữ liệu Công Việc
    /// </summary>
public class DtoCongViec
{
    /// <summary>
    /// tạo thể hiện công việc mới.
    /// </summary>
	public DtoCongViec()
	{
        TENCV = "";
        NGAYBATDAU = DateTime.MinValue;
        NGAYKETTHUC = DateTime.MinValue;
        MOTA = "";
	}
	private int mmaCV ;

    /// <summary>
    /// mã công việc.
    /// </summary>
	public int MACV 

	{
		get { return mmaCV ; }

		set { mmaCV = value ; }
	}

	private string mtenCV ;

    /// <summary>
    /// tên công việc
    /// </summary>
	public string TENCV 

	{
		get { return mtenCV ; }

		set { mtenCV = value ; }
	}

	private int mngayBatDau ;

    /// <summary>
    /// ngày bắt đầu công việc
    /// </summary>
	public int NGAYBATDAU 

	{
		get { return mngayBatDau ; }

		set { mngayBatDau = value ; }
	}

	private int mngayKetThuc ;

    /// <summary>
    /// ngày kết thúc công việc
    /// </summary>
	public int NGAYKETTHUC 

	{
		get { return mngayKetThuc ; }

		set { mngayKetThuc = value ; }
	}

	private string mmoTa ;

    /// <summary>
    /// Mô tả về công việc.
    /// </summary>
	public string MOTA 

	{
		get { return mmoTa ; }

		set { mmoTa = value ; }
	}

}

}
