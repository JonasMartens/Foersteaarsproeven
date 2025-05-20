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
    class SQLController
    {
        GUI Gui;
        Chicken Chicken;
        public SQLController(IRepository rep)
        {            
             Gui = new GUI();
             Chicken = new Chicken(rep);
        }
        public void Run()
        {
            while (true)
            {
                int choice = Gui.MainMenuMetode();

                switch (choice)
                {
                    case 1:
                        Chicken.ForbindelseTilSQLRepository();                
                        break;

                    case 2:
                        //IRepository.insert();
                        break;

                    case 3:
                        SøgefunktionValgKriterier();
                        break;

                    case 404:
                        Gui.VisFejl();
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
                    List<Kunde> matchendOmrådernr = Chicken.FindKunderOmrådeNr(Gui.VælgOmrådeNummer());
                    Gui.VisKunderFraOmrådeNr(matchendOmrådernr);
                    break;

                case 2:
                    List<Kunde> matchendeBy = Chicken.FindKunderBy(Gui.VælgBy());
                    Gui.VisKunderFraBy(matchendeBy);
                    break;

                case 3:
                    int a = Gui.VælgSMSEllerEmail();
                    if (a == 1)
                    {
                        Gui.FilterSMS(Chicken.FiltrerEfterSMSDato(Gui.VælgStartDato(), Gui.VælgSlutDato()));
                    }
                    else if  (a == 2)
                    {
                        Gui.FilterEmail(Chicken.FiltrerEfterEmailDato(Gui.VælgStartDato(), Gui.VælgSlutDato()));
                    }
                    else
                    {
                        Gui.VisFejl();                        
                    }
                    break;

                case 4:
                    List<Kunde> matchendeId = Chicken.FindKunderID(Gui.VælgID());
                    Gui.VisKunderFraID(matchendeId);
                    break;

                case 5:
                    List<string> matchendeSMSTyper = Chicken.FindAntalKunderSendtSMS(Gui.VælgSMS());
                    Gui.VisAntalSendtSMS(matchendeSMSTyper);
                    break;

                case 6:
                    List<string> matchendeEmailTyper = Chicken.FindAntalKunderSendtEmail(Gui.VælgEMail());
                    Gui.VisAntalSendtEmail(matchendeEmailTyper);
                    break;

                default:
                    Gui.VisFejl();
                    break;
            }
        }

        public void SMSValgOgKriterieValg()
        {
            int kriterieValg = Gui.VælgListeFraOmrådeNrEllerBy();
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
                    Gui.VisHeleKundeListenMedAlleInfo(matchendeKunderBy);

                    break;

                default:
                    Gui.VisFejl();
                    break;
            }
        }

        public void EmailValgOgKriterieValg()
        {
            int kriterieValg = Gui.VælgListeFraOmrådeNrEllerBy();
            int EmailValg = Gui.VælgEMail();
            Gui.Print(Chicken.EmailValgt(EmailValg));
            switch (kriterieValg)
            {
                case 1:
                    Chicken.EmailValgChicken(EmailValg);
                    break;

                case 2:
                    string by = Gui.VælgBy();
                    List<Kunde> matchendeKunderBy = Chicken.FindKunderBy(by);
                    Gui.VisHeleKundeListenMedAlleInfo(matchendeKunderBy);
                    break;

                default:
                    Gui.VisFejl();
                    break;
            }
        }
    }
}