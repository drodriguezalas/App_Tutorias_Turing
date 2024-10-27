namespace App_Tutorias_Turing.Models
{
    public class Tutoria
    {
        private int id;
        private string descripcion;
        private string url;

        public Tutoria()
        {
            this.id = 0;
            this.descripcion = "";
            this.url = "";
        }

        public Tutoria(int id, string descripcion, string url)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.url = url;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Url { get => url; set => url = value; }
    }
}

