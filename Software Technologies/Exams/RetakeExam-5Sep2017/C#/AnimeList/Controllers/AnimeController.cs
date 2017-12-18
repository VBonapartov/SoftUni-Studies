using System.Linq;
using System.Net;
using System.Web.Mvc;
using AnimeList.Models;

namespace AnimeList.Controllers
{
    [ValidateInput(false)]
    public class AnimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new AnimeListDbContext())
            {
                var animes = db.Animes.ToList();

                return View(animes);
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
        public ActionResult Create(Anime anime)
        {
            if (anime == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(anime.Name) || anime.Rating == 0 ||
                string.IsNullOrWhiteSpace(anime.Description) || string.IsNullOrWhiteSpace(anime.Watched))
            {
                return View(anime);
            }

            if (ModelState.IsValid)
            {
                using (var db = new AnimeListDbContext())
                {
                    db.Animes.Add(anime);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(anime);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AnimeListDbContext())
            {
                var anime = db.Animes.Find(id);

                if (anime == null)
                {
                    return HttpNotFound();
                }

                return View(anime);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Anime animeModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AnimeListDbContext())
            {
                var anime = db.Animes
                                    .Where(a => a.Id == id)
                                    .FirstOrDefault();

                if (anime == null)
                {
                    return HttpNotFound();
                }

                db.Animes.Remove(anime);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}