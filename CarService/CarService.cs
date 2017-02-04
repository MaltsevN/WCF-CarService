using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Xml.Linq;
using System.Globalization;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarService" in both code and config file together.
    public class CarService : ICarService
    {
        public Car GetCar(int id)
        {
            var file = ConfigurationManager.AppSettings["fileCar"];
            var doc = XDocument.Load(file);
            Car result;
 

            var element = doc.Descendants("Car").FirstOrDefault(x => x.Attribute("Id").Value == id.ToString());


            var type = element.Attribute("Type").Value;
            switch (type)
            {
                case "Truck":
                    result = new TruckCar();
                    ((TruckCar)result).Capacity = double.Parse(element.Element("Capacity").Value, CultureInfo.GetCultureInfo("en-US"));
                    break;
                case "Passenger":
                    result = new PassengerCar();
                    ((PassengerCar)result).Passengers = int.Parse(element.Element("Passengers").Value, CultureInfo.GetCultureInfo("en-US"));
                    break;
                default:
                    result = new Car();
                    break;
            }

            result.Id = int.Parse(element.Attribute("Id").Value);
            result.Vendor = element.Element("Vendor").Value;
            result.Model = element.Element("Model").Value;
            result.Year = int.Parse(element.Element("Year").Value);

            return result;
        }

        public void SetCar(Car c)
        {
            var file = ConfigurationManager.AppSettings["fileCar"];
            var doc = XDocument.Load(file);

            var element = new XElement("Car", new XAttribute("Id", c.Id), new XElement("Vendor", c.Vendor),
                                    new XElement("Model", c.Model), new XElement("Year", c.Year));

            if(c is TruckCar)
            {
                element.Add(new XAttribute("Type", "Truck"), new XElement("Capacity", ((TruckCar)c).Capacity.ToString(CultureInfo.GetCultureInfo("en-US"))));
            }
            else
            {
                element.Add(new XAttribute("Type", "Passenger"), new XElement("Passengers", ((PassengerCar)c).Passengers.ToString(CultureInfo.GetCultureInfo("en-US"))));
            }
            doc.Root.Add(element);
            doc.Save(file);
        }
    }
}
