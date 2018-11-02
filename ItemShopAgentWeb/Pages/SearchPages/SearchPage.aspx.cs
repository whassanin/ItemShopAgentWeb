using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.SearchPages
{
    public partial class SearchPage : System.Web.UI.Page
    {
        static CustomerAgent _sb;
        static CustomerAgent _pb;
        static CustomerAgent _ib;
        static DataTable searchBookDT = new DataTable();
        static DataTable shoppingCartDT = new DataTable();
        static DataTable shoppingCartbookDT = new DataTable();
        static DataTable customerSearchDT = new DataTable();
        static int currentIndex = 0;
        static double maxTop = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
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

                    if (Session["SearchBroker"] != null)
                    {
                        _sb = (CustomerAgent)Session["SearchBroker"];
                    }
                    else
                    {
                        _sb = new CustomerAgent();
                        Session["SearchBroker"] = _sb;
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

                    if (Session["shoppingCart"] != null)
                    {
                        shoppingCartDT = (DataTable)Session["shoppingCart"];
                    }
                    else 
                    {
                        Session["shoppingCart"] = shoppingCartDT;
                    }

                    if (Session["ShoppingCartBook"] != null)
                    {
                        shoppingCartbookDT = (DataTable)Session["ShoppingCartBook"];
                    }
                    else
                    {
                        shoppingCartbookDT = new DataTable();
                        Session["ShoppingCartBook"] = shoppingCartbookDT;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            Search(searchtxt.Text, "S", currentIndex, 1000);
        }

        protected void BookGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int pageIndex = BookGV.PageIndex;

                if (pageIndex > 0)
                {
                    index = index + (pageIndex * BookGV.PageSize);
                }

                SaveShoppingCart(index);
                Save();
                Response.Redirect(@"~/Pages/CartPage.aspx");
            }
        }

        private void SaveShoppingCart(int index)
        {
            DataRow currentRow = searchBookDT.Rows[index];
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

        private void SaveShoppingCartDetail(DataRow currentRow)
        {
            _pb._BookId = int.Parse(currentRow["Id"].ToString());

            DataRow[] rows = shoppingCartbookDT.Select("BookId = " + _pb._BookId);
            if (rows.Count() == 0)
            {
                _pb._BookId = int.Parse(currentRow["Id"].ToString());
                _pb._Quantity = 1;
                _pb._Price = float.Parse(currentRow["Price"].ToString());
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

                            newRow["Id"] = currentRow["Id"];
                            newRow["ISBN"] = currentRow["ISBN"];
                            newRow["Title"] = currentRow["Title"];
                            newRow["EditionNumber"] = currentRow["EditionNumber"];
                            newRow["CopyRight"] = currentRow["CopyRight"];
                            newRow["Amount"] = currentRow["Amount"];
                            newRow["Price1"] = currentRow["Price"];
                            newRow["CategoryId"] = currentRow["CategoryId"];
                            newRow["OriginalPrice"] = currentRow["OriginalPrice"];
                            newRow["DiscountRate"] = currentRow["DiscountRate"];
                            newRow["NumOfVisits"] = currentRow["NumOfVisits"];
                            newRow["OfferId"] = currentRow["OfferId"];

                            shoppingCartbookDT.Rows.Add(newRow);
                        }
                    }
                }
            }
        }

        private void Save()
        {
            Session["PurchaseBroker"] = _pb;
            Session["ShoppingCartBook"] = shoppingCartbookDT;
            Session["shoppingCart"] = shoppingCartDT;
        }

        protected void BookGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void firstbtn_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            Search(searchtxt.Text, "R", currentIndex, 1000);
        }

        protected void previousbtn_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                Search(searchtxt.Text, "R", currentIndex, 1000);
            }
        }

        protected void nextbtn_Click(object sender, EventArgs e)
        {
            if (currentIndex <= maxTop)
            {
                currentIndex++;
                Search(searchtxt.Text, "R", currentIndex, 1000);
            }
        }

        protected void lastbtn_Click(object sender, EventArgs e)
        {
            currentIndex = int.Parse(maxTop.ToString());
            Search(searchtxt.Text, "R", currentIndex, 1000);
        }

        private void Search(string v,string f,int t,int p) 
        {
            _sb._Title = v;
            _sb._Flag = f;
            _sb._Top = t;
            _sb._PageSize = p;
 
            _sb.Execute("SearchBookByTitleCapability");
            if (_sb.Success != null)
            {
                if (_sb._Flag == "C")
                {
                    if (_sb._SearchBookByTitleCount > 0)
                    {
                        maxTop = Math.Ceiling((double)_sb._SearchBookByTitleCount / (double)_sb._PageSize);
                        totalRecordslbl.Visible = true;
                        totalRecordslbl.Text = _sb._SearchBookByTitleCount.ToString();
                    }
                }

                searchBookDT = (DataTable)_sb.Success;

                BookGV.DataSource = searchBookDT;
                BookGV.DataBind();
            }
        }
    }
}