using EventGarden.BLL.Interfaces;
using EventGarden.DTOs.CategoryDTOs;
using EventGarden.DTOs.EtkinlikDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventGarden.PL.Controllers
{
    
    public class EtkinlikController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IEtkinlikService _etkinlikService;

        public EtkinlikController(ICategoryService categoryService, IEtkinlikService etkinlikService)
        {
            _categoryService = categoryService;
            _etkinlikService = etkinlikService;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //var response=  await _etkinlikService.GetAllAsync();
            var response = await _etkinlikService.GetEtkinlikWithCategory();
            return View(response.Data);
        }
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Create()
        {
          var categoryResponse=await  _categoryService.GetAllAsync();
            ViewBag.CategoryList = new SelectList(categoryResponse.Data, "Id","Name");
            return View(new EtkinlikCreateDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, EtkinlikCreateDTO dto)
        {
            var categoryResponse = await _categoryService.GetAllAsync();
            ViewBag.CategoryList = new SelectList(categoryResponse.Data, "Id", "Name");
            var filepath = this.GetImagePath(file);
            dto.ImagePath = filepath;
            if (User.IsInRole("Admin") == true)
            {
                dto.IsStatus = true;
            }
            else
            {
                dto.IsStatus = false;
            }
            
           


          
          var response=  await _etkinlikService.CreateAsync(dto);
            if (response.ResponseType==Common.Concretes.ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(dto);
            }
            if (User.IsInRole("Member"))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var categoryResponse = await _categoryService.GetAllAsync();
            ViewBag.CategoryList = new SelectList(categoryResponse.Data, "Id", "Name");
           var response= await _etkinlikService.GetByIdAsync<EtkinlikUpdateDTO>(id);
            if (response.Data!=null)
            {
                return View(response.Data);

            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Update(IFormFile file, EtkinlikUpdateDTO dto)
        {
            var categoryResponse = await _categoryService.GetAllAsync();
            ViewBag.CategoryList = new SelectList(categoryResponse.Data, "Id", "Name");
            var filepath = this.GetImagePath(file);
            dto.ImagePath = filepath;
            var response = await _etkinlikService.UpdateAsync(dto);
            if (response.ResponseType == Common.Concretes.ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(dto);
            }
            return RedirectToAction("Index", "Home");

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
          var response=  await _etkinlikService.RemoveAsync(id);
            if (response.ResponseType==Common.Concretes.ResponseType.NotFound)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> StateUpdate(int id)
        {
            var response = await _etkinlikService.GetByIdAsync<EtkinlikUpdateDTO>(id);
            if (response.Data!=null)
            {
                var dto = response.Data;
                if (dto.IsStatus == false)
                {
                    dto.IsStatus = true;
                    await _etkinlikService.UpdateAsync(dto);

                }
                else
                {
                    dto.IsStatus = false;
                    await _etkinlikService.UpdateAsync(dto);
                }
               

                return RedirectToAction("Index");
            }
            return NotFound();
        }





    }
}
