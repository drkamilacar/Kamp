using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Adapters
{
    public class MernisServiceAdapter : IGamerCheckService
    {
        public bool CheckIfRealPerson(Gamer gamer)
        {
            if (gamer.FirstName=="Kamil" && gamer.LastName == "Acar")
            {
                return true;
            }
            else
            {
                return false;
                            }
        }
    }
}
