
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoLoaiChungChi
{

	public DtoLoaiChungChi()
	{
	}
	private int mmaLCC ;


	public int MALCC 

	{
		get { return mmaLCC ; }

		set { mmaLCC = value ; }
	}

	private string mtenLCC ;


	public string TENLCC 

	{
		get { return mtenLCC ; }

		set { mtenLCC = value ; }
	}

}

}
