using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using ProudChickenEksamen.Model.Entities;
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
            while (true)
            {
                int choice = Gui.VælgSMS();
                switch (choice)
                {
                    case 1:                       
                        Gui.Print(Chicken.TestMetode(choice));
                        Gui.VælgListeKriterie();
                        break;

                    case 2:
                        Gui.Print(Chicken.TestMetode(choice));
                        Gui.VælgListeKriterie();
                        break;

                    case 3:
                        Gui.Print(Chicken.TestMetode(choice));
                        Gui.VælgListeKriterie();
                        break;

                    case 4:
                        Gui.Print(Chicken.TestMetode(choice));
                        Gui.VælgListeKriterie();
                        break;


                    default:
                        Gui.VisFejl();
                        break;
                }
            }
        }
    }
}
