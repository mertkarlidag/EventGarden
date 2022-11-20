using EventGarden.DTOs.BasketEventDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Interfaces
{
    public interface IBasketEventService
    {
        Task AddToBasket(BasketEventCreateDTO dto);
    }
}
