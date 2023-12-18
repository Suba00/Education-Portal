using Microsoft.AspNetCore.Mvc;
using NewWebApp.Data;
using NewWebApp.Models.Domain;
using NewWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NewWebApp.Controllers
{
    public class VideoMetadataController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public VideoMetadataController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var videos = await mvcDemoDbContext.VideoMetadatas.ToListAsync();
            return View(videos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVideoMetadata addVideoMetadata)
        {
            var videoMetadata = new VideoMetadata();

            await mvcDemoDbContext.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC InsertVideoMetadata
            @VideoTitle = {addVideoMetadata.VideoTitle},
            @Description = {addVideoMetadata.Description},
            @VideoUrl = {addVideoMetadata.VideoUrl},
            ");

            return RedirectToAction("Index");
        }
    }
}
