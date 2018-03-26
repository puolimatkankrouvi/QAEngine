using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Models;

namespace QAEngine.Controllers
{
    public class ThreadController : Controller
    {
        QuestionEntities db = new QuestionEntities();

        // GET:Thread
        [Authorize]
        public ActionResult Index(int id)
        {
            var questions = from q in db.Questions
                            where q.id = id
                            select q;
            ViewData["Questions"] = questions.toList();

            var answers = from a in db.Answers
                          where a.id = id
                          select a;

            ViewData["Answers"] = answers.toList();


            return View();
        }

        // GET: Thread/Create
        [Authorize]
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