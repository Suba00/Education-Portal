using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using NewWebApp.Data;
using NewWebApp.Models.Domain;

namespace NewWebApp.Controllers
{
    public class FileMetadataController : Controller
    {
        private readonly IWebHostEnvironment _webHost;

        public FileMetadataController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string fileName = Path.GetFileName(file.FileName);
            string fileSavePath = Path.Combine(uploadFolder, fileName);

            using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            
            }

            ViewBag.Message = fileName + "Yes";

            return View();
        }
    };
}
