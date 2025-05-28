using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamenProjektWPFMain
{
    public class Person
    {
        public int Id { get; set; }
        public string Adresse { get; set; }

        public string OmrådeNR { get; set; }


        public string DisplayText => $"ID : {Id}, Adresse : {Adresse},  OmraadeNr : {OmrådeNR}";


    }
}
