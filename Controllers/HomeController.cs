using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

        // private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var statuses = db.Statuses.ToList();

                var table = db.Tasks.Join(
                        db.Statuses,
                        tsk => tsk.Id,
                        sts => sts.StatusId,
                        (tsk, sts) => new IndexTable
                        {
                            Id = tsk.Id,
                            Name = tsk.Name,
                            Description = tsk.Description,
                            Status = sts.StatusName
                        }
                    ).ToList();
                
                return View(table);
            }
        }

        public IActionResult Statuses()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var statuses = db.Statuses.ToList();
                return View(statuses);
            }
        }

        public IActionResult Tasks()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var tasks = db.Tasks.ToList();
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
