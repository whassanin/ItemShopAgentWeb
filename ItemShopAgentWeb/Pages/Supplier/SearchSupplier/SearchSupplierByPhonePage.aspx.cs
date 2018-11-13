using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ItemStoreDBNameSpace;
namespace ItemShopAgentWeb.Pages.Supplier.SearchSupplier
{
    public partial class SearchSupplierByPhonePage : System.Web.UI.Page
    {
        static AdminAgent _schb;
        static AdminAgent _pmb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SearchBroker"] != null)
                {
                    if (Session["SearchBroker"].GetType() != typeof(AdminAgent))
                    {
                        _schb = new AdminAgent();
                    }
                    else
                    {
                        _schb = (AdminAgent)Session["SearchBroker"];
                    }
                }
                else
                {
                    _schb = new AdminAgent();
                }

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
            }

        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            _schb._Phone = phonetxt.Text;
            _schb._Top = 1;
            _schb._PageSize = 1;
            _schb._Flag = "C";
            _schb.Execute("SearchSupplier_PhoneByPhoneCapability");
            if (_schb.Success != null)
            {
                if (_schb._SearchSupplier_PhoneByPhoneCount > 0)
                {
                    DataTable supplierDT = (DataTable)_schb.Success;
                    if (supplierDT.Rows.Count > 0)
                    {
                        fullNametxt.Text = supplierDT.Rows[0]["SupplierName"].ToString().TrimEnd();
                        _pmb._Id = int.Parse(supplierDT.Rows[0]["Id"].ToString());
                        _pmb._SupplierName = supplierDT.Rows[0]["SupplierName"].ToString().TrimEnd();
                        Session["ProfileMonitorBroker"] = _pmb;
                    }
                }
            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {

        }
        
        protected void ViewSupplierbtn_Click(object sender, EventArgs e)
        {

        }

        protected void selectSupplierbtn_Click(object sender, EventArgs e)
        {
            Session["ProfileMonitorBroker"] = _pmb;
            Response.Redirect("~/Pages/Order/OrderIn/NewOrderInDetailPage.aspx");
        }
    }
}