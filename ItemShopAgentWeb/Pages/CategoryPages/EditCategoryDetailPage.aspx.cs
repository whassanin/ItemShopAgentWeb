using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.CategoryPages
{
    public partial class EditCategoryPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
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

                _cb._Top = 1;
                _cb._PageSize = 1000;
                _cb._Flag = "C";

                DisplayCatgeory();
                
                SetCategory();

                _cb._SubCategoryId = int.Parse(Idtxt.Text);
                _cb._CategoryId = int.Parse(Idtxt.Text);

                GetSubCategory();

                GetBooksByCategory();
            }

        }

        private void SetCategory()
        {
            Idtxt.Text = _cb._Id.ToString();
            nametxt.Text = _cb._Name.TrimEnd();
            if (_cb._SubCategoryId == 0)
            {
                isMainCB.Checked = true;
            }
            else
            {
                subCategoryNameDDL.SelectedIndex = _cb._SubCategoryId - 1;
            }
        }

        private void DisplayCatgeory()
        {
            try
            {
                _cb.Execute("SelectAllCategoryCapability");
                if (_cb.Success != null)
                {
                     subCategoryNameDDL.DataSource = (DataTable)_cb.Success;
                     subCategoryNameDDL.DataTextField = "Name";
                     subCategoryNameDDL.DataValueField = "Id";
                     subCategoryNameDDL.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        private void GetSubCategory() 
        {
            try
            {
                _cb.Execute("SelectCategoryBySubCategoryIdCapability");
                if (_cb.Success != null)
                {
                    DataTable subCategoryDT = (DataTable)_cb.Success;
                    SubCategoryGV.DataSource = subCategoryDT;
                    SubCategoryGV.DataBind();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void GetBooksByCategory() 
        {
            try
            {
                _cb.Execute("SelectBookByCategoryIdCapability");
                if (_cb.Success != null)
                {
                    DataTable BookDT = (DataTable)_cb.Success;
                    BookGV.DataSource = BookDT;
                    BookGV.DataBind();
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {

        }
    }
}