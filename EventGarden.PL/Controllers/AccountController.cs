using EventGarden.BLL.Interfaces;
using EventGarden.DTOs.AppUserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace EventGarden.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMemberService _memberService;

        public AccountController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult SignUp()
        {
            return View(new AppUserCreateDTO());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateDTO dTO)
        {
            if (ModelState.IsValid)
            {
                await _memberService.Create(dTO);
                return RedirectToAction("Index", "Home");

            }
            return View(dTO);

        }
        public IActionResult Login()
        {
            return View(new AppUserLoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _memberService.Login(dto);
                if (response.ResponseType == Common.Concretes.ResponseType.Success)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewBag.GirisMessage=response.Message;
                    return View();
                }
            }
            return View(dto);
          
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _memberService.Logout();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GetAllEvents()
        {
           var userName= User.Identity.Name;
            var userId =await _memberService.GetUserId(userName);
         var result=  _memberService.GetAllBasketEvents(userId);
            return View(result);
        }
    }
}
