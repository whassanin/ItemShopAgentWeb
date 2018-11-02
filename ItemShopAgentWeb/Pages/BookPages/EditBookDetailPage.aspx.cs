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
    public partial class EditBookDetailPage : System.Web.UI.Page
    {
        static AdminAgent _cb,_sb,_pb,_ib;
        static int bookId;
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

                if (Session["PurchaseBroker"] != null)
                {
                    if (Session["PurchaseBroker"].GetType() != typeof(AdminAgent))
                    {
                        _pb = new AdminAgent();
                    }
                    else
                    {
                        _pb = (AdminAgent)Session["PurchaseBroker"];
                    }
                }
                else
                {
                    _pb = new AdminAgent();
                }

                if (Session["InteractionBroker"] != null)
                {
                    if (Session["InteractionBroker"].GetType() != typeof(AdminAgent))
                    {
                        _ib = new AdminAgent();
                    }
                    else
                    {
                        _ib = (AdminAgent)Session["InteractionBroker"];
                    }
                }
                else
                {
                    _ib = new AdminAgent();
                }

                DisplayCatgeory();
                SetBook();

                bookId = _cb._Id;

                GetOrderOutByBook();
                GetOrderInByBook();
                GetShoppingCartbyBook();
                GetWishListbyBook();
                GetReviewbyBook();
                GetRatebyBook();
            }
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
                    categoryDDL.DataSource = (DataTable)_cb.Success;
                    categoryDDL.DataTextField = "Name";
                    categoryDDL.DataValueField = "Id";
                    categoryDDL.DataBind();
                }

            }
            catch (Exception)
            {

            }
        }

        private void SetBook() 
        {
            idtxt.Text = _cb._Id.ToString();
            ISBNtxt.Text = _cb._ISBN.TrimEnd();
            titletxt.Text = _cb._Title.TrimEnd();
            editionNumbertxt.Text = _cb._EditionNumber.ToString();
            copyRighttxt.Text = _cb._CopyRight.ToString();
            Amounttxt.Text = _cb._Amount.ToString();
            pricetxt.Text = _cb._BookPrice.ToString();
            if (_cb._CategoryId == 0)
            {
                categoryDDL.SelectedIndex = 0;
            }
            else 
            {
                categoryDDL.SelectedIndex = _cb._CategoryId - 1;
            }
        }

        private void GetOrderOutByBook() 
        {
            _sb._Flag = "C";
            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._BookId = bookId;

            _sb.Execute("SelectOrderOut_ItemByBookIdCapability");
            if (_sb.Success != null)
            {
                DataTable orderOutItemBook = (DataTable)_sb.Success;
                OrderOutGV.DataSource = orderOutItemBook;
                OrderOutGV.DataBind();
            }
        }

        private void GetOrderInByBook()
        {
            _sb._Flag = "C";
            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._BookId = bookId;

            _sb.Execute("SelectOrderIn_ItemByBookIdCapability");
            if (_sb.Success != null)
            {
                DataTable orderInItemBook = (DataTable)_sb.Success;
                OrderInGV.DataSource = orderInItemBook;
                OrderInGV.DataBind();
            }
        }

        private void GetShoppingCartbyBook() 
        {
            _pb._Flag = "C";
            _pb._Top = 1;
            _pb._PageSize = 1000;
            _pb._BookId = bookId;

            _pb.Execute("SelectShoppingCart_BookByBookIdCapability");
            if (_pb.Success != null)
            {
                DataTable shoppingCartbook = (DataTable)_pb.Success;
                shoppingCartBookGV.DataSource = shoppingCartbook;
                shoppingCartBookGV.DataBind();
            }
        }

        private void GetWishListbyBook()
        {
            _ib._Flag = "C";
            _ib._Top = 1;
            _ib._PageSize = 1000;
            _ib._BookId = bookId;

            _ib.Execute("SelectCustomerWishListByBookIdCapability");
            if (_ib.Success != null)
            {
                DataTable wishListbook = (DataTable)_ib.Success;
                WishListByBookGV.DataSource = wishListbook;
                WishListByBookGV.DataBind();
            }
        }

        private void GetReviewbyBook()
        {
            _ib._Flag = "C";
            _ib._Top = 1;
            _ib._PageSize = 1000;
            _ib._BookId = bookId;

            _ib.Execute("SelectCustomerReviewByBookIdCapability");
            if (_ib.Success != null)
            {
                DataTable reviewbook = (DataTable)_ib.Success;
                CommentGV.DataSource = reviewbook;
                CommentGV.DataBind();
            }
        }

        private void GetRatebyBook()
        {
            _ib._Flag = "C";
            _ib._Top = 1;
            _ib._PageSize = 1000;
            _ib._BookId = bookId;

            _ib.Execute("SelectCustomerRateByBookIdCapability");
            if (_ib.Success != null)
            {
                DataTable ratebook = (DataTable)_ib.Success;
                RateGV.DataSource = ratebook;
                RateGV.DataBind();

                ratebook = (DataTable)_ib.Success;
                double sum = 0;
                for (int i = 0; i < ratebook.Rows.Count; i++)
                {
                    sum += double.Parse(ratebook.Rows[i]["Rate"].ToString());
                }
                double v = sum / ratebook.Rows.Count;
                ratelbl.Text = v.ToString();
            }
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            _cb._Id = int.Parse(idtxt.Text);
            _cb._ISBN = ISBNtxt.Text;
            _cb._Title = titletxt.Text;
            _cb._EditionNumber = int.Parse(editionNumbertxt.Text);
            _cb._CopyRight = int.Parse(copyRighttxt.Text);
            _cb._Amount = int.Parse(Amounttxt.Text);
            _cb._Price = float.Parse(pricetxt.Text);

            _cb.Execute("UpdateBookCapability");
            if (_cb.Success!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved');", true);
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            _cb._Id = int.Parse(idtxt.Text);

            _cb.Execute("DeleteBookCapability");
            if (_cb.Success!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted');", true);
                Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
            }
        }

    }
}