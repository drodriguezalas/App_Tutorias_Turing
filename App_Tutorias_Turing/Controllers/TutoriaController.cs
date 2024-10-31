using App_Tutorias_Turing.Services;
using Microsoft.AspNetCore.Mvc;
using App_Tutorias_Turing.Models;
using System.Linq;

namespace App_Tutorias_Turing.Controllers
{
    public class TutoriaController : Controller
    {
        private readonly Service _services;

        public TutoriaController()
        {
            _services = new Service();
        }

        // GET: TutoriaController - Lista todas las tutorías disponibles
        public ActionResult Index()
        {
            var tutorias = _services.mostrarTutorias();
            return View(tutorias);
        }

        // GET: TutoriaController/Details/5 - Detalles de una tutoría específica
        public ActionResult Details(int id)
        {
            var tutoria = _services.Tutorias.FirstOrDefault(t => t.Id == id);
            if (tutoria == null)
            {
                return NotFound();
            }
            return View(tutoria);
        }

        // GET: TutoriaController/Create - Vista para crear una nueva tutoría
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutoriaController/Create - Crear una nueva tutoría
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                _services.agregarTutoria(tutoria);
                return RedirectToAction(nameof(Index));
            }
            return View(tutoria);
        }

        // GET: TutoriaController/Edit/5 - Vista para editar una tutoría
        public ActionResult Edit(int id)
        {
            var tutoria = _services.Tutorias.FirstOrDefault(t => t.Id == id);
            if (tutoria == null)
            {
                return NotFound();
            }
            return View(tutoria);
        }

        // POST: TutoriaController/Edit/5 - Editar una tutoría
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                // Actualizar la tutoría en la base de datos si es necesario
                var existingTutoria = _services.Tutorias.FirstOrDefault(t => t.Id == id);
                if (existingTutoria != null)
                {
                    existingTutoria.Descripcion = tutoria.Descripcion;
                    existingTutoria.Url = tutoria.Url;
                    _services.SaveChanges(); // Asumiendo que tienes un método para guardar los cambios
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tutoria);
        }

        // POST: TutoriaController/VerificarMatricula - Verifica si hay un choque de horarios
        [HttpPost]
        public ActionResult VerificarMatricula(int usuarioId, int tutoriaId)
        {
            var usuario = _services.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            var nuevaTutoria = _services.Tutorias.FirstOrDefault(t => t.Id == tutoriaId);

            if (usuario == null || nuevaTutoria == null)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            var choqueHorarios = usuario.MisTutorias.Any(t => t.Id == nuevaTutoria.Id);

            if (choqueHorarios)
            {
                return Json(new { success = false, message = "Existe un choque de horarios con otra tutoría" });
            }

            return Json(new { success = true, message = "No hay choques de horarios" });
        }

        // POST: TutoriaController/ConfirmarMatricula - Confirma la matrícula del usuario
        [HttpPost]
        public ActionResult ConfirmarMatricula(int usuarioId, int tutoriaId)
        {
            var usuario = _services.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            var tutoria = _services.Tutorias.FirstOrDefault(t => t.Id == tutoriaId);

            if (usuario == null || tutoria == null)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            usuario.MisTutorias.Add(tutoria);
            _services.agregarUsuario(usuario);

            return Json(new { success = true, message = "Matrícula confirmada" });
        }
    }
}
