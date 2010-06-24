
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
    /// Đối tượng dữ liệu thông báo.
    /// </summary>
public class DtoThongBao
{
    /// <summary>
    /// tạo thể hiện thông báo mới cho nhân viên thực hiện công việc.
    /// </summary>
    public DtoThongBao()
    {
        NOIDUNG = "";
    }
    private int mmaTB;

    /// <summary>
    /// mã thông báo.
    /// </summary>
    public int MATB
    {
        get { return mmaTB; }

        set { mmaTB = value; }
    }

    private string mnoiDung;

    /// <summary>
    /// Nội dung thông báo.
    /// </summary>
    public string NOIDUNG
    {
        get { return mnoiDung; }

        set { mnoiDung = value; }
    }

    private int mmaTD;

    /// <summary>
    /// mã tiến độ liên quan đến thông báo.
    /// </summary>
    public int MATD
    {
        get { return mmaTD; }

        set { mmaTD = value; }
    }

    private int mtrangThai;

    /// <summary>
    /// trạng thái của thông báo.
    /// 1: chưa đọc
    /// 0: đã đọc.
    /// </summary>
    public int TRANGTHAI
    {
        get { return mtrangThai; }

        set { mtrangThai = value; }
    }

}

}
