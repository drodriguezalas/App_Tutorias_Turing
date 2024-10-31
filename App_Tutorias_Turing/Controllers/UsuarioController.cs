using App_Tutorias_Turing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Tutorias_Turing.Models;

namespace App_Tutorias_Turing.Controllers
{
    public class UsuarioController : Controller
    {
        private Service services;
        private static int? usuarioIdAutenticado; // Campo estático para almacenar el ID del usuario

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
                    return RedirectToAction("Usuario", "Login");
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Autenticar al usuario
                var usuarioAutenticado = services.autenticarUsuario(usuario.Correo, usuario.Contrasenna);
                if (usuarioAutenticado != null)
                {
                    usuarioIdAutenticado = usuarioAutenticado.Id; // Almacenar el ID del usuario
                    return RedirectToAction("MisTutorias"); // Redirigir a la vista de tutorías del usuario
                }
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            }
            return View();
        }

        public ActionResult MisTutorias()
        {
            if (usuarioIdAutenticado == null)
            {
                return RedirectToAction("Login"); // Redirigir a Login si no hay usuario autenticado
            }

            // Obtener las tutorías del usuario autenticado
            var usuario = services.Usuarios.FirstOrDefault(u => u.Id == usuarioIdAutenticado);

            Console.WriteLine($"Usuario autenticado ID: {usuarioIdAutenticado}");

            if(usuario == null)
            {
                return View("Usuario", "Login");
            }
            return View(usuario.MisTutorias); // Pasar la lista de tutorías a la vista
        }

        public ActionResult SistemaMatricula()
        {
            var tutorias = services.mostrarTutorias();
            return View(tutorias);
        }

        public ActionResult Matricular(int tutoriaId)
        {
            if (usuarioIdAutenticado == null)
            {
                return RedirectToAction("Login"); // Redirigir a Login si no hay usuario autenticado
            }

            // Obtener la tutoría por su ID
            var tutoria = services.Tutorias.FirstOrDefault(t => t.Id == tutoriaId);
            if (tutoria != null && usuarioIdAutenticado != null)
            {
                services.MatricularUsuarioATutoria(usuarioIdAutenticado.Value, tutoria); // Matricular al usuario
                return RedirectToAction("MisTutorias"); // Redirigir a la vista de tutorías del usuario
            }

            return View("Usuario","Login"); // Manejar el caso donde no se encuentra la tutoría
        }

        public ActionResult TodasLasTutorias()
        {
            var todasLasTutorias = services.ObtenerTodasLasTutorias();
            return View(todasLasTutorias);
        }
    }
}
