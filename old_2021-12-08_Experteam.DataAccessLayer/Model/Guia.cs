namespace Experteam.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Guia")]
    public partial class Guia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guia()
        {
            Factura = new HashSet<Factura>();
        }

        [Key]
        public int IdGuia { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroGuia { get; set; }

        public DateTime FechaEnvio { get; set; }

        public int IdPaisOrigen { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreRemitente { get; set; }

        [Required]
        [StringLength(100)]
        public string DireccionRemitente { get; set; }

        [StringLength(50)]
        public string TelefonoRemitente { get; set; }

        [StringLength(50)]
        public string EmailRemitente { get; set; }

        public int IdPaisDestino { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreDestinatario { get; set; }

        [Required]
        [StringLength(100)]
        public string DireccionDestinatario { get; set; }

        [StringLength(50)]
        public string TelefonoDestinatario { get; set; }

        [StringLength(50)]
        public string EmailDestinatario { get; set; }
        
        [Required]
        public decimal Total { get; set; }

        public int IdStatus { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual Pais Pais1 { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
