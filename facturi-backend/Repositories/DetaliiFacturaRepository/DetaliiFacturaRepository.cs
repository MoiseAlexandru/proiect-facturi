using facturi_backend.Data;
using facturi_backend.Models;
using facturi_backend.Repositories.GenericRepository;

namespace facturi_backend.Repositories.DetaliiFacturaRepository
{
    public class DetaliiFacturaRepository : GenericRepository<DetaliiFactura>, IDetaliiFacturaRepository
    {
        public DetaliiFacturaRepository(DatabaseContext context) : base(context) { }

        public int GenerateUniqueId()
        {
            Random rand = new Random();
            int currentId = rand.Next(100000);
            while (_table.FirstOrDefault(detaliiFactura => detaliiFactura.IdDetaliiFactura == currentId) != null)
                currentId = rand.Next(100000);
            return currentId;
        }

        public DetaliiFactura? FindByFacturaId(int idFactura)
        {
            return _table.FirstOrDefault(detaliFactura => detaliFactura.IdFactura == idFactura);
        }
    }
}
