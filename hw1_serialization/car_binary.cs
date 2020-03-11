using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1_serialization
{
    [Serializable]
    class car_binary
    {
        public string number { get; set; }
        public string name { get; set; }
        
        public car_binary(string number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}
