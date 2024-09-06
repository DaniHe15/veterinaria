using Microsoft.EntityFrameworkCore;
using Veterinaria5.Modelos;

namespace veterinaria5.Data
{
    public partial class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration Configuration) : base(options)
        {
            _configuration = Configuration;
        }

        public virtual DbSet<Dueno> dueno { get; set; }
        public virtual DbSet<Mascota> mascota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer(_configuration.GetSection("ConnectionStrings:Connection").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Dueno>(entity =>
            {
                entity.HasKey(e => e.IdDueno)
                       .HasName("PK_DUENO"); ;

                entity.ToTable("DUENO");

                entity.Property(e => e.IdDueno).HasColumnName("ID_DUENO");

                entity.Property(e => e.TipoDocumento)
                      .HasMaxLength(250)
                      .IsUnicode(false)
                      .HasColumnName("TIPO_DOCUMENTO");


                entity.Property(e => e.NumDocumento)
                      .HasMaxLength(250)
                      .IsUnicode(false)
                      .HasColumnName("NUM_DOCUMENTO");


                entity.Property(e => e.Nombre)
                      .HasMaxLength(250)
                      .IsUnicode(false)
                      .HasColumnName("NOMBRE");
            });
            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                       .HasName("PK_MASCOTA"); ;

                entity.ToTable("MASCOTA");

                entity.Property(e => e.IdMascota).HasColumnName("ID_MASCOTA");

                entity.Property(e => e.IdDueno).HasColumnName("ID_DUENO");


                entity.Property(e => e.Tipo)
                      .HasMaxLength(45)
                      .IsUnicode(false)
                      .HasColumnName("TIPO");


                entity.Property(e => e.Nombre)
                      .HasColumnType("text")
                      .IsUnicode(false)
                      .HasColumnName("NOMBRE");


                entity.Property(e => e.Peso)
                      .IsUnicode(false)
                      .HasColumnName("PESO");

                entity.Property(e => e.FechaNacimiento)
                     .HasColumnType("DateTime")
                     .IsUnicode(false)
                     .HasColumnName("FECHA_NACIMIENTO");

                entity.HasOne(d => d.IdDuenoNavigation)
                       .WithMany(p => p.MascotaFK)
                       .HasForeignKey(d => d.IdDueno)
                       .HasConstraintName("FK_MASCOTA");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
