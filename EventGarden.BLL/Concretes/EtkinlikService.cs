using AutoMapper;
using EventGarden.BLL.Interfaces;
using EventGarden.Common.Concretes;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.Entities.Entitity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Concretes
{
    public class EtkinlikService : GenericService<EtkinlikListDTO, EtkinlikCreateDTO, EtkinlikUpdateDTO, Etkinlik>,IEtkinlikService
    {
        private readonly IMapper _mapper;
        private readonly IuOW _uOW;
        public EtkinlikService(IMapper mapper, IValidator<EtkinlikCreateDTO> createValidator, IValidator<EtkinlikUpdateDTO> updateValidator, IuOW uOW) : base(mapper, createValidator, updateValidator, uOW)
        {
            _mapper = mapper;
            _uOW = uOW;
        }
        public async Task<Response<List<EtkinlikListDTO>>> GetEtkinlikWithCategory()
        {
           var query= _uOW.GetRepository<Etkinlik>().GetQuery();
           var entity= query.Include(x => x.Category).ToList();
            var dto = _mapper.Map<List<EtkinlikListDTO>>(entity);
            return new Response<List<EtkinlikListDTO>>(ResponseType.Success, dto);
        }
       
    }
}
