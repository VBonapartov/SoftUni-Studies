using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
            using (var db = new TeisterMaskDbContext())
            {
                var tasks = db.Tasks.ToList();

                return View(tasks);
            }
        }

        [HttpGet]
        [Route("create11")]
        public ActionResult Create()
		{
            return View();
        }

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            if (task == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(task.Title) || string.IsNullOrWhiteSpace(task.Status))
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                using (var db = new TeisterMaskDbContext())
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(task);
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int? id)
		{
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new TeisterMaskDbContext())
            {
                //var task = db.Tasks
                //                    .Where(a => a.Id == id)
                //                    .FirstOrDefault();

                var task = db.Tasks.Find(id);

                if (task == null)
                {
                    return HttpNotFound();
                }

                return View(task);
            }
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult Edit(Task taskModel)
		{
            if (!ModelState.IsValid)
            {
                return View(taskModel);
                // return RedirectToAction("Edit", new { id = taskModel.Id });
                // return RedirectToAction("Index");
            }

            using (var db = new TeisterMaskDbContext())
            {
                var taskFromDb = db.Tasks.Find(taskModel.Id);

                if (taskFromDb == null)
                {
                    return HttpNotFound();
                }

                taskFromDb.Title = taskModel.Title;
                taskFromDb.Status = taskModel.Status;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
        }
	}
}