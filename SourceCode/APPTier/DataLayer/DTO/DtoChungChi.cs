
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
    /// Đối tượng dữ liệu Chứng Chỉ.
    /// </summary>
public class DtoChungChi
{
    /// <summary>
    /// tạo thể hiện chứng chỉ mới.
    /// </summary>
	public DtoChungChi()
	{
	}
	private int mmaCC ;

    /// <summary>
    /// Mã chứng chỉ
    /// </summary>
	public int MACC 

	{
		get { return mmaCC ; }

		set { mmaCC = value ; }
	}

	private string mtenCC ;

    /// <summary>
    /// Tên chứng chỉ
    /// </summary>
	public string TENCC 

	{
		get { return mtenCC ; }

		set { mtenCC = value ; }
	}

}

}
