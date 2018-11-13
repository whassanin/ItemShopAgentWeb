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
    public partial class EditOrderInDetailPage : System.Web.UI.Page
    {
        static AdminAgent _cb;
        static AdminAgent _sb;
        static DataTable OrderDetailDT;
        static double _pageCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StockBroker"] != null)
                {
                    if (Session["StockBroker"].GetType() != typeof(AdminAgent))
                    {
                        _sb = new AdminAgent();
                    }
                    else
                    {
                        _sb = (AdminAgent)Session["StockBroker"];
                    }
                }
                else
                {
                    _sb = new AdminAgent();
                }

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

                Initialize();
            }
        }
        
        protected void firstTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderDetail();
        }

        protected void previousTopbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderDetail();
            }
        }

        protected void nextTopbtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderDetail();
            }
        }

        protected void lastTopbtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderDetail();
        }

        protected void OrderDetailGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void OrderDetailGV_RowDataBound(object sender, GridViewRowEventArgs e)
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
            OrderDetailDT.Rows[row.RowIndex]["Quantity"] = int.Parse(v);
            OrderDetailDT.Rows[row.RowIndex]["Total"] = int.Parse(v) * float.Parse(OrderDetailDT.Rows[row.RowIndex]["BookPrice"].ToString());
            OrderDetailGV.DataSource = OrderDetailDT;
            OrderDetailGV.DataBind();
            Calculate();
        }

        protected void firstBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = 1;
            _sb._Flag = "R";
            GetOrderDetail();
        }

        protected void previousBottompbtn_Click(object sender, EventArgs e)
        {
            if ((_sb._Top - 1) > 0)
            {
                _sb._Top--;
                _sb._Flag = "R";
                GetOrderDetail();
            }
        }

        protected void nextBottombtn_Click(object sender, EventArgs e)
        {
            if (_sb._Top < _pageCount)
            {
                _sb._Top++;
                _sb._Flag = "R";
                GetOrderDetail();
            }         
        }

        protected void lastBottombtn_Click(object sender, EventArgs e)
        {
            _sb._Top = (int)_pageCount;
            _sb._Flag = "R";
            GetOrderDetail();
        }

        private void Initialize() 
        {
            OrderInlbl.Text = _sb._OrderInId.ToString();
            OrderDatalbl.Text = _sb._OrderDate.ToString();
            SupplierNamelbl.Text = _sb._SupplierName;

            GetOrderDetail();

            double vc = _sb._SelectOrderIn_ItemByOrderInIdCount;
            double vp = _sb._PageSize;
            double v = vc / vp;
            double m = Math.Ceiling(v);

            _pageCount = m;

            indexToplbl.Text = _sb._Top.ToString();
            PagesTop.Text = _pageCount.ToString();

            indexBottomlbl.Text = _sb._Top.ToString();
            Pagesbottom.Text = _pageCount.ToString();
        }

        private void GetOrderDetail() 
        {
            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._Flag = "C";
            _sb.Execute("SelectOrderOut_ItemByOrderInIdCapability");
            if (_sb.Success != null)
            {
                OrderDetailDT = (DataTable)_sb.Success;
                
                Calculate();
                
                OrderDetailGV.DataSource = OrderDetailDT;
                OrderDetailGV.DataBind();

            }
        }

        private void Calculate()
        {
            double sum = 0;
            for (int i = 0; i < OrderDetailDT.Rows.Count; i++)
            {
                sum += double.Parse(OrderDetailDT.Rows[i]["Total"].ToString());
            }
            Totallbl.Text = "Total:" + Math.Round(sum).ToString();
        }
    }
}