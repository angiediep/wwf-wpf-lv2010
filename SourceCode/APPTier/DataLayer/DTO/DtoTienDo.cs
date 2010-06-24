
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
    /// đối tượng dữ liệu Tiến độ
    /// </summary>
public class DtoTienDo
{
    /// <summary>
    /// tạo thể hiện tiến độ mới.
    /// </summary>
	public DtoTienDo()
	{

	}
	private int mmaTD ;

    /// <summary>
    /// mã tiến độ
    /// </summary>
	public int MATD 

	{
		get { return mmaTD ; }

		set { mmaTD = value ; }
	}

	private int mtongKhoiLuongCV ;

    /// <summary>
    /// tổng khối lượng công việc cần thực hiện.
    /// </summary>
	public int TONGKHOILUONGCV 

	{
		get { return mtongKhoiLuongCV ; }

		set { mtongKhoiLuongCV = value ; }
	}

	private int mkhoiLuongCVHT ;
    /// <summary>
    /// khối lượng công việc đã hoàn thành.
    /// </summary>

	public int KHOILUONGCVHT 

	{
		get { return mkhoiLuongCVHT ; }

		set { mkhoiLuongCVHT = value ; }
	}

	private DateTime mngayBatDauQuyDinh ;

    /// <summary>
    /// ngày bắt đầu công việc theo quy định
    /// </summary>
	public DateTime NGAYBATDAUQUYDINH 

	{
		get { return mngayBatDauQuyDinh ; }

		set { mngayBatDauQuyDinh = value ; }
	}

	private DateTime mngayKetThucQuyDinh ;

    /// <summary>
    /// ngày kết thúc công việc theo quy định
    /// </summary>
	public DateTime NGAYKETTHUCQUYDINH 

	{
		get { return mngayKetThucQuyDinh ; }

		set { mngayKetThucQuyDinh = value ; }
	}

	private DateTime mngayBatDauThucTe ;

    /// <summary>
    /// ngày công việc thực sự được bắt đầu.
    /// </summary>
	public DateTime NGAYBATDAUTHUCTE 

	{
		get { return mngayBatDauThucTe ; }

		set { mngayBatDauThucTe = value ; }
	}

	private DateTime mngayKetThucThucTe ;

    /// <summary>
    /// ngày công việc thực sự được kết thúc
    /// </summary>
	public DateTime NGAYKETTHUCTHUCTE 

	{
		get { return mngayKetThucThucTe ; }

		set { mngayKetThucThucTe = value ; }
	}

	private int mmaDT ;

    /// <summary>
    /// mã đợt thi có công việc đang theo dõi tiến độ
    /// </summary>
	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private int mmaCV ;

    /// <summary>
    /// mã công việc đang theo dõi tiến độ.
    /// </summary>
	public int MACV 

	{
		get { return mmaCV ; }

		set { mmaCV = value ; }
	}

	private int mmaNV ;

    /// <summary>
    /// mã nhân viên thực hiện công việc.
    /// </summary>
	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

}

}
