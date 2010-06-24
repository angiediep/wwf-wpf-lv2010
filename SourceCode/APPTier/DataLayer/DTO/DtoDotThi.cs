
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
    /// Đối tượng dữ liệu Đợt Thi.
    /// </summary>
public class DtoDotThi
{
    /// <summary>
    /// tạo thể hiện đợt thi mới.
    /// </summary>
	public DtoDotThi()
	{
        TENDOTTHI = "";
        NGAYTHI = DateTime.MinValue;
        SOLUONGTHISINH = 0;
        WORKFLOWINSTANCEID = "";
	}
	private int mmaDT ;

    /// <summary>
    /// mã đợt thi
    /// </summary>
	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private string mtenDotThi ;

    /// <summary>
    /// tên đợt thi
    /// </summary>
	public string TENDOTTHI 

	{
		get { return mtenDotThi ; }

		set { mtenDotThi = value ; }
	}

	private DateTime mngayThi ;

    /// <summary>
    /// ngày diễn ra đợt thi
    /// </summary>
	public DateTime NGAYTHI 

	{
		get { return mngayThi ; }

		set { mngayThi = value ; }
	}

	private int msoLuongThiSinh ;

    /// <summary>
    /// số lượng thí sinh đăng ký dự thi trong đợt thi này.
    /// </summary>
	public int SOLUONGTHISINH 

	{
		get { return msoLuongThiSinh ; }

		set { msoLuongThiSinh = value ; }
	}


    private string mworkflowInstanceID;

    /// <summary>
    /// Mã đại diện cho thể hiện luồng công việc trong hệ thống.
    /// </summary>
    public string WORKFLOWINSTANCEID
    {
        get { return mworkflowInstanceID; }

        set { mworkflowInstanceID = value; }
    }
}

}
