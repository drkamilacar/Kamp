using GameProject.Adapters;
using GameProject.Concrete;
using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GamerManager gamerManager = new GamerManager(new MernisServiceAdapter());
            
            //Oyuncu Kayıt
            Gamer gamer = new Gamer()
            {
                Id = 1,
                FirstName = "Kamil",
                LastName = "Acar",
                BirthDate = new DateTime(1972, 12, 13),
                NationalityId = "12345678901"
            };

            gamerManager.Add(gamer);


        }
    }
}
