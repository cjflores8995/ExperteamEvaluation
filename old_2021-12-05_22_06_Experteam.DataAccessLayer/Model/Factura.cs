namespace Experteam.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            Pago = new HashSet<Pago>();
            Guia = new HashSet<Guia>();
        }

        [Key]
        public int IdFactura { get; set; }

        public int IdEstablecimiento { get; set; }

        public int IdPuntoEmision { get; set; }

        public int Secuencial { get; set; }

        public DateTime FechaEmision { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }

        public virtual PuntoEmision PuntoEmision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guia> Guia { get; set; }
    }
}
