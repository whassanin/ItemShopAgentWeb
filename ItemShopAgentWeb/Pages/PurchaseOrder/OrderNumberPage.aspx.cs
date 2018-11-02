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
    public partial class OrderNumberPage : System.Web.UI.Page
    {
        static CustomerAgent _sb;
        static CustomerAgent _db;
        static CustomerAgent _pmb;
        static CustomerAgent _cb;
        static CustomerAgent _pb;
        static CustomerAgent _ib;
        static DataTable shoppingCartDT = new DataTable();
        static DataTable shoppingCartbookDT = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["InteractionBroker"] != null)
                    {
                        _ib = (CustomerAgent)Session["InteractionBroker"];
                    }
                    else
                    {
                        _ib = new CustomerAgent();
                        Session["InteractionBroker"] = _ib;
                    }

                    if (Session["PurchaseBroker"] != null)
                    {
                        _pb = (CustomerAgent)Session["PurchaseBroker"];
                    }
                    else
                    {
                        _pb = new CustomerAgent();
                        Session["PurchaseBroker"] = _pb;
                    }

                    if (Session["CatalogueBroker"] != null)
                    {
                        _cb = (CustomerAgent)Session["CatalogueBroker"];
                    }
                    else
                    {
                        _cb = new CustomerAgent();
                        Session["CatalogueBroker"] = _cb;
                    }

                    if (Session["StockBroker"] != null)
                    {
                        _sb = (CustomerAgent)Session["StockBroker"];
                    }
                    else
                    {
                        _sb = new CustomerAgent();
                        Session["StockBroker"] = _sb;
                    }

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

                    if (Session["ShoppingCartBook"] != null)
                    {
                        shoppingCartbookDT = (DataTable)Session["ShoppingCartBook"];
                    }

                    if (Session["shoppingCart"] != null)
                    {
                        shoppingCartDT = (DataTable)Session["shoppingCart"];
                    }

                    Calculate();
                    SaveOrder();
                }
                catch (Exception)
                {

                }
            }
        }

        private void Calculate()
        {
            try
            {
                float sum = 0, sumDelivery = 0;
                for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
                {
                    sum += float.Parse(shoppingCartbookDT.Rows[i]["Total"].ToString());
                }

                sumDelivery = _db._Cost + (shoppingCartbookDT.Rows.Count * _db._PerItemCost);
                _db._Cost = sumDelivery;

                DateTime d = DateTime.Now;
                _db._StartDate = d;
                _db._EndDate = d.AddDays(double.Parse(_db._MaxDeliveryTime.ToString()));

                sum += sumDelivery;
                _sb._Total = sum;
            }
            catch (Exception)
            {
                
            }
            
        }

        private void SaveOrder() 
        {
            try
            {
                _sb.Execute("SelectMaxIdOrderOutCapability");
                if (_sb.Success != null)
                {
                    _sb._Id = (int)_sb.Success;
                    _sb._Paid = _sb._Total;
                    _sb._Change = 0;
                    _sb._CreditCardNumber = _pmb._CCNumber;
                    _sb._OrderDate = DateTime.Now;
                    _sb._Holder = _pmb._Name;
                    _sb._CustomerId = _pmb._CustomerId;

                    _sb.Execute("InsertOrderOutCapability");
                    if (_sb.Success != null)
                    {
                        SaveOrderDetail(_sb._Id);
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void SaveOrderDetail(int orderId) 
        {
            try
            {
                int ce = 0;
                for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
                {
                    _sb.Execute("SelectMaxIdOrderOut_ItemCapability");
                    if (_sb.Success != null)
                    {
                        _sb._Id = (int)_sb.Success;
                        _sb._BookId = int.Parse(shoppingCartbookDT.Rows[i]["BookId"].ToString());
                        _sb._Price = float.Parse(shoppingCartbookDT.Rows[i]["Price"].ToString());
                        _sb._Quantity = int.Parse(shoppingCartbookDT.Rows[i]["Quantity"].ToString());
                        _sb._OrderOutId = orderId;

                        _sb.Execute("InsertOrderOut_ItemCapability");
                        if (_sb.Success != null)
                        {
                            bool v = bool.Parse(_sb.Success.ToString());
                            if (v == true)
                            {
                                _cb._Id = int.Parse(shoppingCartbookDT.Rows[i]["BookId"].ToString());
                                _cb._ISBN = shoppingCartbookDT.Rows[i]["ISBN"].ToString().TrimEnd();
                                _cb._Title = shoppingCartbookDT.Rows[i]["Title"].ToString().TrimEnd();
                                _cb._EditionNumber = int.Parse(shoppingCartbookDT.Rows[i]["EditionNumber"].ToString());
                                _cb._CopyRight = int.Parse(shoppingCartbookDT.Rows[i]["CopyRight"].ToString());
                                _cb._Amount = int.Parse(shoppingCartbookDT.Rows[i]["Amount"].ToString()) - int.Parse(_sb._Quantity.ToString());
                                _cb._BookPrice = float.Parse(shoppingCartbookDT.Rows[i]["Price"].ToString());
                                _cb._CategoryId = (shoppingCartbookDT.Rows[i]["CategoryId"].ToString() == string.Empty ? 0 : int.Parse(shoppingCartbookDT.Rows[i]["CategoryId"].ToString()));
                                _cb._NumOfVisits = int.Parse(shoppingCartbookDT.Rows[i]["NumOfVisits"].ToString());
                                _cb._OfferId =(shoppingCartbookDT.Rows[i]["OfferId"].ToString() == string.Empty?0:int.Parse(shoppingCartbookDT.Rows[i]["OfferId"].ToString()));

                                _cb.Execute("UpdateBookCapability");
                                if (_cb.Success != null)
                                {
                                    bool c = bool.Parse(_cb.Success.ToString());
                                    if (c == true)
                                    {
                                        _pb._Id = int.Parse(shoppingCartbookDT.Rows[i]["Id"].ToString());
                                        _pb.Execute("DeleteShoppingCart_BookCapability");

                                        if (_pb.Success != null)
                                        {
                                            bool s = bool.Parse(_pb.Success.ToString());
                                            if (s == true)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ce++;
                            }
                        }
                    }
                }

                if (ce == 0)
                {
                    SaveDelivery(orderId);
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void SaveDelivery(int orderId) 
        {
            try
            {
                _db._OrderOutId = orderId;
                _db._Status = "Processing";
                _db._Number = _pmb._Number;
                _db._Street = _pmb._Street;
                _db._District = _pmb._District;
                _db._Country = _pmb._Country;
                _db._City = _pmb._City;
                _db._ZipCode = _pmb._ZipCode;

                _db.Execute("InsertDeliveryCapability");
                if (_db.Success != null)
                {
                    Label1.Text = "Thank you for ordering, Your order number is " + orderId.ToString();
                    repeatertxt.DataSource = shoppingCartbookDT;
                    repeatertxt.DataBind();
                    //Session.Clear();
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in repeatertxt.Items)
                {
                    Label l = (Label)item.FindControl("Bookidlbl");
                    TextBox c = (TextBox)item.FindControl("commenttxt");
                    DropDownList d = (DropDownList)item.FindControl("rateDDL");
                    ListItem di = d.SelectedItem;

                    _ib._BookId = int.Parse(l.Text);
                    _ib._CustomerId = _pb._ShoppingCartId;
                    _ib._Rate = float.Parse(di.Value.ToString());
                    _ib._Review = c.Text;

                    _ib.Execute("SelectMaxIdCustomerRateCapability");
                    if (_ib.Success != null)
                    {
                        _ib._Id = int.Parse(_ib.Success.ToString());
                        _ib.Execute("InsertCustomerRateCapability");
                        if (_ib.Success != null)
                        {

                        }
                    }

                    _ib.Execute("SelectMaxIdCustomerReviewCapability");
                    if (_ib.Success != null)
                    {
                        _ib._Id = int.Parse(_ib.Success.ToString());
                        _ib.Execute("InsertCustomerReviewCapability");
                        if (_ib.Success != null)
                        {

                        }
                    }
                }

                Session.Clear();
                Response.Redirect("~/Pages/HomePage.aspx");
            }
            catch (Exception)
            {

            }
        }

        protected void skipbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Pages/HomePage.aspx");
        }
    }
}