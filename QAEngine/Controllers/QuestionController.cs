using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Models;
using QAEngine.Data;

namespace QAEngine.Controllers
{
    public class QuestionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET:Question
        [Authorize]
        public ActionResult Index(int id)
        {
            var questions = from q in db.Questions
                            where q.ID == id
                            select q;
            ViewData["Questions"] = questions;

            var answers = from a in db.Answers
                          where a.ID == id
                          select a;

            ViewData["Answers"] = answers;


            return View();
        }

        // GET: Question/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
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

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
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