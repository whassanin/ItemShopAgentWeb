using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
namespace ItemShopAgentWeb.Pages.DeliveryMethod
{
    public partial class NewDeliveryMethodPage : System.Web.UI.Page
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

                GetDeliveryMethodNewId();
            }
        }

        private void GetDeliveryMethodNewId() 
        {
            try
            {
                _db.Execute("SelectMaxIdDeliveryMethodCapability");
                if (_db.Success != null)
                {
                    idtxt.Text = _db.Success.ToString();
                }
            }
            catch (Exception)
            {
                
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

            _db.Execute("InsertDeliveryMethodCapability");
            if (_db.Success!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved');", true);
                methodtxt.Text = "";
                costtxt.Text = "";
                perItemCosttxt.Text = "";
                minDeliveryTimetxt.Text = "";
                maxDeliveryTimetxt.Text = "";
                GetDeliveryMethodNewId();
            }
        }
    }
}