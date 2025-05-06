using ProudChickenEksamen.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Vælg Sms: VelkomstSMS (1), Er i OmrådetSMS (2), FarvelSMS (3) eller CustomSMS (4).");
            int smsVALG = Convert.ToInt32(Console.ReadLine());
            return smsVALG;
        }

        

        public string VisKreterierne()
        {
            Console.WriteLine("Til hem vil du sende en besked? Du kan vælge mellem -> OmrNr");
            string userIn = Console.ReadLine();
            return userIn;
        }




        public int VælgEMail()
        {
            Console.WriteLine("Vælg e-mail: VelkomstEmail (1), Er I OmrådetMail (2), 3 eller CustomMail (4).");
            string EMailUserInput = Console.ReadLine();
            return Convert.ToInt32(EMailUserInput);
        }

       




        public int VælgListeKriterie()
        {
            Console.WriteLine("Vælg mellem: OmrådeNr (1), By, 3, 4.");
            string KriterieUserInput = Console.ReadLine();
            return Convert.ToInt32(KriterieUserInput);
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





        
        public void VisListeOverSMSOgKriterie(List<SMS> StandardSMSBesked)
        {
            int i = 0;

            while (i < StandardSMSBesked.Count)
            {
                Console.WriteLine(StandardSMSBesked[i]);
                i++;
            }
        }







        public void VisFejl()
        {
            Console.WriteLine("Ugyldigt valg");
        }


    }
}
