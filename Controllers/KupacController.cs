using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.EF;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class KupacController : Controller
    {

        public ActionResult DodajForm()   // Dodaj u bazu
        {
           
            return View("DodajForm");
        }
        public ActionResult DodajSnimi(string Naziv, int Score) // Snimi u bazu
        {
            Kupac x = new Kupac
            {
                Name = Naziv,
                Score = Score
            };
            MyContext db = new MyContext();
            db.Add(x);
            db.SaveChanges();
            
            return Redirect("/Kupac/Prikazi");
        }

        // snima nakon edita
        public ActionResult UrediSnimi(int KupacId, string Naziv, int Score, string Naziv1, int Score1) // Snimi u bazu
        {
            MyContext db = new MyContext();
            if (Score > Score1) { 


            Kupac x = db.Kupac.Find(KupacId);

            x.Id = KupacId;
            x.Name = Naziv;
            x.Score +=1 ;
            db.SaveChanges();

            return Redirect("/Kupac/Prikazi");
        }
        else {
                
                return Redirect("/Kupac/Prikazi");

            }
        }
        // GET: Kupac
        public ActionResult Prikazi()
        {          
            MyContext db = new MyContext();
            List<KupacPrikaziViewModel> podaci = db.Kupac.Select(k => new KupacPrikaziViewModel
            {
                
                    Id = k.Id,
                    Name = k.Name,
                    Score = k.Score
                
            })
            .ToList();
            ViewData["podaci-kljuc"] = podaci;
            db.Dispose();
            return View();
        }
        
     
        // Dodavanje metode obrisi cisto radi vjezbe
         public ActionResult Obrisi(int KupacId)
        {
            MyContext db = new MyContext();  // potreban nam je objekat klase 
            Kupac k = db.Kupac.Find(KupacId);  // pronalazimo kupca funkcijom find
            if (k == null)
            {
                return Content("Kupac ne postoji");
            }
            else
            {
                db.Remove(k);  // brisemo funkcijom remove, međutim pravo brisanje je kad dodamo SaveChanges
                db.SaveChanges();
            }
            db.Dispose();
            return Redirect("/Kupac/Prikazi");
        }               
        // editovanje u bazi
       public ActionResult UrediForm(int KupacId)
        {
            MyContext db = new MyContext();  // potreban nam je objekat klase 
            Kupac k = db.Kupac.Find(KupacId);  // pronalazimo kupca funkcijom find
            if (k == null)
            {
                return Redirect("/Kupac/Prikazi");
            }

            ViewData["kupac-kljuc"] = k;
               
            return View("UrediForm");
        }
        // Sortiranje
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ScoreSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            MyContext db = new MyContext();
            var students = from s in db.Kupac
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.Id);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Id);
                    break;
                default:
                    students = students.OrderBy(s => s.Score);
                    break;
            }
            return View(students.ToList());
        }

    }
}