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
    public partial class SearchBookPage : System.Web.UI.Page
    {
        static AdminAgent _cb, _sb;
        static DataTable BookDT;
        static double _pageCount;
        static string _CurrentFlagSearch;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SearchBroker"] != null)
                {
                    if (Session["SearchBroker"].GetType() != typeof(AdminAgent))
                    {
                        _sb = new AdminAgent();
                    }
                    else
                    {
                        _sb = (AdminAgent)Session["SearchBroker"];
                    }
                }
                else
                {
                    _sb = new AdminAgent();
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

            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
        }

        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
        }

        protected void BookGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName.ToString();
            if (cmd == "Select")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                DataRow currentRow = BookDT.Rows[i];
                _cb._Id = int.Parse(currentRow["Id"].ToString());
                _cb._ISBN = currentRow["ISBN"].ToString().TrimEnd();
                _cb._Title = currentRow["Title"].ToString().TrimEnd();
                _cb._EditionNumber = int.Parse(currentRow["EditionNumber"].ToString());
                _cb._CopyRight = int.Parse(currentRow["CopyRight"].ToString());
                _cb._Amount = int.Parse(currentRow["Amount"].ToString());
                _cb._BookPrice = float.Parse(currentRow["BookPrice"].ToString());
                _cb._CategoryId = (currentRow["CategoryId"].ToString() == string.Empty ? 0 : int.Parse(currentRow["CategoryId"].ToString()));

                Session["CatalogueBroker"] = _cb;
                Response.Redirect("~/Pages/BookPages/EditBookDetailPage.aspx");

            }
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
            }
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            SearchBook(searchOptionDDL.SelectedValue, searchtxt.Text);
        }

        private void SearchBook(string Flag, string value)
        {
            bool a = ValidateSearchOption(Flag);
            if (a == false)
            {
                _sb._Top = 1;
                _sb._PageSize = 1000;
                _sb._Flag = "C";
            }

            if (_CurrentFlagSearch == "Title")
            {
                SearchBookByTitle(value);
            }
            else if (_CurrentFlagSearch == "ISBN")
            {
                SearchBookByISBN(value);
            }
            else if (_CurrentFlagSearch == "EditionNumber")
            {
                SearchBookByEditionNumber(value);
            }
            else if (_CurrentFlagSearch == "CopyRight")
            {
                SearchBookByCopyRight(value);
            }
            else if (_CurrentFlagSearch == "Price")
            {
                SearchBookByPrice(value);
            }
        }

        private bool ValidateSearchOption(string Flag)
        {
            bool isCheck = true;
            if (Flag != string.Empty)
            {
                if (_CurrentFlagSearch != Flag)
                {
                    isCheck = false;
                    _CurrentFlagSearch = Flag;
                }
            }
            else
            {
                _CurrentFlagSearch = Flag;
            }
            return isCheck;
        }

        private void SearchBookByTitle(string v)
        {
            _sb._Title = searchtxt.Text;
            _sb.Execute("SearchBookByTitleCapability");
            if (_sb.Success != null)
            {
                BookDT = (DataTable)_sb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();
                //_SearchBookByTitleCount
                if (_sb._SearchBookByTitleCount > 0)
                {
                    double vc = _sb._SearchBookByTitleCount;
                    double vp = _sb._PageSize;
                    double c = vc / vp;
                    double m = Math.Ceiling(c);

                    if (_pageCount != m)
                    {
                        _pageCount = m;

                        indexToplbl.Text = _sb._Top.ToString();
                        bookPagesTop.Text = _pageCount.ToString();

                        indexBottomlbl.Text = _sb._Top.ToString();
                        bookPagesbottom.Text = _pageCount.ToString();
                    }

                    indexToplbl.Text = _sb._Top.ToString();
                    indexBottomlbl.Text = _sb._Top.ToString();
                }
            }
        }

        private void SearchBookByISBN(string v)
        {
            _sb._ISBN = searchtxt.Text;
            _sb.Execute("SearchBookByISBNCapability");
            if (_sb.Success != null)
            {
                BookDT = (DataTable)_sb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();

                if (_sb._SearchBookByISBNCount > 0)
                {
                    double vc = _sb._SearchBookByISBNCount;
                    double vp = _sb._PageSize;
                    double c = vc / vp;
                    double m = Math.Ceiling(c);

                    if (_pageCount != m)
                    {
                        _pageCount = m;

                        indexToplbl.Text = _sb._Top.ToString();
                        bookPagesTop.Text = _pageCount.ToString();

                        indexBottomlbl.Text = _sb._Top.ToString();
                        bookPagesbottom.Text = _pageCount.ToString();
                    }

                    indexToplbl.Text = _sb._Top.ToString();
                    indexBottomlbl.Text = _sb._Top.ToString();
                }
            }
        }

        private void SearchBookByEditionNumber(string v)
        {
            _sb._EditionNumber = int.Parse(searchtxt.Text);
            _sb.Execute("SearchBookByEditionNumberCapability");
            if (_sb.Success != null)
            {
                BookDT = (DataTable)_sb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();

                if (_sb._SearchBookByEditionNumberCount > 0)
                {
                    double vc = _sb._SearchBookByEditionNumberCount;
                    double vp = _sb._PageSize;
                    double c = vc / vp;
                    double m = Math.Ceiling(c);

                    if (_pageCount != m)
                    {
                        _pageCount = m;

                        indexToplbl.Text = _sb._Top.ToString();
                        bookPagesTop.Text = _pageCount.ToString();

                        indexBottomlbl.Text = _sb._Top.ToString();
                        bookPagesbottom.Text = _pageCount.ToString();
                    }

                    indexToplbl.Text = _sb._Top.ToString();
                    indexBottomlbl.Text = _sb._Top.ToString();
                }
            }
        }

        private void SearchBookByCopyRight(string v)
        {
            _sb._CopyRight = int.Parse(searchtxt.Text);
            _sb.Execute("SearchBookByCopyRightCapability");
            if (_sb.Success != null)
            {
                BookDT = (DataTable)_sb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();

                if (_sb._SearchBookByCopyRightCount > 0)
                {
                    double vc = _sb._SearchBookByCopyRightCount;
                    double vp = _sb._PageSize;
                    double c = vc / vp;
                    double m = Math.Ceiling(c);

                    if (_pageCount != m)
                    {
                        _pageCount = m;

                        indexToplbl.Text = _sb._Top.ToString();
                        bookPagesTop.Text = _pageCount.ToString();

                        indexBottomlbl.Text = _sb._Top.ToString();
                        bookPagesbottom.Text = _pageCount.ToString();
                    }

                    indexToplbl.Text = _sb._Top.ToString();
                    indexBottomlbl.Text = _sb._Top.ToString();
                }
            }
        }

        private void SearchBookByPrice(string v)
        {
            _sb._Price = float.Parse(searchtxt.Text);
            _sb.Execute("SearchBookByPriceCapability");
            if (_sb.Success != null)
            {
                BookDT = (DataTable)_sb.Success;
                BookGV.DataSource = BookDT;
                BookGV.DataBind();

                if (_sb._SearchBookByBookPriceCount > 0)
                {
                    double vc = _sb._SearchBookByBookPriceCount;
                    double vp = _sb._PageSize;
                    double c = vc / vp;
                    double m = Math.Ceiling(c);

                    if (_pageCount != m)
                    {
                        _pageCount = m;

                        indexToplbl.Text = _sb._Top.ToString();
                        bookPagesTop.Text = _pageCount.ToString();

                        indexBottomlbl.Text = _sb._Top.ToString();
                        bookPagesbottom.Text = _pageCount.ToString();
                    }

                    indexToplbl.Text = _sb._Top.ToString();
                    indexBottomlbl.Text = _sb._Top.ToString();
                }
            }
        }
    }
}