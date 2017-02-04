using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarService
{   [DataContract]
    public class Car
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Vendor { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public int Year { get; set; }
    }
}
