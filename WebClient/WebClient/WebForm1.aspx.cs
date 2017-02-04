using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CarService.CarServiceClient _client = new CarService.CarServiceClient("BasicHttpBinding_ICarService");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSetCar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(TxtId.Text);
            var ven = TxtVendor.Text;
            var mod = TxtModel.Text;
            var year = int.Parse(TxtYear.Text);

            _client.SetCar(new CarService.Car { Id = id, Vendor = ven, Model = mod, Year = year });
        }

        protected void BtnGetCar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(TxtId.Text);

            var car = _client.GetCar(id);
            TxtId.Text = car.Id.ToString();
            TxtVendor.Text = car.Vendor;
            TxtModel.Text = car.Model;
            TxtYear.Text = car.Year.ToString() ;

        }
    }
}