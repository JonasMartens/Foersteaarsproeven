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
                    default:
                        Console.WriteLine("Ugyldigt valg!");
                        break;
                }
            }

        }
    }
}
