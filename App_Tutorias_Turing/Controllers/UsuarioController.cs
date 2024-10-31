using App_Tutorias_Turing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Tutorias_Turing.Models;

namespace App_Tutorias_Turing.Controllers
{
    public class UsuarioController : Controller
    {
        private Service services;

        public UsuarioController()
        {
            services = new Service();
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var model = services.mostrarUsuarios();
            return View(model);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario nuevoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    services.agregarUsuario(nuevoUsuario);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
