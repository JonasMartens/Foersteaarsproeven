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
                        SMSValgOgKriterieValg();
                        break;

                    case 2:
                        EmailValgOgKriterieValg();
                        break;

                    case 3:
                        SøgefunktionValgKriterier();
                        break;

                    default:
                        Gui.VisFejl();
                        break;
                }
            }
        }

        public void SøgefunktionValgKriterier()
        {
            int søgeKriterieValg = Gui.SøgIKundeListeUdFraKriterier();

            switch (søgeKriterieValg)
            {

                case 1:
                    Gui.VælgOmrådeNummer();
                    break;

                case 2:
                    Gui.VælgBy();
                    break;

                case 3:
                    Chicken.TestMetodeTilTid(Gui.StartDatoMetode(), Gui.SlutDatoMetode());
                    break;

                case 4:
                    Gui.VælgID();
                    break;

                case 5:
                    Gui.VælgSMS();
                    break;

                case 6:
                    Gui.VælgEMail();
                    break;

                default:
                    Gui.VisFejl();
                    break;
            }
        }

        public void SMSValgOgKriterieValg()
        {
            int kriterieValg = Gui.VælgListeKriterie();
            int smsValg = Gui.VælgSMS();
            Gui.Print(Chicken.SMSValgt(smsValg));
            
            switch (kriterieValg)
            {
                case 1:
                    Chicken.smsValgChicken(smsValg);
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
        public void EmailValgOgKriterieValg()
        {
            int kriterieValg = Gui.VælgListeKriterie();
            int EmailValg = Gui.VælgEMail();
            Gui.Print(Chicken.EmailValgt(EmailValg));
            switch (kriterieValg)
            {
                case 1:
                    string områdeNr = Gui.VælgOmrådeNummer();
                    List<Kunde> nuværendeKundeData = repository.LoadKunder();
                    List<Kunde> matchendeKunderOmrådeNr = Chicken.FindKunderOmrådeNr(områdeNr);
                    List<Kunde> opdateretKundeData = new List<Kunde>();
                    Gui.VisKundeListe(matchendeKunderOmrådeNr);
                    string bekræftelse = Gui.BekræftValgAfSMSEllerEmailOgKundeKriterie();

                    if (bekræftelse == "1")
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
                                kunde1.SendtEmail.Add(EmailValg.ToString());
                                kunde1.SendtEmailDato.Add(DateTime.Now.ToString("dd/MM yy"));

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
