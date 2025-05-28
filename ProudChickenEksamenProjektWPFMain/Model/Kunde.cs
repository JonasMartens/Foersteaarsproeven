using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class Kunde
    {     
        public int id { get; set; }
        public string navn { get; set; }
        public string vejadresseringsnavn { get; set; }
        public string OmrådeNr { get; set; }
        public string myndighedsnavn { get; set; }
        public string mobilnummer { get; set; }
        public string email { get; set; }
        public List<string> SendtSMS { get; set; }
        public List<string> SendtSMSDato { get; set; }
        public List<string> SendtEmail { get; set; }
        public List<string> SendtEmailDato { get; set; }
    }
}
