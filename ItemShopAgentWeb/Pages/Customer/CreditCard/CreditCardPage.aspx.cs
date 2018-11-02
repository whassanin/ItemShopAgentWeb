using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages
{
    public partial class CreditCardPage : System.Web.UI.Page
    {
        static CustomerAgent _pmb = new CustomerAgent();
        DataTable creditCardDT=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["ProfileMonitor"] != null)
                    {
                        _pmb = (CustomerAgent)Session["ProfileMonitor"];
                    }
                    else
                    {
                        _pmb = new CustomerAgent();
                        Session["ProfileMonitor"] = _pmb;
                    }
                }

                _pmb.Execute("SelectCustomer_CreditCardByCustomerIdCapability");
                if (_pmb.Success != null)
                {
                    creditCardDT = (DataTable)_pmb.Success;
                    if (creditCardDT.Rows.Count > 0)
                    {
                        CreditCardGV.DataSource = creditCardDT;
                        CreditCardGV.DataBind();
                    }
                    else
                    {
                        CreditCardtable.Visible = true;
                        Addbtn.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            if (CreditCardtable.Visible == false)
            {
                CreditCardtable.Visible = true;
            }
            else if (CreditCardtable.Visible == true)
            {
                CreditCardtable.Visible = false;
            }
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                _pmb.Execute("SelectMaxIdCustomer_CreditCardCapability");
                if (_pmb.Success != null)
                {
                    _pmb._Id = int.Parse(_pmb.Success.ToString());
                    _pmb._CCNumber = CCNumbertxt.Text;
                    _pmb._Name = nametxt.Text;
                    ListItem cardTypeItem = cardTypeDDL.SelectedItem;
                    _pmb._CardType = cardTypeItem.Text;
                    _pmb._ExpirationMonth = int.Parse(ExpirationMonthtxt.Text);
                    _pmb._ExpirationYear = int.Parse(ExpirationYeartxt.Text);

                    DateTime d = new DateTime(_pmb._ExpirationYear, _pmb._ExpirationMonth, 1);

                    if (d.Month >= DateTime.Now.Month && d.Year >= DateTime.Now.Year)
                    {
                        _pmb.Execute("InsertCustomer_CreditCardCapability");
                        if (_pmb.Success != null)
                        {
                            bool v = bool.Parse(_pmb.Success.ToString());
                            if (v == true)
                            {
                                Save();
                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void CreditCardGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    _pmb._Id = int.Parse(creditCardDT.Rows[index]["Id"].ToString());
                    _pmb._CCNumber = creditCardDT.Rows[index]["CCNumber"].ToString().TrimEnd();
                    _pmb._Name = creditCardDT.Rows[index]["Name"].ToString().TrimEnd();
                    _pmb._CardType = creditCardDT.Rows[index]["CardType"].ToString().TrimEnd();
                    _pmb._ExpirationMonth = int.Parse(creditCardDT.Rows[index]["ExpirationMonth"].ToString());
                    _pmb._ExpirationYear = int.Parse(creditCardDT.Rows[index]["ExpirationYear"].ToString());
                    Save();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void Save()
        {
            Session["ProfileMonitor"] = _pmb;
            Response.Redirect("~/Pages/Customer/CreditCard/ConfirmCreditCardPage.aspx");
        }
    }
}