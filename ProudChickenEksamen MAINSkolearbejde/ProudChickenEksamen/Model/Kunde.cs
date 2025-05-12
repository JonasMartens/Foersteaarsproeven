using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class Kunde
    {
        public int Id { get; set; }
        public string navn { get; set; }
        public string Adresse { get; set; }
        public string OmrådeNr { get; set; }
        public string By { get; set; }
        public string MobilNr { get; set; }
        public string EMail { get; set; }
        public List<string> SendtSMS { get; set; }
        public List<string> SendtSMSDato { get; set; }
        public List<string> SendtEmail { get; set; }
        public List<string> SendtEmailDato { get; set; }
    }
}
