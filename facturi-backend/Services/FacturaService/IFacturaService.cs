using facturi_backend.Models.DTOs;

namespace facturi_backend.Services.FacturaService
{
    public interface IFacturaService
    {
        Task<List<FacturaResponseDTO>> GetAll();
        FacturaResponseDTO? GetFacturaById(int id);
        int AddFactura(FacturaReceiveDTO payload);
        int UpdateFacturaById(int id, FacturaReceiveDTO payload);
        void DeleteFacturaById(int id);
    }
}
