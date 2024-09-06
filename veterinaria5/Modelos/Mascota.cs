namespace Veterinaria5.Modelos
{
    public class Mascota
    {

        public int IdMascota { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }

        public int Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdDueno { get; set; }


        public virtual Dueno IdDuenoNavigation { get; set; }
    }
}

