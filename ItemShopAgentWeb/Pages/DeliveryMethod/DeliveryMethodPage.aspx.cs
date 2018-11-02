using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages
{
    public partial class DeliveryMethodPage : System.Web.UI.Page
    {
        static CustomerAgent _db;
        static DataTable deliveryDT = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["DeliveryAgent"] != null)
                    {
                        _db = (CustomerAgent)Session["DeliveryAgent"];
                    }
                    else
                    {
                        _db = new CustomerAgent();
                        Session["DeliveryAgent"] = _db;
                    }

                    _db._Top = 1;
                    _db._PageSize = 100;
                    _db._Flag = "C";
                    _db.Execute("SelectAllDeliveryMethodCapability");
                    if (_db.Success != null)
                    {
                        deliveryDT = (DataTable)_db.Success;
                        for (int i = 0; i < deliveryDT.Rows.Count; i++)
                        {
                            deliveryDT.Rows[i]["Method"] = deliveryDT.Rows[i]["Method"].ToString().TrimEnd();
                        }

                        DeliveryGV.DataSource = deliveryDT;
                        DeliveryGV.DataBind();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        protected void DeliveryGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    _db._DeliveryMethodId = int.Parse(deliveryDT.Rows[index]["Id"].ToString());
                    _db._Method = deliveryDT.Rows[index]["Method"].ToString().TrimEnd();
                    _db._Cost = float.Parse(deliveryDT.Rows[index]["Cost"].ToString());
                    _db._PerItemCost = float.Parse(deliveryDT.Rows[index]["PerItemCost"].ToString());
                    _db._MinDeliveryTime = int.Parse(deliveryDT.Rows[index]["MinDeliveryTime"].ToString());
                    _db._MaxDeliveryTime = int.Parse(deliveryDT.Rows[index]["MaxDeliveryTime"].ToString());

                    Session["DeliveryAgent"] = _db;

                    Response.Redirect("~/Pages/Delivery/DeliveryPage.aspx");
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Pages/ShoppingCart/CartPage.aspx");
        }
    }
}