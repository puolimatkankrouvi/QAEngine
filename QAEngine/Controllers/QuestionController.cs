using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Models;
using QAEngine.Data;
using System.ComponentModel.DataAnnotations;
using QAEngine.Models.ThreadModels;

namespace QAEngine.Controllers
{

    public class QuestionController : Controller
    {
        private IAuthorizationService authorizationService;
    

        public QuestionController(IAuthorizationService service, ApplicationDbContext context)
        {
            authorizationService = service;
        }

        // GET:Question
        [Authorize]
        public ActionResult Index(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var question = db.Questions.FirstOrDefault( q => q.Id == id);
                ViewData["Question"] = question;

                var answers = db.Answers.
                        Where(a => a.QuestionId == id)
                        .ToList();

                ViewData["Answers"] = answers;


                return View();
            }
            
        }

        // GET: Question/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                using ( ApplicationDbContext context = new ApplicationDbContext())
                {
                    string text, title;

                    title = collection["Title"];
                    text = collection["Text"];

                    var username = User.Identity.Name;

                    var date = DateTime.Now;

                    var poster = context.Users.FirstOrDefault( u => u.UserName == username);

                    QuestionModel question = new QuestionModel() {
                        Title = title,
                        Text = text,
                        Date = date,
                        Poster = poster
                    };

                    context.Questions.Add(question);

                    await context.SaveChangesAsync();
                }


                 return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using( ApplicationDbContext context = new ApplicationDbContext())
            {

                var question = context.Questions.FirstOrDefault();

                var user = User;

                bool authorizationSuccess = await authorizationService.AuthorizeAsync(user, question, "IsAuthorPolicy");


                if (authorizationSuccess)
                {
                    return View();
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            
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