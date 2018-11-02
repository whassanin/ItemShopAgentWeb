using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.Customer
{
    public partial class NewOrderOutPage : System.Web.UI.Page
    {
        static DataTable SelectedBookOutDT;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SelectedBookOut"] != null)
                {
                    SelectedBookOutDT = (DataTable)Session["SelectedBookOut"];
                }
                else 
                {
                    SelectedBookOutDT = new DataTable();
                }

                SelectedBookOutGV.DataSource = SelectedBookOutDT;
                SelectedBookOutGV.DataBind();

                Calculate();
            }

        }

        protected void SelectedBookOutGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string t = e.CommandName;
                int index = int.Parse(e.CommandArgument.ToString());
                if (t == "Inc" || t == "Dec")
                {
                    int a = int.Parse(SelectedBookOutDT.Rows[index]["Amount"].ToString());
                    int q = int.Parse(SelectedBookOutDT.Rows[index]["Quantity"].ToString());
                    float p = float.Parse(SelectedBookOutDT.Rows[index]["BookPrice"].ToString());

                    if (t == "Inc")
                    {
                        q++;
                        if (q <= a)
                        {
                            SelectedBookOutDT.Rows[index]["Quantity"] = q;
                        }
                    }
                    else if (t == "Dec")
                    {
                        if (q > 1)
                        {
                            q--;
                            SelectedBookOutDT.Rows[index]["Quantity"] = q;
                        }
                    }

                    SelectedBookOutDT.Rows[index]["Total"] = Math.Round(q * p, 1);
                    SelectedBookOutGV.DataSource = SelectedBookOutDT;
                    SelectedBookOutGV.DataBind();
                    Calculate();
                    Save();
                }
                else if(t == "Delete") 
                {
                    SelectedBookOutDT.Rows.RemoveAt(index);

                    SelectedBookOutGV.DataSource = SelectedBookOutDT;
                    SelectedBookOutGV.DataBind();
                    
                    if (SelectedBookOutDT.Rows.Count == 0)
                    {
                        Save();
                        Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void cancelOrderbtn_Click(object sender, EventArgs e)
        {
            SelectedBookOutDT.Rows.Clear();
            Save();
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        protected void ConfirmOrderbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Customer/SearchCustomer/SearchCustomerByPhonePage.aspx");
        }

        protected void continueOrderbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        protected void SelectedBookOutGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void Calculate()
        {
            double sum = 0;
            for (int i = 0; i < SelectedBookOutDT.Rows.Count; i++)
            {
                sum += double.Parse(SelectedBookOutDT.Rows[i]["Total"].ToString());
            }
            totallbl.Text = "Total:" + Math.Round(sum).ToString();
        }

        private void Save()
        {
            Session["SelectedBookOut"] = SelectedBookOutDT;
        }
    }
}