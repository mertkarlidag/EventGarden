using AutoMapper;
using EventGarden.DTOs.BasketEventDTO;
using EventGarden.DTOs.CategoryDTOs;
using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Etkinlik, EtkinlikCreateDTO>().ReverseMap();
            CreateMap<Etkinlik, EtkinlikUpdateDTO>().ReverseMap();
            CreateMap<Etkinlik, EtkinlikListDTO>().ReverseMap();

            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<BasketEvent, BasketEventCreateDTO>().ReverseMap();
            CreateMap<BasketEvent, BasketEventListDTO>().ReverseMap();



        }
    }
}
