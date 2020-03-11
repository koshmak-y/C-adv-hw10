using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw2_serialization
{
    [Serializable]
    public class Font
    {
        [XmlAttribute]
        public string fontName;
        [XmlAttribute]
        public int fontSize;

        public Font() { }
        /*public Font(string fn, int fs)
        {
            this.fontName = fn;
            this.fontSize = fs;
        }*/
    }
}
