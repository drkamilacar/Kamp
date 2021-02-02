using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    public class GamerManager : IGamerService
    {
        IGamerCheckService _gamerCheckService;

        public GamerManager(IGamerCheckService gamerCheckService)
        {
            _gamerCheckService = gamerCheckService;
        }
        public void Add(Gamer gamer)
        {
            if (_gamerCheckService.CheckIfRealPerson(gamer))
            {
                Console.WriteLine("Oyuncu eklendi : " + gamer.FirstName);
            }
            else
            {
                Console.WriteLine("Doğrulama başarısız ! Kayıt yapılamadı.");
            }
        }

        public void Delete(Gamer gamer)
        {
            Console.WriteLine("Oyuncu silindi : " + gamer.FirstName);
        }

        public void Update(Gamer gamer)
        {
            Console.WriteLine("Oyuncu güncellendi : " + gamer.FirstName);
        }
    }
}
