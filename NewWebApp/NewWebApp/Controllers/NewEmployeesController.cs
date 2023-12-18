using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebApp.Data;
using NewWebApp.Models;
using NewWebApp.Models.Domain;

namespace NewWebApp.Controllers
{
    public class NewEmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public NewEmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDbContext.NewEmployees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            //var employee = new NewEmployee()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = addEmployeeRequest.Name,
            //    Email = addEmployeeRequest.Email,
            //    Salary = addEmployeeRequest.Salary,
            //    Department = addEmployeeRequest.Department,
            //    DateOfBirth = addEmployeeRequest.DateOfBirth
            //};
            //await mvcDemoDbContext.NewEmployees.AddAsync(employee);
            //await mvcDemoDbContext.SaveChangesAsync();
            //return RedirectToAction("Add");

            var employee = new NewEmployee();
            await mvcDemoDbContext.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC SP_Insert_NewEmployee 
            @Name = {addEmployeeRequest.Name},
            @Email = {addEmployeeRequest.Email},
            @Salary = {addEmployeeRequest.Salary},
            @DateOfBirth = {addEmployeeRequest.DateOfBirth},
            @Department = {addEmployeeRequest.Department}");

            await mvcDemoDbContext.NewEmployees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }



    }
}
