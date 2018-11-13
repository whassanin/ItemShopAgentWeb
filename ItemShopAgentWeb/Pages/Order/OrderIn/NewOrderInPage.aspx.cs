using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemStoreDBNameSpace;
using System.Data;
namespace ItemShopAgentWeb.Pages.Order.OrderIn
{
    public partial class NewOrderInPage : System.Web.UI.Page
    {
        static DataTable SelectedBookInDT;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SelectedBookIn"] != null)
                {
                    SelectedBookInDT = (DataTable)Session["SelectedBookIn"];
                }
                else
                {
                    SelectedBookInDT = new DataTable();
                }

                SelectedBookInGV.DataSource = SelectedBookInDT;
                SelectedBookInGV.DataBind();
                Calculate();
            }
        }

        protected void SelectedBookInGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

            }
        }

        protected void SelectedBookInGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList quantityDDL = e.Row.FindControl("QuantityDDL") as DropDownList;

                int j = 0;
                for (int i = 20; i >= 1; i--)
                {
                    quantityDDL.Items.Insert(j, new ListItem(i.ToString()));
                    j++;
                }

                string v = (e.Row.FindControl("Quantitylbl") as Label).Text;
                quantityDDL.Items.FindByValue(v).Selected = true;
            }
        }

        protected void QuantityDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(sender as DropDownList).NamingContainer;
            string v = ((DropDownList)row.FindControl("QuantityDDL")).SelectedItem.Value;
            SelectedBookInDT.Rows[row.RowIndex]["Quantity"] = int.Parse(v);
            SelectedBookInDT.Rows[row.RowIndex]["Total"] = int.Parse(v) * float.Parse(SelectedBookInDT.Rows[row.RowIndex]["BookPrice"].ToString());
            SelectedBookInGV.DataSource = SelectedBookInDT;
            SelectedBookInGV.DataBind();
            Calculate();
        }

        protected void SelectedBookInGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void cancelOrderbtn_Click(object sender, EventArgs e)
        {
            SelectedBookInDT.Rows.Clear();
            Save();
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        protected void continueOrderbtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/Pages/BookPages/EditBookPage.aspx");
        }

        protected void ConfirmOrderbtn_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/Pages/Supplier/SearchSupplier/SearchSupplierByPhonePage.aspx");
        }

        private void Calculate()
        {
            double sum = 0;
            for (int i = 0; i < SelectedBookInDT.Rows.Count; i++)
            {
                sum += double.Parse(SelectedBookInDT.Rows[i]["Total"].ToString());
            }
            totallbl.Text = "Total:" + Math.Round(sum).ToString();
        }

        private void Save()
        {
            Session["SelectedBookInDT"] = SelectedBookInDT;
        }
    }
}