using EventGarden.BLL.Interfaces;
using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventGarden.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEtkinlikService _etkinlikService;

        public HomeController(ILogger<HomeController> logger, IEtkinlikService etkinlikService)
        {
            _logger = logger;
            _etkinlikService = etkinlikService;
        }

        public async Task<IActionResult> Index()
        {
            var entity = await _etkinlikService.GetAllAsync();
           var dtomodel= entity.Data.Where(x=>x.IsStatus==true).ToList();
         
            return View(dtomodel);
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}