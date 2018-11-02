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
    public partial class NewBookPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CatalogueAgent"] != null)
                {
                    _cb = (AdminAgent)Session["CatalogueAgent"];
                }
                else 
                {
                    _cb = new AdminAgent();
                }

                GetBookNewId();

                DisplayCatgeory();

                categoryDDL.SelectedIndex = 0;
            }
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void GetBookNewId()
        {
            _cb.Execute("SelectMaxIdBookCapability");
            if (_cb.Success != null)
            {
                idtxt.Text = _cb.Success.ToString();
            }
        }

        private void SaveBook()
        {
            _cb._Id = int.Parse(idtxt.Text);
            _cb._Title = titletxt.Text;
            _cb._ISBN = ISBNtxt.Text;
            _cb._EditionNumber = int.Parse(editionNumbertxt.Text);
            _cb._CopyRight = int.Parse(copyRighttxt.Text);
            _cb._Amount = int.Parse(Amounttxt.Text);
            _cb._Price = float.Parse(pricetxt.Text);

            _cb._CategoryId = int.Parse(categoryDDL.SelectedValue);

            _cb.Execute("InsertBookCapability");
            if (_cb.Success != null)
            {
                if (_cb.Success.GetType() == typeof(bool))
                {
                    bool v = (bool)_cb.Success;
                    if (v == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved');", true);
                        GetBookNewId();

                        ISBNtxt.Text = "";
                        titletxt.Text = "";
                        editionNumbertxt.Text = "";
                        copyRighttxt.Text = "";
                        Amounttxt.Text = "";
                        pricetxt.Text = "";

                    }
                }
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
    }
}