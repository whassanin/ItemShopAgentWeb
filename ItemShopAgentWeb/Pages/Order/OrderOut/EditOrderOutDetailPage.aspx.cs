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
    public partial class EditOrderOutDetailPage : System.Web.UI.Page
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
            try
            {
                string cmd = e.CommandName;
                int i = int.Parse(e.CommandArgument.ToString());
                
                DataRow currentRow = OrderDetailDT.Rows[i];
               
                int q = int.Parse(currentRow["Quantity"].ToString());
                int r = int.Parse(currentRow["Return"].ToString());

                if (cmd == "Inc")
                {
                    if (r == 0)
                    {
                        r = 1;
                    }
                    else if (r < q)
                    {
                        r++;
                    }
                }
                else if (cmd == "Dec")
                {
                    if (r > 0)
                    {
                        r--;
                    }
                }

                OrderDetailDT.Rows[i]["Return"] = r;
                OrderDetailGV.DataSource = OrderDetailDT;
                OrderDetailGV.DataBind();
            }
            catch (Exception)
            {
                
            }
        }

        protected void ReturnItembtn_Click(object sender, EventArgs e)
        {
            if (ReturnItems() == 0) 
            {
                Response.Redirect("~/Pages/Order/OrderOut/EditOrderOutPage.aspx");
            }
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
            OrderOutlbl.Text = _sb._OrderOutId.ToString();
            OrderDatalbl.Text = _sb._OrderDate.ToString();
            Totallbl.Text = _sb._Total.ToString();
            Paidlbl.Text = _sb._Paid.ToString();
            Changelbl.Text = _sb._Change.ToString();
            CreditCardNumberlbl.Text = _sb._CreditCardNumber;
            Holderlbl.Text = _sb._Holder;
            PaymentType.Text = _sb._Flag.TrimEnd();
            FirstNamelbl.Text = _sb._FirstName.TrimEnd();
            LastNamelbl.Text = _sb._LastName.TrimEnd();
            MiddleNamelbl.Text = _sb._MiddleName.TrimEnd();

            TimeSpan t = DateTime.Now - _sb._OrderDate;
            if (Math.Abs(t.Days) < 14)
            {
                OrderDetailGV.Columns[7].Visible = true;
                OrderDetailGV.Columns[8].Visible = true;
            }
            else
            {
                OrderDetailGV.Columns[7].Visible = false;
                OrderDetailGV.Columns[8].Visible = false;
            }

            _sb._Top = 1;
            _sb._PageSize = 1000;
            _sb._Flag = "C";

            GetOrderDetail();

            double vc = _sb._SelectOrderOut_ItemByOrderOutIdCount;
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
            _sb.Execute("SelectOrderOut_ItemByOrderOutIdCapability");
            if (_sb.Success != null)
            {
                OrderDetailDT = (DataTable)_sb.Success;
                for (int i = 0; i < OrderDetailDT.Rows.Count; i++)
                {
                    OrderDetailDT.Rows[i]["Price"] = float.Parse(OrderDetailDT.Rows[i]["Price"].ToString()).ToString("F2");
                }

                if (!OrderDetailDT.Columns.Contains("Return"))
                {
                    OrderDetailDT.Columns.Add("Return", typeof(int));

                    for (int j = 0; j < OrderDetailDT.Rows.Count; j++)
                    {
                        OrderDetailDT.Rows[j]["Return"] = 0;
                    }
                }

                if (!OrderDetailDT.Columns.Contains("Operation"))
                {
                    OrderDetailDT.Columns.Add("Operation", typeof(string));

                    for (int j = 0; j < OrderDetailDT.Rows.Count; j++)
                    {
                        OrderDetailDT.Rows[j]["Operation"] = "";
                    }
                }

                OrderDetailGV.DataSource = OrderDetailDT;
                OrderDetailGV.DataBind();
            }
        }

        private int ReturnItems() 
        {
            bool IsCheck = false;
            try
            {
                for (int c = 0; c < OrderDetailDT.Rows.Count; c++)
                {
                    DataRow currentRow = OrderDetailDT.Rows[c];

                    IsCheck = UpdateBookAmount(currentRow);

                    if (IsCheck == true)
                    {
                        UpdateOrderDetail(currentRow);
                    }
                }

                GetOrderDetail();

                float s = 0;

                for (int j = 0; j < OrderDetailDT.Rows.Count; j++)
                {
                    float t = float.Parse(OrderDetailDT.Rows[j]["Total"].ToString());
                    s = s + t;
                }

                _sb._Paid = float.Parse(Paidlbl.Text);
                _sb._Change = _sb._Paid - s;
                _sb._Total = s;

                IsCheck = UpdateOrder();

                int x = OrderDetailDT.Rows.Count;
                
                if (IsCheck == true)
                {
                    Totallbl.Text = _sb._Total.ToString();
                    return x;
                }
            }
            catch (Exception)
            {

            }

            return 0;
        }

        private bool UpdateBookAmount(DataRow currentRow) 
        {
            bool IsCheck = false;
            _cb._Id = int.Parse(currentRow["BookId"].ToString());
            _cb._Amount = int.Parse(currentRow["Amount"].ToString()) + int.Parse(currentRow["Return"].ToString());
            _cb.Execute("UpdateAmountInBookCapability");
            if (_cb.Success!=null)
            {
                IsCheck = bool.Parse(_cb.Success.ToString());
            }
            return IsCheck;
        }

        private bool UpdateOrderDetail(DataRow currentRow) 
        {
            bool IsCheck = false;
            _sb._OrderOutId = int.Parse(currentRow["OrderOutId"].ToString());
            _sb._Id = int.Parse(currentRow["Id"].ToString());
            _sb._BookId = int.Parse(currentRow["BookId"].ToString());
            _sb._Price = float.Parse(currentRow["Price"].ToString());
            _sb._Quantity = int.Parse(currentRow["Quantity"].ToString()) - int.Parse(currentRow["Return"].ToString());
            _sb._Total = _sb._Quantity * _sb._Price;
            if (_sb._Quantity <= 0)
            {
                _sb.Execute("DeleteOrderOut_ItemCapability");
            }
            else 
            {
                _sb.Execute("UpdateOrderOut_ItemCapability");
            }

            if (_sb.Success != null)
            {
                IsCheck = bool.Parse(_sb.Success.ToString());
            }
            return IsCheck;
        }

        private bool UpdateOrder() 
        {
            bool IsCheck = false;
            _sb._Id = _sb._OrderOutId;
            _sb._OrderDate = DateTime.Now;
            _sb._Flag = PaymentType.Text;
            if (PaymentType.Text == "Cash")
            {
                _sb._CreditCardNumber = null;
                _sb._Holder = null;
            }
            else 
            {
                _sb._CreditCardNumber = CreditCardNumberlbl.Text.TrimEnd();
                _sb._Holder = Holderlbl.Text.TrimEnd();
            }

            if (_sb._Total > 0)
            {
                _sb.Execute("UpdateOrderOutCapability");
            }
            else 
            {
                _sb.Execute("DeleteOrderOutCapability");
            }

            if (_sb.Success != null)
            {
                IsCheck = bool.Parse(_sb.Success.ToString());
            }
            return IsCheck;
        }
    }
}