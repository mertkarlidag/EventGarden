using EventGarden.DTOs.EtkinlikDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.BasketEventDTO
{
    public class BasketEventListDTO
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int EtkinlikId { get; set; }
        public EtkinlikListDTO Etkinlik { get; set; }
    }
}
