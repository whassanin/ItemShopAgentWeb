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
    public partial class DeliveryPage : System.Web.UI.Page
    {
        static CustomerAgent _pb = new CustomerAgent();
        static CustomerAgent _pmb = new CustomerAgent();
        static DataTable countryDT = new DataTable();
        static DataTable cityDT = new DataTable();
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

                    if (Session["ProfileMonitor"] != null)
                    {
                        _pmb = (CustomerAgent)Session["ProfileMonitor"];
                    }
                    else
                    {
                        _pmb = new CustomerAgent();
                        Session["ProfileMonitor"] = _pmb;
                    }
                    
                    GetCountries();
                    GetCities(int.Parse(CountryDDL.Text.ToString()));

                    _pmb._CustomerId = _pb._CustomerId;
                    _pmb._Flag = "C";
                    _pmb._Top = 1;
                    _pmb._PageSize = 1000;
                    _pmb.Execute("SelectCustomer_AddressByCustomerIdCapability");
                    if (_pmb.Success != null)
                    {
                        DataTable addressDT = (DataTable)_pmb.Success;
                        if (addressDT.Rows.Count > 0)
                        {
                            AddressGV.DataSource = addressDT;
                            AddressGV.DataBind();
                        }
                        else
                        {
                            addresstable.Visible = true;
                            Addbtn.Visible = false;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            if (addresstable.Visible == false)
            {
                addresstable.Visible = true;   
            }
            else if (addresstable.Visible == true)
            {
                   addresstable.Visible = false;   
            }
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                _pmb.Execute("SelectMaxIdCustomer_AddressCapability");
                if (_pmb.Success != null)
                {
                    _pmb._Id = int.Parse(_pmb.Success.ToString());
                    _pmb._Number = int.Parse(numbertxt.Text);
                    _pmb._Street = streettxt.Text.TrimEnd();
                    _pmb._District = int.Parse(Districttxt.Text);
                    ListItem countryItem = CountryDDL.SelectedItem;
                    _pmb._Country = countryItem.Text.TrimEnd();
                    ListItem cityItem = CityDDL.SelectedItem;
                    _pmb._City = cityItem.Text;
                    _pmb._ZipCode = int.Parse(ZipCode.Text);

                    _pmb.Execute("InsertCustomer_AddressCapability");
                    if (_pmb.Success != null)
                    {
                        bool v = bool.Parse(_pmb.Success.ToString());
                        if (v == true)
                        {
                            Save();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void AddressGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    //_pmb._Id = int.Parse(AddressGV.Rows[index].Cells[0].Text);
                    _pmb._Number = int.Parse(AddressGV.Rows[index].Cells[1].Text);
                    _pmb._Street = AddressGV.Rows[index].Cells[2].Text.TrimEnd();
                    _pmb._District = int.Parse(AddressGV.Rows[index].Cells[3].Text);
                    _pmb._Country = AddressGV.Rows[index].Cells[4].Text.TrimEnd();
                    _pmb._City = AddressGV.Rows[index].Cells[5].Text.TrimEnd();
                    _pmb._ZipCode = int.Parse(AddressGV.Rows[index].Cells[6].Text);
                    Save();
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        protected void CountryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCities(int.Parse(CountryDDL.Text));
            }
            catch (Exception)
            {

            }
        }
        private void Save()
        {
            Session["ProfileMonitor"] = _pmb;
            Session["PurchaseBroker"] = _pb;
            Response.Redirect("~/Pages/PurchaseOrder/ConfirmOrderPage.aspx");
        }

        private void GetCountries()
        {
            try
            {
                if (countryDT.Columns.Count == 0)
                {
                    countryDT.Columns.Add("Id", typeof(int));
                    countryDT.Columns.Add("Name", typeof(string));
                }

                if (cityDT.Columns.Count == 0)
                {
                    cityDT.Columns.Add("Id", typeof(int));
                    cityDT.Columns.Add("Name", typeof(string));
                    cityDT.Columns.Add("CountryId", typeof(int));
                }

                if (countryDT.Rows.Count == 0)
                {
                    countryDT.Rows.Add(1, "Egypt");
                    countryDT.Rows.Add(2, "Spain");
                    countryDT.Rows.Add(3, "United Arab Emirates");
                    countryDT.Rows.Add(4, "United States");
                }

                CountryDDL.DataSource = countryDT;
                CountryDDL.DataValueField = "Id";
                CountryDDL.DataTextField = "Name";
                CountryDDL.DataBind();

                if (cityDT.Rows.Count == 0)
                {
                    cityDT.Rows.Add(1, "Cairo", 1);
                    cityDT.Rows.Add(2, "Alexandria", 1);
                    cityDT.Rows.Add(3, "Giza", 1);
                    cityDT.Rows.Add(4, "Port Said", 1);

                    cityDT.Rows.Add(5, "Madrid", 2);
                    cityDT.Rows.Add(6, "Barcelona", 2);
                    cityDT.Rows.Add(7, "Sevilla", 2);
                    cityDT.Rows.Add(8, "Murcia", 2);

                    cityDT.Rows.Add(9, "Dubai", 3);
                    cityDT.Rows.Add(10, "Abu Dhabi", 3);
                    cityDT.Rows.Add(11, "Sharjah", 3);
                    cityDT.Rows.Add(12, "Ras al-Khaimah", 3);

                    cityDT.Rows.Add(13, "New York", 4);
                    cityDT.Rows.Add(14, "Los Angeles", 4);
                    cityDT.Rows.Add(15, "San Diego", 4);
                    cityDT.Rows.Add(16, "Las Vegas", 4);
                }
            }
            catch (Exception)
            {

            }
        }

        private void GetCities(int countryId)
        {
            try
            {
                DataRow[] rows = cityDT.Select("CountryId = " + countryId);
                DataTable temp = new DataTable();


                temp.Columns.Add("Id", typeof(int));
                temp.Columns.Add("Name", typeof(string));
                temp.Columns.Add("CountryId", typeof(int));

                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow newrow = temp.NewRow();
                    newrow["Id"] = rows[i]["Id"];
                    newrow["Name"] = rows[i]["Name"];
                    newrow["CountryId"] = rows[i]["CountryId"];
                    temp.Rows.Add(newrow);
                }

                CityDDL.DataSource = temp;
                CityDDL.DataTextField = "Name";
                CityDDL.DataValueField = "Id";
                CityDDL.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DeliveryMethod/DeliveryMethodPage.aspx");
        }

    }
}