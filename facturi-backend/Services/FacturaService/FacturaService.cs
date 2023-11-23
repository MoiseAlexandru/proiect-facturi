using facturi_backend.Models;
using facturi_backend.Models.DTOs;
using facturi_backend.Repositories.DetaliiFacturaRepository;
using facturi_backend.Repositories.FacturaRepository;
using System.Numerics;

namespace facturi_backend.Services.FacturaService
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IDetaliiFacturaRepository _detaliiFacturaRepository;
        public FacturaService(IFacturaRepository facturaRepository, IDetaliiFacturaRepository detaliiFacturaRepository)
        {
            _facturaRepository = facturaRepository;
            _detaliiFacturaRepository = detaliiFacturaRepository;
        }

        public FacturaResponseDTO? GetFacturaById(int id)
        {
            Factura? factura = _facturaRepository.FindById(id);
            if (factura == null)
                return null;
            FacturaResponseDTO response = new()
            {
                IdFactura = factura.IdFactura,
                IdLocatie = factura.IdLocatie,
                NumarFactura = factura.NumarFactura,
                DataFacturare = factura.DataFacturare,
                NumeClient = factura.NumeClient
            };
            return response;
        }

        public void AddFactura(FacturaReceiveDTO payload)
        {
            int genIdFactura = _facturaRepository.GenerateUniqueId();
            DetaliiFactura emptyDetaliiFactura = new()
            {
                IdDetaliiFactura = _detaliiFacturaRepository.GenerateUniqueId(),
                IdLocatie = payload.IdLocatie,
                IdFactura = genIdFactura,
                NumeProdus = "",
                Cantitate = 0,
                PretUnitar = 0,
                Valoare = 0
            };
            Factura factura = new()
            {
                IdFactura = genIdFactura,
                IdLocatie = payload.IdLocatie,
                NumarFactura = payload.NumarFactura,
                DataFacturare = payload.DataFacturare,
                NumeClient = payload.NumeClient,
            };
            emptyDetaliiFactura.Factura = factura;
            factura.DetaliiFactura = emptyDetaliiFactura;
            _facturaRepository.Create(factura);
            _detaliiFacturaRepository.Create(emptyDetaliiFactura);
            _facturaRepository.Save();
            _detaliiFacturaRepository.Save();
        }

        public void UpdateFacturaById(int id, FacturaReceiveDTO payload)
        {
            Factura? factura = _facturaRepository.FindById(id);
            if(factura == null)
                return;
            factura.NumarFactura = payload.NumarFactura;
            factura.DataFacturare = payload.DataFacturare;
            factura.NumeClient = payload.NumeClient;
            _facturaRepository.Update(factura);
            _facturaRepository.Save();
        }

        public void DeleteFacturaById(int id)
        {
            Factura? factura = _facturaRepository.FindById(id);
            DetaliiFactura? detaliiFactura = _detaliiFacturaRepository.FindByFacturaId(id);
            if(factura == null || detaliiFactura == null)
                return;
            _facturaRepository.Delete(factura);
            _detaliiFacturaRepository.Delete(detaliiFactura);
            _facturaRepository.Save();
            _detaliiFacturaRepository.Save();
        }
    }
}
