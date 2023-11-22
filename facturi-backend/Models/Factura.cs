namespace facturi_backend.Models
{
    public class Factura : BaseEntity.BaseEntity
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        public string? NumarFactura { get; set; }
        public DateTime? DataFacturare { get; set; }
        public string? NumeClient {  get; set; }
        public DetaliiFactura? DetaliiFactura { get; set; }
    }
}
    