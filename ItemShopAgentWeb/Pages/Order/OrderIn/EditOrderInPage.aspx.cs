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
    public partial class EditOrderInPage : System.Web.UI.Page
    {
        static AdminAgent _sb;
        static DataTable OrderInDT;
        static double _pageCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected void CreateOrderbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Order/OrderIn/BookLessAmountPage.aspx");
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderIn();
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderIn();
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderIn();
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderIn();
        }

        protected void OrderOutGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            if (cmd == "ViewDetail")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                _sb._OrderInId = int.Parse(OrderInDT.Rows[i]["Id"].ToString());
                _sb._OrderDate = DateTime.Parse(OrderInDT.Rows[i]["OrderDate"].ToString());
                _sb._Status = OrderInDT.Rows[i]["Status"].ToString().TrimEnd();
                _sb._SupplierId = int.Parse(OrderInDT.Rows[i]["SupplierId"].ToString());
                _sb._SupplierName = OrderInDT.Rows[i]["SupplierName"].ToString().TrimEnd();

                Session["StockBroker"] = _sb;
                Response.Redirect("~/Pages/Order/OrderIn/EditOrderInDetailPage.aspx");
            }
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderIn();
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderIn();
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderIn();
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderIn();
        }

        private void Initialize()
        {
            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._Flag = "C";

            GetOrderIn();

            double vc = _sb._SelectAllOrderInCount;
            double vp = _sb._PageSize;
            double v = vc / vp;
            double m = Math.Ceiling(v);

            _pageCount = m;

            indexToplbl.Text = _sb._Top.ToString();
            PagesTop.Text = _pageCount.ToString();

            indexBottomlbl.Text = _sb._Top.ToString();
            Pagesbottom.Text = _pageCount.ToString();
        }

        private void GetOrderIn()
        {
            _sb.Execute("SelectAllOrderInCapability");
            if (_sb.Success != null)
            {
                OrderInDT = (DataTable)_sb.Success;
                OrderInGV.DataSource = OrderInDT;
                OrderInGV.DataBind();
            }
        }
    }
}