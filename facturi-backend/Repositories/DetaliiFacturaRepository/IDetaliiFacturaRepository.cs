using facturi_backend.Models;
using facturi_backend.Repositories.GenericRepository;

namespace facturi_backend.Repositories.DetaliiFacturaRepository
{
    public interface IDetaliiFacturaRepository : IGenericRepository<DetaliiFactura>
    {
        int GenerateUniqueId();
        DetaliiFactura? FindByFacturaId(int facturaId);
    }
}
