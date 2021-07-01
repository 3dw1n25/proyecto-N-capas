namespace Sistema.Entidades
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public int IdVideo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDev { get; set; }
        public bool Estado { get; set; }

    }
}
