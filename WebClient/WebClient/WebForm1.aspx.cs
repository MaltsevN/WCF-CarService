using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.CarService;
using System.Globalization;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CarService.CarServiceClient _client = new CarService.CarServiceClient("BasicHttpBinding_ICarService");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.SelectedIndex = 0;
            }
        }

        protected void BtnSetCar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(TxtId.Text);
            var ven = TxtVendor.Text;
            var mod = TxtModel.Text;
            var year = int.Parse(TxtYear.Text);

            Car car;

            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    car = new TruckCar();
                    ((TruckCar)car).Capacity = double.Parse(txtcap.Text, CultureInfo.GetCultureInfo("en-US"));
                    break;
                case 1:
                    car = new PassengerCar();
                    ((PassengerCar)car).Passengers = int.Parse(txtpas.Text, CultureInfo.GetCultureInfo("en-US"));
                    break;
                default:
                    car = new Car();
                    break;
            }

            car.Id = id;
            car.Vendor = ven;
            car.Model = mod;
            car.Year = year;

            _client.SetCar(car);
        }

        protected void BtnGetCar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(TxtId.Text);

            var car = _client.GetCar(id);
            TxtId.Text = car.Id.ToString();
            TxtVendor.Text = car.Vendor;
            TxtModel.Text = car.Model;
            TxtYear.Text = car.Year.ToString() ;

            if(car is TruckCar)
            {
                txtcap.Text = ((TruckCar)car).Capacity.ToString(CultureInfo.GetCultureInfo("en-US"));
                DropDownList1.SelectedIndex = 0;
                trpas.Visible = false;
                trcap.Visible = true;
            }
            else
            {
                txtpas.Text = ((PassengerCar)car).Passengers.ToString(CultureInfo.GetCultureInfo("en-US"));
                DropDownList1.SelectedIndex = 1;
                trcap.Visible = false;
                trpas.Visible = true;
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch(DropDownList1.SelectedIndex)
            {
                case 0:
                    trpas.Visible = false;
                    trcap.Visible = true;
                    break;
                case 1:
                    trcap.Visible = false;
                    trpas.Visible = true;
                    break;
            }
        }
    }
}