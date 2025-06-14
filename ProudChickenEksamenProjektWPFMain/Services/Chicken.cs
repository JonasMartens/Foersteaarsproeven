﻿//using ProudChickenEksamen.Data;
//using ProudChickenEksamen.Model;
//using ProudChickenEksamen.View;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.SymbolStore;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProudChickenEksamen.Services
//{
//    class Chicken
//    {

//        public List<SMS> SMSList = new List<SMS>();
//        private List<SMS> nySMSListe = new List<SMS>();

//        public List<email> EmailList = new List<email>();
//        private List<email> nyEmailListe = new List<email>();

//        public IRepository repository;

//        GUI Gui = new GUI();

//        public Chicken(IRepository repository)
//        {
//            this.repository = repository;
//            SMS sms1 = new SMS() { ID = 1, SMSStandardBesked = "Velkommen til Proud Chickens SMS Service." };
//            SMS sms2 = new SMS() { ID = 2, SMSStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlige plads. \nVi ses snart." };
//            SMS sms3 = new SMS() { ID = 3, SMSStandardBesked = "Vi er kede af, at De ikke længere er medlem af Proud Chickens SMS Service." };
//            SMS sms4 = new SMS() { ID = 4, SMSStandardBesked = "brugerInput" };

//            SMSList.Add(sms1);
//            SMSList.Add(sms2);
//            SMSList.Add(sms3);
//            SMSList.Add(sms4);

//            email email1 = new email() { ID = 1, EmailStandardBesked = "Velkommen til Proud Chickens Email Service." };
//            email email2 = new email() { ID = 2, EmailStandardBesked = "Vores FoodTruck er netop nu på vej til sin sædvanlige plads. \nVi ses snart." };
//            email email3 = new email() { ID = 3, EmailStandardBesked = "Vi er kede af, at De ikke længere er medlem af Proud Chickens Email Service." };
//            email email4 = new email() { ID = 4, EmailStandardBesked = "brugerInput" };

//            EmailList.Add(email1);
//            EmailList.Add(email2);
//            EmailList.Add(email3);
//            EmailList.Add(email4);
//        }

//        public List<SMS> SMSValgt(int smsType)
//        {
//            nySMSListe.Clear(); 

//            switch (smsType)
//            {
//                case 1:
//                    nySMSListe.Add(SMSList[0]);
//                    break;

//                case 2:
//                    nySMSListe.Add(SMSList[1]);
//                    break;

//                case 3:
//                    nySMSListe.Add(SMSList[2]);
//                    break;

//                case 4: 
//                    string brugerInput = Gui.CustomSMS();
//                    SMSList[3].SMSStandardBesked = brugerInput;
//                    nySMSListe.Add(SMSList[3]);
//                    break;

//                default:
//                    break;
//            }
//            return nySMSListe;
//        }

//        public List<email> EmailValgt(int emailType)
//        {
//            nyEmailListe.Clear();

//            switch (emailType)
//            {
//                case 1:
//                    nyEmailListe.Add(EmailList[0]);
//                    break;

//                case 2:
//                    nyEmailListe.Add(EmailList[1]);
//                    break;

//                case 3:
//                    nyEmailListe.Add(EmailList[2]);
//                    break;

//                case 4:
//                    string brugerInput = Gui.CustomEmail();
//                    EmailList[3].EmailStandardBesked = brugerInput;
//                    nyEmailListe.Add(EmailList[3]);
//                    break;

//                default:
//                    break;
//            }
//            return nyEmailListe;
//        }

//        public List<Kunde> FindKunderOmrådeNr(string områdeNr)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<Kunde> matchendeKunder = new List<Kunde>();

//            int i = 0;
//            while (i < kundeliste.Count)
//            {
//                Kunde kunde = kundeliste[i];
//                if (kunde.OmrådeNr == områdeNr)
//                {
//                    matchendeKunder.Add(kunde);
//                }
//                i++;
//            }
//            return matchendeKunder;
//        }

