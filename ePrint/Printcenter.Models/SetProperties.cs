using nmsCommon;
using nmsLanguage;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public class SetProperties
{
	private languageClass objLanguage = new languageClass();

	private BasePage objPage = new BasePage();

	private int _opportunityID;

	private int _priceID;

	private int _tableID;

	private string _priceBookName = "";

	public int opportunityID
	{
		get
		{
			return this._opportunityID;
		}
		set
		{
			this._opportunityID = value;
		}
	}

	public string priceBookName
	{
		get
		{
			return this._priceBookName;
		}
		set
		{
			this._priceBookName = value;
		}
	}

	public int priceID
	{
		get
		{
			return this._priceID;
		}
		set
		{
			this._priceID = value;
		}
	}

	public int tableID
	{
		get
		{
			return this._tableID;
		}
		set
		{
			this._tableID = value;
		}
	}

	public SetProperties()
	{
	}

	public string colorCode(int companyId, string pg)
	{
		string str = "";
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand("crm_common_select_navigationcolor", _commonClass.openConnection())
		{
			CommandType = CommandType.StoredProcedure
		};
        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        sqlCommand.Parameters.AddWithValue("@pg", pg);
		sqlCommand.Parameters.AddWithValue("@companyID", companyId);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		while (sqlDataReader.Read())
		{
			str = sqlDataReader["colorcode"].ToString();
		}
		sqlDataReader.Close();
		_commonClass.closeConnection();
		return str;
	}

	public string Forecolor(int companyId, string pg)
	{
		string str = "";
		if (pg.Trim().ToLower() == "moretabs")
		{
			str = "white";
		}
		if (pg.Trim().ToLower() != "admin")
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_navigationcolor", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				str = sqlDataReader["forecolor"].ToString();
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
		}
		else
		{
			str = "white";
		}
		return str;
	}

	public void MakeDataGridRowAndHeaderClickable(DataGrid gridView, DataGridItem gridViewRow)
	{
		if (gridViewRow.ItemType == ListItemType.AlternatingItem)
		{
			gridViewRow.Attributes.Add("onmouseover", "this.className='hover1'");
			gridViewRow.Attributes.Add("onmouseout", "this.className='normalText_GridView'");
		}
		if (gridViewRow.ItemType == ListItemType.Item)
		{
			gridViewRow.Attributes.Add("onmouseover", "this.className='hover1'");
			gridViewRow.Attributes.Add("onmouseout", "this.className='normaltablerow'");
		}
	}

	public void MakeGridViewHeaderClickable(GridView gridView, GridViewRow gridViewRow, int companyid, string pg)
	{
		Color color;
		gridViewRow.ForeColor = Color.Black;
		gridViewRow.Font.Underline = false;
		gridView.CellPadding = 2;
		gridView.CellSpacing = 1;
		if (gridViewRow.RowType == DataControlRowType.Header)
		{
			for (int i = 0; i < gridView.Columns.Count; i++)
			{
				string sortExpression = gridView.Columns[i].SortExpression;
				TableCell item = gridViewRow.Cells[i];
				item.ForeColor = Color.FromName(this.objPage.Forecolor(companyid, pg));
				item.BackColor = Color.FromName(this.objPage.colorCode(companyid, pg));
				try
				{
					item.ForeColor = Color.FromName(this.objPage.Forecolor(companyid, pg));
					item.BackColor = Color.FromName(this.objPage.colorCode(companyid, pg));
				}
				catch
				{
				}
				if (!string.IsNullOrEmpty(sortExpression))
				{
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
					string str = "~/Images/1t.gif";
					if (sortExpression == gridView.SortExpression)
					{
						str = (gridView.SortDirection == SortDirection.Ascending ? "~/Images/descending.gif" : "~/Images/ascending.gif");
						item.ForeColor = Color.FromName(this.objPage.Forecolor(companyid, pg));
						item.BackColor = Color.FromName(this.objPage.colorCode(companyid, pg));
						item.Font.Underline = false;
					}
					image.ImageUrl = str;
					image.Style.Add(HtmlTextWriterStyle.MarginLeft, "10px");
					item.Wrap = false;
					item.Controls.Add(image);
					foreach (Control control in gridViewRow.Cells[i].Controls)
					{
						LinkButton linkButton = control as LinkButton;
						if (linkButton == null || !(linkButton.CommandName == "Sort"))
						{
							continue;
						}
						item.Attributes.Add("onclick", string.Concat("RequestData('", linkButton.ClientID, "', this, event)"));
						item.Style.Add(HtmlTextWriterStyle.Cursor, "hand");
						item.Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
						item.ForeColor = Color.FromName(this.objPage.Forecolor(companyid, pg));
						item.BackColor = Color.FromName(this.objPage.colorCode(companyid, pg));
						break;
					}
				}
			}
		}
		if (gridViewRow.RowType == DataControlRowType.DataRow)
		{
			for (int j = 0; j < gridViewRow.Cells.Count; j++)
			{
				if (!string.IsNullOrEmpty(gridView.SortExpression) && gridView.Columns[j].SortExpression == gridView.SortExpression)
				{
					color = (gridViewRow.RowState != DataControlRowState.Alternate ? ColorTranslator.FromHtml("#d7e3f1") : ColorTranslator.FromHtml("#f7fbff"));
					gridViewRow.Cells[j].BackColor = color;
				}
			}
		}
	}

	public void MakeGridViewRowClickable(GridView gridView, GridViewRow gridViewRow)
	{
		if (gridViewRow.RowType == DataControlRowType.DataRow)
		{
			gridViewRow.Attributes.Add("onmouseover", "this.className='hover1'");
			if (gridViewRow.RowIndex % 2 == 0)
			{
				gridViewRow.Attributes.Add("onmouseout", "this.className='NewTableRows'");
				return;
			}
			gridViewRow.Attributes.Add("onmouseout", "this.className='NewAlternative'");
		}
	}

	public void MakeGridViewRowStyle(GridView gridView, GridViewRow gridViewRow)
	{
		if (gridViewRow.RowType == DataControlRowType.DataRow)
		{
			gridView.CssClass = "GV_Row";
			gridView.ForeColor = Color.Black;
			gridView.RowStyle.CssClass = "GV_Row";
		}
	}

	public GridView setGridViewProprties(GridView GridViewclient, int companyId, string pg)
	{
		GridViewclient.PageSize = 20;
		GridViewclient.AllowPaging = true;
		GridViewclient.AllowSorting = true;
		GridViewclient.AutoGenerateColumns = false;
		GridViewclient.Width = Unit.Percentage(100);
		if (GridViewclient.Rows.Count != 0)
		{
			GridViewclient.CssClass = "GridviewBorder";
		}
		else
		{
			GridViewclient.CssClass = "GridviewBorderEmpty";
		}
		GridViewclient.RowStyle.CssClass = "NewTableRows";
		GridViewclient.AlternatingRowStyle.CssClass = "NewAlternative";
		GridViewclient.HeaderStyle.CssClass = "bgcustomize";
		if (pg != "")
		{
			GridViewclient.HeaderStyle.ForeColor = Color.FromName(this.Forecolor(companyId, pg));
		}
		GridViewclient.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
		GridViewclient.HeaderStyle.Height = Unit.Pixel(23);
		GridViewclient.HeaderStyle.Font.Underline = false;
		GridViewclient.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
		GridViewclient.PagerSettings.FirstPageImageUrl = string.Concat(global.imagePath(), "icn_firstrecord.gif");
		GridViewclient.PagerSettings.NextPageImageUrl = string.Concat(global.imagePath(), "icn_next_record.gif");
		GridViewclient.PagerSettings.PreviousPageImageUrl = string.Concat(global.imagePath(), "icn_previous_record.gif");
		GridViewclient.PagerSettings.LastPageImageUrl = string.Concat(global.imagePath(), "icn_last_record.gif");
		GridViewclient.PagerSettings.FirstPageText = this.objLanguage.convert("First");
		GridViewclient.PagerSettings.NextPageText = this.objLanguage.convert("Next");
		GridViewclient.PagerSettings.PreviousPageText = this.objLanguage.convert("Previous");
		GridViewclient.PagerSettings.LastPageText = this.objLanguage.convert("Last");
		GridViewclient.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
		GridViewclient.PagerStyle.CssClass = "normalText_GridView";
		GridViewclient.EmptyDataText = this.objLanguage.convert("No Records Available !");
		GridViewclient.EmptyDataRowStyle.Width = Unit.Percentage(100);
		GridViewclient.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
		for (int i = 0; i < GridViewclient.Columns.Count; i++)
		{
			GridViewclient.Columns[i].HeaderText = this.objLanguage.convert(GridViewclient.Columns[i].HeaderText);
		}
		return GridViewclient;
	}

	public GridView setGridViewProprtieswithoutpagesize(GridView GridViewclient, int companyId, string pg)
	{
		GridViewclient.AllowPaging = true;
		GridViewclient.AllowSorting = true;
		GridViewclient.AutoGenerateColumns = false;
		GridViewclient.Width = Unit.Percentage(100);
		if (GridViewclient.Rows.Count != 0)
		{
			GridViewclient.CssClass = "GridviewBorder";
		}
		else
		{
			GridViewclient.CssClass = "GridviewBorderEmpty";
		}
		GridViewclient.RowStyle.CssClass = "NewTableRows";
		GridViewclient.AlternatingRowStyle.CssClass = "NewAlternative";
		if (pg != "")
		{
			GridViewclient.HeaderStyle.BackColor = Color.FromName(this.colorCode(companyId, pg));
		}
		GridViewclient.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
		GridViewclient.HeaderStyle.Font.Underline = false;
		GridViewclient.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
		GridViewclient.EmptyDataText = this.objLanguage.convert("No records found");
		GridViewclient.EmptyDataRowStyle.Width = Unit.Percentage(100);
		GridViewclient.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
		for (int i = 0; i < GridViewclient.Columns.Count; i++)
		{
			GridViewclient.Columns[i].HeaderText = this.objLanguage.convert(GridViewclient.Columns[i].HeaderText);
		}
		return GridViewclient;
	}

	public GridView setGridViewProprtieswithoutpagesizenew(GridView GridViewclient, int companyId, string pg)
	{
		GridViewclient.AllowPaging = false;
		GridViewclient.AllowSorting = true;
		GridViewclient.AutoGenerateColumns = false;
		GridViewclient.Width = Unit.Percentage(100);
		if (GridViewclient.Rows.Count != 0)
		{
			GridViewclient.CssClass = "GridviewBorder";
		}
		else
		{
			GridViewclient.CssClass = "GridviewBorderEmpty";
		}
		GridViewclient.RowStyle.CssClass = "NewTableRows";
		GridViewclient.AlternatingRowStyle.CssClass = "NewAlternative";
		if (pg != "")
		{
			GridViewclient.HeaderStyle.BackColor = Color.FromName(this.colorCode(companyId, pg));
		}
		GridViewclient.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
		GridViewclient.HeaderStyle.Font.Underline = false;
		GridViewclient.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
		GridViewclient.EmptyDataText = this.objLanguage.convert("No records found");
		GridViewclient.EmptyDataRowStyle.Width = Unit.Percentage(100);
		GridViewclient.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
		for (int i = 0; i < GridViewclient.Columns.Count; i++)
		{
			GridViewclient.Columns[i].HeaderText = this.objLanguage.convert(GridViewclient.Columns[i].HeaderText);
		}
		return GridViewclient;
	}

	public GridView setHomeGridViewProprties(GridView GridViewclient, int companyId, string pg)
	{
		GridViewclient.PageSize = 20;
		GridViewclient.AllowPaging = true;
		GridViewclient.AllowSorting = true;
		GridViewclient.AutoGenerateColumns = false;
		GridViewclient.Width = Unit.Percentage(100);
		if (GridViewclient.Rows.Count != 0)
		{
			GridViewclient.CssClass = "GridviewBorder";
		}
		else
		{
			GridViewclient.CssClass = "EventsBorder";
		}
		GridViewclient.RowStyle.CssClass = "NewTableRows";
		GridViewclient.AlternatingRowStyle.CssClass = "NewAlternative";
		if (pg != "")
		{
			GridViewclient.HeaderStyle.BackColor = Color.FromName(this.colorCode(companyId, pg));
		}
		GridViewclient.HeaderStyle.CssClass = "bgImageDGHeader";
		GridViewclient.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
		GridViewclient.HeaderStyle.Font.Underline = false;
		GridViewclient.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
		GridViewclient.PagerSettings.FirstPageImageUrl = string.Concat(global.imagePath(), "icn_firstrecord.gif");
		GridViewclient.PagerSettings.NextPageImageUrl = string.Concat(global.imagePath(), "icn_next_record.gif");
		GridViewclient.PagerSettings.PreviousPageImageUrl = string.Concat(global.imagePath(), "icn_previous_record.gif");
		GridViewclient.PagerSettings.LastPageImageUrl = string.Concat(global.imagePath(), "icn_last_record.gif");
		GridViewclient.PagerSettings.FirstPageText = this.objLanguage.convert("First");
		GridViewclient.PagerSettings.NextPageText = this.objLanguage.convert("Next");
		GridViewclient.PagerSettings.PreviousPageText = this.objLanguage.convert("Previous");
		GridViewclient.PagerSettings.LastPageText = this.objLanguage.convert("Last");
		GridViewclient.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
		GridViewclient.PagerStyle.CssClass = "normalText_GridView";
		GridViewclient.EmptyDataText = this.objLanguage.convert("No Records Available !");
		GridViewclient.EmptyDataRowStyle.Width = Unit.Percentage(100);
		GridViewclient.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
		for (int i = 0; i < GridViewclient.Columns.Count; i++)
		{
			GridViewclient.Columns[i].HeaderText = this.objLanguage.convert(GridViewclient.Columns[i].HeaderText);
		}
		return GridViewclient;
	}
}