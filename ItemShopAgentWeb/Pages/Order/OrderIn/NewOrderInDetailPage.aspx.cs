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
    public partial class NewOrderInDetailPage : System.Web.UI.Page
    {
        static AdminAgent _pmb,_sb;
        static DataTable SelectedBookInDT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ProfileMonitorBroker"] != null)
                {
                    if (Session["ProfileMonitorBroker"].GetType() != typeof(AdminAgent))
                    {
                        _pmb = new AdminAgent();
                    }
                    else
                    {
                        _pmb = (AdminAgent)Session["ProfileMonitorBroker"];
                    }
                }
                else
                {
                    _pmb = new AdminAgent();
                }

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

                if (Session["SelectedBookInDT"] != null)
                {
                    SelectedBookInDT = (DataTable)Session["SelectedBookInDT"];
                }
                else 
                {
                    SelectedBookInDT = new DataTable();
                }

                supplierNamelbl.Text = _pmb._SupplierName;

                SelectedBookInGV.DataSource = SelectedBookInDT;
                SelectedBookInGV.DataBind();
                Calculate();
            }
        }

        protected void CancelOrderbtn_Click(object sender, EventArgs e)
        {
            SelectedBookInDT.Rows.Clear();
            Session["SelectedBookInDT"] = SelectedBookInDT;
        }

        protected void saveOrderbtn_Click(object sender, EventArgs e)
        {
            CreateOrder();
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

        private void CreateOrder() 
        {
            _sb.Execute("SelectMaxIdOrderInCapability");
            if (_sb.Success!=null)
            {
                _sb._Id = int.Parse(_sb.Success.ToString());
                _sb._OrderDate = DateTime.Now;
                _sb._SupplierId = _pmb._Id;
                _sb._Status = "Processing";
                _sb.Execute("InsertOrderInCapability");
                if (_sb.Success != null)
                {
                    bool isCheck = bool.Parse(_sb.Success.ToString());
                    if (isCheck == true)
                    {
                        _sb._OrderInId = _sb._Id;
                        CreateOrderDetail();
                    }
                }
            }
        }

        private void CreateOrderDetail() 
        {
            int ce = 0;
            for (int i = 0; i < SelectedBookInDT.Rows.Count; i++)
            {
                _sb.Execute("SelectMaxIdOrderIn_ItemCapability");
                if (_sb.Success!=null)
                {
                    _sb._Id = int.Parse(_sb.Success.ToString());
                    _sb._BookId = int.Parse(SelectedBookInDT.Rows[i]["Id"].ToString());
                    _sb._Price = float.Parse(SelectedBookInDT.Rows[i]["BookPrice"].ToString());
                    _sb._Quantity = int.Parse(SelectedBookInDT.Rows[i]["Quantity"].ToString());
                    _sb._Total = _sb._Price * _sb._Quantity;

                    _sb.Execute("InsertOrderIn_ItemCapability");
                    if (_sb.Success!=null)
                    {
                        bool isCheck = bool.Parse(_sb.Success.ToString());
                        if (isCheck == true)
                        {
                            ce++;   
                        }
                    }
                }
            }

            if (ce == SelectedBookInDT.Rows.Count)
            {
                SelectedBookInDT.Rows.Clear();
                orderNumberlbl.Text = "Order Number is " + _sb._OrderInId.ToString();
            }
        }
    }
}