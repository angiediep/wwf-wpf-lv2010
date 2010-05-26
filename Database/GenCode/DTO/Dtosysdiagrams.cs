
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DTO
{
public class Dtosysdiagrams
{

	public Dtosysdiagrams()
	{
	}
	private string mname ;


	public string NAME 

	{
		get { return mname ; }

		set { mname = value ; }
	}

	private int mprincipal_id ;


	public int PRINCIPAL_ID 

	{
		get { return mprincipal_id ; }

		set { mprincipal_id = value ; }
	}

	private int mdiagram_id ;


	public int DIAGRAM_ID 

	{
		get { return mdiagram_id ; }

		set { mdiagram_id = value ; }
	}

	private int mversion ;


	public int VERSION 

	{
		get { return mversion ; }

		set { mversion = value ; }
	}

	private System.Byte[] mdefinition ;


	public System.Byte[] DEFINITION 

	{
		get { return mdefinition ; }

		set { mdefinition = value ; }
	}

}

}
