using EventGarden.Common.Concretes;
using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Interfaces
{
    public interface IEtkinlikService:IGenericService<EtkinlikListDTO,EtkinlikCreateDTO,EtkinlikUpdateDTO,Etkinlik>
    {
        Task<Response<List<EtkinlikListDTO>>> GetEtkinlikWithCategory();
    }
}
