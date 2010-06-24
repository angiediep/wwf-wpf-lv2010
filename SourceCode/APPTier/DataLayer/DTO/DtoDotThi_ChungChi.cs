
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
/// đối tượng dữ liệu Đợt Thi _ Chứng Chỉ. Đối tượng này thể hiện mối liên kết giữa đợt thi
/// và chứng chỉ sẽ được cấp trong đợt thi đó.
/// </summary>
public class DtoDotThi_ChungChi
{
    /// <summary>
    /// tạo thể hiện đợt thi _ Chứng Chỉ mới.
    /// </summary>
	public DtoDotThi_ChungChi()
	{
        SOLUONGTHISINH = 0;
	}
	private int mmaDT ;

    /// <summary>
    /// mã đợt thi.
    /// </summary>
	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private int mmaCC ;

    /// <summary>
    /// mã chứng chỉ
    /// </summary>
	public int MACC 

	{
		get { return mmaCC ; }

		set { mmaCC = value ; }
	}

	private int msoLuongThiSinh ;

    /// <summary>
    /// Số lượng thí sinh đăng ký dự thi ứng với chứng chỉ (maCC) trong đợt thi này (maDT).
    /// </summary>
	public int SOLUONGTHISINH 

	{
		get { return msoLuongThiSinh ; }

		set { msoLuongThiSinh = value ; }
	}

}

}
