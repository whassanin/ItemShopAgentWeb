using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;

namespace ItemShopAgentWeb.Pages.Order.OrderIn
{
    public partial class BookLessAmountPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
        static DataTable SelectedBookInDT;
        static double _pageCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                Initialize();
            }
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderOut();
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderOut();
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderOut();
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderOut();
        }

        protected void SelectedBookInGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void SelectedBookInGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderOut();
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderOut();
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderOut();
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderOut();
        }

        protected void createOrderbtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/Pages/Order/OrderIn/NewOrderInPage.aspx");
        }

        protected void cancelorderbtn_Click(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            _cb._Top = 1;
            _cb._PageSize = 1000;
            _cb._Flag = "C";

            GetBookLessAmount();

            double vc = _cb._SelectBookByAmountCount;
            double vp = _cb._PageSize;
            double v = vc / vp;
            double m = Math.Ceiling(v);

            _pageCount = m;

            indexToplbl.Text = _cb._Top.ToString();
            PagesTop.Text = _pageCount.ToString();

            indexBottomlbl.Text = _cb._Top.ToString();
            Pagesbottom.Text = _pageCount.ToString();
        }

        private void GetBookLessAmount()
        {
            _cb._Amount = 20;
            _cb.Execute("SelectBookByAmountCapability");
            if (_cb.Success != null)
            {
                SelectedBookInDT = (DataTable)_cb.Success;

                if (!SelectedBookInDT.Columns.Contains("Quantity"))
                {
                    SelectedBookInDT.Columns.Add("Quantity", typeof(int));
                    SelectedBookInDT.Columns.Add("Total", typeof(float));

                    for (int i = 0; i < SelectedBookInDT.Rows.Count; i++)
                    {
                        SelectedBookInDT.Rows[i]["Quantity"] = 10;
                        SelectedBookInDT.Rows[i]["Total"] = float.Parse(SelectedBookInDT.Rows[i]["BookPrice"].ToString()) * 10;
                    }
                }

                SelectedBookInGV.DataSource = SelectedBookInDT;
                SelectedBookInGV.DataBind();
            }
        }

        private void Save()
        {
            Session["SelectedBookIn"] = SelectedBookInDT;
        }
    }
}