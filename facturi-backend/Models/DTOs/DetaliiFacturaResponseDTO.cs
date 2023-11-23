namespace facturi_backend.Models.DTOs
{
    public class DetaliiFacturaResponseDTO
    {
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        public int IdFactura { get; set; }
        public string? NumeProdus { get; set; }
        public Decimal? Cantitate { get; set; }
        public Decimal? PretUnitar { get; set; }
        public Decimal? Valoare { get; set; }
    }
}
