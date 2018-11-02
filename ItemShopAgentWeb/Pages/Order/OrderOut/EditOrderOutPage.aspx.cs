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

                _sb.Execute("");
                if (_sb.Success != null)
                {

                }
            }
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {

        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {

        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {

        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {

        }

        protected void OrderOutGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {

        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {

        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {

        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {

        }
    }
}