using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using ProudChickenEksamen.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Services
{
    class Chicken
    {
        public List<SMS> SMSList = new List<SMS>();
        private List<SMS> nySMSListe = new List<SMS>();

        public List<EMail> EmailList = new List<EMail>();
        private List<EMail> nyEmailListe = new List<EMail>();

        private Repository repository = new Repository();
        GUI Gui = new GUI();

        public Chicken()
        {
            SMS sms1 = new SMS() { ID = 1, SMSStandardBesked = "Velkommen til Proud Chickens SMS Service." };
            SMS sms2 = new SMS() { ID = 2, SMSStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlige plads. \nVi ses snart." };
            SMS sms3 = new SMS() { ID = 3, SMSStandardBesked = "Vi er kede af, at De ikke længere er medlem af Proud Chickens SMS Service." };
            SMS sms4 = new SMS() { ID = 4, SMSStandardBesked = "brugerInput" };

            SMSList.Add(sms1);
            SMSList.Add(sms2);
            SMSList.Add(sms3);
            SMSList.Add(sms4);

            EMail email1 = new EMail() { ID = 1, EmailStandardBesked = "Velkommen til Proud Chickens Email Service." };
            EMail email2 = new EMail() { ID = 2, EmailStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlige plads. \nVi ses snart." };
            EMail email3 = new EMail() { ID = 3, EmailStandardBesked = "Vi er kede af, at De ikke længere er medlem af Proud Chickens Email Service." };
            EMail email4 = new EMail() { ID = 4, EmailStandardBesked = "brugerInput" };

            EmailList.Add(email1);
            EmailList.Add(email2);
            EmailList.Add(email3);
            EmailList.Add(email4);
        }

        public List<SMS> SMSValgt(int smsType)
        {
            nySMSListe.Clear(); 

            switch (smsType)
            {
                case 1:
                    nySMSListe.Add(SMSList[0]);
                    break;

                case 2:
                    nySMSListe.Add(SMSList[1]);
                    break;

                case 3:
                    nySMSListe.Add(SMSList[2]);
                    break;

                case 4: 
                    string brugerInput = Gui.CustomSMS();
                    SMSList[3].SMSStandardBesked = brugerInput;
                    nySMSListe.Add(SMSList[3]);
                    break;

                default:
                    break;
            }
            return nySMSListe;
        }
        public List<EMail> EmailValgt(int emailType)
        {
            nyEmailListe.Clear();

            switch (emailType)
            {
                case 1:
                    nyEmailListe.Add(EmailList[0]);
                    break;

                case 2:
                    nyEmailListe.Add(EmailList[1]);
                    break;

                case 3:
                    nyEmailListe.Add(EmailList[2]);
                    break;

                case 4:
                    string brugerInput = Gui.CustomEmail();
                    EmailList[3].EmailStandardBesked = brugerInput;
                    nyEmailListe.Add(EmailList[3]);
                    break;

                default:
                    break;
            }
            return nyEmailListe;
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

        public void TestMetodeTilTid(string a, string b)
        {
            List<Kunde> kundeliste = repository.LoadKunder();

            DateTime fra = DateTime.ParseExact(a, "dd/MM yy", CultureInfo.InvariantCulture);
            DateTime til = DateTime.ParseExact(b, "dd/MM yy", CultureInfo.InvariantCulture);

            foreach (Kunde k in kundeliste)
            {
                List<(DateTime, string)> matchendeSMS = new List<(DateTime, string)>();

                for (int i = 0; i < k.SendtSMSDato.Count; i++)
                {
                    DateTime dato = DateTime.ParseExact(k.SendtSMSDato[i], "dd/MM yy", CultureInfo.InvariantCulture);

                    if (dato >= fra && dato <= til)
                    {
                        string smsNummer = i < k.SendtSMS.Count ? k.SendtSMS[i] : "Ukendt";
                        matchendeSMS.Add((dato, smsNummer));
                    }
                }

                if (matchendeSMS.Count > 0)
                {
                    Console.WriteLine("Kunde Id: " + k.Id);

                    foreach ((DateTime dato, string smsNummer) in matchendeSMS)
                    {
                        Console.WriteLine($"{dato:dd/MM yy} - SMS nummer: {smsNummer}");
                    }
                    Console.WriteLine("\n");
                }
            }
        }




        public void smsValgChicken(int smsValg)
        {
            string områdeNr = Gui.VælgOmrådeNummer();
            List<Kunde> nuværendeKundeData = repository.LoadKunder();
            List<Kunde> matchendeKunderOmrådeNr = FindKunderOmrådeNr(områdeNr);
            List<Kunde> opdateretKundeData = new List<Kunde>();
            Gui.VisKundeListe(matchendeKunderOmrådeNr);
            string bekreftelse = Gui.BekræftValgAfSMSEllerEmailOgKundeKriterie();

            if (bekreftelse == "1")
            {
                int i = 0;

                while (i < nuværendeKundeData.Count)
                {
                    Kunde kunde = nuværendeKundeData[i];

                    Kunde kunde1 = matchendeKunderOmrådeNr.Find(x => x.Id == kunde.Id);

                    if (kunde1 == null)
                    {
                        opdateretKundeData.Add(kunde);
                    }
                    else
                    {
                        kunde1.SendtSMS.Add(smsValg.ToString());
                        kunde1.SendtSMSDato.Add(DateTime.Now.ToString("dd/MM yy"));

                        opdateretKundeData.Add(kunde1);
                    }

                    i++;
                }
                repository.SaveKunder(opdateretKundeData);
            }
            else
            {
                Gui.VisFejl();
            }
        }



    }
}
