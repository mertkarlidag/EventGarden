using EventGarden.Common.Interfaces;
using EventGarden.DTOs.AppUserDTO;
using EventGarden.DTOs.BasketEventDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Interfaces
{
    public interface IMemberService
    {
        Task<IResponse> Create(AppUserCreateDTO dto);
        Task<IResponse> Login(AppUserLoginDTO dto);
        Task Logout();
        Task<int> GetUserId(string userName);
        List<BasketEventListDTO> GetAllBasketEvents(int id);
    }
}
