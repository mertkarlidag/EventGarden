using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.Entities.Entitity
{
    public class BasketEvent:BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
       public int EtkinlikId { get; set; }
        public Etkinlik Etkinlik { get; set; }
    }
}
