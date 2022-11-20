using EventGarden.DTOs.CategoryDTOs;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Interfaces
{
    public interface ICategoryService:IGenericService<CategoryListDTO,CategoryCreateDTO,CategoryUpdateDTO,Category>
    {
    }
}
