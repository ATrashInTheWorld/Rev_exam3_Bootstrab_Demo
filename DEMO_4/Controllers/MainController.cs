using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DEMO_4.Models;
using Angela.Core;
using static DEMO_4.Models.Person;

namespace DEMO_4.Controllers
{
    public class MainController : Controller
    {

        private static ICollection<Person> _people;

        // GET: Main
        public ActionResult Index()
        {

            return View(_people);
        }


        public ActionResult _PersonResult(string searchText)
        {
            var term = searchText.ToLower();
            var result = _people.Where(p =>
                    p.FirstName.ToLower().Contains(term) ||
                    p.LastName.ToLower().Contains(term)
                );
            return PartialView("_PersonResult", result);
        }

        public ActionResult CreatPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _people.Add(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }


        static MainController()
        {
            _people = Angie.Configure<Person>()
                .Fill(p => p.BirthDate)
                .AsPastDate()
                .Fill(p => p.LikesMusic)
                .WithRandom(new List<bool>() { true, true, true, false, false })
                .Fill(p => p.FavoriteMusic)
                .WithRandom(new List<MusicGenre>() { MusicGenre.Country, MusicGenre.Gospel, MusicGenre.HipHop, MusicGenre.Pop, MusicGenre.RB, MusicGenre.Rock })
                .Fill(p => p.Skills, () => new List<string>() { "Math", "Science", "History", "POKEMON GO" })
                .MakeList<Person>(20);
                

        }


    }
}