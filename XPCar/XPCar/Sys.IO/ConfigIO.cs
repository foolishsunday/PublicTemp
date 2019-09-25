using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XPCar.Sys.IO
{
    public class ConfigIO
    {
        private XmlDocument _xmlDoc = new XmlDocument();
        private string _FilePath;

        public ConfigIO(string filePath)
        {
            _FilePath = filePath;
            _xmlDoc.Load(filePath);
        }

        public void Save()
        {
            _xmlDoc.Save(_FilePath);
        }

        public bool SetValue(string field, string key, string value)
        {
            try
            {
                XmlNode node = _xmlDoc.SelectSingleNode("/configuration/" + field + "/add[@key='" + key + "']");
                if (node == null) return false;

                XmlElement ele = (XmlElement)node;
                ele.SetAttribute("value", value);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetValue(string field, string key)
        {
            try
            {
                XmlNode node = _xmlDoc.SelectSingleNode("/configuration/" + field + "/add[@key='" + key + "']");
                if (node == null) return "";

                XmlElement ele = (XmlElement)node;

                return ele.Attributes["value"].Value;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
