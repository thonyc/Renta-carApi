using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class RentaCarContext : DbContext
    {
        public RentaCarContext()
        {
        }

        public RentaCarContext(DbContextOptions<RentaCarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquilers { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Garaje> Garajes { get; set; }
        public virtual DbSet<Reservacione> Reservaciones { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=RentaCar;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.Idalquiler)
                    .HasName("PK__alquiler__3AFF8BE1896DC181");

                entity.ToTable("alquiler");

                entity.Property(e => e.Idalquiler).HasColumnName("idalquiler");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.ReservacionId).HasColumnName("reservacionId");

                entity.HasOne(d => d.Reservacion)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.ReservacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_alquiler_reservaciones_1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__clientes__7B86132F7742A133");

                entity.ToTable("clientes");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Garaje>(entity =>
            {
                entity.HasKey(e => e.Idgaraje)
                    .HasName("PK__garajes__937382A03251EE60");

                entity.ToTable("garajes");

                entity.Property(e => e.Idgaraje).HasColumnName("idgaraje");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado ");
            });

            modelBuilder.Entity<Reservacione>(entity =>
            {
                entity.HasKey(e => e.Idreservacion)
                    .HasName("PK__reservac__56D0AEBC997B1EAC");

                entity.ToTable("reservaciones");

                entity.Property(e => e.Idreservacion).HasColumnName("idreservacion");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.FechaReservacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaReservacion");

                entity.Property(e => e.VehiculoId).HasColumnName("vehiculoId");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservaciones_clientes_1");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservaciones_vehiculos_1");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Idvehiculo)
                    .HasName("PK__vehiculo__8E1E9617FE5C8789");

                entity.ToTable("vehiculos");

                entity.HasIndex(e => e.GarajeId, "UC_garajeId")
                    .IsUnique();

                entity.HasIndex(e => e.GarajeId, "garajeId")
                    .IsUnique();

                entity.Property(e => e.Idvehiculo).HasColumnName("idvehiculo");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.GarajeId).HasColumnName("garajeId");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.Property(e => e.PrecioAlquiler)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("precio_alquiler");

                entity.HasOne(d => d.Garaje)
                    .WithOne(p => p.Vehiculo)
                    .HasForeignKey<Vehiculo>(d => d.GarajeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculos_garajes_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
