using App_Tutorias_Turing.Models;
using System.Data.Entity;


namespace App_Tutorias_Turing.Services
{
    public class Service : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tutoria> Tutorias { get; set; }

        public Service() : base("App_Tutorias_Turing") { }

        public List<Usuario> mostrarUsuarios()
        {
            return Usuarios.ToList();
        }

        public void agregarUsuario(Usuario nuevoUsuario)
        {
            Usuarios.Add(nuevoUsuario);
            SaveChanges();
        }

        public List<Tutoria> mostrarTutoriasDeUsuario(Usuario usuarioPorListar)
        {
            return usuarioPorListar.MisTutorias.ToList();
        }

        public List<Tutoria> mostrarTutorias()
        {
            return Tutorias.ToList();
        }

        public void agregarTutoria(Tutoria nuevaTutoria)
        {
            Tutorias.Add(nuevaTutoria);
            SaveChanges();
        }

        public Usuario autenticarUsuario(string correo, string contrasenna)
        {
            var usuarioAutenticado = Usuarios.FirstOrDefault(u => u.Correo == correo && u.Contrasenna == contrasenna);
            if (usuarioAutenticado != null)
            {
                return usuarioAutenticado;
            }
            return null;
        }

        public void MatricularUsuarioATutoria(int usuarioId, Tutoria tutoria)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario != null && tutoria != null)
            {
                usuario.MisTutorias.Add(tutoria);
                SaveChanges(); // Guardar los cambios en la base de datos
            }
        }

        public List<Tutoria> ObtenerTodasLasTutorias()
        {
            return Tutorias.ToList(); // Donde `Tutorias` es la lista de todas las tutorías en el sistema.
        }

    }
}
