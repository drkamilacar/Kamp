using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    class Order
    {
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int GamerId { get; set; }
        public int CampaignId { get; set; }
        public float Discount { get; set; }
        public float SalePrice { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
