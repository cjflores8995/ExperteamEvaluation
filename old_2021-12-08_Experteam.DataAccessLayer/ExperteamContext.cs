using Experteam.DataAccessLayer.Model;

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Experteam.DataAccessLayer
{
    public partial class ExperteamContext : DbContext
    {
        public ExperteamContext()
            : base("name=ExperteamContext")
        {
        }

        public virtual DbSet<Establecimiento> Establecimiento { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Guia> Guia { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<PuntoEmision> PuntoEmision { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Establecimiento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Establecimiento>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Establecimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Establecimiento>()
                .HasMany(e => e.PuntoEmision)
                .WithRequired(e => e.Establecimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Pago)
                .WithMany(e => e.Factura)
                .Map(m => m.ToTable("FacturaPago").MapLeftKey("IdFactura").MapRightKey("IdPago"));

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Guia)
                .WithMany(e => e.Factura)
                .Map(m => m.ToTable("GuiaFactura").MapLeftKey("IdFactura").MapRightKey("IdGuia"));

            modelBuilder.Entity<Guia>()
                .Property(e => e.NumeroGuia)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.NombreRemitente)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.DireccionRemitente)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.TelefonoRemitente)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.EmailRemitente)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.NombreDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.DireccionDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.TelefonoDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<Guia>()
                .Property(e => e.EmailDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Guia)
                .WithRequired(e => e.Pais)
                .HasForeignKey(e => e.IdPaisOrigen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Guia1)
                .WithRequired(e => e.Pais1)
                .HasForeignKey(e => e.IdPaisDestino)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PuntoEmision>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PuntoEmision>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.PuntoEmision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Guia)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPago>()
                .HasMany(e => e.Pago)
                .WithRequired(e => e.TipoPago)
                .WillCascadeOnDelete(false);
        }
    }
}
