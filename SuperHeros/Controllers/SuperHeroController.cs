using SuperHeros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext context;
        public SuperHeroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            List<SuperHero> supers = context.Supers.ToList();
            return View(supers);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero superhero = new SuperHero();
            return View(superhero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Supers.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            
            SuperHero dbSuperHero = context.Supers.Where(s => s.Id == id).Single();
           
            return View(dbSuperHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero superhero)
        {
            try
            {
                // TODO: Add update logic here
                SuperHero dbSuperHero = context.Supers.Where(i => i.Id == superhero.Id).Single();
                dbSuperHero.name = superhero.name;
                dbSuperHero.alterEgo = superhero.alterEgo;
                dbSuperHero.primaryAbility = superhero.primaryAbility;
                dbSuperHero.secondAbility = superhero.secondAbility;
                dbSuperHero.catchPhrase = superhero.catchPhrase;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
           
            SuperHero superHero = context.Supers.Where(i => i.Id == id).Single();
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public  ActionResult Delete(SuperHero superhero)
        {
            try
            {
                // TODO: Add delete logic here

                SuperHero superHero = context.Supers.Where(i => i.Id == superhero.Id).Single();
                context.Supers.Remove(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
