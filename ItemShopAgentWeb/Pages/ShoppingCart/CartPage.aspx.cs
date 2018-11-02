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
    public partial class CartPage : System.Web.UI.Page
    {
        static CustomerAgent _pb;
        static DataTable shoppingCartDT = new DataTable();
        static DataTable shoppingCartbookDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["PurchaseBroker"] != null)
                    {
                        _pb = (CustomerAgent)Session["PurchaseBroker"];
                    }

                    if (Session["ShoppingCartBook"] != null)
                    {
                        shoppingCartbookDT = (DataTable)Session["ShoppingCartBook"];
                    }

                    if (Session["ShoppingCart"] != null)
                    {
                        shoppingCartDT = (DataTable)Session["ShoppingCart"];
                    }

                    ShoppingCartBookGV.DataSource = shoppingCartbookDT;
                    ShoppingCartBookGV.DataBind();

                    Calculate();
                }
                catch (Exception)
                {

                }
            }
        }
        protected void ShoppingCartBookGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string t = e.CommandName.ToString();
                int index = int.Parse(e.CommandArgument.ToString());
                if (t == "Inc" || t == "Dec")
                {
                    DataKey currentRow = ShoppingCartBookGV.DataKeys[index];
                    int a = int.Parse(shoppingCartbookDT.Rows[index]["Amount"].ToString());
                    int q = int.Parse(shoppingCartbookDT.Rows[index]["Quantity"].ToString());
                    float p = float.Parse(shoppingCartbookDT.Rows[index]["Price"].ToString());
                    if (t == "Inc")
                    {
                        q++;
                        if (q <= a)
                        {
                            shoppingCartbookDT.Rows[index]["Quantity"] = q;
                        }
                        else
                        {

                        }

                    }
                    else if (t == "Dec")
                    {
                        if (q > 1)
                        {
                            q--;
                            shoppingCartbookDT.Rows[index]["Quantity"] = q;
                        }
                        else
                        {

                        }

                    }

                    shoppingCartbookDT.Rows[index]["Total"] = Math.Round(q * p, 1);

                    _pb._Id = int.Parse(shoppingCartbookDT.Rows[index]["Id"].ToString());
                    _pb._ShoppingCartId = int.Parse(shoppingCartbookDT.Rows[index]["ShoppingCartId"].ToString());
                    _pb._BookId = int.Parse(shoppingCartbookDT.Rows[index]["BookId"].ToString());
                    _pb._Price = float.Parse(shoppingCartbookDT.Rows[index]["Price"].ToString());
                    _pb._Quantity = int.Parse(shoppingCartbookDT.Rows[index]["Quantity"].ToString());
                    _pb._Total = float.Parse(shoppingCartbookDT.Rows[index]["Total"].ToString());
                    _pb._Status = shoppingCartbookDT.Rows[index]["Status"].ToString().TrimEnd();

                    _pb.Execute("UpdateShoppingCart_BookCapability");
                    if (_pb.Success != null)
                    {
                        Calculate();
                        _pb._Date = DateTime.Now;
                        _pb._Total = float.Parse(totaltxt.Text);
                        _pb.Execute("UpdateShoppingCartCapability");
                        if (_pb.Success != null)
                        {
                            ShoppingCartBookGV.DataSource = shoppingCartbookDT;
                            ShoppingCartBookGV.DataBind();
                            Save();
                        }
                    }
                }
                else if (t == "Delete")
                {
                    _pb._Id = int.Parse(shoppingCartbookDT.Rows[index]["ShoppingCart_BookId"].ToString());
                    _pb.Execute("DeleteShoppingCart_BookCapability");
                    if (_pb.Success != null)
                    {
                        shoppingCartbookDT.Rows.RemoveAt(index);

                        ShoppingCartBookGV.DataSource = shoppingCartbookDT;
                        ShoppingCartBookGV.DataBind();
                        Save();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ContinueShoppingbtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/Pages/HomePage.aspx");
        }

        protected void ArrangeDeliverybtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/Pages/DeliveryMethod/DeliveryMethodPage.aspx");
        }
        private void Save()
        {
            Session["ShoppingCart"] = shoppingCartDT;
            Session["ShoppingCartBook"] = shoppingCartbookDT;
            Session["PurchaseBroker"] = _pb;
        }

        private void Calculate()
        {
            double sum = 0;
            for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
            {
                sum += double.Parse(shoppingCartbookDT.Rows[i]["Total"].ToString());
            }
            totaltxt.Text = Math.Round(sum).ToString();
        }

        protected void ShoppingCartBookGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ShoppingCartBookGV.DataSource = shoppingCartbookDT;
            ShoppingCartBookGV.DataBind();
            Save();
        }
    }
}