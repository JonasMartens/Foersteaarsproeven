using ProudChickenEksamen.Data;
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
        public void Run()
        {
            while (true)
            {
                int choice = Gui.MainMenuMetode();

                switch (choice)
                {
                    case 1:
                        Gui.VælgSMS();
                        break;

                    case 2:
                        Gui.VælgEMail();
                        break;

                    case 3:
                        Gui.VisKundeListe(repository.LoadKunder());
                        break;

                    default:
                        Console.WriteLine("Ugyldigt valg!");
                        break;
                }
            }

        }
    }
}
