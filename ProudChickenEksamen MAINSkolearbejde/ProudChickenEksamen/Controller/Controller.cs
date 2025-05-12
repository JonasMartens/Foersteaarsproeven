using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using ProudChickenEksamen.Services;
using ProudChickenEksamen.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Controller
{
    class Controller
    {
        Repository repository = new Repository();
        GUI Gui = new GUI();
        Chicken Chicken = new Chicken();
        public void Run()
        {
            while (true)
            {
                int choice = Gui.MainMenuMetode();

                switch (choice)
                {
                    case 1:
                        VaelgStandardSMS();
                        break;

                    case 2:
                        Gui.VælgEMail();
                        break;

                    case 3:
                        Gui.VisKundeListe(repository.LoadKunder());
                        break;

                    default:
                        Gui.VisFejl();
                        break;
                }
            }

        }
        public void VaelgStandardSMS()
        {
            int choice = Gui.VælgSMS();
            Gui.Print(Chicken.TestMetode(choice));
            HaandterKriterieValg();

        }

        public void HaandterKriterieValg()
        {
            int kriterieValg = Gui.VælgListeKriterie();
            int smsValg = Gui.VælgSMS();
            switch (kriterieValg)
            {
                case 1: 
                    string områdeNr = Gui.VælgOmrådeNummer();
                    List<Kunde> matchendeKunderOmrådeNr = Chicken.FindKunderOmrådeNr(områdeNr);
                    Gui.VisKundeListe(matchendeKunderOmrådeNr);
                    string bekreftelse = Gui.BekræftValgAfSMSOgKundeKriterie();
                    if (bekreftelse == "1")
                    {
                        int i = 0;
                        while (i < matchendeKunderOmrådeNr.Count)
                        {
                            Kunde kunde = matchendeKunderOmrådeNr[i];

                            kunde.SendtSMS.Add(smsValg.ToString());
                            kunde.SendtSMSDato.Add(DateTime.Now.ToString("d/M yy"));

                            i++;
                        }
                        repository.SaveKunder(matchendeKunderOmrådeNr);
                    }
                    else
                    {
                        Gui.VisFejl();
                    }
                    break;

                case 2: 
                    string by = Gui.VælgBy();
                    List<Kunde> matchendeKunderBy = Chicken.FindKunderBy(by);
                    Gui.VisKundeListe(matchendeKunderBy);

                    break;

                default:
                    Gui.VisFejl();
                    break;
            }
        }
    }
}
