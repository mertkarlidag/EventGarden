using AutoMapper;
using EventGarden.BLL.Extension;
using EventGarden.BLL.Interfaces;
using EventGarden.Common.Concretes;
using EventGarden.Common.Interfaces;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.Interfaces;
using EventGarden.Entities.Entitity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Concretes
{
    public class GenericService<ListDto,CreateDto,UpdateDto,T>:IGenericService<ListDto,CreateDto,UpdateDto,T>
         where T : BaseEntity
        where ListDto : class, IDTO, new()
        where UpdateDto : class, IUpdateDTO, new()
        where CreateDto : class, IDTO, new()
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createValidator;
        private readonly IValidator<UpdateDto> _updateValidator;
        private readonly IuOW _uOW;

        public GenericService(IMapper mapper, IValidator<CreateDto> createValidator, IValidator<UpdateDto> updateValidator, IuOW uOW)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uOW = uOW;
        }
        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uOW.GetRepository<T>().CreateAsync(createdEntity);
                await _uOW.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            return new Response<CreateDto>(ResponseType.ValidationError, dto, result.ConvertToCustomValidationError());

        }
        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var unchanged = await _uOW.GetRepository<T>().GetByIdAsync(dto.Id);
            if (unchanged!=null)
            {
                var result = _updateValidator.Validate(dto);
                if (result.IsValid)
                {

                    var entity = _mapper.Map<T>(dto);
                    _uOW.GetRepository<T>().Update(entity, unchanged);
                   await _uOW.SaveChangesAsync();
                    return new Response<UpdateDto>(ResponseType.Success,"Güncelleme İşlemi Başarılıdır");
                }
                return new Response<UpdateDto>(ResponseType.ValidationError, dto, result.ConvertToCustomValidationError());
            }
            return new Response<UpdateDto>(ResponseType.NotFound,String.Empty);

           
        }
        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
          var listEntity=  await _uOW.GetRepository<T>().GetAllAsync();
            var listDTO = _mapper.Map<List<ListDto>>(listEntity);
            return new Response<List<ListDto>>(ResponseType.Success, listDTO);

        }
        public async Task<IResponse<IDTO>> GetByIdAsync<IDTO>(int id)
        {
          var entity=  await _uOW.GetRepository<T>().GetByIdAsync(id);
            if (entity!=null)
            {
                var dto = _mapper.Map<IDTO>(entity);
                return new Response<IDTO>(ResponseType.Success, dto);
            }
            return new Response<IDTO>(ResponseType.NotFound, $"{id} Bulunamadı");
            
        }
        public async Task<IResponse> RemoveAsync(int id)
        {

            var entity = await _uOW.GetRepository<T>().GetByIdAsync(id);
            if (entity != null)
            {
                _uOW.GetRepository<T>().Remove(entity);
               await _uOW.SaveChangesAsync();
                return new Response(ResponseType.Success, $" {id}  Başarı ile silindi. ");
            }
            return new Response(ResponseType.NotFound, $" {id} Bulunamadı ");
        }
    }
}
