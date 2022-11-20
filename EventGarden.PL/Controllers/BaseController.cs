using Microsoft.AspNetCore.Mvc;

namespace EventGarden.PL.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public string GetImagePath(IFormFile file)
        {

            if (file != null)
            {
                var ext = Path.GetExtension(file.FileName);
                var pathImage = "/images/" + Guid.NewGuid() + ext;
                var path = Directory.GetCurrentDirectory() + "/wwwroot" + pathImage;
                FileStream stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                return pathImage;
            }
            return "Product Image is null";
        }
    }
}
