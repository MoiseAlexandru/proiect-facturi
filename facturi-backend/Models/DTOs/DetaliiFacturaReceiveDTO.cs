namespace facturi_backend.Models.DTOs
{
    public class DetaliiFacturaReceiveDTO
    {
        public string? NumeProdus { get; set; }
        public Decimal Cantitate { get; set; }
        public Decimal PretUnitar { get; set; }
    }
}
