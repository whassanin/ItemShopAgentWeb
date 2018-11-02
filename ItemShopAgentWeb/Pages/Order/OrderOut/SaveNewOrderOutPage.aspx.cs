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
    public partial class SaveNewOrderOutPage : System.Web.UI.Page
    {
        static AdminAgent _sb;
        static DataTable SelectedBookOutDT;
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

                if (Session["SelectedBookOut"] != null)
                {
                    SelectedBookOutDT = (DataTable)Session["SelectedBookOut"];
                }
                else
                {
                    SelectedBookOutDT = new DataTable();
                }
            }
        }
    }
}