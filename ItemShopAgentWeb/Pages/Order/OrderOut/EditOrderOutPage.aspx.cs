using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.Customer
{
    public partial class EditOrderOutPage : System.Web.UI.Page
    {
        static AdminAgent _sb;
        static DataTable OrderOutDT;
        static double _pageCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StockBroker"] != null)
                {
                    if (Session["StockBroker"].GetType() != typeof(AdminAgent))
                    {
                        _sb = new AdminAgent();
                    }
                    else
                    {
                        _sb = (AdminAgent)Session["StockBroker"];
                    }
                }
                else
                {
                    _sb = new AdminAgent();
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

        protected void OrderOutGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            if (cmd == "ViewDetail")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                _sb._OrderOutId = int.Parse(OrderOutDT.Rows[i]["Id"].ToString());
                _sb._OrderDate = DateTime.Parse(OrderOutDT.Rows[i]["OrderDate"].ToString());
                _sb._Total = float.Parse(OrderOutDT.Rows[i]["Total"].ToString());
                _sb._Change = float.Parse(OrderOutDT.Rows[i]["Change"].ToString());
                _sb._Paid = float.Parse(OrderOutDT.Rows[i]["Paid"].ToString());
                _sb._CustomerId = int.Parse(OrderOutDT.Rows[i]["CustomerId"].ToString());
                _sb._FirstName = OrderOutDT.Rows[i]["FirstName"].ToString().TrimEnd();
                _sb._LastName = OrderOutDT.Rows[i]["LastName"].ToString().TrimEnd();
                _sb._MiddleName = OrderOutDT.Rows[i]["MiddleName"].ToString().TrimEnd();
                _sb._Flag = OrderOutDT.Rows[i]["MiddleName"].ToString().TrimEnd();
                _sb._CreditCardNumber = OrderOutDT.Rows[i]["CreditCardNumber"].ToString().TrimEnd();
                _sb._Holder = OrderOutDT.Rows[i]["Holder"].ToString().TrimEnd();
                _sb._Flag = OrderOutDT.Rows[i]["Flag"].ToString().TrimEnd();

                Session["StockBroker"] = _sb;
                Response.Redirect("~/Pages/Order/OrderOut/EditOrderOutDetailPage.aspx");
            }
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

        private void Initialize() 
        {
            GetOrderOut();

            double vc = _sb._SelectAllOrderOutCount;
            double vp = _sb._PageSize;
            double v = vc / vp;
            double m = Math.Ceiling(v);

            _pageCount = m;

            indexToplbl.Text = _sb._Top.ToString();
            PagesTop.Text = _pageCount.ToString();

            indexBottomlbl.Text = _sb._Top.ToString();
            Pagesbottom.Text = _pageCount.ToString();
        }

        private void GetOrderOut() 
        {
            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._Flag = "C";
            _sb.Execute("SelectAllOrderOutCapability");
            if (_sb.Success != null)
            {
                OrderOutDT = (DataTable)_sb.Success;
                OrderOutGV.DataSource = OrderOutDT;
                OrderOutGV.DataBind();
            }
        }
    }
}