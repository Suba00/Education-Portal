using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebApp.Data;
using NewWebApp.Models;
using NewWebApp.Models.Domain;

namespace NewWebApp.Controllers
{
	public class TestController : Controller
	{
		private readonly MVCDemoDbContext mvcDemoDbContext;

		public TestController(MVCDemoDbContext mvcDemoDbContext)
		{
			this.mvcDemoDbContext = mvcDemoDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var test = await mvcDemoDbContext.Tests1.ToListAsync();
			return View(test);
		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTest addTest)
        {
            //var test = new Test1()
            //{
            //    FullName = addTest.FullName
            //};
            //await mvcDemoDbContext.Tests1.AddAsync(test);
            //await mvcDemoDbContext.SaveChangesAsync();
            //return RedirectToAction("Index");


            //var test = new Test1();
            await mvcDemoDbContext.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC InsertTest1
            @FullName = {addTest.FullName}");

            //await mvcDemoDbContext.Tests1.AddAsync(test);
            //await mvcDemoDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
