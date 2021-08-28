using System;
using System.Collections.Generic;
using System.Text;

namespace GSP
{
    class Waygate
    {
        private Dictionary<String, String> values = new Dictionary<string, string>();

        public Waygate(string loc, string a, string b, string t, string o)
        {
            values.Add("Location", loc);
            values.Add("Alpha", a);
            values.Add("Beta", b);
            values.Add("Theta", t);
            values.Add("Omega", o);
        }
        public String getData(String type)
        {
            try
            {
                return values[type];
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public Dictionary<String, String> getAllData()
        {
            return values;
        }
    }
}
