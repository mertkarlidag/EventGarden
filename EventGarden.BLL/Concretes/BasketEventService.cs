using AutoMapper;
using EventGarden.BLL.Interfaces;
using EventGarden.Common.Concretes;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.BasketEventDTO;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Concretes
{
    public class BasketEventService:IBasketEventService
    {
        private readonly IuOW _uOW;
        private readonly IMapper _mapper;

        public BasketEventService(IuOW uOW, IMapper mapper)
        {
            _uOW = uOW;
            _mapper = mapper;
        }
        public async Task AddToBasket(BasketEventCreateDTO dto)
        {
           var query= _uOW.GetRepository<BasketEvent>().GetQuery();
          var check=  query.Where(x=>x.EtkinlikId==dto.EtkinlikId ).Where(x=>x.AppUserId==dto.AppUserId).FirstOrDefault();
            if (check==null)
            {
                var entity = _mapper.Map<BasketEvent>(dto);
                await _uOW.GetRepository<BasketEvent>().CreateAsync(entity);
                await _uOW.SaveChangesAsync();
            }

            

        }
    }
}
