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
                        VaelgStandardSMS();     // Methode zu einem neuen switch damit man zwischen den 4 sachen wählen kann
                        break;

                    case 2:
                        Gui.VælgEMail();
                        break;

                    case 3:
                        Gui.VisKundeListe(repository.LoadKunder());
                        break;

                    default:
                        Gui.VisFejl();          //Geändert weil kein cw im controller
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
                        Chicken.TilføjSendSMS();
                        // Fåå omraadenr 
                        break;

                    

                    default:
                        Gui.VisFejl();
                        break;
                }
            }
        }






    }
}
