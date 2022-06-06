using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiterTP7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.Models;

namespace MultiterTP7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private EmployeeBusiness Business = new EmployeeBusiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           var data= Business.GetList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            var result = Business.CreateEmployee(emp);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }

        public IActionResult Edit(int id)
        {
            var u = Business.GetList().Find(e => e.Id == id);
            return View(u);
        }
        [HttpPost]
        public IActionResult Edit(int id,Employee emp)
        {
            Business.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Business.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
