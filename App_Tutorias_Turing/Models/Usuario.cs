namespace App_Tutorias_Turing.Models
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string cedula;
        private string correo;
        private string contrasenna;
        private List<Tutoria> misTutorias;

        public Usuario()
        {
            this.id = 0;
            this.nombre = "";
            this.apellido = "";
            this.cedula = "";
            this.correo = "";
            this.contrasenna = "";
            this.misTutorias = new List<Tutoria>();
        }

        public Usuario(int id, string nombre, string apellido, string cedula, string correo, string contrasenna)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.correo = correo;
            this.contrasenna = contrasenna;
            this.misTutorias = new List<Tutoria>();
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasenna { get => contrasenna; set => contrasenna = value; }
        public List<Tutoria> MisTutorias { get => misTutorias; set => misTutorias = value; }
    }
}

