using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Components;

namespace Assignment2.Data
{
    public class EmployeesController : Controller
    {
        [Inject]
        private IHttpContextAccessor _httpContextAccessor { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }
        private readonly AppDbContext _dbContext;

        public EmployeesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _dbContext.Employeed.ToList();
            return Ok(employees);
        }

        [HttpPut]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            _dbContext.Employeed.Add(employee);
            _dbContext.SaveChanges();
            return Ok(employee);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Logout()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Clear();

            var response = _httpContextAccessor.HttpContext.Response;

            // Disable caching
            response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            response.Headers["Expires"] = "-1";
            response.Headers["Pragma"] = "no-cache";

            response.StatusCode = 303; // Set the status code to redirect with POST

            _navigationManager.NavigateTo("/Employees/Login", true);
        }






    }
}
