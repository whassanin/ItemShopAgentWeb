using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.DeliveryMethod
{
    public partial class EditDeliveryMethodPage : System.Web.UI.Page
    {
        static AdminAgent _db;
        static DataTable DeliveryMethodDT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["DeliveryBorker"] != null)
                {
                    if (Session["DeliveryBorker"].GetType() != typeof(AdminAgent))
                    {
                        _db = new AdminAgent();
                    }
                    else
                    {
                        _db = (AdminAgent)Session["DeliveryBorker"];
                    }
                }
                else
                {
                    _db = new AdminAgent();
                }

                _db._Top = 1;
                _db._PageSize = 1000;
                _db._Flag = "C";
                GetDeliveryMethod();
            }
        }

        protected void DeliveryMethodGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            if (cmd == "Select")
            {
                int i = int.Parse(e.CommandArgument.ToString());
                DataRow currentRow = DeliveryMethodDT.Rows[i];
                _db._Id = int.Parse(currentRow["Id"].ToString());
                _db._Method = currentRow["Method"].ToString().TrimEnd();
                _db._Cost = float.Parse(currentRow["Cost"].ToString());
                _db._PerItemCost = float.Parse(currentRow["PerItemCost"].ToString());
                _db._MinDeliveryTime = int.Parse(currentRow["MinDeliveryTime"].ToString());
                _db._MaxDeliveryTime = int.Parse(currentRow["MaxDeliveryTime"].ToString());

                Session["DeliveryBorker"] = _db;
                Response.Redirect("~/Pages/DeliveryMethod/EditDeliveryMethodDetailPage.aspx");
            }
        }

        private void GetDeliveryMethod()
        {
            _db.Execute("SelectAllDeliveryMethodCapability");
            if (_db.Success != null)
            {
                DeliveryMethodDT = (DataTable)_db.Success;
                DeliveryMethodGV.DataSource = DeliveryMethodDT;
                DeliveryMethodGV.DataBind();
            }
        }
    }
}