using EventGarden.BLL.Concretes;
using EventGarden.BLL.Interfaces;
using EventGarden.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace EventGarden.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
          var response=  await _categoryService.GetAllAsync();
            return View(response.Data);
        }
        public IActionResult Create()
        {
            return View(new CategoryCreateDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO dto)
        {
           var response= await _categoryService.CreateAsync(dto);
            if (response.ResponseType==Common.Concretes.ResponseType.ValidationError)
            {
                return View(dto);

            }
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Update(int id)
        {
          var response=  await _categoryService.GetByIdAsync<CategoryUpdateDTO>(id);
            if (response.Data!=null)
            {
                return View(response.Data);

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTO dto)
        {
          var response=  await _categoryService.UpdateAsync(dto);
            if (response.ResponseType==Common.Concretes.ResponseType.ValidationError)
            {
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.RemoveAsync(id);
            if (response.ResponseType==Common.Concretes.ResponseType.NotFound)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        
    }
}
