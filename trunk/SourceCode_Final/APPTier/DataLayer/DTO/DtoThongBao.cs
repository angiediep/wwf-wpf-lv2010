
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoThongBao
{

    public DtoThongBao()
    {
    }
    private int mmaTB;


    public int MATB
    {
        get { return mmaTB; }

        set { mmaTB = value; }
    }

    private string mnoiDung;


    public string NOIDUNG
    {
        get { return mnoiDung; }

        set { mnoiDung = value; }
    }

    private int mmaTD;


    public int MATD
    {
        get { return mmaTD; }

        set { mmaTD = value; }
    }

    private int mtrangThai;

    /// <summary>
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