//        public List<Kunde> FindKunderBy(string by)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<Kunde> matchendeKunder = new List<Kunde>();

//            int i = 0;
//            while (i < kundeliste.Count)
//            {
//                Kunde kunde = kundeliste[i];
//                if (kunde.myndighedsnavn == by)
//                {
//                    matchendeKunder.Add(kunde);
//                }
//                i++;
//            }
//            return matchendeKunder;
//        }

//        public List<Kunde> FindKunderID(int id)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<Kunde> matchendeKunder = new List<Kunde>();

//            int i = 0;
//            while (i < kundeliste.Count)
//            {
//                Kunde kunde = kundeliste[i];
//                if (kunde.id == id)
//                {
//                    matchendeKunder.Add(kunde);
//                }
//                i++;
//            }
//            return matchendeKunder;
//        }

//        public List<string> FindAntalKunderSendtSMS(int smsType)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<string> kundeModtogAntalSms = new List<string>();
//            string smsType1 = smsType.ToString();

//            int i = 0;
//            while (i < kundeliste.Count)
//            {
//                Kunde kunde = kundeliste[i];

//                int antalSms = 0;
//                int j = 0;
//                while (j < kunde.SendtSMS.Count)
//                {
//                    if (kunde.SendtSMS[j] == smsType1)
//                    {
//                        antalSms++;
//                    }
//                    j++;
//                }                
//                string kundeMedAntalString = "Kunde " + kunde.id + " har modtaget " + antalSms + " styk af type nr. " + smsType1;
//                kundeModtogAntalSms.Add(kundeMedAntalString);
//                i++;
//            }
//            return kundeModtogAntalSms;
//        }

//        public List<string> FindAntalKunderSendtEmail(int emailType)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<string> kundeModtogAntalEmail = new List<string>();
//            string emailType1 = emailType.ToString();

//            int i = 0;
//            while (i < kundeliste.Count)
//            {
//                Kunde kunde = kundeliste[i];

//                int antalEmail = 0;
//                int j = 0;
//                while (j < kunde.SendtSMS.Count)
//                {
//                    if (kunde.SendtSMS[j] == emailType1)
//                    {
//                        antalEmail++;
//                    }
//                    j++;
//                }
//                string kundeMedAntalString = "Kunde " + kunde.id + " har modtaget " + antalEmail + " styk af type nr. " + emailType1;
//                kundeModtogAntalEmail.Add(kundeMedAntalString);
//                i++;
//            }
//            return kundeModtogAntalEmail;
//        }

//        public void OmrådeNummerValg(int smsValg)
//        {
//            string v = "SELECT * FROM KontaktView WHERE myndighedsnavn = 'Aarhus'";
//            string områdeNr = Gui.VælgOmrådeNummer();
//            List<Kunde> nuværendeKundeData = repository.databaseConnection();
//            List<Kunde> matchendeKunderOmrådeNr = FindKunderOmrådeNr(områdeNr);
//            List<Kunde> opdateretKundeData = new List<Kunde>();
//            Gui.VisHeleKundeListenMedAlleInfo(matchendeKunderOmrådeNr);
//            string bekreftelse = Gui.BekræftValgAfSMSEllerEmailOgKundeKriterie();

//            if (bekreftelse == "1")
//            {
//                int i = 0;

//                while (i < nuværendeKundeData.Count)
//                {
//                    Kunde kunde = nuværendeKundeData[i];

//                    Kunde kunde1 = matchendeKunderOmrådeNr.Find(x => x.id == kunde.id);

//                    if (kunde1 == null)
//                    {
//                        opdateretKundeData.Add(kunde);
//                    }
//                    else
//                    {
//                        kunde1.SendtSMS.Add(smsValg.ToString());
//                        kunde1.SendtSMSDato.Add(DateTime.Now.ToString("dd-MM yy"));

