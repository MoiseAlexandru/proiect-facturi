using facturi_backend.Models;
using facturi_backend.Models.DTOs;
using facturi_backend.Repositories.DetaliiFacturaRepository;

namespace facturi_backend.Services.DetaliiFacturaService
{
    public class DetaliiFacturaService : IDetaliiFacturaService
    {
        private readonly IDetaliiFacturaRepository _detaliiFacturaRepository;
        public DetaliiFacturaService(IDetaliiFacturaRepository detaliiFacturaRepository)
        {
            _detaliiFacturaRepository = detaliiFacturaRepository;
        }
        
        private DetaliiFacturaResponseDTO? ConvertToDTO(DetaliiFactura? detaliiFactura)
        {
            if(detaliiFactura == null)
                return null;
            DetaliiFacturaResponseDTO result = new()
            {
                IdDetaliiFactura = detaliiFactura.IdDetaliiFactura,
                IdLocatie = detaliiFactura.IdLocatie,
                IdFactura = detaliiFactura.IdFactura,
                NumeProdus = detaliiFactura.NumeProdus,
                Cantitate = detaliiFactura.Cantitate,
                PretUnitar = detaliiFactura.PretUnitar,
                Valoare = detaliiFactura.Valoare
            };
            return result;
        }
        public DetaliiFacturaResponseDTO? GetDetaliiFacturaById(int id)
        {
            DetaliiFactura? detaliiFactura = _detaliiFacturaRepository.FindById(id);
            DetaliiFacturaResponseDTO? response = ConvertToDTO(detaliiFactura);
            return response;
        }

        public DetaliiFacturaResponseDTO? GetDetaliiFacturaByFacturaId(int id)
        {
            DetaliiFactura? detaliiFactura = _detaliiFacturaRepository.FindByFacturaId(id);
            DetaliiFacturaResponseDTO? response = ConvertToDTO(detaliiFactura);
            return response;
        }

        public void UpdateDetaliiFactura(int id, DetaliiFacturaReceiveDTO payload)
        {
            DetaliiFactura? detaliiFactura = _detaliiFacturaRepository.FindById(id);
            if (detaliiFactura == null) // nu ar trebui sa se intample
                return;
            detaliiFactura.NumeProdus = payload.NumeProdus;
            detaliiFactura.Cantitate = payload.Cantitate;
            detaliiFactura.PretUnitar = payload.Cantitate == 0 ? 0 : payload.Valoare / payload.Cantitate;
            detaliiFactura.Valoare = payload.Valoare;
            _detaliiFacturaRepository.Update(detaliiFactura);
            _detaliiFacturaRepository.Save();
        }
    }
}
