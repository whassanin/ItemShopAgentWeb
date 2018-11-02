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
    public partial class NewCategoryPage1 : System.Web.UI.Page
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

                GetCategoryNewId();
            }
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            if (isMainCB.Checked == false)
            {
                _cb._SubCategoryId = int.Parse(subCategoryNameDDL.SelectedValue);
            }

            _cb._Id = int.Parse(Idtxt.Text);
            _cb._Name = nametxt.Text;

            _cb.Execute("InsertCategoryCapability");
            if (_cb.Success!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved');", true);
                GetCategoryNewId();
                nametxt.Text = "";
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

        private void GetCategoryNewId()
        {
            try
            {
                _cb.Execute("SelectMaxIdCategoryCapability");
                if (_cb.Success != null)
                {
                    Idtxt.Text = _cb.Success.ToString();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}