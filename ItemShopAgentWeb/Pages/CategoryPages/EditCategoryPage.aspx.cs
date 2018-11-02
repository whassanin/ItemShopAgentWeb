using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.CategoryPages
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
        static double CategoryCount = 0;
        static DataTable CategoryDT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CatalogueBroker"] != null)
                {
                    if (Session["CatalogueBroker"].GetType() != typeof(AdminAgent))
                    {
                        _cb = new AdminAgent();
                    }
                    else
                    {
                        _cb = (AdminAgent)Session["CatalogueBroker"];
                    }
                }
                else
                {
                    _cb = new AdminAgent();
                }

                _cb._Top = 1;
                _cb._PageSize = 1000;
                _cb._Flag = "C";

                DisplayCatgeory();

                double vc = _cb._SelectAllCategoryCount;
                double vp = _cb._PageSize;
                double v = vc / vp;
                double m = Math.Ceiling(v);

                CategoryCount = m;

                indexToplbl.Text = _cb._Top.ToString();
                CategoryPagesTop.Text = CategoryCount.ToString();

                indexBottomlbl.Text = _cb._Top.ToString();
                CategoryPagesBottom.Text = CategoryCount.ToString();
            }
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _cb._Top = 1;
            _cb._Flag = "R";
            DisplayCatgeory();
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_cb._Top - 1) > 0)
            {
                _cb._Top--;
                _cb._Flag = "R";
                DisplayCatgeory();
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_cb._Top < CategoryCount)
            {
                _cb._Top++;
                _cb._Flag = "R";
                DisplayCatgeory();
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _cb._Top = (int)CategoryCount;
            _cb._Flag = "R";
            DisplayCatgeory();
        }

        protected void CategoryGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName.ToString();
            if (cmd == "Select")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                DataRow currentRow = CategoryDT.Rows[i];
                _cb._Id = int.Parse(currentRow["Id"].ToString());
                _cb._Name = currentRow["Name"].ToString().TrimEnd();
                _cb._SubCategoryId = (currentRow["SubCategoryId"].ToString() == string.Empty ? 0 : int.Parse(currentRow["SubCategoryId"].ToString()));

                Session["CatalogueBroker"] = _cb;
                Response.Redirect("~/Pages/CategoryPages/EditCategoryDetailPage.aspx");
            }
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _cb._Top = 1;
            _cb._Flag = "R";
            DisplayCatgeory();
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_cb._Top - 1) > 0)
            {
                _cb._Top--;
                _cb._Flag = "R";
                DisplayCatgeory();
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_cb._Top < CategoryCount)
            {
                _cb._Top++;
                _cb._Flag = "R";
                DisplayCatgeory();
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _cb._Top = (int)CategoryCount;
            _cb._Flag = "R";
            DisplayCatgeory();
        }

        private void DisplayCatgeory()
        {
            try
            {
                _cb.Execute("SelectAllCategoryCapability");
                if (_cb.Success != null)
                {
                    CategoryDT = (DataTable)_cb.Success;
                    CategoryGV.DataSource = CategoryDT;
                    CategoryGV.DataBind();
                    indexToplbl.Text = _cb._Top.ToString();
                    indexBottomlbl.Text = _cb._Top.ToString();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}