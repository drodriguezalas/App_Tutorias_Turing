using App_Tutorias_Turing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Tutorias_Turing.Models;

namespace App_Tutorias_Turing.Controllers
{
    public class TutoriaController : Controller
    {
        private Service services;

        public TutoriaController()
        {
            services = new Service();
        }

        // GET: TutoriaController
        public ActionResult Index()
        {
            var model = services.mostrarTutorias();
            return View(model);
        }

        // GET: TutoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TutoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tutoria nuevaTutoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    services.agregarTutoria(nuevaTutoria);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                
            }
            return View();
        }

        // GET: TutoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TutoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TutoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TutoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
