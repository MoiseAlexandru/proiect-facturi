using facturi_backend.Models;
using facturi_backend.Repositories.GenericRepository;

namespace facturi_backend.Repositories.FacturaRepository
{
    public interface IFacturaRepository : IGenericRepository<Factura>
    {
        int GenerateUniqueId();
    }
}
