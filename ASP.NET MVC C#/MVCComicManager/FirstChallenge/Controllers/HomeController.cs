using FirstChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {

        List<ComicBook> comics = ComicBookManager.GetComicBooks();


        // GET: Home
        public ActionResult Index()
        {
            return View(comics);
        }

        public ActionResult Details(int id)
        {
            var comic = comics.FirstOrDefault(p => p.ComicBookId == id);
            return View(comic);
        }

    }
}