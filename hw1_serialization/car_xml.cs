using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace hw1_serialization
{
    [XmlRoot("Producion")]
    public class car_xml
    {
        [XmlAttribute("CarNo")]
        public string number { get; set; }

        [XmlAttribute("CarName")]
        public string name { get; set; }

        [XmlArrayItem("NumbCar")]

        public List<car_xml> Cars = new List<car_xml>();

        [XmlElement]
        public CarOwner Owner;

        public car_xml()
        {

        }
    }

    public class CarOwner
    {
        public string Person { get; set; }
    }
}
