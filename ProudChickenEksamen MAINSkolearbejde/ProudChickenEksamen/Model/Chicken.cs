using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model.Entities;
using ProudChickenEksamen.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class Chicken
    {
        public List<SMS> SMSList = new List<SMS>();

        GUI gui = new GUI();

        public Chicken()
        {
            SMS sms1 = new SMS() { ID = 1, SMSStandardBesked = "Velkommen til Proud Chickens SMS Service." };
            SMS sms2 = new SMS() { ID = 2, SMSStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlig plads. Vi ses snart." };
            SMS sms3 = new SMS() { ID = 3, SMSStandardBesked = "Vi er kede af De ikke er medlem af Proud Chickens SMS Service." };
            SMS sms4 = new SMS() { ID = 4, SMSStandardBesked = "brugerInput" };

            SMSList.Add(sms1);
            SMSList.Add(sms2);
            SMSList.Add(sms3);
            SMSList.Add(sms4);
        }
        List<SMS> nyListe = new List<SMS>();

        public List<SMS> TestMetode(int a)      //lav til switch?
        {
            if (a == SMSList[0].ID)
            {
                nyListe.Add(SMSList[0]);
            }
            if (a == SMSList[1].ID)
            {
                nyListe.Add(SMSList[1]);
            }
            if (a == SMSList[2].ID)
            {
                nyListe.Add(SMSList[2]);
            }
            if (a == SMSList[3].ID)
            {
                string brugerInput = gui.CustomSMS();
                SMSList[3].SMSStandardBesked = brugerInput;
                nyListe.Add(SMSList[3]);
            }
            return nyListe;
        }






        //List<Kunde> valgtKriterie = new List<Kunde>();

        List<Kunde> kundeliste = new List<Kunde>();

        Repository repository = new Repository();
        public int VælgListeKriterie(int num)
        {
            kundeliste = repository.LoadKunder();
            if (num == 1)
            {
                int i = 0;
                int svar = 0;
                while (i < kundeliste.Count)
                {
                    if (kundeliste[i].OmrådeNr == gui.VælgOmrådeNummer())
                    {

                        svar++;

                    }                    
                    i++;                    
                }
                return svar;
            }
            else
            {
                return 0;
            }
        }
    }
}
