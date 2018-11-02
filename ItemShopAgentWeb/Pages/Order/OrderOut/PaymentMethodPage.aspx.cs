using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
using System.Text;
namespace ItemShopAgentWeb.Pages.Order.OrderOut
{
    public partial class PaymentMethodPage : System.Web.UI.Page
    {
        static AdminAgent _sb;
        static AdminAgent _pmb;
        static AdminAgent _cb;
        static DataTable SelectedBookOutDT;
        static DataTable CreditCardDT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (PaymentMethodDDl.SelectedValue == "Cash")
                {
                    cashRow.Visible = true;
                    ccGridViewRow.Visible = false;
                    ccDetail.Visible = false;
                }

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

                if (Session["SelectedBookOut"] != null)
                {
                    SelectedBookOutDT = (DataTable)Session["SelectedBookOut"];
                }
                else
                {
                    SelectedBookOutDT = new DataTable();
                }

                totallbl.Text = _sb._Total.ToString();
            }
        }

        protected void PaymentMethodDDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentMethodDDl.SelectedValue.ToString() == "Cash")
            {
                cashRow.Visible = true;
                ccGridViewRow.Visible = false;
                ccDetail.Visible = false;
            }
            else 
            {
                cashRow.Visible = false;
                ccGridViewRow.Visible = true;
                
                _pmb._CustomerId = _pmb._Id;
                _pmb._Top = 1;
                _pmb._Flag = "C";
                _pmb._PageSize = 1000;

                _pmb.Execute("SelectCustomer_CreditCardByCustomerIdCapability");
                if (_pmb.Success!=null)
                {
                    CreditCardDT = (DataTable) _pmb.Success;
                    for (int i = 0; i < CreditCardDT.Rows.Count; i++)
                    {
                        string n = CreditCardDT.Rows[i]["CCNumber"].ToString().TrimEnd();
                        StringBuilder sb = new StringBuilder(n);
                        for (int j = 0; j < sb.Length; j++)
                        {
                            if (j>=0 && j<=11)
                            {
                                sb[j] = 'X';
                            }
                        }
                        n = sb.ToString();
                        CreditCardDT.Rows[i]["CCNumber"] = n;
                    }
                    CreditCardGV.DataSource = CreditCardDT;
                    CreditCardGV.DataBind();
                }
            }
        }

        protected void paidtxt_TextChanged(object sender, EventArgs e)
        {
            if (paidtxt.Text != string.Empty)
            {
                float s = float.Parse(paidtxt.Text) - _sb._Total;
                changetxt.Text = s.ToString();
                _sb._Paid = float.Parse(paidtxt.Text);
                _sb._Change = s;
                _sb._Flag = "Cash";
            }
        }

        protected void changetxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CreditCardGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            if (cmd == "Select")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                _sb._CreditCardNumber = CreditCardDT.Rows[i]["CCNumber"].ToString().TrimEnd();
                _sb._Holder = CreditCardDT.Rows[i]["Name"].ToString().TrimEnd();

                ccDetail.Visible = true;

                CCNumberlbl.Text = CreditCardDT.Rows[i]["CCNumber"].ToString().TrimEnd();
                Namelbl.Text = CreditCardDT.Rows[i]["Name"].ToString().TrimEnd();
                CardTypelbl.Text = CreditCardDT.Rows[i]["CardType"].ToString().TrimEnd();
                ExpirationMonthlbl.Text = CreditCardDT.Rows[i]["ExpirationMonth"].ToString().TrimEnd();
                ExpirationYearlbl.Text = CreditCardDT.Rows[i]["ExpirationYear"].ToString().TrimEnd();

                _sb._CreditCardNumber = CCNumberlbl.Text;
                _sb._Holder = Namelbl.Text;
                _sb._Flag = "CreditCard";
            }

        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            if (_sb._Status != "Done")
            {
                bool IsDone = Save();
                if (IsDone == true)
                {
                    _sb._Status = "Done";
                    orderNumberlbl.Text = "Order number is " + _sb._OrderOutId.ToString();

                    Session["StockBroker"] = _sb;
                }
                else
                {
                    _sb._Status = "Error";
                    orderNumberlbl.Text = "Can not save the order";
                }
            }
            else 
            {
                orderNumberlbl.Text = "Order is already saved";
            }
        }

        private bool Save()
        {
            bool IsDone = false;
            if (SelectedBookOutDT.Rows.Count > 0)
            {
                _sb.Execute("SelectMaxIdOrderOutCapability");
                if (_sb.Success != null)
                {
                    _sb._Id = (int)_sb.Success;
                    _sb._OrderDate = DateTime.Now;

                    _sb.Execute("InsertOrderOutCapability");
                    if (_sb.Success != null)
                    {
                       IsDone =  SaveOrderDetail(_sb._Id);
                       _sb._OrderOutId = _sb._Id;
                    }
                }
            }

            if (IsDone == true)
            {
                SelectedBookOutDT.Rows.Clear();
                _sb._Status = "Done";
            }
            else 
            {
                _sb._Status = "Error";
            }

            return IsDone;
        }

        private bool SaveOrderDetail(int orderId) 
        {
            bool IsDone = false;
            int rowAffected = 0;
            for (int i = 0; i < SelectedBookOutDT.Rows.Count; i++)
            {
                _sb.Execute("SelectMaxIdOrderOut_ItemCapability");
                if (_sb.Success != null)
                {
                    _sb._Id = (int)_sb.Success;
                    _sb._BookId = int.Parse(SelectedBookOutDT.Rows[i]["Id"].ToString());
                    _sb._Price = float.Parse(SelectedBookOutDT.Rows[i]["BookPrice"].ToString());
                    _sb._Quantity = int.Parse(SelectedBookOutDT.Rows[i]["Quantity"].ToString());
                    _sb._OrderOutId = orderId;

                    _sb.Execute("InsertOrderOut_ItemCapability");
                    if (_sb.Success != null)
                    {
                        bool v = bool.Parse(_sb.Success.ToString());

                        if (v == true)
                        {
                            _cb._Id = int.Parse(SelectedBookOutDT.Rows[i]["Id"].ToString());
                            _cb._Amount = int.Parse(SelectedBookOutDT.Rows[i]["Amount"].ToString()) - int.Parse(_sb._Quantity.ToString());

                            _cb.Execute("UpdateAmountInBookCapability");
                            if (_cb.Success != null)
                            {
                                bool c = bool.Parse(_cb.Success.ToString());
                                if (c == true)
                                {
                                    rowAffected++;
                                }
                            }
                        }
                    }
                }
            }

            if (rowAffected == SelectedBookOutDT.Rows.Count)
            {
                IsDone = true;
            }
            return IsDone;
        }
    }
}