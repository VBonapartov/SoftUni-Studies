namespace LogNoziroh.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ReportController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new LogNozirohDbContext())
            {
                var reports = db.Reports.ToList();

                return View(reports);
            }
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports
                                    .Where(a => a.Id == id)
                                    .FirstOrDefault();

                if (report == null)
                {
                    return HttpNotFound();
                }

                return View(report);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (report == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(report.Message) || string.IsNullOrWhiteSpace(report.Status) ||
                string.IsNullOrWhiteSpace(report.Origin))
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                using (var db = new LogNozirohDbContext())
                {
                    db.Reports.Add(report);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(report);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports.Find(id);

                if (report == null)
                {
                    return HttpNotFound();
                }

                return View(report);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Report reportModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports
                                    .Where(a => a.Id == id)
                                    .FirstOrDefault();

                if (report == null)
                {
                    return HttpNotFound();
                }

                db.Reports.Remove(report);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}