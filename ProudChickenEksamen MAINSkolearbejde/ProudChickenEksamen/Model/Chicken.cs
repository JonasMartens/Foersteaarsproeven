using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Model
{
    class Chicken
    {
        Repository Repository = new Repository();
        Kunde Kunde = new Kunde();
        
        public void TilføjSendSMS()
        {
            List<Kunde> kunder = Repository.LoadKunder();

            //kunder.Add
            



        }

    }
}
