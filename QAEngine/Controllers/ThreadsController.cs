using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QAEngine.Controllers
{
    public class ThreadsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var threads = from th in db.Questions
                          orderby th.Date descending
                          select th;

            ViewData["Threads"] = threads.ToList();

            return View();
        }
    }
}
