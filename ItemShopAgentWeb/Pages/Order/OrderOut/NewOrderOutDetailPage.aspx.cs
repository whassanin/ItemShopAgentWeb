using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.Order.OrderOut
{
    public partial class NewOrderOutDetialPage : System.Web.UI.Page
    {
        static AdminAgent _pmb;
        static AdminAgent _sb;
        static DataTable SelectedBookOutDT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ProfileMonitorBroker"] != null)
                {
                    if (Session["ProfileMonitorBroker"].GetType() != typeof(AdminAgent))
                    {
                        _pmb = new AdminAgent();
                    }
                    else
                    {
                        _pmb = (AdminAgent)Session["ProfileMonitorBroker"];
                    }
                }
                else
                {
                    _pmb = new AdminAgent();
                }

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

                _sb._CustomerId = _pmb._Id;

                firstNamelbl.Text = _pmb._FirstName;
                lastNamelbl.Text = _pmb._LastName;
                MiddleNamelbl.Text = _pmb._MiddleName;

                if (Session["SelectedBookOut"] != null)
                {
                    SelectedBookOutDT = (DataTable)Session["SelectedBookOut"];
                }
                else
                {
                    SelectedBookOutDT = new DataTable();
                }

                SelectedBookOutGV.DataSource = SelectedBookOutDT;
                SelectedBookOutGV.DataBind();
                Calculate();
            }
        }

        protected void ConfirmOrderbtn_Click(object sender, EventArgs e)
        {
            Session["StockBroker"] = _sb;
            Session["SelectedBookOut"] = SelectedBookOutDT;
            Response.Redirect("~/Pages/Order/OrderOut/PaymentMethodPage.aspx");
        }

        protected void continueOrderbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        protected void cancelOrderbtn_Click(object sender, EventArgs e)
        {
            SelectedBookOutDT.Rows.Clear();
            Save();
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        private void Calculate()
        {
            double sum = 0;
            for (int i = 0; i < SelectedBookOutDT.Rows.Count; i++)
            {
                sum += double.Parse(SelectedBookOutDT.Rows[i]["Total"].ToString());
            }

            float s = float.Parse(Math.Round(sum).ToString());
            _sb._Total = s;
            totallbl.Text = totallbl.Text + s.ToString();
        }
        private void Save()
        {
            Session["SelectedBookOut"] = SelectedBookOutDT;
        }
    }
}