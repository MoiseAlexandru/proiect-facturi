using facturi_backend.Data;
using facturi_backend.Models;

namespace facturi_backend.Helper.Seeders
{
    public class FacturiSeeder
    {
        public readonly DatabaseContext _databaseContext;
        public FacturiSeeder(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private DateTime GenerateRandomDate() // Copiata de pe stackoverflow
        {

            DateTime startDate = new DateTime(2020, 1, 1);
            DateTime endDate = DateTime.Now;

            Random rand = new Random();
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;
            return newDate;
        }

        private void CreateAndConnectObj(int IdLocatie, string NumarFactura, string NumeClient, string NumeProdus, Decimal Cantitate, Decimal Valoare)
        {
            Random rand = new Random();
            int IdFactura = rand.Next();
            int IdDetaliiFactura = rand.Next();
            Factura factura = new Factura()
            {
                IdFactura = IdFactura,
                IdLocatie = IdLocatie,
                NumarFactura = NumarFactura,
                DataFacturare = GenerateRandomDate(),
                NumeClient = NumeClient
            };
            DetaliiFactura detaliiFactura = new DetaliiFactura()
            {
                IdDetaliiFactura = IdDetaliiFactura,
                IdLocatie = IdLocatie,
                IdFactura = IdFactura,
                NumeProdus = NumeProdus,
                Cantitate = Cantitate,
                PretUnitar = Cantitate == 0 ? 0 : Valoare / Cantitate,
                Valoare = Valoare
            };
            factura.DetaliiFactura = detaliiFactura;
            detaliiFactura.Factura = factura;
            _databaseContext.Add(factura);
            _databaseContext.Add(detaliiFactura);
            _databaseContext.SaveChanges();
        }

        public void SeedFacturiInitiale()
        {
            if(!_databaseContext.Facturi.Any())
            {
                CreateAndConnectObj(56789, "123456", "John Doe", "Laptop", 3, 10042.15M);
                CreateAndConnectObj(12345, "987654", "Jane Smith", "Smartphone", 7, 17002.89M);
                CreateAndConnectObj(98765, "456789", "Alice Johnson", "Tablet", 5, 5910.99M);
                CreateAndConnectObj(43210, "654321", "Bob Williams", "Desktop Computer", 2, 12052.50M);
                CreateAndConnectObj(87654, "1112223", "Eva Davis", "Headphones", 10, 2830.75M);
                _databaseContext.SaveChanges();
            }
        }
    }
}
