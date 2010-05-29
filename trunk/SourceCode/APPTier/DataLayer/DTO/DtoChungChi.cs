
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DTO
{
public class DtoChungChi
{

	public DtoChungChi()
	{
	}
	private int mmaCC ;


	public int MACC 

	{
		get { return mmaCC ; }

		set { mmaCC = value ; }
	}

	private string mtenCC ;


	public string TENCC 

	{
		get { return mtenCC ; }

		set { mtenCC = value ; }
	}

}

}
