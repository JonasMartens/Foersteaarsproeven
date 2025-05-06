using ProudChickenEksamen.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.View
{
    class GUI
    {        
        public int MainMenuMetode()
        {
            Console.WriteLine("Vælg Metode: Send SMS (1), Send Email (2), Vis Liste (3)");
            return int.Parse(Console.ReadLine());
        }
        public int VælgSMS()
        {
            Console.WriteLine("Vælg Sms: VelkomstSMS (1), Er i områdetSMS (2), FarvelSMS (3) eller CustomSMS (4).");
            string SMSUserInput = Console.ReadLine();
            return Convert.ToInt32(SMSUserInput);
        }
        public int VælgEMail()
        {
            Console.WriteLine("Vælg e-mail: VelkomstEmail (1), TilbudsEmail (2), FarvelEmail (3) eller CustomEmail (4).");
            string EMailUserInput = Console.ReadLine();
            return Convert.ToInt32(EMailUserInput);
        }

        public int VælgListeKriterie()
        {
            Console.WriteLine("Vælg mellem: OmrådeNr (1), By (2).");
            string KriterieUserInput = Console.ReadLine();
            return Convert.ToInt32(KriterieUserInput);
        }
        public string VælgOmrådeNummer()
        {
            Console.WriteLine("Vælg OmrådeNummer");
            string OmrådeNummer = Console.ReadLine();
            return OmrådeNummer;
        }






        public string CustomSMS()
        {
            Console.WriteLine("Input customSMS: ");
            string CustomUserInput = Console.ReadLine();
            return CustomUserInput;
        }

        public List<SMS> Print(List<SMS> nyListe)
        {
            Console.WriteLine(nyListe[0].SMSStandardBesked);
            nyListe.RemoveAt(0);
            return nyListe;
        }


        public List<Kunde> VisKundeListe(List<Kunde>kunder)
        {
            Console.WriteLine("1 = VelkomstSMS, 2 = TilbudsSMS 3 = FarvelSMS 4 = CustomSMS");
            int i = 0;
            while (i < kunder.Count)
            {
                Console.WriteLine($"\nID: {kunder[i].Id}, navn: {kunder[i].navn}, adresse: {kunder[i].Adresse}, områdenr: {kunder[i].OmrådeNr}, " +
                    $"by: {kunder[i].By}, mobilnr: {kunder[i].MobilNr}, email: {kunder[i].EMail}");
                int j = 0;

                while (j < kunder[i].SendtSMS.Count)
                {
                    Console.Write($" {kunder[i].SendtSMS[j]}, ");
                    j++;
                }
                i++;                
                Console.WriteLine(" ");
            }
            return kunder;
        }
        public void VisFejl()
        {
            Console.WriteLine("Ugyldigt valg");
        }






        public void VisListeOverSMSOgKriterie(List<SMS> StandardSMSBesked)
        {
            int i = 0;

            while (i < StandardSMSBesked.Count)
            {
                Console.WriteLine(StandardSMSBesked[i]);
                i++;
            }
        }
    }
}
