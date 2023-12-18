using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebApp.Data;
using NewWebApp.Migrations;
using NewWebApp.Models;
using NewWebApp.Models.Domain;
using System.Diagnostics;

namespace NewWebApp.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly IWebHostEnvironment _webHost;
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public HomeController(MVCDemoDbContext mvcDemoDbContext, IWebHostEnvironment webHost)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
            _webHost = webHost;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fileMetadatas = await mvcDemoDbContext.FileMetadatas.ToListAsync();
            return View(fileMetadatas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FileMetadata fileMetadata, IFormFile file)
        {
            string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            fileMetadata.FileName = Path.GetFileName(file.FileName);
            fileMetadata.FilePath = Path.Combine(uploadFolder, fileMetadata.FileName);

            using (FileStream stream = new FileStream(fileMetadata.FilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //// Сохранение метаданных в базе данных
            await mvcDemoDbContext.FileMetadatas.AddAsync(fileMetadata);
            await mvcDemoDbContext.SaveChangesAsync();
            ViewBag.Message = $"{fileMetadata.FileName} успешно загружен.";
            //return redirecttoaction("index");

            return View();
        }


        //download
        public IActionResult FileList()
        {
            var fileMetadatas = mvcDemoDbContext.FileMetadatas.ToList();
            return View(fileMetadatas);
        }

        public IActionResult Download(string fileName)
        {
            if (fileName == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_webHost.WebRootPath, "uploads", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), Path.GetFileName(filePath));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
    {
        { ".txt", "text/plain" },
        { ".pdf", "application/pdf" },
        { ".doc", "application/vnd.ms-word" },
        { ".docx", "application/vnd.ms-word" },
        // Добавьте другие типы файлов по необходимости
    };
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}