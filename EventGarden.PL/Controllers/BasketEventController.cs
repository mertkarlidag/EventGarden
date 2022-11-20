using EventGarden.BLL.Concretes;
using EventGarden.BLL.Interfaces;
using EventGarden.DTOs.BasketEventDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventGarden.PL.Controllers
{
    public class BasketEventController : Controller
    {
        private readonly IBasketEventService _basketEventService;
        private readonly IMemberService _memberService;


        public BasketEventController(IBasketEventService basketEventService, IMemberService memberService)
        {
            _basketEventService = basketEventService;
            _memberService = memberService;
        }
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Add(int id)
        {
            var userName = User.Identity.Name;
             var userId= await  _memberService.GetUserId(userName);
             BasketEventCreateDTO dto = new() { AppUserId = userId, EtkinlikId = id };
             await _basketEventService.AddToBasket(dto);
             return RedirectToAction("Index","Home");
        }
        
    }
}
