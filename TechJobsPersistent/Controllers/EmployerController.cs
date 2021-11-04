using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class 
        EmployerController : Controller
    {
        private JobDbContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel view = new AddEmployerViewModel();
            return View(view);
        }

        
            public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployer)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployer.Name,
                    Location = addEmployer.Location
                };
                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            return View("Add",addEmployer);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id);
            //AddEmployerViewModel = new AddEmployerViewModel(employer);
            return View(employer);
        }
    }
}
