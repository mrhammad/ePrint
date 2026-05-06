using nmsCommon;
using nmsLanguage;
using nmsView;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace nmsReport
{
	public class reportclass : BaseClass
	{
		private commonClass cmn = new commonClass();

		private languageClass objLanguage = new languageClass();

		private BasePage objpage = new BasePage();

		public string strImagepath = global.imagePath();

		public string tabcolor = string.Empty;

		public reportclass()
		{
		}

		public void addFunctionAndPathToImage(Image imgTop, Image imgUp, Image imgDown, Image imgBottom)
		{
			imgTop.ImageUrl = string.Concat(global.imagePath(), "double_arrow_up.gif");
			imgUp.ImageUrl = string.Concat(global.imagePath(), "arrow_up.gif");
			imgDown.ImageUrl = string.Concat(global.imagePath(), "arrow_dwn.gif");
			imgBottom.ImageUrl = string.Concat(global.imagePath(), "double_arrow_dwn.gif");
			imgTop.ToolTip = this.objLanguage.convert("Top");
			imgUp.ToolTip = this.objLanguage.convert("Up");
			imgDown.ToolTip = this.objLanguage.convert("Down");
			imgBottom.ToolTip = this.objLanguage.convert("Bottom");
			imgTop.Attributes.Add("onclick", "imgTop_Click()");
			imgUp.Attributes.Add("onclick", "imgUp_Click()");
			imgDown.Attributes.Add("onclick", "imgDown_Click()");
			imgBottom.Attributes.Add("onclick", "imgBottom_Click()");
		}

		public string display_condition(string pg, PlaceHolder plh)
		{
			DropDownList[] dropDownListArray = new DropDownList[5];
			DropDownList[] dropDownListArray1 = new DropDownList[5];
			DropDownList[] dropDownListArray2 = new DropDownList[0];
			DropDownList dropDownList = new DropDownList();
			DropDownList dropDownList1 = new DropDownList();
			DropDownList dropDownList2 = new DropDownList();
			DropDownList dropDownList3 = new DropDownList();
			DropDownList dropDownList4 = new DropDownList();
			DropDownList dropDownList5 = new DropDownList();
			DropDownList dropDownList6 = new DropDownList();
			DropDownList dropDownList7 = new DropDownList();
			DropDownList dropDownList8 = new DropDownList();
			DropDownList dropDownList9 = new DropDownList();
			dropDownListArray[0] = dropDownList;
			dropDownListArray[1] = dropDownList1;
			dropDownListArray[2] = dropDownList2;
			dropDownListArray[3] = dropDownList3;
			dropDownListArray[4] = dropDownList4;
			dropDownListArray1[0] = dropDownList5;
			dropDownListArray1[1] = dropDownList6;
			dropDownListArray1[2] = dropDownList7;
			dropDownListArray1[3] = dropDownList8;
			dropDownListArray1[4] = dropDownList9;
			for (int i = 0; i < (int)dropDownListArray.Length; i++)
			{
				dropDownListArray[i].CssClass = "normaltext";
				dropDownListArray1[i].CssClass = "normaltext";
			}
			createViewClass _createViewClass = new createViewClass();
			_createViewClass.initialize_DropDown(int.Parse(this.Session["companyid"].ToString()), pg, dropDownListArray2, dropDownListArray, dropDownListArray1);
			dropDownListArray[0].ID = "ddlsearchfield1";
			dropDownListArray[1].ID = "ddlsearchfield2";
			dropDownListArray[2].ID = "ddlsearchfield3";
			dropDownListArray[3].ID = "ddlsearchfield4";
			dropDownListArray[4].ID = "ddlsearchfield5";
			dropDownListArray1[0].ID = "ddlsearchcondition1";
			dropDownListArray1[1].ID = "ddlsearchcondition2";
			dropDownListArray1[2].ID = "ddlsearchcondition3";
			dropDownListArray1[3].ID = "ddlsearchcondition4";
			dropDownListArray1[4].ID = "ddlsearchcondition5";
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>&nbsp;"));
			plh.Controls.Add(dropDownListArray[0]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[0]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			TextBox textBox = new TextBox()
			{
				ID = "searchkeyword1",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			Label label = new Label()
			{
				ID = "lblerror1",
				Visible = false,
				Height = Unit.Pixel(25),
				CssClass = "error"
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[1]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[1]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox = new TextBox()
			{
				ID = "searchkeyword2",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label = new Label()
			{
				ID = "lblerror2",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>&nbsp;"));
			plh.Controls.Add(dropDownListArray[2]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[2]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox = new TextBox()
			{
				ID = "searchkeyword3",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label = new Label()
			{
				ID = "lblerror3",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[3]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[3]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox = new TextBox()
			{
				ID = "searchkeyword4",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr >"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label = new Label()
			{
				ID = "lblerror4",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[4]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[4]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox = new TextBox()
			{
				ID = "searchkeyword5",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label = new Label()
			{
				ID = "lblerror5",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			return plh.ToString();
		}

		public void display_plhColumnsToSum(string pg, PlaceHolder plh)
		{
			this.tabcolor = this.objpage.colorCode(Convert.ToInt32(this.Session["companyid"]), pg);
			plh.Controls.Add(new LiteralControl("<table id='tb_display_plhColumnsToSum' align=left cellpadding=1 cellspacing=1 border=0  width=50%>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td class=headertext>"));
			Label label = new Label()
			{
				ID = "lblColumnsToSum",
				Text = this.objLanguage.convert("Step 2:")
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("Select Columns To Total"))));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td><hr size=1 color=#CACACA /></td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td class=normaltext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select the summary information and summary type you are looking for")));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td>"));
			plh.Controls.Add(new LiteralControl("<table width=100% border=0 cellpadding=0 cellspacing=0 align=center>"));
			plh.Controls.Add(new LiteralControl("<tr height=23>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td width=5 height=5 valign=top bgcolor=", this.tabcolor, ">")));
			plh.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "lt_tabnotch.gif'>")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap class='bgcustomize navigatorpanel' width=150>&nbsp;", this.objLanguage.convert("Columns"), "</td>")));
			plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap class='bgcustomize navigatorpanel'  width=100>", this.objLanguage.convert("Sum"), "</td>")));
			plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap class='bgcustomize navigatorpanel' width=100>", this.objLanguage.convert("Average"), "</td>")));
			plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap class='bgcustomize navigatorpanel'  width=150>", this.objLanguage.convert("Largest Value"), "</td>")));
			plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap class='bgcustomize navigatorpanel'  width=150>", this.objLanguage.convert("Smallest value"), "</td>")));
			plh.Controls.Add(new LiteralControl(string.Concat("<td valign=top width=5 height=5 align=right bgcolor=", this.tabcolor, ">")));
			plh.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "rt_tabnotch.gif'>")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td colspan=8 width=100%><table cellspacing=0 cellpadding=0 width=100% class=borderWithoutTop>"));
			plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
			plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td width=150 nowrap class=normaltext>&nbsp;", this.objLanguage.convert("Record count"), "</td>")));
			plh.Controls.Add(new LiteralControl("<td nowrap>&nbsp;"));
			CheckBox checkBox = new CheckBox()
			{
				ID = "chkrecordcount"
			};
			plh.Controls.Add(checkBox);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td nowrap></td>"));
			plh.Controls.Add(new LiteralControl("<td nowrap></td>"));
			plh.Controls.Add(new LiteralControl("<td nowrap></td>"));
			plh.Controls.Add(new LiteralControl("<td nowrap></td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["databasefieldname"].ToString().ToLower().Trim() != "contactid") & (sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "d") & (sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") & ((sqlDataReader["inputtype"].ToString().ToLower().Trim() == "checkbox") | (sqlDataReader["inputtype"].ToString().ToLower().Trim() == "number") | (sqlDataReader["inputtype"].ToString().ToLower().Trim() == "currency"))))
				{
					continue;
				}
				num++;
				if (num % 2 != 0)
				{
					plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				}
				else
				{
					plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				}
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap=nowrap width=150 class=normaltext>&nbsp;", this.objLanguage.convert(sqlDataReader["labelName"].ToString()), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>&nbsp;"));
				checkBox = new CheckBox()
				{
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_sum")
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_average")
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_largest")
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_smallest")
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
			}
			sqlDataReader.Close();
			this.cmn.closeConnection();
			if (pg == "campaign")
			{
				plh.Controls.Add(new LiteralControl("<tr><td colspan=7 width=100%><table cellspacing=0 cellpadding=0 width=100%>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Total Leads") ?? ""));
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalleads_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalleads_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalleads_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalleads_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Converted Leads"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "convertedleads_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "convertedleads_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "convertedleads_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "convertedleads_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Total Response"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalresponse_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalresponse_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalresponse_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalresponse_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap width=150 class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Total Opportunity"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalopportunities_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalopportunities_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalopportunities_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalopportunities_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Total Won Opportunity"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalwonopportunities_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalwonopportunities_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalwonopportunities_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalwonopportunities_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Total Value Opportunity"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvalueopportunities_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvalueopportunities_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvalueopportunities_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvalueopportunities_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap=nowrap class=normaltext>"));
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Total Value Won Opportunity"), "</td>")));
				plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvaluewonopportunities_sum"
				};
				plh.Controls.Add(new LiteralControl("&nbsp;"));
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=99 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvaluewonopportunities_average"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvaluewonopportunities_largest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
				checkBox = new CheckBox()
				{
					ID = "totalvaluewonopportunities_smallest"
				};
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td width=8></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("</table></td></tr>"));
			}
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td width=1 nowrap></td>"));
			plh.Controls.Add(new LiteralControl("<td nowrap=nowrap width=150 class=normaltext>&nbsp;</td>"));
			plh.Controls.Add(new LiteralControl("<td width=100 nowrap>&nbsp;"));
			plh.Controls.Add(new LiteralControl("<a id=__lnksum href='' onclick=\"javascript:CheckAndUnCheckReportCheckBox('tb_display_plhColumnsToSum','_sum',this.id);  return false;\">Check All</a>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=100 nowrap>"));
			plh.Controls.Add(new LiteralControl("<a id='__lnkaverage' href='' onclick=\"javascript:CheckAndUnCheckReportCheckBox('tb_display_plhColumnsToSum','_average',this.id);  return false;\">Check All</a>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
			plh.Controls.Add(new LiteralControl("<a id='__lnklargest' href='' onclick=\"javascript:CheckAndUnCheckReportCheckBox('tb_display_plhColumnsToSum','_largest',this.id);  return false;\">Check All</a>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=150 nowrap>"));
			plh.Controls.Add(new LiteralControl("<a href='' id='__lnksmallest' onclick=\"javascript:CheckAndUnCheckReportCheckBox('tb_display_plhColumnsToSum','_smallest',this.id); return false;\">Check All</a>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=8 nowrap></td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("</table></td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
		}

		public void display_plhMatrix(string pg, PlaceHolder plh)
		{
			plh.Controls.Add(new LiteralControl("<table align=left cellpadding=1 cellspacing=1 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td class=headertext>"));
			Label label = new Label()
			{
				ID = "lblMatrix",
				Text = "Step 2: "
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("Select the grouping for which you would like to calculate summary information"))));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td><hr size=1 color=#CACACA /></td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td class=normaltext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select columns by which your report will be grouped")));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td>"));
			plh.Controls.Add(new LiteralControl("<table width=1% cellpadding=4 cellspacing=2 align=left>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<span class=headertext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Specify your row headings")));
			plh.Controls.Add(new LiteralControl("</span>"));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select the fields that will be used as the summary rows in your matrix report")));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<img src='", global.imagePath(), "reportmatrixdown.gif'>")));
			plh.Controls.Add(new LiteralControl("</span>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Subtotal by"), ":")));
			plh.Controls.Add(new LiteralControl("<br>"));
			DropDownList dropDownList = new DropDownList();
			DropDownList str = new DropDownList();
			dropDownList.CssClass = "normaltext";
			dropDownList.ID = "ddl_subtotalbyrow";
			str.CssClass = "normaltext";
			str.ID = "ddl_subtotalbycolumn";
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") & (sqlDataReader["databasefieldname"].ToString().ToLower() != "description")))
				{
					continue;
				}
				dropDownList.Items.Insert(num, sqlDataReader["labelname"].ToString());
				dropDownList.Items[num].Text = sqlDataReader["labelname"].ToString();
				str.Items.Insert(num, sqlDataReader["labelname"].ToString());
				str.Items[num].Text = sqlDataReader["labelname"].ToString();
				if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "d")
				{
					dropDownList.Items[num].Value = string.Concat(sqlDataReader["CustomizeID"].ToString(), "__e__", sqlDataReader["inputtype"].ToString());
					str.Items[num].Value = string.Concat(sqlDataReader["CustomizeID"].ToString(), "__e__", sqlDataReader["inputtype"].ToString());
				}
				else
				{
					dropDownList.Items[num].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
					str.Items[num].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
				}
				num++;
			}
			sqlDataReader.Close();
			this.cmn.closeConnection();
			plh.Controls.Add(dropDownList);
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Sort by"), ":")));
			plh.Controls.Add(new LiteralControl("<br>"));
			DropDownList dropDownList1 = new DropDownList()
			{
				ID = "ddl_sortorderrowmatrix",
				CssClass = "normaltext"
			};
			dropDownList1.Items.Insert(0, "Ascending");
			dropDownList1.Items[0].Text = this.objLanguage.convert("Ascending");
			dropDownList1.Items[0].Value = "asc";
			dropDownList1.Items.Insert(1, "Descending");
			dropDownList1.Items[1].Text = this.objLanguage.convert("Descending");
			dropDownList1.Items[1].Value = "desc";
			plh.Controls.Add(dropDownList1);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=10%></td>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<span class=headertext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Specify your column headings")));
			plh.Controls.Add(new LiteralControl("</span>"));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select the fields that will be used as the summary columns in your matrix report")));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<img src='", global.imagePath(), "reportmatrixacross.gif'>")));
			plh.Controls.Add(new LiteralControl("</span>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Subtotal by"), ":")));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(str);
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl("<br>"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Sort by"), ":")));
			plh.Controls.Add(new LiteralControl("<br>"));
			DropDownList dropDownList2 = new DropDownList()
			{
				ID = "ddl_sortordercolumnmatrix",
				CssClass = "normaltext"
			};
			dropDownList2.Items.Insert(0, "Ascending");
			dropDownList2.Items[0].Text = this.objLanguage.convert("Ascending");
			dropDownList2.Items[0].Value = "asc";
			dropDownList2.Items.Insert(1, "Descending");
			dropDownList2.Items[1].Text = this.objLanguage.convert("Descending");
			dropDownList2.Items[1].Value = "desc";
			plh.Controls.Add(dropDownList2);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td width=50%></td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
		}

		public void display_plhSearchCriteria(string pg, PlaceHolder plh)
		{
			int year;
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=1 cellspacing=1 border=0 width=99%>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td class=headertext>"));
			Label label = new Label()
			{
				ID = "lblSearchCriteria",
				Text = this.objLanguage.convert("Step 5:")
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp; Select Your ", base.ReturnScreenName("REPORTS", 2, "p"), " Criteria")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td><hr size=1 color=#CACACA /></td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td class=normaltext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select the criteria by which your records will be returned.")));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td>"));
			plh.Controls.Add(new LiteralControl("<table width=100% border=0 cellpadding=1 cellspacing=1 class=label align=center>"));
			plh.Controls.Add(new LiteralControl("<tr class=headertext>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td width=100%>&nbsp;", this.objLanguage.convert("Standard Filters"), "</td>")));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>&nbsp;"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("View"), "&nbsp;")));
			BaseClass baseClass = new BaseClass();
			DropDownList dropDownList = new DropDownList()
			{
				ID = "ddlView",
				CssClass = "normaltext"
			};
			string lower = pg.ToLower();
			string str = lower;
			if (lower != null)
			{
				switch (str)
				{
					case "lead":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("LEADS", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("LEADS", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "client":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("CLIENTS", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("CLIENTS", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "contact":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("CONTACTS", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("CONTACTS", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "opportunity":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("OPPORTUNITIES", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("OPPORTUNITIES", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "campaign":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("CAMPAIGN", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("CAMPAIGN", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "ticket":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("TICKETS", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("TICKETS", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "solution":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("SOLUTIONS", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("SOLUTIONS", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
					case "forecast":
					{
						dropDownList.Items.Insert(0, "");
						dropDownList.Items[0].Text = string.Concat("My ", baseClass.ReturnScreenName("FORECAST", 1, "p"));
						dropDownList.Items[0].Value = "my";
						dropDownList.Items.Insert(1, "");
						dropDownList.Items[1].Text = string.Concat("All ", baseClass.ReturnScreenName("FORECAST", 1, "p"));
						dropDownList.Items[1].Value = "all";
						break;
					}
				}
			}
			plh.Controls.Add(dropDownList);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Date Field")));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			DropDownList dropDownList1 = new DropDownList()
			{
				ID = "ddl_interval",
				CssClass = "normaltext"
			};
			string lower1 = pg.ToLower();
			string str1 = lower1;
			if (lower1 != null)
			{
				if (str1 == "lead")
				{
					dropDownList1.Items.Insert(0, "");
					dropDownList1.Items[0].Text = this.objLanguage.convert("Create Date");
					dropDownList1.Items[0].Value = "createdate";
					dropDownList1.Items.Insert(1, "");
					dropDownList1.Items[1].Text = this.objLanguage.convert("Modified Date");
					dropDownList1.Items[1].Value = "modifieddate";
					dropDownList1.Items.Insert(2, "");
					dropDownList1.Items[2].Text = this.objLanguage.convert("Last View Date");
					dropDownList1.Items[2].Value = "lastviewdate";
					dropDownList1.Items.Insert(3, "");
					dropDownList1.Items[3].Text = this.objLanguage.convert("Convert Date");
					dropDownList1.Items[3].Value = "convertdate";
					goto Label0;
				}
				else
				{
					if (str1 != "campaign")
					{
						goto Label2;
					}
					dropDownList1.Items.Insert(0, "");
					dropDownList1.Items[0].Text = this.objLanguage.convert("Create Date");
					dropDownList1.Items[0].Value = "createdate";
					dropDownList1.Items.Insert(1, "");
					dropDownList1.Items[1].Text = this.objLanguage.convert("Modified Date");
					dropDownList1.Items[1].Value = "modifieddate";
					dropDownList1.Items.Insert(2, "");
					dropDownList1.Items[2].Text = this.objLanguage.convert("Last View Date");
					dropDownList1.Items[2].Value = "lastviewdate";
					goto Label0;
				}
			}
		Label2:
			dropDownList1.Items.Insert(0, "");
			dropDownList1.Items[0].Text = this.objLanguage.convert("Create Date");
			dropDownList1.Items[0].Value = "createdate";
			dropDownList1.Items.Insert(1, "");
			dropDownList1.Items[1].Text = this.objLanguage.convert("Modified Date");
			dropDownList1.Items[1].Value = "modifieddate";
			dropDownList1.Items.Insert(2, "");
			dropDownList1.Items[2].Text = this.objLanguage.convert("Last View Date");
			dropDownList1.Items[2].Value = "lastviewdate";
		Label0:
			plh.Controls.Add(dropDownList1);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("Date Interval"))));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			DropDownList dropDownList2 = new DropDownList()
			{
				ID = "ddl_currentfq",
				CssClass = "normaltext"
			};
			dropDownList2.Attributes.Add("onchange", "javascript:changecolDt(this.value);");
			string str2 = DateTime.Now.Month.ToString();
			int num = DateTime.Now.Year;
			DateTime dateTime = DateTime.Parse(string.Concat("01/", str2, "/", num.ToString()));
			dateTime.AddMonths(3).AddDays(-1);
			dateTime.AddMonths(6).AddDays(-1);
			DateTime dateTime1 = dateTime.AddMonths(-3);
			dateTime.AddMonths(3).AddDays(-1);
			DateTime now = DateTime.Now;
			DateTime dateTime2 = dateTime.AddMonths(3);
			dateTime2.AddMonths(3).AddDays(-1);
			dateTime.AddDays(-1);
			dateTime1.AddMonths(-3);
			dateTime.AddMonths(9).AddDays(-1);
			int year1 = DateTime.Now.Year;
			DateTime.Parse(string.Concat("01/01/", year1.ToString()));
			int num1 = DateTime.Now.Year;
			DateTime.Parse(string.Concat("12/31/", num1.ToString()));
			int year2 = DateTime.Now.Year;
			DateTime.Parse(string.Concat("01/01/", year2.ToString()));
			int num2 = DateTime.Now.AddMonths(-12).Year;
			DateTime.Parse(string.Concat("12/31/", num2.ToString()));
			int year3 = DateTime.Now.AddMonths(-12).Year;
			DateTime.Parse(string.Concat("01/01/", year3.ToString()));
			int num3 = DateTime.Now.AddMonths(12).Year;
			DateTime.Parse(string.Concat("01/01/", num3.ToString()));
			DateTime now1 = DateTime.Now.AddMonths(12);
			year = now1.Year;
			DateTime.Parse(string.Concat("12/31/", year.ToString()));
			now1 = DateTime.Now;
			DateTime dateTime3 = this.returnWeekDate(now1.AddDays(-7));
			DateTime dateTime4 = dateTime3.AddDays(6);
			now1 = DateTime.Now;
			DateTime dateTime5 = this.returnWeekDate(now1.AddDays(7));
			dateTime5.AddDays(6);
			DateTime dateTime6 = now.AddMonths(-1);
			year = dateTime6.Month;
			string str3 = year.ToString();
			year = dateTime6.Year;
			dateTime6 = DateTime.Parse(string.Concat(str3, "/01/", year.ToString()));
			string[] strArrays = new string[5];
			year = dateTime6.Month;
			strArrays[0] = year.ToString();
			strArrays[1] = "/";
			year = this.GetTotalDayOfMonth(dateTime6);
			strArrays[2] = year.ToString();
			strArrays[3] = "/";
			year = dateTime6.Year;
			strArrays[4] = year.ToString();
			DateTime dateTime7 = DateTime.Parse(string.Concat(strArrays));
			dropDownList2.Items.Insert(0, "Till Now");
			dropDownList2.Items[0].Text = this.objLanguage.convert("Till Now");
			dropDownList2.Items[0].Value = " @@ ";
			dropDownList2.Items.Insert(1, "Yesterday");
			dropDownList2.Items[1].Text = this.objLanguage.convert("Yesterday");
			ListItem item = dropDownList2.Items[1];
			now1 = DateTime.Now.AddDays(-1);
			string shortDateString = now1.ToShortDateString();
			now1 = DateTime.Now;
			item.Value = string.Concat(shortDateString, "@@", now1.ToShortDateString());
			dropDownList2.Items.Insert(2, "Last Week");
			dropDownList2.Items[2].Text = this.objLanguage.convert("Last Week");
			dropDownList2.Items[2].Value = string.Concat(dateTime3.ToShortDateString(), "@@", dateTime4.ToShortDateString());
			dropDownList2.Items.Insert(3, "Last Month");
			dropDownList2.Items[3].Text = this.objLanguage.convert("Last Month");
			dropDownList2.Items[3].Value = string.Concat(dateTime6.ToShortDateString(), "@@", dateTime7.ToShortDateString());
			dropDownList2.Items.Insert(4, "This Month");
			dropDownList2.Items[4].Text = this.objLanguage.convert("This Month");
			ListItem listItem = dropDownList2.Items[4];
			now1 = dateTime6.AddMonths(1);
			string shortDateString1 = now1.ToShortDateString();
			now1 = dateTime7.AddMonths(1);
			listItem.Value = string.Concat(shortDateString1, "@@", now1.ToShortDateString());
			plh.Controls.Add(dropDownList2);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("Start Date"))));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			TextBox textBox = new TextBox()
			{
				ID = "startdate",
				CssClass = "txtbox"
			};
			now1 = DateTime.Now.AddMonths(-12);
			textBox.Text = now1.ToShortDateString();
			textBox.Width = 100;
			textBox.Attributes.Add("onFocus", "javascript:this.select();lcs(this);");
			textBox.Attributes.Add("onClick", "javascript:event.cancelBubble=true;this.select();lcs(this);");
			plh.Controls.Add(textBox);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("End Date"))));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			TextBox textBox1 = new TextBox()
			{
				ID = "enddate",
				CssClass = "txtbox"
			};
			now1 = DateTime.Now.AddMonths(12);
			textBox1.Text = now1.ToShortDateString();
			textBox1.Width = 100;
			textBox1.Attributes.Add("onFocus", "javascript:this.select();lcs(this);");
			textBox1.Attributes.Add("onClick", "javascript:event.cancelBubble=true;this.select();lcs(this);");
			plh.Controls.Add(textBox1);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=headertext>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td width=100%>&nbsp;", this.objLanguage.convert("Advance Filters"), "</td>")));
			plh.Controls.Add(new LiteralControl("</tr>"));
			DropDownList[] dropDownListArray = new DropDownList[5];
			DropDownList[] dropDownListArray1 = new DropDownList[5];
			DropDownList[] dropDownListArray2 = new DropDownList[0];
			DropDownList dropDownList3 = new DropDownList();
			DropDownList dropDownList4 = new DropDownList();
			DropDownList dropDownList5 = new DropDownList();
			DropDownList dropDownList6 = new DropDownList();
			DropDownList dropDownList7 = new DropDownList();
			DropDownList dropDownList8 = new DropDownList();
			DropDownList dropDownList9 = new DropDownList();
			DropDownList dropDownList10 = new DropDownList();
			DropDownList dropDownList11 = new DropDownList();
			DropDownList dropDownList12 = new DropDownList();
			dropDownListArray[0] = dropDownList3;
			dropDownListArray[1] = dropDownList4;
			dropDownListArray[2] = dropDownList5;
			dropDownListArray[3] = dropDownList6;
			dropDownListArray[4] = dropDownList7;
			dropDownListArray1[0] = dropDownList8;
			dropDownListArray1[1] = dropDownList9;
			dropDownListArray1[2] = dropDownList10;
			dropDownListArray1[3] = dropDownList11;
			dropDownListArray1[4] = dropDownList12;
			for (int i = 0; i < (int)dropDownListArray.Length; i++)
			{
				dropDownListArray[i].CssClass = "normaltext";
				dropDownListArray1[i].CssClass = "normaltext";
			}
			createViewClass _createViewClass = new createViewClass();
			_createViewClass.initialize_DropDown(int.Parse(this.Session["companyid"].ToString()), pg, dropDownListArray2, dropDownListArray, dropDownListArray1);
			dropDownListArray[0].ID = "ddlsearchfield1";
			dropDownListArray[1].ID = "ddlsearchfield2";
			dropDownListArray[2].ID = "ddlsearchfield3";
			dropDownListArray[3].ID = "ddlsearchfield4";
			dropDownListArray[4].ID = "ddlsearchfield5";
			dropDownListArray1[0].ID = "ddlsearchcondition1";
			dropDownListArray1[1].ID = "ddlsearchcondition2";
			dropDownListArray1[2].ID = "ddlsearchcondition3";
			dropDownListArray1[3].ID = "ddlsearchcondition4";
			dropDownListArray1[4].ID = "ddlsearchcondition5";
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>&nbsp;"));
			plh.Controls.Add(dropDownListArray[0]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[0]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			TextBox textBox2 = new TextBox()
			{
				ID = "searchkeyword1",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox2);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			Label label1 = new Label()
			{
				ID = "lblerror1",
				Visible = false,
				Height = Unit.Pixel(25),
				CssClass = "error"
			};
			plh.Controls.Add(label1);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[1]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[1]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox2 = new TextBox()
			{
				ID = "searchkeyword2",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox2);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label1 = new Label()
			{
				ID = "lblerror2",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label1);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext>&nbsp;"));
			plh.Controls.Add(dropDownListArray[2]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[2]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox2 = new TextBox()
			{
				ID = "searchkeyword3",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox2);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label1 = new Label()
			{
				ID = "lblerror3",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label1);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[3]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[3]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox2 = new TextBox()
			{
				ID = "searchkeyword4",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox2);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("And")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr >"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label1 = new Label()
			{
				ID = "lblerror4",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label1);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td class=normaltext >&nbsp;"));
			plh.Controls.Add(dropDownListArray[4]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			plh.Controls.Add(dropDownListArray1[4]);
			plh.Controls.Add(new LiteralControl("&nbsp;"));
			textBox2 = new TextBox()
			{
				ID = "searchkeyword5",
				CssClass = "txtbox"
			};
			plh.Controls.Add(textBox2);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			plh.Controls.Add(new LiteralControl("<table align=center cellpadding=0 cellspacing=0 border=0 width=100%>"));
			plh.Controls.Add(new LiteralControl("<tr><td width=3px></td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			label1 = new Label()
			{
				ID = "lblerror5",
				CssClass = "error",
				Visible = false,
				Height = Unit.Pixel(25)
			};
			plh.Controls.Add(label1);
			plh.Controls.Add(new LiteralControl("</td></tr></table>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
		}

		public void display_plhSelectColumns(string pg, PlaceHolder plh, ListBox listbox1, bool isPostBack)
		{
			CheckBox checkBox;
			plh.Controls.Add(new LiteralControl("<table id='tb_display_plhSelectColumns' align=center cellpadding=1 cellspacing=1 border=0 width=99%>"));
			plh.Controls.Add(new LiteralControl("<tr><td>"));
			plh.Controls.Add(new LiteralControl("<table width=100% cellpadding=0 cellspacing=0 class=tablerowcolor2 align=center>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td colspan=5>"));
			plh.Controls.Add(new LiteralControl("<table cellspacing=0 cellpadding=0 width=100% border=0>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<td valign=top width=5 height=5 align=left class=bgcustomize><img src=", global.imagePath(), "lt_tabnotch.gif width=5 height=5/></td>")));
			plh.Controls.Add(new LiteralControl("<td width=99% align=left height=23 class='bgcustomize navigatorpanel'>Select Columns To Run Report</td>"));
			plh.Controls.Add(new LiteralControl("<td valign=top align=right width=5 height=5 class=bgcustomize>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "rt_tabnotch.gif'>")));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr></table></td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			int str = 0;
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td colspan=5>"));
			plh.Controls.Add(new LiteralControl("<table cellspacing=0 cellpadding=0 width=100% border=0 class=borderWithoutTop>"));
			plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "d") & (sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true")))
				{
					continue;
				}
				num++;
				bool flag = false;
				if (!isPostBack)
				{
					string str1 = pg;
					string str2 = str1;
					if (str1 != null)
					{
						switch (str2)
						{
							case "lead":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "firstname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "isconverted") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "companyname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "industryname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "title") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "client":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientsite") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientno") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "parentclient") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clienttypename") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ownershiptype") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "annualrevenue") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "contact":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "firstname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "title") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "contactalias") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "clientname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "mobile") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "opportunity":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "opportunityname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "opportunitytype") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "amount") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "expectedamount") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "opportunitystagename") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "probability") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "forecast":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "forecastname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "forecastyear") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "quoteamount1") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "commitamount1") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "bestcaseamount1") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "campaign":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "campaignname") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "campaignstatus") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "campaigntype") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "expectedrevenue") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "budgetedcost") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "actualcost") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "startdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "ticket":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ticketnumber") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ticketalias") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "tickettype") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ticketstatus") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ticketreason") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "subject") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "closedate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
							case "solution":
							{
								if (!(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "solutionnumber") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "solutionalias") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "solutiontitle") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "ispublished") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "solutionstatus") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "createdate") && !(sqlDataReader["databasefieldname"].ToString().ToLower().Trim() == "lastviewdate"))
								{
									break;
								}
								flag = true;
								listbox1.Items.Insert(str, sqlDataReader["labelName"].ToString());
								listbox1.Items[str].Text = sqlDataReader["labelName"].ToString();
								listbox1.Items[str].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
								str++;
								break;
							}
						}
					}
				}
				plh.Controls.Add(new LiteralControl("<td nowrap>"));
				checkBox = new CheckBox()
				{
					Checked = flag,
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_selectedcolumns")
				};
				AttributeCollection attributes = checkBox.Attributes;
				string[] strArrays = new string[] { "selectThisField('", sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString(), "','", this.objLanguage.convert(sqlDataReader["labelname"].ToString()), "',this.name)" };
				attributes.Add("onclick", string.Concat(strArrays));
				checkBox.Text = this.objLanguage.convert(sqlDataReader["labelName"].ToString());
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				if (num % 5 != 0)
				{
					continue;
				}
				if (num % 10 != 0)
				{
					plh.Controls.Add(new LiteralControl("</tr><tr class=NewAlternative>"));
				}
				else
				{
					plh.Controls.Add(new LiteralControl("</tr><tr class=NewTableRows>"));
				}
			}
			plh.Controls.Add(new LiteralControl("</tr></table></td></tr>"));
			plh.Controls.Add(new LiteralControl(string.Concat("<tr><td><img alt= src=", this.strImagepath, "nil.gif width=1 height=20 /></td></tr>")));
			sqlDataReader.Close();
			this.cmn.closeConnection();
			sqlCommand = new SqlCommand("crm_common_select_customizefield", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			sqlDataReader = sqlCommand.ExecuteReader();
			num = 0;
			bool flag1 = true;
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["fieldtype"].ToString().ToLower().Trim() == "e") & (sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true")))
				{
					continue;
				}
				if (flag1)
				{
					plh.Controls.Add(new LiteralControl("<tr><td colspan=5><table align=center cellpadding=0  cellspacing=0 border=0 width=100%>"));
					plh.Controls.Add(new LiteralControl("<tr>"));
					plh.Controls.Add(new LiteralControl("<td height=5 align=left valign=top class=bgcustomize>"));
					plh.Controls.Add(new LiteralControl(string.Concat("<img height=5 src='", global.imagePath(), "lt_tabnotch.gif'>")));
					plh.Controls.Add(new LiteralControl("</td>"));
					plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap  align=left width=100% class='bgcustomize navigatorpanel' height=23>&nbsp;", this.objLanguage.convert("Select Columns Created By You"), "</td>")));
					plh.Controls.Add(new LiteralControl("<td valign=top width=5 height=5 class=bgcustomize>"));
					plh.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "rt_tabnotch.gif'>")));
					plh.Controls.Add(new LiteralControl("</td>"));
					plh.Controls.Add(new LiteralControl("</tr>"));
					plh.Controls.Add(new LiteralControl("</table></td></tr>"));
					plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				}
				flag1 = false;
				num++;
				plh.Controls.Add(new LiteralControl("<td nowrap>"));
				checkBox = new CheckBox()
				{
					ID = string.Concat(sqlDataReader["databasefieldname"].ToString(), "_selectedcolumns")
				};
				AttributeCollection attributeCollection = checkBox.Attributes;
				string[] strArrays1 = new string[] { "selectThisField('", sqlDataReader["CustomizeID"].ToString(), "__e__", sqlDataReader["inputtype"].ToString(), "','", sqlDataReader["labelname"].ToString(), "',this.name)" };
				attributeCollection.Add("onclick", string.Concat(strArrays1));
				checkBox.Text = sqlDataReader["labelName"].ToString();
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				if (num % 5 != 0)
				{
					continue;
				}
				if (num % 10 != 0)
				{
					plh.Controls.Add(new LiteralControl("</tr><tr class=NewAlternative>"));
				}
				else
				{
					plh.Controls.Add(new LiteralControl("</tr><tr class=NewTableRows>"));
				}
			}
			sqlDataReader.Close();
			this.cmn.closeConnection();
			if (pg == "forecast")
			{
				plh.Controls.Add(new LiteralControl("<tr>"));
				plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap colspan=5 class=headertext>", this.objLanguage.convert("Select Calculated Columns"), "</td>")));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalquoteamount"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalquoteamount__c__currency','", this.objLanguage.convert("Total Quote Amount"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Quote Amount");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalcommitamount"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalcommitamount__c__currency','", this.objLanguage.convert("Total Commit Amount"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Commit Amount");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalbestcaseamount"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalbestcaseamount__c__currency','", this.objLanguage.convert("Total Best Case Amount"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Best Case Amount");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalpipeline"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalpipeline__c__currency','", this.objLanguage.convert("Total PipeLine"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total PipeLine");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalclosedwon"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalclosedwon__c__number','", this.objLanguage.convert("Total Closed & Won"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Closed & Won");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalclosedlost"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalclosedlost__c__currency','", this.objLanguage.convert("Total Closed & Lost"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Closed & Lost");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext colspan=3>"));
				checkBox = new CheckBox()
				{
					ID = "totalquotepercentage"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalquotepercentage__c__currency','", this.objLanguage.convert("Total Quote %"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total Quote %");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
			}
			if (pg == "campaign")
			{
				plh.Controls.Add(new LiteralControl("<tr>"));
				plh.Controls.Add(new LiteralControl(string.Concat("<td nowrap colspan=5 class=headertext>", this.objLanguage.convert("Select Calculated Columns"), "</td>")));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "convertedleads"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('convertedleads__c__number','", this.objLanguage.convert("Converted leads"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Converted leads");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "ROI"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('ROI__c__number','", this.objLanguage.convert("ROI"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("ROI");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "averagecostpercustomer"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('averagecostpercustomer__c__currency','", this.objLanguage.convert("Average cost per customer"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Average cost per customer");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "averagecostperresponse"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('averagecostperresponse__c__currency','", this.objLanguage.convert("Average cost per response"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Average cost per response");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "averagecostperlead"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('averagecostperlead__c__currency','", this.objLanguage.convert("Average cost per lead"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Average cost per lead");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewAlternative>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "averagecostperopportunity"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('averagecostperopportunity__c__currency','", this.objLanguage.convert("Average cost per opportunity"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Average cost per opportunity");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalresponse"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalresponse__c__number','", this.objLanguage.convert("Total response"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total response");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalleads"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalleads__c__number','", this.objLanguage.convert("Total leads"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total leads");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalopportunities"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalopportunities__c__number','", this.objLanguage.convert("Total opportunities"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total opportunities");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalwonopportunities"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalwonopportunities__c__number','", this.objLanguage.convert("Total won opportunities"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total won opportunities");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
				plh.Controls.Add(new LiteralControl("<tr class=NewTableRows>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalvalueopportunities"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalvalueopportunities__c__currency','", this.objLanguage.convert("Total value opportunities"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total value opportunities");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap class=normaltext>"));
				checkBox = new CheckBox()
				{
					ID = "totalvaluewonopportunities"
				};
				checkBox.Attributes.Add("onclick", string.Concat("selectThisField('totalvaluewonopportunities__c__currency','", this.objLanguage.convert("Total value won opportunities"), "',this.name)"));
				checkBox.Text = this.objLanguage.convert("Total value won opportunities");
				plh.Controls.Add(checkBox);
				plh.Controls.Add(new LiteralControl("</td>"));
				plh.Controls.Add(new LiteralControl("<td nowrap colspan=3></td>"));
				plh.Controls.Add(new LiteralControl("</tr>"));
			}
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
		}

		public void display_plhSummary(string pg, PlaceHolder plh)
		{
			plh.Controls.Add(new LiteralControl("<table align=left cellpadding=1 cellspacing=1 border=0 width=99%>"));
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td class=headertext>"));
			Label label = new Label()
			{
				ID = "lblSummary",
				Text = "Step 2: "
			};
			plh.Controls.Add(label);
			plh.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.convert("Select the grouping for which you would like to calculate summary information"))));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td><hr size=1 color=#CACACA /></td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td class=normaltext>"));
			plh.Controls.Add(new LiteralControl(this.objLanguage.convert("Select columns by which your report will be grouped")));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("<tr><td>"));
			plh.Controls.Add(new LiteralControl("<table width=100% cellpadding=2 cellspacing=2 align=left>"));
			plh.Controls.Add(new LiteralControl("<tr class=normaltext>"));
			plh.Controls.Add(new LiteralControl("<td nowrap class=headertext>"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Summarize information by"), ":&nbsp;")));
			DropDownList dropDownList = new DropDownList()
			{
				ID = "ddl_summarizeby",
				CssClass = "normaltext"
			};
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", this.cmn.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			while (sqlDataReader.Read())
			{
				if (!((sqlDataReader["isdisplayed"].ToString().ToLower().Trim() == "true") & (sqlDataReader["databasefieldname"].ToString().ToLower() != "description")))
				{
					continue;
				}
				dropDownList.Items.Insert(num, sqlDataReader["labelname"].ToString());
				dropDownList.Items[num].Text = sqlDataReader["labelname"].ToString();
				if (sqlDataReader["fieldtype"].ToString().ToLower().Trim() != "d")
				{
					dropDownList.Items[num].Value = string.Concat(sqlDataReader["CustomizeID"].ToString(), "__e__", sqlDataReader["inputtype"].ToString());
				}
				else
				{
					dropDownList.Items[num].Value = string.Concat(sqlDataReader["databasefieldname"].ToString(), "__d__", sqlDataReader["inputtype"].ToString());
				}
				num++;
			}
			sqlDataReader.Close();
			this.cmn.closeConnection();
			plh.Controls.Add(dropDownList);
			plh.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			plh.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.convert("Sort order"), ":&nbsp;")));
			DropDownList dropDownList1 = new DropDownList()
			{
				ID = "ddl_sortorder",
				CssClass = "normaltext"
			};
			dropDownList1.Items.Insert(0, "Ascending");
			dropDownList1.Items[0].Text = this.objLanguage.convert("Ascending");
			dropDownList1.Items[0].Value = "asc";
			dropDownList1.Items.Insert(1, "Descending");
			dropDownList1.Items[1].Text = this.objLanguage.convert("Descending");
			dropDownList1.Items[1].Value = "desc";
			plh.Controls.Add(dropDownList1);
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
			plh.Controls.Add(new LiteralControl("</td></tr>"));
			plh.Controls.Add(new LiteralControl("</table>"));
		}

		public string fieldElement(string databasefieldname, int companyId, int userId, string strDate, string inputtype, string labelname)
		{
			if (databasefieldname.ToLower().Trim() == "campaignid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnCampaignName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "clientid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnClientName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "contactid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnContactName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "assigntogroupid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnGroupName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "reporttouserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "createuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "modifyuserid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (databasefieldname.ToLower().Trim() == "userid")
			{
				strDate = string.Concat(global.databaseUserName().ToString(), ".ReturnUserName(", strDate, ") ");
			}
			if (!(inputtype.ToLower().Trim() == "currency") && (inputtype.ToLower().Trim() == "date") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "createdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "modifieddate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "lastviewdate") | (databasefieldname.Trim().ToLower().Replace(" ", "") == "convertdate"))
			{
				try
				{
					Convert.ToDateTime(strDate);
					object[] str = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, ", ", companyId, ", ", userId, ") " };
					strDate = string.Concat(str);
				}
				catch
				{
				}
			}
			return strDate;
		}

		public string fieldElement_U(string databasefieldname, int companyId, int userId, string strDate, string inputtype)
		{
			if (!(inputtype.ToLower().Trim() == "currency") && inputtype.ToLower().Trim() == "date")
			{
				object[] str = new object[] { global.databaseUserName().ToString(), ".return_DateTime_Before_View(", strDate, ", ", companyId, ", ", userId, ") " };
				strDate = string.Concat(str);
			}
			return strDate;
		}

		public int GetTotalDayOfMonth(DateTime dateval)
		{
			string str = dateval.Month.ToString();
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "1":
					{
						return 31;
					}
					case "2":
					{
						if (dateval.Year / 4 == 0)
						{
							return 29;
						}
						return 28;
					}
					case "3":
					{
						return 31;
					}
					case "4":
					{
						return 30;
					}
					case "5":
					{
						return 31;
					}
					case "6":
					{
						return 30;
					}
					case "7":
					{
						return 31;
					}
					case "8":
					{
						return 31;
					}
					case "9":
					{
						return 30;
					}
					case "10":
					{
						return 31;
					}
					case "11":
					{
						return 30;
					}
					case "12":
					{
						return 31;
					}
				}
			}
			return 0;
		}

		public void notIsPostBack(Button btnCustomizeReport, Panel pnlReport, Button btnRunReport2, RadioButton rdtabular, RadioButton rdsummary, RadioButton rdmixed, Image imgTabularReport, Image imgSummaryReport, Image imgMixedReport)
		{
			btnCustomizeReport.Visible = false;
			pnlReport.Visible = false;
			btnRunReport2.Attributes.Add("onclick", "checkSearchCondition()");
			rdtabular.Attributes.Add("onclick", "rdtabular_onclick()");
			rdsummary.Attributes.Add("onclick", "rdsummary_onclick()");
			rdmixed.Attributes.Add("onclick", "rdmixed_onclick()");
			imgTabularReport.Attributes.Add("onclick", "rdtabular_onclick()");
			imgSummaryReport.Attributes.Add("onclick", "rdsummary_onclick()");
			imgMixedReport.Attributes.Add("onclick", "rdmixed_onclick()");
			string str = "";
			str = " <script language=JavaScript>";
			str = string.Concat(str, " var pnlMatrix = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');                               ");
			str = string.Concat(str, " pnlMatrix.style.display='none';                   ");
			str = string.Concat(str, " var pnlSummary = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');                               ");
			str = string.Concat(str, " pnlSummary.style.display='none';                   ");
			str = string.Concat(str, "  </script>                                                     ");
			if (!base.IsStartupScriptRegistered("clientScript1"))
			{
				this.RegisterStartupScript("clientScript1", str);
			}
		}

		public void onIsPostBack(HtmlInputHidden txttest, ListBox ListBox1, RadioButton rdmixed, RadioButton rdsummary)
		{
			string str = "";
			string str1 = txttest.Value.Trim();
			if (str1.Length > 0)
			{
				str1 = str1.Substring(1);
			}
			if (str1 != "")
			{
				string[] strArrays = str1.Split(new char[] { '$' });
				ListBox1.Items.Clear();
				str = " <script language=JavaScript>";
				str = string.Concat(str, " var ctl_ListBox = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');                               ");
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '\u005E' });
					string str2 = strArrays1[0];
					string str3 = strArrays1[1];
					str3.Substring(str3.Length - 2, 2);
					str3.Substring(0, str3.Length - 2);
					object obj = str;
					object[] objArray = new object[] { obj, " ctl_ListBox.options[", i, "] = new Option();" };
					str = string.Concat(objArray);
					object obj1 = str;
					object[] objArray1 = new object[] { obj1, " ctl_ListBox.options[", i, "].text = '", str2, "';" };
					str = string.Concat(objArray1);
					object obj2 = str;
					object[] objArray2 = new object[] { obj2, " ctl_ListBox.options[", i, "].value = '", str3, "';" };
					str = string.Concat(objArray2);
				}
				if ((int)strArrays.Length > 1)
				{
					str = string.Concat(str, " var img1 = document.getElementById('ctl00_ContentPlaceHolder1_imgTop');");
					str = string.Concat(str, " var img2 = document.getElementById('ctl00_ContentPlaceHolder1_imgUp');");
					str = string.Concat(str, " var img3 = document.getElementById('ctl00_ContentPlaceHolder1_imgDown');");
					str = string.Concat(str, " var img4 = document.getElementById('ctl00_ContentPlaceHolder1_imgBottom');");
					str = string.Concat(str, " img1.style.display='block';");
					str = string.Concat(str, " img2.style.display='block';");
					str = string.Concat(str, " img3.style.display='block';");
					str = string.Concat(str, " img4.style.display='block';");
				}
				str = string.Concat(str, "  </script>                                                     ");
				if (!base.IsStartupScriptRegistered("clientScript4"))
				{
					this.RegisterStartupScript("clientScript4", str);
				}
			}
			if (rdmixed.Checked.ToString().ToLower() != "true")
			{
				str = " <script language=JavaScript>";
				str = string.Concat(str, " var pnlMatrix = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');                               ");
				str = string.Concat(str, " pnlMatrix.style.display='none';                   ");
				str = string.Concat(str, "  </script>                                                     ");
				if (!base.IsStartupScriptRegistered("clientScript3"))
				{
					this.RegisterStartupScript("clientScript3", str);
				}
			}
			else
			{
				str = " <script language=JavaScript>";
				str = string.Concat(str, " var pnlMatrix = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');                               ");
				str = string.Concat(str, " pnlMatrix.style.display='block';                   ");
				str = string.Concat(str, "  </script>                                                     ");
				if (!base.IsStartupScriptRegistered("clientScript3"))
				{
					this.RegisterStartupScript("clientScript3", str);
				}
			}
			if (rdsummary.Checked.ToString().ToLower() != "true")
			{
				str = " <script language=JavaScript>";
				str = string.Concat(str, " var pnlSummary = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');                               ");
				str = string.Concat(str, " pnlSummary.style.display='none';                   ");
				str = string.Concat(str, "  </script>                                                     ");
				if (!base.IsStartupScriptRegistered("clientScript2"))
				{
					this.RegisterStartupScript("clientScript2", str);
				}
			}
			else
			{
				str = " <script language=JavaScript>";
				str = string.Concat(str, " var pnlSummary = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');                               ");
				str = string.Concat(str, " pnlSummary.style.display='block';                   ");
				str = string.Concat(str, "  </script>                                                     ");
				if (!base.IsStartupScriptRegistered("clientScript2"))
				{
					this.RegisterStartupScript("clientScript2", str);
					return;
				}
			}
		}

		public string ReplaceIDwithText(string databasefieldname, string fieldvalue)
		{
			bool flag = true;
			string str = "";
			commonClass _commonClass = new commonClass();
			if (databasefieldname.ToLower().Trim() == "campaignid")
			{
				string[] strArrays = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnCampaignName(", fieldvalue, ") " };
				str = string.Concat(strArrays);
			}
			else if (databasefieldname.ToLower().Trim() == "clientid")
			{
				string[] str1 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnClientName(", fieldvalue, ") " };
				str = string.Concat(str1);
			}
			else if (databasefieldname.ToLower().Trim() == "contactid")
			{
				string[] strArrays1 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnContactName(", fieldvalue, ") " };
				str = string.Concat(strArrays1);
			}
			else if (databasefieldname.ToLower().Trim() == "assigntouserid")
			{
				string[] str2 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnUserName(", fieldvalue, ") " };
				str = string.Concat(str2);
			}
			else if (databasefieldname.ToLower().Trim() == "assigntogroupid")
			{
				string[] strArrays2 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnGroupName(", fieldvalue, ") " };
				str = string.Concat(strArrays2);
			}
			else if (databasefieldname.ToLower().Trim() == "reporttouserid")
			{
				string[] str3 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnUserName(", fieldvalue, ") " };
				str = string.Concat(str3);
			}
			else if (databasefieldname.ToLower().Trim() == "createuserid")
			{
				string[] strArrays3 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnUserName(", fieldvalue, ") " };
				str = string.Concat(strArrays3);
			}
			else if (databasefieldname.ToLower().Trim() != "modifyuserid")
			{
				flag = false;
			}
			else
			{
				string[] str4 = new string[] { " select ", global.databaseUserName().ToString(), ".ReturnUserName(", fieldvalue, ") " };
				str = string.Concat(str4);
			}
			string str5 = "";
			if (!flag)
			{
				str5 = fieldvalue;
			}
			else
			{
				SqlCommand sqlCommand = new SqlCommand(str, _commonClass.openConnection());
				str5 = sqlCommand.ExecuteScalar().ToString();
				_commonClass.closeConnection();
			}
			return str5;
		}

		public string returnCampaigncalculatedFieldSummary(string reporttype, string checkboxname, string strSearchCondition, string addaccessright, string checkDateInterval)
		{
			commonClass _commonClass;
			SqlDataReader sqlDataReader;
			string str = "";
			string str1 = "";
			string str2 = "";
			string str3 = reporttype;
			string str4 = str3;
			if (str3 != null)
			{
				if (str4 == "matrix")
				{
					str = "";
					if (str1 != "")
					{
						_commonClass = new commonClass();
						sqlDataReader = (new SqlCommand(str1, _commonClass.openConnection())).ExecuteReader();
						while (sqlDataReader.Read())
						{
							str = string.Concat(str2, sqlDataReader["result"].ToString());
						}
						sqlDataReader.Close();
						_commonClass.closeConnection();
					}
					return str;
				}
				else
				{
					if (str4 != "summary")
					{
						goto Label2;
					}
					str = "";
					if (str1 != "")
					{
						_commonClass = new commonClass();
						sqlDataReader = (new SqlCommand(str1, _commonClass.openConnection())).ExecuteReader();
						while (sqlDataReader.Read())
						{
							str = string.Concat(str2, sqlDataReader["result"].ToString());
						}
						sqlDataReader.Close();
						_commonClass.closeConnection();
					}
					return str;
				}
			}
		Label2:
			string str5 = checkboxname;
			string str6 = str5;
			if (str5 != null)
			{
				switch (str6)
				{
					case "totalleads_sum":
					{
						str1 = " select count(*) as result from tb_lead where isdelete=0 and campaignid in (";
						object obj = str1;
						object[] objArray = new object[] { obj, " select campaignid from tb_campaign L where L.companyid=", int.Parse(this.Session["companyid"].ToString()), strSearchCondition, addaccessright, checkDateInterval, ") " };
						str1 = string.Concat(objArray);
						str2 = string.Concat(this.objLanguage.convert("Sum"), ": ");
						break;
					}
					case "totalleads_average":
					{
						object[] objArray1 = new object[] { " select count(*)/(select count(*) from tb_campaign L where companyid=", int.Parse(this.Session["companyid"].ToString()), strSearchCondition, addaccessright, checkDateInterval, ") as result from tb_lead where isdelete=0 and campaignid in (" };
						str1 = string.Concat(objArray1);
						object obj1 = str1;
						object[] objArray2 = new object[] { obj1, " select campaignid from tb_campaign L where L.companyid=", int.Parse(this.Session["companyid"].ToString()), strSearchCondition, addaccessright, checkDateInterval, ") " };
						str1 = string.Concat(objArray2);
						str2 = string.Concat(this.objLanguage.convert("Avg"), ": ");
						break;
					}
					case "totalleads_largest":
					{
						str1 = " select top 1 count(A.leadid) as result from tb_campaign L LEFT JOIN tb_lead A ON A.campaignid=L.campaignid and A.isdelete=0 ";
						object obj2 = str1;
						object[] objArray3 = new object[] { obj2, " where L.companyid=", int.Parse(this.Session["companyid"].ToString()), strSearchCondition, addaccessright, checkDateInterval, " group by L.campaignid order by result desc" };
						str1 = string.Concat(objArray3);
						str2 = string.Concat(this.objLanguage.convert("Max"), ": ");
						break;
					}
					case "totalleads_smallest":
					{
						str1 = " select top 1 count(A.leadid) as result from tb_campaign L LEFT JOIN tb_lead A ON A.campaignid=L.campaignid and A.isdelete=0 ";
						object obj3 = str1;
						object[] objArray4 = new object[] { obj3, " where L.companyid=", int.Parse(this.Session["companyid"].ToString()), strSearchCondition, addaccessright, checkDateInterval, " group by L.campaignid order by result asc" };
						str1 = string.Concat(objArray4);
						str2 = string.Concat(this.objLanguage.convert("Min"), ": ");
						break;
					}
					case "totalopportunities_sum":
					{
						str2 = string.Concat(this.objLanguage.convert("Sum"), ": ");
						break;
					}
					case "totalopportunities_average":
					{
						str2 = string.Concat(this.objLanguage.convert("Avg"), ": ");
						break;
					}
					case "totalopportunities_largest":
					{
						str2 = string.Concat(this.objLanguage.convert("Max"), ": ");
						break;
					}
					case "totalopportunities_smallest":
					{
						str2 = string.Concat(this.objLanguage.convert("Min"), ": ");
						break;
					}
					case "totalwonopportunities_sum":
					{
						str2 = string.Concat(this.objLanguage.convert("Sum"), ": ");
						break;
					}
					case "totalwonopportunities_average":
					{
						str2 = string.Concat(this.objLanguage.convert("Avg"), ": ");
						break;
					}
					case "totalwonopportunities_largest":
					{
						str2 = string.Concat(this.objLanguage.convert("Max"), ": ");
						break;
					}
					case "totalwonopportunities_smallest":
					{
						str2 = string.Concat(this.objLanguage.convert("Min"), ": ");
						break;
					}
					case "totalvalueopportunities_sum":
					{
						str2 = string.Concat(this.objLanguage.convert("Sum"), ": ");
						break;
					}
					case "totalvalueopportunities_average":
					{
						str2 = string.Concat(this.objLanguage.convert("Avg"), ": ");
						break;
					}
					case "totalvalueopportunities_largest":
					{
						str2 = string.Concat(this.objLanguage.convert("Max"), ": ");
						break;
					}
					case "totalvalueopportunities_smallest":
					{
						str2 = string.Concat(this.objLanguage.convert("Min"), ": ");
						break;
					}
					case "totalvaluewonopportunities_sum":
					{
						str2 = string.Concat(this.objLanguage.convert("Sum"), ": ");
						break;
					}
					case "totalvaluewonopportunities_average":
					{
						str2 = string.Concat(this.objLanguage.convert("Avg"), ": ");
						break;
					}
					case "totalvaluewonopportunities_largest":
					{
						str2 = string.Concat(this.objLanguage.convert("Max"), ": ");
						break;
					}
					case "totalvaluewonopportunities_smallest":
					{
						str2 = string.Concat(this.objLanguage.convert("Min"), ": ");
						break;
					}
				}
			}
			if (str1 != "")
			{
				_commonClass = new commonClass();
				sqlDataReader = (new SqlCommand(str1, _commonClass.openConnection())).ExecuteReader();
				while (sqlDataReader.Read())
				{
					str = string.Concat(str2, sqlDataReader["result"].ToString());
				}
				sqlDataReader.Close();
				_commonClass.closeConnection();
			}
			return str;
		}

		public string returnCustomizedTableColumn(string pg)
		{
			string str = pg;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "lead":
					{
						return " leadcustomizeid ";
					}
					case "client":
					{
						return " clientcustomizeid ";
					}
					case "contact":
					{
						return " contactcustomizeid ";
					}
					case "opportunity":
					{
						return " opportunitycustomizeid ";
					}
					case "forecast":
					{
						return " forecastcustomizeid ";
					}
					case "campaign":
					{
						return " campaigncustomizeid ";
					}
					case "ticket":
					{
						return " casecustomizeid ";
					}
					case "solution":
					{
						return " solutioncustomizeid ";
					}
				}
			}
			return "ERROR";
		}

		public string returnCustomizeTableName(string pg)
		{
			string str = pg;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "lead":
					{
						return " tb_leadcustomizevalue ";
					}
					case "client":
					{
						return " tb_clientcustomizevalue ";
					}
					case "contact":
					{
						return " tb_contactcustomizevalue ";
					}
					case "opportunity":
					{
						return " tb_opportunitycustomizevalue ";
					}
					case "forecast":
					{
						return " tb_forecastcustomizevalue ";
					}
					case "campaign":
					{
						return " tb_campaigncustomizevalue ";
					}
					case "ticket":
					{
						return " tb_ticketcustomizevalue ";
					}
					case "solution":
					{
						return " tb_solutioncustomizevalue ";
					}
				}
			}
			return "ERROR";
		}

		public string returnSumQuery(string pg, string rowfield, string rowfielddatatype, string rowfieldvalue, string rowfieldtype, string columnfield, string columnfielddatatype, string columnfieldvalue, string columnfieldtype, string matrix_sum_query, string addaccessright, string checkDateInterval, string strSearchCondition)
		{
			string str = "";
			string str1 = "";
			string str2 = "";
			string str3 = "";
			if ((rowfielddatatype.ToLower().Trim() == "checkbox") & (rowfieldtype == "d"))
			{
				if (rowfieldvalue.ToLower().Trim() != "true")
				{
					rowfieldvalue = "0";
				}
				else
				{
					rowfieldvalue = "1";
				}
			}
			if ((columnfielddatatype.ToLower().Trim() == "checkbox") & (columnfieldtype == "d"))
			{
				if (columnfieldvalue.ToLower().Trim() != "true")
				{
					columnfieldvalue = "0";
				}
				else
				{
					columnfieldvalue = "1";
				}
			}
			if (rowfieldtype == "d")
			{
				if ((rowfielddatatype.ToLower().Trim() != "currency") & (rowfielddatatype.ToLower().Trim() != "number"))
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				}
				else if (rowfieldvalue == "")
				{
					rowfieldvalue = "0";
				}
				str2 = string.Concat(rowfield, "=", rowfieldvalue);
			}
			else if (rowfielddatatype.ToLower().Trim() != "currency")
			{
				rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				str2 = string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
			}
			else
			{
				try
				{
					if (rowfieldvalue.Trim() == "")
					{
						rowfieldvalue = "0";
					}
					str2 = string.Concat(" cast(cast(isnull(C.customizedvalue,'') as nvarchar(4000)) as money)=", rowfieldvalue);
				}
				catch
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
					str2 = string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
				}
			}
			if (columnfieldtype == "d")
			{
				if ((columnfielddatatype.ToLower().Trim() != "currency") & (columnfielddatatype.ToLower().Trim() != "number"))
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				}
				else if (columnfieldvalue == "")
				{
					columnfieldvalue = "0";
				}
				str3 = string.Concat(columnfield, "=", columnfieldvalue);
			}
			else if (columnfielddatatype.ToLower().Trim() != "currency")
			{
				columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				str3 = string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
			}
			else
			{
				try
				{
					if (columnfieldvalue.Trim() == "")
					{
						columnfieldvalue = "0";
					}
					str3 = string.Concat(" cast(cast(isnull(D.customizedvalue,'') as nvarchar(4000)) as money)=", columnfieldvalue);
				}
				catch
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
					str3 = string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
				}
			}
			if (rowfieldtype == "d")
			{
				if (columnfieldtype != "d")
				{
					string[] strArrays = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
					str1 = string.Concat(strArrays);
					string[] matrixSumQuery = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND ", str3, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery);
				}
				else
				{
					str1 = string.Concat(" FROM ", this.returnTableName(pg), " ");
					string[] matrixSumQuery1 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND ", str3, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery1);
				}
			}
			else if (columnfieldtype != "d")
			{
				string[] strArrays1 = new string[] { "  FROM ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield, " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
				str1 = string.Concat(strArrays1);
				string[] matrixSumQuery2 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str3, " AND ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery2);
			}
			else
			{
				string[] strArrays2 = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield };
				str1 = string.Concat(strArrays2);
				string[] matrixSumQuery3 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str3, " AND ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery3);
			}
			return str;
		}

		public string returnSumQueryAtColumnEnd(string pg, string rowfield, string rowfielddatatype, string rowfieldvalue, string rowfieldtype, string columnfield, string columnfielddatatype, string columnfieldvalue, string columnfieldtype, string matrix_sum_query, string addaccessright, string checkDateInterval, string strSearchCondition)
		{
			string str = "";
			string str1 = "";
			string str2 = "";
			if ((rowfielddatatype.ToLower().Trim() == "checkbox") & (rowfieldtype == "d"))
			{
				if (rowfieldvalue.ToLower().Trim() != "true")
				{
					rowfieldvalue = "0";
				}
				else
				{
					rowfieldvalue = "1";
				}
			}
			if ((columnfielddatatype.ToLower().Trim() == "checkbox") & (columnfieldtype == "d"))
			{
				if (columnfieldvalue.ToLower().Trim() != "true")
				{
					columnfieldvalue = "0";
				}
				else
				{
					columnfieldvalue = "1";
				}
			}
			if (rowfieldtype == "d")
			{
				if ((rowfielddatatype.ToLower().Trim() != "currency") & (rowfielddatatype.ToLower().Trim() != "number"))
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				}
				else if (rowfieldvalue == "")
				{
					rowfieldvalue = "0";
				}
				string.Concat(rowfield, "=", rowfieldvalue);
			}
			else if (rowfielddatatype.ToLower().Trim() != "currency")
			{
				rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
			}
			else
			{
				try
				{
					if (rowfieldvalue.Trim() == "")
					{
						rowfieldvalue = "0";
					}
					string.Concat(" cast(cast(isnull(C.customizedvalue,'') as nvarchar(4000)) as money)=", rowfieldvalue);
				}
				catch
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
					string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
				}
			}
			if (columnfieldtype == "d")
			{
				if ((columnfielddatatype.ToLower().Trim() != "currency") & (columnfielddatatype.ToLower().Trim() != "number"))
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				}
				else if (columnfieldvalue == "")
				{
					columnfieldvalue = "0";
				}
				str2 = string.Concat(columnfield, "=", columnfieldvalue);
			}
			else if (columnfielddatatype.ToLower().Trim() != "currency")
			{
				columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				str2 = string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
			}
			else
			{
				try
				{
					if (columnfieldvalue.Trim() == "")
					{
						columnfieldvalue = "0";
					}
					str2 = string.Concat(" cast(cast(isnull(D.customizedvalue,'') as nvarchar(4000)) as money)=", columnfieldvalue);
				}
				catch
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
					str2 = string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
				}
			}
			if (rowfieldtype == "d")
			{
				if (columnfieldtype != "d")
				{
					string[] strArrays = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
					str1 = string.Concat(strArrays);
					string[] matrixSumQuery = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery);
				}
				else
				{
					str1 = string.Concat(" FROM ", this.returnTableName(pg), " ");
					string[] matrixSumQuery1 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery1);
				}
			}
			else if (columnfieldtype != "d")
			{
				string[] strArrays1 = new string[] { "  FROM ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield, " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
				str1 = string.Concat(strArrays1);
				string[] matrixSumQuery2 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery2);
			}
			else
			{
				string[] strArrays2 = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield };
				str1 = string.Concat(strArrays2);
				string[] matrixSumQuery3 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery3);
			}
			return str;
		}

		public string returnSumQueryAtRowEnd(string pg, string rowfield, string rowfielddatatype, string rowfieldvalue, string rowfieldtype, string columnfield, string columnfielddatatype, string columnfieldvalue, string columnfieldtype, string matrix_sum_query, string addaccessright, string checkDateInterval, string strSearchCondition)
		{
			string str = "";
			string str1 = "";
			string str2 = "";
			if ((rowfielddatatype.ToLower().Trim() == "checkbox") & (rowfieldtype == "d"))
			{
				if (rowfieldvalue.ToLower().Trim() != "true")
				{
					rowfieldvalue = "0";
				}
				else
				{
					rowfieldvalue = "1";
				}
			}
			if ((columnfielddatatype.ToLower().Trim() == "checkbox") & (columnfieldtype == "d"))
			{
				if (columnfieldvalue.ToLower().Trim() != "true")
				{
					columnfieldvalue = "0";
				}
				else
				{
					columnfieldvalue = "1";
				}
			}
			if (rowfieldtype == "d")
			{
				if ((rowfielddatatype.ToLower().Trim() != "currency") & (rowfielddatatype.ToLower().Trim() != "number"))
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				}
				else if (rowfieldvalue == "")
				{
					rowfieldvalue = "0";
				}
				str2 = string.Concat(rowfield, "=", rowfieldvalue);
			}
			else if (rowfielddatatype.ToLower().Trim() != "currency")
			{
				rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				str2 = string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
			}
			else
			{
				try
				{
					if (rowfieldvalue.Trim() == "")
					{
						rowfieldvalue = "0";
					}
					str2 = string.Concat(" cast(cast(isnull(C.customizedvalue,'') as nvarchar(4000)) as money)=", rowfieldvalue);
				}
				catch
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
					str2 = string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
				}
			}
			if (columnfieldtype == "d")
			{
				if ((columnfielddatatype.ToLower().Trim() != "currency") & (columnfielddatatype.ToLower().Trim() != "number"))
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				}
				else if (columnfieldvalue == "")
				{
					columnfieldvalue = "0";
				}
				string.Concat(columnfield, "=", columnfieldvalue);
			}
			else if (columnfielddatatype.ToLower().Trim() != "currency")
			{
				columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
			}
			else
			{
				try
				{
					if (columnfieldvalue.Trim() == "")
					{
						columnfieldvalue = "0";
					}
					string.Concat(" cast(cast(isnull(D.customizedvalue,'') as nvarchar(4000)) as money)=", columnfieldvalue);
				}
				catch
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
					string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
				}
			}
			if (rowfieldtype == "d")
			{
				if (columnfieldtype != "d")
				{
					string[] strArrays = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
					str1 = string.Concat(strArrays);
					string[] matrixSumQuery = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery);
				}
				else
				{
					str1 = string.Concat(" FROM ", this.returnTableName(pg), " ");
					string[] matrixSumQuery1 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery1);
				}
			}
			else if (columnfieldtype != "d")
			{
				string[] strArrays1 = new string[] { "  FROM ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield, " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
				str1 = string.Concat(strArrays1);
				string[] matrixSumQuery2 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery2);
			}
			else
			{
				string[] strArrays2 = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield };
				str1 = string.Concat(strArrays2);
				string[] matrixSumQuery3 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE ", str2, " AND companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery3);
			}
			return str;
		}

		public string returnSumQueryFinal(string pg, string rowfield, string rowfielddatatype, string rowfieldvalue, string rowfieldtype, string columnfield, string columnfielddatatype, string columnfieldvalue, string columnfieldtype, string matrix_sum_query, string addaccessright, string checkDateInterval, string strSearchCondition)
		{
			string str = "";
			string str1 = "";
			if ((rowfielddatatype.ToLower().Trim() == "checkbox") & (rowfieldtype == "d"))
			{
				if (rowfieldvalue.ToLower().Trim() != "true")
				{
					rowfieldvalue = "0";
				}
				else
				{
					rowfieldvalue = "1";
				}
			}
			if ((columnfielddatatype.ToLower().Trim() == "checkbox") & (columnfieldtype == "d"))
			{
				if (columnfieldvalue.ToLower().Trim() != "true")
				{
					columnfieldvalue = "0";
				}
				else
				{
					columnfieldvalue = "1";
				}
			}
			if (rowfieldtype == "d")
			{
				if ((rowfielddatatype.ToLower().Trim() != "currency") & (rowfielddatatype.ToLower().Trim() != "number"))
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				}
				else if (rowfieldvalue == "")
				{
					rowfieldvalue = "0";
				}
				string.Concat(rowfield, "=", rowfieldvalue);
			}
			else if (rowfielddatatype.ToLower().Trim() != "currency")
			{
				rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
				string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
			}
			else
			{
				try
				{
					if (rowfieldvalue.Trim() == "")
					{
						rowfieldvalue = "0";
					}
					string.Concat(" cast(cast(isnull(C.customizedvalue,'') as nvarchar(4000)) as money)=", rowfieldvalue);
				}
				catch
				{
					rowfieldvalue = string.Concat("'", rowfieldvalue, "'");
					string.Concat(" cast(isnull(C.customizedvalue,'') as nvarchar(4000))=", rowfieldvalue);
				}
			}
			if (columnfieldtype == "d")
			{
				if ((columnfielddatatype.ToLower().Trim() != "currency") & (columnfielddatatype.ToLower().Trim() != "number"))
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				}
				else if (columnfieldvalue == "")
				{
					columnfieldvalue = "0";
				}
				string.Concat(columnfield, "=", columnfieldvalue);
			}
			else if (columnfielddatatype.ToLower().Trim() != "currency")
			{
				columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
				string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
			}
			else
			{
				try
				{
					if (columnfieldvalue.Trim() == "")
					{
						columnfieldvalue = "0";
					}
					string.Concat(" cast(cast(isnull(D.customizedvalue,'') as nvarchar(4000)) as money)=", columnfieldvalue);
				}
				catch
				{
					columnfieldvalue = string.Concat("'", columnfieldvalue, "'");
					string.Concat(" cast(isnull(D.customizedvalue,'') as nvarchar(4000))=", columnfieldvalue);
				}
			}
			if (rowfieldtype == "d")
			{
				if (columnfieldtype != "d")
				{
					string[] strArrays = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
					str1 = string.Concat(strArrays);
					string[] matrixSumQuery = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery);
				}
				else
				{
					str1 = string.Concat(" FROM ", this.returnTableName(pg), " ");
					string[] matrixSumQuery1 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
					str = string.Concat(matrixSumQuery1);
				}
			}
			else if (columnfieldtype != "d")
			{
				string[] strArrays1 = new string[] { "  FROM ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield, " LEFT JOIN ", this.returnCustomizeTableName(pg), " D ON L.", this.returnTableColumn(pg).Trim(), "=D.", this.returnTableColumn(pg).Trim(), " AND D.", this.returnCustomizedTableColumn(pg).Trim(), "=", columnfield };
				str1 = string.Concat(strArrays1);
				string[] matrixSumQuery2 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery2);
			}
			else
			{
				string[] strArrays2 = new string[] { " FROM  ", this.returnTableName(pg), " LEFT JOIN ", this.returnCustomizeTableName(pg), " C ON L.", this.returnTableColumn(pg).Trim(), "=C.", this.returnTableColumn(pg).Trim(), " AND C.", this.returnCustomizedTableColumn(pg).Trim(), "=", rowfield };
				str1 = string.Concat(strArrays2);
				string[] matrixSumQuery3 = new string[] { " SELECT count(*) as noofrecords ", matrix_sum_query, " ", str1, " WHERE companyid = ", this.Session["companyid"].ToString(), " ", strSearchCondition, " ", addaccessright, checkDateInterval };
				str = string.Concat(matrixSumQuery3);
			}
			return str;
		}

		public string returnTableColumn(string pg)
		{
			string str = pg;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "lead":
					{
						return " leadid ";
					}
					case "client":
					{
						return " clientid ";
					}
					case "contact":
					{
						return " contactid ";
					}
					case "opportunity":
					{
						return " opportunityid ";
					}
					case "forecast":
					{
						return " forecastid ";
					}
					case "campaign":
					{
						return " campaignid ";
					}
					case "ticket":
					{
						return " ticketid ";
					}
					case "solution":
					{
						return " solutionid ";
					}
				}
			}
			return "ERROR";
		}

		public string returnTableName(string pg)
		{
			string str = pg;
			string str1 = str;
			if (str != null)
			{
				switch (str1)
				{
					case "lead":
					{
						return " tb_lead L ";
					}
					case "client":
					{
						return " tb_client L ";
					}
					case "contact":
					{
						return " tb_contact L ";
					}
					case "opportunity":
					{
						return " tb_opportunity L ";
					}
					case "forecast":
					{
						return " tb_forecast L ";
					}
					case "campaign":
					{
						return " tb_campaign L ";
					}
					case "ticket":
					{
						return " tb_ticket L ";
					}
					case "solution":
					{
						return " tb_solution L ";
					}
				}
			}
			return "ERROR";
		}

		public DateTime returnWeekDate(DateTime dateval)
		{
			string lower = dateval.DayOfWeek.ToString().ToLower();
			string str = lower;
			if (lower != null)
			{
				switch (str)
				{
					case "sunday":
					{
						return dateval.AddDays(-6);
					}
					case "monday":
					{
						return dateval;
					}
					case "tuesday":
					{
						return dateval.AddDays(-1);
					}
					case "wednesday":
					{
						return dateval.AddDays(-2);
					}
					case "thursday":
					{
						return dateval.AddDays(-3);
					}
					case "friday":
					{
						return dateval.AddDays(-4);
					}
					case "saturday":
					{
						return dateval.AddDays(-5);
					}
				}
			}
			return dateval;
		}
	}
}