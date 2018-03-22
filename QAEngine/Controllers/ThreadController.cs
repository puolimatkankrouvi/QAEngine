using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QAEngine.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult Index(int id)
        {

            return View();
        }

        // GET: Thread/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thread/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thread/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thread/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}