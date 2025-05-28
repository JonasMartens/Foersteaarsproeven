using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class Kunde
    {     
        public int ID { get; set; }
        public string Navn { get; set; }
        public string VejAdresseringsNavn { get; set; }
        public string OmrådeNr { get; set; }
        public string MyndighedsNavn { get; set; }
        public string Mobilnummer { get; set; }
        public string Email { get; set; }
        public List<string> SendtSMS { get; set; }
        public List<string> SendtSMSDato { get; set; }
        public List<string> SendtEmail { get; set; }
        public List<string> SendtEmailDato { get; set; }
        public string DisplayText => $"ID : {ID}, Navn : {Navn}, By : {MyndighedsNavn},  OmrådeNr : {OmrådeNr}";

    }
}
