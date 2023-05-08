using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Data
{
    public class EmployeesController : Controller
    {
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
    }
}
