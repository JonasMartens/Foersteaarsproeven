using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class SMS
    {
        public int ID { get; set; }
        public string Dato { get; set; }
        public string SMSStandardBesked { get; set; }
        public string Custom { get; set; }


        public List<SMS> StandardSMSBesked = new List<SMS>();
        public SMS()
        {
            SMS sms1 = new SMS() { ID = 1, SMSStandardBesked = "Velkommen til Proud Chicken" };
            
            StandardSMSBesked.Add(sms1 ); 
        }
    }
}
        
