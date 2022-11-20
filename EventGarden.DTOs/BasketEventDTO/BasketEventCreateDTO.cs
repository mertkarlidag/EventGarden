using EventGarden.DTOs.AppUserDTO;
using EventGarden.DTOs.EtkinlikDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.BasketEventDTO
{
    public class BasketEventCreateDTO
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDTO AppUser { get; set; }
        public int EtkinlikId { get; set; }
        public EtkinlikListDTO Etkinlik { get; set; }
    }
}
