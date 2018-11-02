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
    public partial class HomePage : System.Web.UI.Page
    {
        static CustomerAgent _cb;
        static CustomerAgent _pb;
        static DataTable shoppingCartDT = new DataTable();
        static DataTable shoppingCartbookDT = new DataTable();
        static DataTable BookDT = new DataTable();
        static int bc = 250000;
        static int currentIndex = 0;

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

                    if (Session["CatalogueBroker"] != null)
                    {
                        _cb = (CustomerAgent)Session["CatalogueBroker"];
                    }
                    else
                    {
                        _cb = new CustomerAgent();
                        Session["CatalogueBroker"] = _cb;
                    }

                    DisplayCatgeory();

                    currentIndex = 1;
                    
                    DisplayBook(currentIndex);

                    _pb._CustomerId = 1;

                    DisplayShoppingCart();

                    Save();

                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void BookGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int pageIndex = BookGV.PageIndex;

                if (pageIndex > 0)
                {
                    index = index + (pageIndex * BookGV.PageSize);
                }

                if (e.CommandName == "New")
                {
                    SaveShoppingCart(index);
                    Save();
                    Response.Redirect(@"~/Pages/ShoppingCart/CartPage.aspx");
                }
                else if (e.CommandName == "Select")
                {
                    GetBook(index);
                    Save();
                    Response.Redirect(@"~/Pages/BookPages/BookDetailPage.aspx");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void cartbtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect(@"~/Pages/ShoppingCart/CartPage.aspx");
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            DisplayBook(currentIndex);
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayBook(currentIndex);
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (currentIndex < bc)
            {
                currentIndex++;
                DisplayBook(currentIndex);
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            currentIndex = 100;
            DisplayBook(currentIndex);
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            DisplayBook(currentIndex);
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayBook(currentIndex);
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (currentIndex < bc)
            {
                currentIndex++;
                DisplayBook(currentIndex);
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            currentIndex = 100;
            DisplayBook(currentIndex);
        }

        private void DisplayCatgeory()
        {
            try
            {
                _cb._Top = 1;
                _cb._PageSize = 1000;
                _cb._Flag = "C";
                _cb.Execute("SelectAllCategoryCapability");
                if (_cb.Success != null)
                {
                    CategoryDDL.DataSource = (DataTable)_cb.Success;
                    CategoryDDL.DataTextField = "Name";
                    CategoryDDL.DataValueField = "Id";
                    CategoryDDL.DataBind();
                }

            }
            catch (Exception)
            {

            }
        }

        private void DisplayBook(int index)
        {
            try
            {
                _cb._Top = index;
                _cb._PageSize = 1000;
                _cb._Flag = "C";
                _cb.Execute("SelectAllBookCapability");
                if (_cb.Success != null)
                {
                    BookDT = (DataTable)_cb.Success;
                    BookGV.DataSource = BookDT;
                    BookGV.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        private void DisplayShoppingCart()
        {
            try
            {
                _pb._ShoppingCartId = _pb._CustomerId;
                _pb._Flag = "C";
                _pb._Top = 1;
                _pb._PageSize = 1000;
                _pb.Execute("SelectShoppingCartByCustomerIdCapability");
                if (_pb.Success != null)
                {
                    shoppingCartDT = (DataTable)_pb.Success;
                    if (shoppingCartDT.Rows.Count > 0)
                    {
                        DisplayShoppingCartDetial();
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void DisplayShoppingCartDetial()
        {
            try
            {

                _pb.Execute("SelectShoppingCart_BookByShoppingCartIdCapability");
                if (_pb.Success != null)
                {
                    shoppingCartbookDT = (DataTable)_pb.Success;
                    for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
                    {
                        shoppingCartbookDT.Rows[i]["Total"] = Math.Round(double.Parse(shoppingCartbookDT.Rows[i]["Total"].ToString()), 1);
                        shoppingCartbookDT.Rows[i]["Price"] = Math.Round(double.Parse(shoppingCartbookDT.Rows[i]["Price"].ToString()), 1);
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void SaveShoppingCart(int index)
        {
            try
            {
                DataRow currentRow = BookDT.Rows[index];
                if (shoppingCartDT.Rows.Count > 0)
                {
                    _pb._ShoppingCartId = int.Parse(shoppingCartDT.Rows[0]["CustomerId"].ToString());
                    SaveShoppingCartDetail(currentRow);
                }
                else
                {
                    _pb._Date = DateTime.Now;
                    _pb._Total = float.Parse(currentRow["Price"].ToString());
                    _pb._ShoppingCartId = _pb._CustomerId;
                    _pb.Execute("InsertShoppingCartCapability");
                    if (_pb.Success != null)
                    {
                        SaveShoppingCartDetail(currentRow);
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
            catch (Exception)
            {

            }
        }

        private void SaveShoppingCartDetail(DataRow currentRow)
        {
            try
            {
                _pb._BookId = int.Parse(currentRow["Id"].ToString());

                DataRow[] rows = shoppingCartbookDT.Select("BookId = " + _pb._BookId);
                if (rows.Count() == 0)
                {
                    _pb._BookId = int.Parse(currentRow["Id"].ToString());
                    _pb._Quantity = 1;
                    _pb._Price = float.Parse(currentRow["BookPrice"].ToString());
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
                                newRow["Title"] = currentRow["Title"];
                                newRow["Amount"] = currentRow["Amount"];

                                newRow["ISBN"] = currentRow["ISBN"];
                                newRow["EditionNumber"] = currentRow["EditionNumber"];
                                newRow["CopyRight"] = currentRow["CopyRight"];
                                newRow["BookPrice"] = currentRow["BookPrice"];
                                newRow["CategoryId"] = currentRow["CategoryId"];
                                newRow["NumOfVisits"] = currentRow["NumOfVisits"];
                                newRow["OfferId"] = currentRow["OfferId"];

                                shoppingCartbookDT.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void GetBook(int index)
        {
            try
            {
                DataRow currentRow = BookDT.Rows[index];
                _cb._Id = int.Parse(currentRow["Id"].ToString());
                _cb._ISBN = currentRow["ISBN"].ToString().TrimEnd();
                _cb._Title = currentRow["Title"].ToString().TrimEnd();
                _cb._EditionNumber = int.Parse(currentRow["EditionNumber"].ToString());
                _cb._CopyRight = int.Parse(currentRow["CopyRight"].ToString());
                _cb._Amount = int.Parse(currentRow["Amount"].ToString());
                _cb._BookPrice = float.Parse(currentRow["BookPrice"].ToString());
                _cb._CategoryId = int.Parse(currentRow["CategoryId"].ToString());
                _cb._NumOfVisits = int.Parse(currentRow["NumOfVisits"].ToString());
                _cb._OfferId = int.Parse(currentRow["OfferId"].ToString());
                _cb._Name = currentRow["Name"].ToString();
            }
            catch (Exception)
            {

            }

        }

        private void Save()
        {
            Session["CatalogueBroker"] = _cb;
            Session["PurchaseBroker"] = _pb;
            Session["ShoppingCartBook"] = shoppingCartbookDT;
            Session["shoppingCart"] = shoppingCartDT;
        }
    }
}