//                        opdateretKundeData.Add(kunde1);
//                    }
//                    i++;
//                }
//                repository.SaveKunder(opdateretKundeData);
//            }
//            else
//            {
//                Gui.AfvisBekræft();
//            }
//        }

//        public void ByNavnValg(int a)
//        {
//            string områdeNr = Gui.VælgOmrådeNummer();
//            List<Kunde> nuværendeKundeData = repository.LoadKunder();
//            List<Kunde> matchendeKunderOmrådeNr = FindKunderOmrådeNr(områdeNr);
//            List<Kunde> opdateretKundeData = new List<Kunde>();
//            Gui.VisHeleKundeListenMedAlleInfo(matchendeKunderOmrådeNr);
//            string bekræftelse = Gui.BekræftValgAfSMSEllerEmailOgKundeKriterie();

//            if (bekræftelse == "1")
//            {
//                int i = 0;

//                while (i < nuværendeKundeData.Count)
//                {
//                    Kunde kunde = nuværendeKundeData[i];

//                    Kunde kunde1 = matchendeKunderOmrådeNr.Find(x => x.id == kunde.id);

//                    if (kunde1 == null)
//                    {
//                        opdateretKundeData.Add(kunde);
//                    }
//                    else
//                    {
//                        kunde1.SendtEmail.Add(a.ToString());
//                        kunde1.SendtEmailDato.Add(DateTime.Now.ToString("dd-MM yy"));

//                        opdateretKundeData.Add(kunde1);
//                    }

//                    i++;
//                }
//                repository.SaveKunder(opdateretKundeData);
//            }
//            else
//            {
//                Gui.AfvisBekræft();
//            }
//        }

//        public List<(DateTime, string, int)> FiltrerEfterSMSDato(string b, string c)
//        {          
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<(DateTime, string, int)> matchendeBesked = new List<(DateTime, string, int)>();
//            DateTime fra = DateTime.ParseExact(b, "dd-MM yy", CultureInfo.InvariantCulture);
//            DateTime til = DateTime.ParseExact(c, "dd-MM yy", CultureInfo.InvariantCulture);

//            foreach (Kunde k in kundeliste)
//            {
                 

//                for (int i = 0; i < k.SendtSMSDato.Count; i++)
//                {
//                    DateTime dato = DateTime.ParseExact(k.SendtSMSDato[i], "dd-MM yy", CultureInfo.InvariantCulture);

//                    if (dato >= fra && dato <= til)
//                    {
//                        string nummerType = i < k.SendtSMS.Count ? k.SendtSMS[i] : "Ukendt";
//                        matchendeBesked.Add((dato, nummerType, k.id));
//                    }
//                }
//            }
//            return matchendeBesked;
//        }

//        public List<(DateTime, string, int)> FiltrerEfterEmailDato(string b, string c)
//        {
//            List<Kunde> kundeliste = repository.LoadKunder();
//            List<(DateTime, string, int)> matchendeBesked = new List<(DateTime, string, int)>();
//            DateTime fra = DateTime.ParseExact(b, "dd-MM yy", CultureInfo.InvariantCulture);
//            DateTime til = DateTime.ParseExact(c, "dd-MM yy", CultureInfo.InvariantCulture);

//            foreach (Kunde k in kundeliste)
//            {
                

//                for (int i = 0; i < k.SendtEmailDato.Count; i++)
//                {
//                    DateTime dato = DateTime.ParseExact(k.SendtEmailDato[i], "dd-MM yy", CultureInfo.InvariantCulture);

//                    if (dato >= fra && dato <= til)
//                    {
//                        string nummerType = i < k.SendtEmail.Count ? k.SendtEmail[i] : "Ukendt";
//                        matchendeBesked.Add((dato, nummerType, k.id));
//                    }
//                }
//            }
//            return matchendeBesked;
//        }
//        public void ForbindelseTilSQLRepository(int a)
//        {
//             repository.Insert(a);            
//        }
//    }
//}
