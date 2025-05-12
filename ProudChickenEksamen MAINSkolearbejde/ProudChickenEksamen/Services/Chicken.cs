using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using ProudChickenEksamen.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Services
{
    class Chicken
    {
        public List<SMS> SMSList = new List<SMS>();
        private List<SMS> nyListe = new List<SMS>();
        private Repository repository = new Repository();
        GUI gui = new GUI();

        public Chicken()
        {
            SMS sms1 = new SMS() { ID = 1, SMSStandardBesked = "Velkommen til Proud Chickens SMS Service." };
            SMS sms2 = new SMS() { ID = 2, SMSStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlig plads. Vi ses snart." };
            SMS sms3 = new SMS() { ID = 3, SMSStandardBesked = "Vi er kede af, at De ikke længere er medlem af Proud Chickens SMS Service." };
            SMS sms4 = new SMS() { ID = 4, SMSStandardBesked = "brugerInput" };

            SMSList.Add(sms1);
            SMSList.Add(sms2);
            SMSList.Add(sms3);
            SMSList.Add(sms4);
        }

        public List<SMS> TestMetode(int smsType)
        {
            nyListe.Clear(); 

            switch (smsType)
            {
                case 1: 
                    nyListe.Add(SMSList[0]);
                    break;

                case 2:
                    nyListe.Add(SMSList[1]);
                    break;

                case 3: 
                    nyListe.Add(SMSList[2]);
                    break;

                case 4: 
                    string brugerInput = gui.CustomSMS();
                    SMSList[3].SMSStandardBesked = brugerInput;
                    nyListe.Add(SMSList[3]);
                    break;

                default:
                    break;
            }

            return nyListe;
        }

        public List<Kunde> FindKunderOmrådeNr(string områdeNr)
        {
            List<Kunde> kundeliste = repository.LoadKunder();
            List<Kunde> matchendeKunder = new List<Kunde>();

            int i = 0;
            while (i < kundeliste.Count)
            {
                Kunde kunde = kundeliste[i];
                if (kunde.OmrådeNr == områdeNr)
                {
                    matchendeKunder.Add(kunde);
                }
                i++;
            }

            return matchendeKunder;
        }

        public List<Kunde> FindKunderBy(string by)
        {
            List<Kunde> kundeliste = repository.LoadKunder();
            List<Kunde> matchendeKunder = new List<Kunde>();

            int i = 0;
            while (i < kundeliste.Count)
            {
                Kunde kunde = kundeliste[i];
                if (kunde.By == by)
                {
                    matchendeKunder.Add(kunde);

                }
                i++;
            }

            return matchendeKunder;
        }


    }
}
