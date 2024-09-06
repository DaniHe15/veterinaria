namespace Veterinaria5.Modelos
{

    public class Dueno
    {
        public Dueno()
        {
            MascotaFK = new HashSet<Mascota>();
        }

        public int IdDueno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Mascota> MascotaFK { get; set; }
    }
}
