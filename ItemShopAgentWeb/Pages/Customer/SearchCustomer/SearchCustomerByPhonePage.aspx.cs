using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.Customer.SearchCustomer
{
    public partial class SearchCustomerByPhonePage : System.Web.UI.Page
    {
        static AdminAgent _schb;
        static AdminAgent _pmb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            _schb.Execute("SearchCustomer_PhoneByPhoneCapability");
            if (_schb.Success != null)
            {
                if (_schb._SearchCustomer_PhoneByPhoneCount > 0)
                {
                    DataTable customerDT = (DataTable)_schb.Success;
                    if (customerDT.Rows.Count > 0)
                    {
                        firstNametxt.Text = customerDT.Rows[0]["FirstName"].ToString().TrimEnd();
                        lastNametxt.Text = customerDT.Rows[0]["LastName"].ToString().TrimEnd();
                        MiddleName.Text = customerDT.Rows[0]["MiddleName"].ToString().TrimEnd();
                        _pmb._Id = int.Parse(customerDT.Rows[0]["Id"].ToString());
                        _pmb._FirstName = firstNametxt.Text;
                        _pmb._LastName = lastNametxt.Text;
                        _pmb._MiddleName = MiddleName.Text;

                        Session["ProfileMonitorBroker"] = _pmb;
                    }   
                }
            }
        }

        protected void selectCustomerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Order/OrderOut/NewOrderOutDetailPage.aspx");
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Order/OrderOut/NewOrderOutPage.aspx");
        }
    }
}