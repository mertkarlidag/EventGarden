using EventGarden.Common.Interfaces;
using EventGarden.DTOs.Interfaces;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Interfaces
{
    public interface IGenericService<ListDto, CreateDto, UpdateDto, T> 
        where T : BaseEntity
        where ListDto : class,IDTO,new()
        where UpdateDto:class,IUpdateDTO,new()
        where CreateDto:class,IDTO,new()
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<IDTO>> GetByIdAsync<IDTO>(int id);
        Task<IResponse> RemoveAsync(int id);
    }
}
