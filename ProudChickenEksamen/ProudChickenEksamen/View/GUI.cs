using ProudChickenEksamen.Model;
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
            Console.WriteLine("Vælg Sms: 1, 2, 3 eller 4.");
            string SMSUserInput = Console.ReadLine();
            return Convert.ToInt32(SMSUserInput);
        }
        public int VælgEMail()
        {
            Console.WriteLine("Vælg e-mail: 1, 2, 3 eller 4.");
            string EMailUserInput = Console.ReadLine();
            return Convert.ToInt32(EMailUserInput);
        }

        public int VælgListeKriterie()
        {
            Console.WriteLine("Vælg mellem: OmrådeNr, By, 3, 4.");
            string KriterieUserInput = Console.ReadLine();
            return Convert.ToInt32(KriterieUserInput);
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
