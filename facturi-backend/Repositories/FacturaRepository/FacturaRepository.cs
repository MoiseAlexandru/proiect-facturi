using facturi_backend.Data;
using facturi_backend.Models;
using facturi_backend.Repositories.GenericRepository;

namespace facturi_backend.Repositories.FacturaRepository
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
        public FacturaRepository(DatabaseContext context) : base(context) { }
        
        public int GenerateUniqueId()
        {
            Random rand = new Random();
            int currentId = rand.Next(100000);
            while (_table.FirstOrDefault(factura => factura.IdFactura == currentId) != null)
                currentId = rand.Next(100000);
            return currentId;
        }

    }
}
