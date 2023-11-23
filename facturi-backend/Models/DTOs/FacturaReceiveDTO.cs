namespace facturi_backend.Models.DTOs
{
    public class FacturaReceiveDTO
    {
        public int IdLocatie { get; set; }
        public string? NumarFactura { get; set; }
        public DateTime? DataFacturare { get; set; }
        public string? NumeClient { get; set; }
    }
}
