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

        public ActionResult Matricular(int usuarioId)
        {
            var usuario = services.Usuarios.Include("MisTutorias").FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null)
            {
                TempData["Mensaje"] = "Usuario no encontrado.";
                return RedirectToAction("Login", "Account"); // Redirige al login si el usuario no existe
            }

            var tutorias = services.Tutorias.ToList();
            return View(tutorias);
        }

        // POST: ConfirmarMatricula (Confirma la matrícula de una tutoría)
        [HttpPost]
        public ActionResult ConfirmarMatricula(int usuarioId, int tutoriaId)
        {
            var usuario = services.Usuarios.Include("MisTutorias").FirstOrDefault(u => u.Id == usuarioId);
            var tutoria = services.Tutorias.FirstOrDefault(t => t.Id == tutoriaId);

            if (usuario == null || tutoria == null)
            {
                TempData["Mensaje"] = "Error al encontrar usuario o tutoría.";
                return RedirectToAction("Matricular", new { usuarioId });
            }

            // Evita matriculaciones duplicadas
            if (usuario.MisTutorias.Any(t => t.Id == tutoriaId))
            {
                TempData["Mensaje"] = "Ya estás matriculado en esta tutoría.";
                return RedirectToAction("Matricular", new { usuarioId });
            }

            // Matricular usuario
            usuario.MisTutorias.Add(tutoria);
            services.SaveChanges();

            TempData["Mensaje"] = "¡Matrícula confirmada!";
            return RedirectToAction("Matricular", new { usuarioId });
        }

        // GET: RefrescarTutorias (Refresca la lista de tutorías)
        public ActionResult RefrescarTutorias()
        {
            var tutorias = services.Tutorias.ToList();
            return PartialView("_TutoriasList", tutorias);  // Usando una vista parcial para actualizar la lista
        }
    }
}
