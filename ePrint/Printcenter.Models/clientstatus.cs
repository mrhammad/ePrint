using nmsCommon;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

public class clientstatus : System.Web.UI.Page
{
	public commonClass cmn = new commonClass();

	public clientstatus()
	{
	}

	public float FolderSize(int companyid, int val)
	{
		SqlCommand sqlCommand;
		SqlDataReader sqlDataReader;
		float length = 0f;
		string str = string.Concat(base.Server.MapPath("../document"), "/", companyid.ToString());
		switch (val)
		{
			case 1:
			{
				try
				{
					FileInfo[] files = (new DirectoryInfo(str)).GetFiles();
					for (int i = 0; i < (int)files.Length; i++)
					{
						length = length + (float)files[i].Length;
					}
				}
				catch (Exception exception)
				{
				}
				return length / 1048576f;
			}
			case 2:
			{
				sqlCommand = new SqlCommand(string.Concat("select c.expiredate,c.subscriptionid, c.spacelimit, c.noofuser from tb_company c where c.companyid=", companyid.ToString()), this.cmn.openConnection());
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					length = float.Parse(sqlDataReader["spacelimit"].ToString());
				}
				sqlDataReader.Close();
				this.cmn.closeConnection();
				float single = 0f;
				try
				{
					FileInfo[] fileInfoArray = (new DirectoryInfo(str)).GetFiles();
					for (int j = 0; j < (int)fileInfoArray.Length; j++)
					{
						single = single + (float)fileInfoArray[j].Length;
					}
				}
				catch (Exception exception1)
				{
				}
				return length - single / 1048576f;
			}
		}
		sqlCommand = new SqlCommand(string.Concat("select c.expiredate,c.subscriptionid, c.spacelimit, c.noofuser from tb_company c where c.companyid =", companyid.ToString()), this.cmn.openConnection());
		sqlDataReader = sqlCommand.ExecuteReader();
		while (sqlDataReader.Read())
		{
			length = float.Parse(sqlDataReader["spacelimit"].ToString());
		}
		sqlDataReader.Close();
		this.cmn.closeConnection();
		return length;
	}

	public int NoOfUser(int companyid, int val)
	{
		SqlCommand sqlCommand;
		SqlDataReader sqlDataReader;
		int num = 0;
		switch (val)
		{
			case 1:
			{
				sqlCommand = new SqlCommand(string.Concat("select count(*) as currentnoofuser from tb_user where companyid=", companyid), this.cmn.openConnection());
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					num = int.Parse(sqlDataReader["currentnoofuser"].ToString());
				}
				sqlDataReader.Close();
				this.cmn.closeConnection();
				break;
			}
			case 2:
			{
				sqlCommand = new SqlCommand(string.Concat("select (noofuser- (select count(*) from tb_user where companyid=c.companyid)) as remainingnoofuser from tb_company c where companyid=", companyid), this.cmn.openConnection());
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					num = int.Parse(sqlDataReader["remainingnoofuser"].ToString());
				}
				sqlDataReader.Close();
				this.cmn.closeConnection();
				break;
			}
			default:
			{
				sqlCommand = new SqlCommand(string.Concat("select noofuser from tb_company where companyid=", companyid), this.cmn.openConnection());
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					num = int.Parse(sqlDataReader["noofuser"].ToString());
				}
				sqlDataReader.Close();
				this.cmn.closeConnection();
				break;
			}
		}
		return num;
	}
}