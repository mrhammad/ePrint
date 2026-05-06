using HelpSystem.BusinessAccessLayer;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HelpSystem.DataAccessLayer
{
	public class DbHelp
	{
		public DbHelp()
		{
		}

		public virtual void Article_Insert(int CategoryID, string ArticleName, string Description)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_article_insert", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@CategoryID", SqlDbType.Int).Value = CategoryID;
			sqlCommand.Parameters.AddWithValue("@ArticleName", SqlDbType.Text).Value = ArticleName;
			sqlCommand.Parameters.AddWithValue("@Description", SqlDbType.Text).Value = Description;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual DataTable Article_Select()
		{
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_popular_articles_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}

		public virtual DataTable Article_Select_By_ArticleID(int ArticleID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			SqlCommand sqlCommand = new SqlCommand("help_article_select_by_articleID", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ArticleID", SqlDbType.Int).Value = ArticleID;
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}

		public virtual DataTable Article_Select_By_CategoryID(int CategoryID)
		{
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_articles_select_by_categoryID", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@CategoryID", SqlDbType.Int).Value = CategoryID;
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}

		public virtual void Article_Update(int ArticleID, string ArticleName, string Description)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_article_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ArticleID", SqlDbType.Int).Value = ArticleID;
			sqlCommand.Parameters.AddWithValue("@ArticleName", SqlDbType.Text).Value = ArticleName;
			sqlCommand.Parameters.AddWithValue("@Description", SqlDbType.Text).Value = Description;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual void Article_View_Count_Update(int ArticleID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_article_viewcount_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ArticleID", SqlDbType.Int).Value = ArticleID;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual DataSet Articles_Complete_Selection()
		{
			commonClass _commonClass = new commonClass();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("help_articles_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public virtual DataTable Categories_Select()
		{
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_categories_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}

		public virtual void Issue_Add(HelpItems Items)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_Issue_Add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = Items.Subject;
			sqlCommand.Parameters.AddWithValue("@IssueDesc", SqlDbType.NVarChar).Value = Items.IssueDesc;
			sqlCommand.Parameters.AddWithValue("@BrowserID", SqlDbType.Int).Value = Items.BrowserID;
			sqlCommand.Parameters.AddWithValue("@Version", SqlDbType.NVarChar).Value = Items.Version;
			sqlCommand.Parameters.AddWithValue("@File1", SqlDbType.NVarChar).Value = Items.File1;
			sqlCommand.Parameters.AddWithValue("@File2", SqlDbType.NVarChar).Value = Items.File2;
			sqlCommand.Parameters.AddWithValue("@File3", SqlDbType.NVarChar).Value = Items.File3;
			sqlCommand.Parameters.AddWithValue("@File4", SqlDbType.NVarChar).Value = Items.File4;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual string Rating_Count_By_ArticleID(int ArticleID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_rating_count_by_articleID", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ArticleID", SqlDbType.Int).Value = ArticleID;
			string str = sqlCommand.ExecuteScalar().ToString();
			_commonClass.closeConnection();
			return str;
		}

		public virtual void Rating_Insert(int ArticleID, double Rating)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_rating_insert", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ArticleID", SqlDbType.Int).Value = ArticleID;
			sqlCommand.Parameters.AddWithValue("@Rating", SqlDbType.Decimal).Value = Rating;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual void Search_Insert(string Keyword)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_search_insert", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@Keyword", SqlDbType.NVarChar).Value = Keyword;
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public virtual DataTable Search_Keyword(string Keyword)
		{
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_search_keyword", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@Keyword", SqlDbType.NVarChar).Value = Keyword;
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}

		public virtual DataTable Search_Popular_select()
		{
			DataTable dataTable = new DataTable();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("help_search_popular_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			dataTable.Load(sqlCommand.ExecuteReader());
			_commonClass.closeConnection();
			return dataTable;
		}
	}
}