using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model.Entities
{
    class SMS
    {
        public int ID { get; set; }
        public string Dato { get; set; }
        public string SMSStandardBesked { get; set; }
        public string Custom { get; set; }
        public string SMSDato { get; set; }
    }
}

