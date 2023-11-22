using System.ComponentModel.DataAnnotations.Schema;

namespace facturi_backend.Models
{
    public class DetaliiFactura : BaseEntity.BaseEntity
    {
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        public int IdFactura {  get; set; }
        public string? NumeProdus { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cantitate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PretUnitar { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valoare { get; set; }
        public Factura? Factura { get; set; }
    }
}
