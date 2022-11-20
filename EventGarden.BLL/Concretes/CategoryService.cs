using AutoMapper;
using EventGarden.BLL.Interfaces;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.CategoryDTOs;
using EventGarden.Entities.Entitity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Concretes
{
    public class CategoryService : GenericService<CategoryListDTO, CategoryCreateDTO, CategoryUpdateDTO, Category>,ICategoryService
    {
        public CategoryService(IMapper mapper, IValidator<CategoryCreateDTO> createValidator, IValidator<CategoryUpdateDTO> updateValidator, IuOW uOW) : base(mapper, createValidator, updateValidator, uOW)
        {
        }
    }
}
