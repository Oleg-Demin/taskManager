using System.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TaskManager.ViewModels;
using TaskManager.Models;
using TaskManager.Data;

// using System.Linq;
using Microsoft.EntityFrameworkCore;
// using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IndexViewModel indexViewModel = new IndexViewModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var statuses = db.Statuses.ToList();
                var tasks = db.Tasks.ToList();

                indexViewModel.Statuses = statuses;
                indexViewModel.Tasks = tasks;
                return View(indexViewModel);
            }

        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if (model.Add != null)
            {
                if (AddRow(model.Add))
                {
                    ModelState.Clear();
                }
                else
                {
                    indexViewModel.AlertWrongEntry = true;
                }

                indexViewModel.AddFormOpen = true;
            }
            if (model.Edit != null)
            {
                if (EditRow(model.Edit))
                {
                    ModelState.Clear();
                }
                else
                {
                    indexViewModel.AlertWrongEntry = true;
                }

                indexViewModel.EditFormOpen = true;
            }
            if (model.Delete != null)
            {
                if (DeleteRow(model.Delete))
                {
                    ModelState.Clear();
                }
                else
                {
                    indexViewModel.AlertWrongEntry = true;
                }

                indexViewModel.DeleteFormOpen = true;
            }

            return Index();
        }

        public bool AddRow(AddRowViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var task = new TaskManager.Models.Task
                    {
                        Name = model.EnteredName,
                        Description = model.EnteredDescription,
                        StatusId = model.EnteredStatusId
                    };

                    db.Tasks.Add(task);
                    db.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditRow(EditRowViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var task = db.Tasks.Find(model.ActiveTableRow);

                    task.Name = model.EnteredName;
                    task.Description = model.EnteredDescription;
                    task.StatusId = model.EnteredStatusId;

                    db.Tasks.Update(task);
                    db.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteRow(DeleteRowViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var task = db.Tasks.Find(model.ActiveTableRow);
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Statuses()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var statuses = db.Statuses.OrderBy(item => item.StatusId).ToList();
                return View(statuses);
            }
        }

        public IActionResult Tasks()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var tasks = db.Tasks.OrderBy(item => item.Id).ToList();
                return View(tasks);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
