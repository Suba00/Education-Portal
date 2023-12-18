using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebApp.Data;
using NewWebApp.Models.Domain;
using NewWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using AddUserRating = NewWebApp.Models.Domain.AddUserRating;

namespace NewWebApp.Controllers
{
    public class UserRatingController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public UserRatingController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userRatings = await mvcDemoDbContext.UserRatings.ToListAsync();
            return View(userRatings);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserRating userRating)
        {

            var userRating1 = new UserRating();

            //await mvcDemoDbContext.Database.ExecuteSqlInterpolatedAsync($@"
            //EXEC InsertTest1
            //@FullName = {userRating.FullName},
            //@Score = {userRating.Score},");

            await mvcDemoDbContext.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC InsertUserRating
            @FullName = {userRating.FullName},
            @Score = {userRating.Score}
            ");

            return RedirectToAction("Index");

        }
    }
}
