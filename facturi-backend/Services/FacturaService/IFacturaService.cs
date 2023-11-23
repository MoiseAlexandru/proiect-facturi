using facturi_backend.Models.DTOs;

namespace facturi_backend.Services.FacturaService
{
    public interface IFacturaService
    {
        FacturaResponseDTO? GetFacturaById(int id);
        void AddFactura(FacturaReceiveDTO payload);
        void UpdateFacturaById(int id, FacturaReceiveDTO payload);
        void DeleteFacturaById(int id);
    }
}
