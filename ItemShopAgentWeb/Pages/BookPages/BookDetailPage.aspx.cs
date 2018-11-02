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
    public partial class BookDetailPage : System.Web.UI.Page
    {
        static CustomerAgent _cb;
        static CustomerAgent _pb;
        static CustomerAgent _ib;
        static DataTable shoppingCartDT = new DataTable();
        static DataTable shoppingCartbookDT = new DataTable();
        static DataTable CustomerBookWishListDT = new DataTable();
        static DataTable CustomerBookRateListDT = new DataTable();
        static DataTable CustomerBookReviewListDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["PurchaseBroker"] != null)
                    {
                        _pb = (CustomerAgent)Session["PurchaseBroker"];
                    }
                    else
                    {
                        _pb = new CustomerAgent();
                        Session["PurchaseBroker"] = _pb;
                    }

                    if (Session["InteractionBroker"] != null)
                    {
                        _ib = (CustomerAgent)Session["InteractionBroker"];
                    }
                    else
                    {
                        _ib = new CustomerAgent();
                        Session["InteractionBroker"] = _ib;
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

                    if (Session["ShoppingCartBook"] != null)
                    {
                        shoppingCartbookDT = (DataTable)Session["ShoppingCartBook"];
                    }

                    if (Session["ShoppingCart"] != null)
                    {
                        shoppingCartDT = (DataTable)Session["ShoppingCart"];
                    }

                    idtxt.Text = _cb._Id.ToString();
                    ISBNtxt.Text = _cb._ISBN;
                    titletxt.Text = _cb._Title;
                    editionNumbertxt.Text = _cb._EditionNumber.ToString();
                    copyRighttxt.Text = _cb._CopyRight.ToString();
                    Amounttxt.Text = _cb._Amount.ToString();
                    pricetxt.Text = _cb._Price.ToString();
                    categorylbl.Text = _cb._Name;

                    _cb._NumOfVisits++;
                    _cb.Execute("UpdateBookCapability");
                    if (_cb.Success != null)
                    {

                    }

                    _ib._CustomerId = _pb._ShoppingCartId;
                    _ib.Execute("SelectCustomerWishListByCustomerIdCapability");
                    if (_ib.Success != null)
                    {
                        CustomerBookWishListDT = (DataTable)_ib.Success;
                    }

                    _ib._BookId = int.Parse(idtxt.Text);
                    _ib.Execute("SelectCustomerRateByBookIdCapability");
                    if (_ib.Success != null)
                    {
                        CustomerBookRateListDT = (DataTable)_ib.Success;
                        double sum = 0;
                        for (int i = 0; i < CustomerBookRateListDT.Rows.Count; i++)
                        {
                            sum += double.Parse(CustomerBookRateListDT.Rows[i]["Rate"].ToString());
                        }
                        double v = sum / CustomerBookRateListDT.Rows.Count;
                        ratelbl.Text = v.ToString();
                    }

                    _ib._BookId = int.Parse(idtxt.Text);
                    _ib.Execute("SelectCustomerReviewByBookIdCapability");
                    if (_ib.Success != null)
                    {
                        CustomerBookReviewListDT = (DataTable)_ib.Success;
                        CommentGV.DataSource = CustomerBookReviewListDT;
                        CommentGV.DataBind();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void addtocartbtn_Click(object sender, EventArgs e)
        {
            SaveShoppingCart();
            Save();
            Response.Redirect(@"~/Pages/CartPage.aspx");
        }

        private void SaveShoppingCart()
        {
            if (shoppingCartDT.Rows.Count > 0)
            {
                _pb._ShoppingCartId = int.Parse(shoppingCartDT.Rows[0]["CustomerId"].ToString());
                SaveShoppingCartDetail();
            }
            else
            {
                _pb._Date = DateTime.Now;
                _pb._Total = _cb._Price;
                _pb._ShoppingCartId = _pb._CustomerId;
                _pb.Execute("InsertShoppingCartCapability");
                if (_pb.Success != null)
                {
                    SaveShoppingCartDetail();
                }
            }

            float sum = 0;
            for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
            {
                float p = float.Parse(shoppingCartbookDT.Rows[i]["Price"].ToString());
                int q = int.Parse(shoppingCartbookDT.Rows[i]["Quantity"].ToString());
                sum += p * q;
            }

            _pb._Date = DateTime.Now;
            _pb._Total = sum;

            _pb.Execute("UpdateShoppingCartCapability");
            if (_pb.Success != null)
            {

            }
        }

        private void SaveShoppingCartDetail()
        {
            _pb._BookId = _cb._Id;

            DataRow[] rows = shoppingCartbookDT.Select("BookId = " + _pb._BookId);
            if (rows.Count() == 0)
            {
                _pb._BookId = _cb._Id;
                _pb._Quantity = 1;
                _pb._Price = _cb._Price;
                _pb._Total = _pb._Quantity * _pb._Price;
                _pb._Status = "Processing";

                _pb.Execute("SelectMaxIdShoppingCart_BookCapability");
                if (_pb.Success != null)
                {
                    _pb._Id = int.Parse(_pb.Success.ToString());

                    _pb.Execute("InsertShoppingCart_BookCapability");
                    if (_pb.Success != null)
                    {
                        bool v = bool.Parse(_pb.Success.ToString());
                        if (v == true)
                        {
                            DataRow newRow = shoppingCartbookDT.NewRow();
                            newRow["Id"] = _pb._Id;
                            newRow["BookId"] = _pb._BookId;
                            newRow["ShoppingCartId"] = _pb._ShoppingCartId;
                            newRow["Quantity"] = _pb._Quantity;
                            newRow["Price"] = Math.Round(_pb._Price, 1);
                            newRow["Total"] = Math.Round(_pb._Total, 1);
                            newRow["Status"] = _pb._Status;

                            newRow["Id"] = _cb._Id;
                            newRow["ISBN"] = _cb._ISBN;
                            newRow["Title"] = _cb._Title.ToString();
                            newRow["EditionNumber"] = _cb._EditionNumber;
                            newRow["CopyRight"] = _cb._CopyRight;
                            newRow["Amount"] = _cb._Amount;
                            newRow["BookPrice"] = _cb._Price;
                            newRow["CategoryId"] = _cb._CategoryId;
                            newRow["NumOfVisits"] = _cb._NumOfVisits;
                            newRow["OfferId"] = _cb._OfferId;

                            shoppingCartbookDT.Rows.Add(newRow);
                        }
                    }
                }
            }
        }

        private void Save()
        {
            Session["CatalogueBroker"] = _cb;
            Session["PurchaseBroker"] = _pb;
            Session["ShoppingCartBook"] = shoppingCartbookDT;
            Session["shoppingCart"] = shoppingCartDT;
        }

        protected void addtowishlistbtn_Click(object sender, EventArgs e)
        {
            try
            {

                DataRow[] rows = CustomerBookWishListDT.Select("BookId = " + int.Parse(idtxt.Text));
                if (rows.Count() == 0)
                {
                    _ib.Execute("SelectMaxIdCustomerWishListCapability");
                    if (_ib.Success != null)
                    {
                        _ib._Id = (int)_ib.Success;
                        _ib._BookId = int.Parse(idtxt.Text.ToString());
                        _ib._CustomerId = _pb._ShoppingCartId;

                        _ib.Execute("InsertCustomerWishListCapability");
                        if (_ib.Success != null)
                        {
                            bool s = bool.Parse(_ib.Success.ToString());

                            if (s == true)
                            {
                                DataRow newRow = CustomerBookWishListDT.NewRow();
                                newRow["Id"] = _ib._Id;
                                newRow["BookId"] = _ib._BookId;
                                newRow["CustomerId"] = _ib._CustomerId;

                                CustomerBookWishListDT.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HomePage.aspx");
        }
    }
}
        