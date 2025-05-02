using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model.Entities
{
    class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string OmrNr { get; set; }
        public string MobilNr { get; set; }
        public string EMail { get; set; }
        public int SMSID { get; set; }
        public int EMailID { get; set; }

    }
}
