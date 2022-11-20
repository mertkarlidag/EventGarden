using AutoMapper;
using EventGarden.BLL.Interfaces;
using EventGarden.Common.Concretes;
using EventGarden.Common.Interfaces;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.AppUserDTO;
using EventGarden.DTOs.BasketEventDTO;
using EventGarden.Entities.Entitity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.Concretes
{
    public class MemberService:IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly IuOW _uOW;
        private readonly IMapper _mapper;

        public MemberService(UserManager<AppUser> userManager, IuOW uOW, SignInManager<AppUser> signManager, IMapper mapper)
        {
            _userManager = userManager;
            _uOW = uOW;
            _signManager = signManager;
            _mapper = mapper;
        }

        public async Task<IResponse> Create(AppUserCreateDTO dto)
        {
            
            AppUser user = new AppUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                Surname = dto.Surname,
                Name = dto.Name
            };
           var identityResult= await _userManager.CreateAsync(user,dto.Password);
           await  _uOW.SaveChangesAsync();
            await _userManager.AddToRoleAsync(user, "Member");
            await _uOW.SaveChangesAsync();

            if (identityResult.Succeeded)
            {
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.ValidationError, "Kullanıcı Kaydı Yapılamadı");
        

        }
        public async Task<IResponse> Login(AppUserLoginDTO dto)
        {
          var appUser=await _userManager.FindByNameAsync(dto.UserName);
          var result  = await _signManager.PasswordSignInAsync(appUser,dto.Password,false,false);
            if (!result.Succeeded)
            {
                return new Response(ResponseType.NotFound, "Kullancı Adı veya Parola Hatalı");
            }
            return new Response(ResponseType.Success);
            
        }
        public async Task Logout()
        {
           await _signManager.SignOutAsync();
        }
        public async Task<int> GetUserId(string userName)
        {
          var appuser=await  _userManager.FindByNameAsync(userName);
            return appuser.Id;
        }
        public  List<BasketEventListDTO> GetAllBasketEvents(int id)
        {
            var query =  _uOW.GetRepository<BasketEvent>().GetQuery();
          var dto=  query.Include(x => x.Etkinlik).Where(x => x.AppUserId == id).ToList();
          var dtoList=  _mapper.Map<List<BasketEventListDTO>>(dto);
            
            return dtoList;
        }
        

    }
}
