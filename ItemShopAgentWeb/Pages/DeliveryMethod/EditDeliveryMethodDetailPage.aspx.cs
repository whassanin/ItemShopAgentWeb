using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
namespace ItemShopAgentWeb.Pages.DeliveryMethod
{
    public partial class EditDeliveryMethodDetailPage : System.Web.UI.Page
    {
        static AdminAgent _db;
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

                SetDeliveryMethod();
            }
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            _db._Id = int.Parse(idtxt.Text);
            _db._Method = methodtxt.Text;
            _db._Cost = float.Parse(costtxt.Text);
            _db._PerItemCost = float.Parse(perItemCosttxt.Text);
            _db._MinDeliveryTime = int.Parse(minDeliveryTimetxt.Text);
            _db._MaxDeliveryTime = int.Parse(maxDeliveryTimetxt.Text);

            _db.Execute("UpdateDeliveryMethodCapability");
            if (_db.Success != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved');", true);
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void SetDeliveryMethod() 
        {
            idtxt.Text = _db._Id.ToString();
            methodtxt.Text = _db._Method;
            costtxt.Text = _db._Cost.ToString();
            perItemCosttxt.Text = _db._PerItemCost.ToString();
            minDeliveryTimetxt.Text = _db._MinDeliveryTime.ToString();
            maxDeliveryTimetxt.Text = _db._MaxDeliveryTime.ToString();
        }
    }
}