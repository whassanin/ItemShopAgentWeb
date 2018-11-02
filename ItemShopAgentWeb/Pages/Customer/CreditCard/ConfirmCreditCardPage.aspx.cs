using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
namespace ItemShopAgentWeb.Pages
{
    public partial class ConfirmDeliveryPage : System.Web.UI.Page
    {
        static CustomerAgent _db = new CustomerAgent();
        static CustomerAgent _pmb = new CustomerAgent();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["DeliveryAgent"] != null)
                    {
                        _db = (CustomerAgent)Session["DeliveryAgent"];
                    }
                    else
                    {
                        _db = new CustomerAgent();
                        Session["DeliveryAgent"] = _db;
                    }

                    if (Session["ProfileMonitor"] != null)
                    {
                        _pmb = (CustomerAgent)Session["ProfileMonitor"];
                    }
                    else
                    {
                        _pmb = new CustomerAgent();
                        Session["ProfileMonitor"] = _pmb;
                    }

                    Numberlbl.Text = _pmb._CCNumber.ToString();
                    namelbl.Text = _pmb._Name;
                    CardTypelbl.Text = _pmb._CardType;
                    ExpirationMonthlbl.Text = _pmb._ExpirationMonth.ToString();
                    ExpirationYearlbl.Text = _pmb._ExpirationYear.ToString();

                    DateTime d = new DateTime(_pmb._ExpirationYear, _pmb._ExpirationMonth, 1);

                    if (d.Month >= DateTime.Now.Month && d.Year >= DateTime.Now.Year)
                    {
                        confirmbtn.Visible = true;
                    }
                    else 
                    {
                        updatebtn.Visible = true;
                        ExpirationMonthtxt.Visible = true;
                        ExpirationYeartxt.Visible = true;
                        ExpirationMonthlbl.Visible = false;
                        ExpirationYearlbl.Visible = false;
                        ExpirationMonthtxt.Text = _pmb._ExpirationMonth.ToString();
                        ExpirationYeartxt.Text = _pmb._ExpirationYear.ToString();
                    }

                }
                catch (Exception)
                {

                }        
            }
        }

        protected void gobackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DeliveryPage.aspx");
        }

        protected void confirmbtn_Click(object sender, EventArgs e)
        {
            Session["ProfileMonitor"] = _pmb;
            Response.Redirect("~/Pages/PurchaseOrder/OrderNumberPage.aspx");
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                _pmb._ExpirationYear = int.Parse(ExpirationYeartxt.Text);
                _pmb._ExpirationMonth = int.Parse(ExpirationMonthtxt.Text);

                DateTime d = new DateTime(_pmb._ExpirationYear, _pmb._ExpirationMonth, 1);
                if (d.Month >= DateTime.Now.Month && d.Year >= DateTime.Now.Year)
                {
                    _pmb.Execute("UpdateCustomer_CreditCardCapability");
                    if (_pmb.Success != null)
                    {
                        updatebtn.Visible = false;
                        ExpirationMonthtxt.Visible = false;
                        ExpirationYeartxt.Visible = false;
                        ExpirationMonthlbl.Visible = true;
                        ExpirationYearlbl.Visible = true;
                        ExpirationMonthlbl.Text = _pmb._ExpirationMonth.ToString();
                        ExpirationYearlbl.Text = _pmb._ExpirationYear.ToString();
                        Session["ProfileMonitor"] = _pmb;
                        confirmbtn.Visible = true;
                    }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}