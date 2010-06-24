
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
    /// Đối tượng dữ liệu Phân Công
    /// </summary>
public class DtoPhanCong
{
    /// <summary>
    /// tạo thể hiện phân công mới.
    /// </summary>
	public DtoPhanCong()
	{
        NGAYAPDUNG = DateTime.MinValue;
        NGAYHETHAN = DateTime.MinValue;
	}
	private int mmaCV ;

    /// <summary>
    /// mã công việc cần phân công.
    /// </summary>
	public int MACV 

	{
		get { return mmaCV ; }

		set { mmaCV = value ; }
	}

	private int mmaNV ;

    /// <summary>
    /// mã nhân viên được phân công.
    /// </summary>
	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

	private DateTime mngayApDung ;

    /// <summary>
    /// Ngày bắt đầu áp dụng phân công.
    /// </summary>
	public DateTime NGAYAPDUNG 

	{
		get { return mngayApDung ; }

		set { mngayApDung = value ; }
	}

	private DateTime mngayHetHan ;

    /// <summary>
    /// ngày hết hiệu lực phân công.
    /// </summary>
	public DateTime NGAYHETHAN 

	{
		get { return mngayHetHan ; }

		set { mngayHetHan = value ; }
	}

}

}
