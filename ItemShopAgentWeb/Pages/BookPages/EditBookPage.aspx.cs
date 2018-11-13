using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.BookPages
{
    public partial class EditBookPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
        static AdminAgent _sb;
        static DataTable BookDT;
        
        static DataTable SelectedBookOutDT;
        static DataTable SelectedBookInDT;
        
        static double _pageCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

                Initialization();
            }
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _cb._Top = 1;
            _cb._Flag = "R";
            GetBooks();
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_cb._Top - 1) > 0)
            {
                _cb._Top--;
                _cb._Flag = "R";
                GetBooks();
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_cb._Top < _pageCount)
            {
                _cb._Top++;
                _cb._Flag = "R";
                GetBooks();
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _cb._Top = (int)_pageCount;
            _cb._Flag = "R";
            GetBooks();
        }

        protected void BookGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string cmd = e.CommandName.ToString();
                if (cmd == "ViewDetail" || cmd == "AddOrderOut" || cmd == "AddOrderIn")
                {
                    int i = int.Parse(e.CommandArgument.ToString());
                    DataRow currentRow = BookDT.Rows[i];
                    if (cmd == "ViewDetail")
                    {
                        _cb._Id = int.Parse(currentRow["Id"].ToString());
                        _cb._ISBN = currentRow["ISBN"].ToString().TrimEnd();
                        _cb._Title = currentRow["Title"].ToString().TrimEnd();
                        _cb._EditionNumber = int.Parse(currentRow["EditionNumber"].ToString());
                        _cb._CopyRight = int.Parse(currentRow["CopyRight"].ToString());
                        _cb._Amount = int.Parse(currentRow["Amount"].ToString());
                        _cb._Price = float.Parse(currentRow["Price"].ToString());
                        _cb._CategoryId = (currentRow["CategoryId"].ToString() == string.Empty ? 0 : int.Parse(currentRow["CategoryId"].ToString()));

                        Session["CatalogueBroker"] = _cb;
                        Response.Redirect("~/Pages/BookPages/EditBookDetailPage.aspx");
                    }
                    else if (cmd == "AddOrderOut")
                    {
                        AddSelectedBook(currentRow, false);
                        Save();
                        Response.Redirect("~/Pages/Order/OrderOut/NewOrderOutPage.aspx");
                    }
                    else if (cmd == "AddOrderIn")
                    {
                        AddSelectedBook(currentRow, true);
                        Save();
                        Response.Redirect("~/Pages/Order/OrderIn/NewOrderInPage.aspx");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _cb._Top = 1;
            _cb._Flag = "R";
            GetBooks();
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_cb._Top - 1) > 0)
            {
                _cb._Top--;
                _cb._Flag = "R";
                GetBooks();
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_cb._Top < _pageCount)
            {
                _cb._Top++;
                _cb._Flag = "R";
                GetBooks();
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _cb._Top = (int)_pageCount;
            _cb._Flag = "R";
            GetBooks();
        }

        private void Initialization() 
        {
            _cb._Top = 1;
            _cb._PageSize = 1000;
            _cb._Flag = "C";
            GetBooks();

            double vc = _cb._SelectAllBookCount;
            double vp = _cb._PageSize;
            double v = vc / vp;
            double m = Math.Ceiling(v);

            _pageCount = m;

            indexToplbl.Text = _cb._Top.ToString();
            bookPagesTop.Text = _pageCount.ToString();

            indexBottomlbl.Text = _cb._Top.ToString();
            bookPagesbottom.Text = _pageCount.ToString();

            if (Session["SelectedBookOut"] != null)
            {
                SelectedBookOutDT = (DataTable)Session["SelectedBookOut"];

                if (_sb._Status == "Done")
                {
                    SelectedBookOutDT.Rows.Clear();
                    _sb._CustomerId = 0;
                }
            }
            else 
            {
                SelectedBookOutDT = BookDT.Clone();
                if (!SelectedBookOutDT.Columns.Contains("Quantity"))
                {
                    SelectedBookOutDT.Columns.Add("Quantity", typeof(int));
                }
                if (!SelectedBookOutDT.Columns.Contains("Total"))
                {
                    SelectedBookOutDT.Columns.Add("Total", typeof(float));
                }
            }

            if (Session["SelectedBookIn"] != null)
            {
                SelectedBookInDT = (DataTable)Session["SelectedBookIn"];

                if (_sb._Status == "Done")
                {
                    SelectedBookInDT.Rows.Clear();
                    _sb._SupplierId = 0;
                }
            }
            else
            {
                SelectedBookInDT = BookDT.Clone();
                if (!SelectedBookInDT.Columns.Contains("Quantity"))
                {
                    SelectedBookInDT.Columns.Add("Quantity", typeof(int));
                }
                if (!SelectedBookInDT.Columns.Contains("Total"))
                {
                    SelectedBookInDT.Columns.Add("Total", typeof(float));
                }
            }
        }

        private void GetBooks()
        {
            _cb.Execute("SelectAllBookCapability");
            if (_cb.Success != null)
            {
                BookDT = (DataTable)_cb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();
                indexToplbl.Text = _cb._Top.ToString();
                indexBottomlbl.Text = _cb._Top.ToString();
            }
        }

        private void AddSelectedBook(DataRow currentRow,bool InOut) 
        {
            if (InOut == false)
            {
                DataRow[] Rows = SelectedBookOutDT.Select("Id = " + int.Parse(currentRow["Id"].ToString()));

                if (Rows.Count() == 0)
                {
                    DataRow newRow = SelectedBookOutDT.NewRow();
                    newRow["Id"] = currentRow["Id"];
                    newRow["ISBN"] = currentRow["ISBN"];
                    newRow["Title"] = currentRow["Title"];
                    newRow["EditionNumber"] = currentRow["EditionNumber"];
                    newRow["CopyRight"] = currentRow["CopyRight"];
                    newRow["Amount"] = currentRow["Amount"];
                    newRow["BookPrice"] = currentRow["BookPrice"];
                    newRow["CategoryId"] = currentRow["CategoryId"];
                    newRow["NumOfVisits"] = currentRow["NumOfVisits"];
                    newRow["OfferId"] = currentRow["OfferId"];
                    newRow["Quantity"] = 1;
                    newRow["Total"] = 1 * float.Parse(currentRow["BookPrice"].ToString());
                    SelectedBookOutDT.Rows.Add(newRow);
                }
            }
            else if(InOut == true) 
            {
                DataRow[] Rows = SelectedBookInDT.Select("Id = " + int.Parse(currentRow["Id"].ToString()));

                if (Rows.Count() == 0)
                {
                    DataRow newRow = SelectedBookInDT.NewRow();
                    newRow["Id"] = currentRow["Id"];
                    newRow["ISBN"] = currentRow["ISBN"];
                    newRow["Title"] = currentRow["Title"];
                    newRow["EditionNumber"] = currentRow["EditionNumber"];
                    newRow["CopyRight"] = currentRow["CopyRight"];
                    newRow["Amount"] = currentRow["Amount"];
                    newRow["BookPrice"] = currentRow["BookPrice"];
                    newRow["CategoryId"] = currentRow["CategoryId"];
                    newRow["NumOfVisits"] = currentRow["NumOfVisits"];
                    newRow["OfferId"] = currentRow["OfferId"];
                    newRow["Quantity"] = 10;
                    newRow["Total"] = 10 * float.Parse(currentRow["BookPrice"].ToString());
                    SelectedBookInDT.Rows.Add(newRow);
                }
            }
        }

        private void Save() 
        {
            Session["CatalogueBroker"] = _cb;
            Session["StockBroker"] = _sb;
            Session["SelectedBookOut"] = SelectedBookOutDT;
            Session["SelectedBookIn"] = SelectedBookInDT;
        }
    }
}