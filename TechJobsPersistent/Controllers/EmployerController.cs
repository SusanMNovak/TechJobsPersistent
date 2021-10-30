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
        private JobbDBContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
            List<Employer> employers = context.Employers.ToList;
            return View(employers);
        }

        public IActionResult Add()
        {
            return View();
            AddEmployerViewModel View = new AddEmployerViewModel();
            return View(view);
        }

        public IActionResult ProcessAddEmployerForm()
            [HttpPost]
            [Route("/Employer/Add")]
            public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployer)
        {
            return View();
            if (ModelState.IsValid)
            {
                Employer newEmployer
                {
                    Name = addEmployermployer.Name,
                    Location = addEmployer.Location
                };
                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("/Emploter");
            }
            return View(addEmploter);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Single(else => else.Id == id);
            AddEmployerViewModel = new AddEmployerViewModel(employer);
            return View(ViewModel);
        }
    }
}
