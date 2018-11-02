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
    public partial class ConfirmOrderPage : System.Web.UI.Page
    {
        static CustomerAgent _db = new CustomerAgent();
        static CustomerAgent _pmb = new CustomerAgent();
        static CustomerAgent _pb = new CustomerAgent();
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
                    else
                    {
                        _pb = new CustomerAgent();
                        Session["PurchaseBroker"] = _pb;
                    }

                    if (Session["DeliveryAgent"] != null)
                    {
                        _db = (CustomerAgent)Session["DeliveryAgent"];
                    }
                    else
                    {
                        _db = new CustomerAgent();
                        Session["DeliveryAgent"] = _db;
                    }

                    if (Session["ProfileMonitor"] != null)
                    {
                        _pmb = (CustomerAgent)Session["ProfileMonitor"];
                    }
                    else
                    {
                        _pmb = new CustomerAgent();
                        Session["ProfileMonitor"] = _pmb;
                    }

                    if (Session["ShoppingCartBook"] != null)
                    {
                        shoppingCartbookDT = (DataTable)Session["ShoppingCartBook"];
                    }

                    if (Session["ShoppingCart"] != null)
                    {
                        shoppingCartDT = (DataTable)Session["ShoppingCart"];
                    }

                    numbertxt.Text = _pmb._Number.ToString();
                    streettxt.Text = _pmb._Street;
                    Districttxt.Text = _pmb._District.ToString();
                    countrytxt.Text = _pmb._Country;
                    citytxt.Text = _pmb._City;
                    zipCodetxt.Text = _pmb._ZipCode.ToString();

                    Methodtxt.Text = _db._Method;
                    costtxt.Text = _db._Cost.ToString();
                    peritemCosttxt.Text = _db._PerItemCost.ToString();
                    MinDeliveryTimetxt.Text = _db._MinDeliveryTime.ToString();
                    MaxDeliveryTimetxt.Text = _db._MaxDeliveryTime.ToString();

                    ShoppingCartBookGV.DataSource = shoppingCartbookDT;
                    ShoppingCartBookGV.DataBind();
                    Calculate();
                }

                catch (Exception)
                {

                }
            }
        }
        private void Calculate()
        {
            float sum = 0, sumDelivery = 0;
            for (int i = 0; i < shoppingCartbookDT.Rows.Count; i++)
            {
                sum += float.Parse(shoppingCartbookDT.Rows[i]["Total"].ToString());
            }

            totalCostItemstxt.Text = sum.ToString();

            sumDelivery = _db._Cost + (shoppingCartbookDT.Rows.Count * _db._PerItemCost);
            totalCostOfDeliverytxt.Text = sumDelivery.ToString();
            
            sum += sumDelivery;
            Totaltxt.Text = sum.ToString();
            _pb._Total = sum;
        }

        protected void confirmbtn_Click(object sender, EventArgs e)
        {
            Session["ProfileMonitor"] = _pmb;
            Session["PurchaseBroker"] = _pb;
            Response.Redirect("~/Pages/Customer/CreditCard/CreditCardPage.aspx");
        }

        protected void gobackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Delivery/DeliveryPage.aspx");
        }
    }
}