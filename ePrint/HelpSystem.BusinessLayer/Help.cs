using HelpSystem.BusinessAccessLayer;
using HelpSystem.DataAccessLayer;
using System;
using System.Data;

namespace HelpSystem.BusinessLayer
{
	public class Help : BaseClass
	{
		public Help()
		{
		}

		public static void Article_Insert(int CategoryID, string ArticleName, string Description)
		{
			(new DbHelp()).Article_Insert(CategoryID, ArticleName, Description);
		}

		public static DataTable Article_Select()
		{
			return (new DbHelp()).Article_Select();
		}

		public static DataTable Article_Select_By_ArticleID(int ArticleID)
		{
			return (new DbHelp()).Article_Select_By_ArticleID(ArticleID);
		}

		public static DataTable Article_Select_By_CategoryID(int CategoryID)
		{
			return (new DbHelp()).Article_Select_By_CategoryID(CategoryID);
		}

		public static void Article_Update(int ArticleID, string ArticleName, string Description)
		{
			(new DbHelp()).Article_Update(ArticleID, ArticleName, Description);
		}

		public static void Article_View_Count_Update(int ArticleID)
		{
			(new DbHelp()).Article_View_Count_Update(ArticleID);
		}

		public static DataSet Articles_Complete_Selection()
		{
			return (new DbHelp()).Articles_Complete_Selection();
		}

		public static DataTable Categories_Select()
		{
			return (new DbHelp()).Categories_Select();
		}

		public static void Issue_Add(HelpItems Items)
		{
			(new DbHelp()).Issue_Add(Items);
		}

		public static string Rating_Count_By_ArticleID(int ArticleID)
		{
			return (new DbHelp()).Rating_Count_By_ArticleID(ArticleID);
		}

		public static void Rating_Insert(int ArticleID, double Rating)
		{
			(new DbHelp()).Rating_Insert(ArticleID, Rating);
		}

		public static void Search_Insert(string Keyword)
		{
			(new DbHelp()).Search_Insert(Keyword);
		}

		public static DataTable Search_Keyword(string keyword)
		{
			return (new DbHelp()).Search_Keyword(keyword);
		}

		public static DataTable Search_Popular_select()
		{
			return (new DbHelp()).Search_Popular_select();
		}
	}
}