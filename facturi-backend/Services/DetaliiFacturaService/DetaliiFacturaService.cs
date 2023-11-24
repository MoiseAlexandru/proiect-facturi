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
        
        public async Task<List<DetaliiFacturaResponseDTO?> > GetAll()
        {
            List<DetaliiFactura> detaliiFacturi = await _detaliiFacturaRepository.GetAll();
            List<DetaliiFacturaResponseDTO?> resultList = new List<DetaliiFacturaResponseDTO?>();
            foreach (DetaliiFactura detaliiFactura in detaliiFacturi)
                resultList.Add(ConvertToDTO(detaliiFactura));
            return resultList;
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
            detaliiFactura.PretUnitar = payload.PretUnitar;
            detaliiFactura.Valoare = payload.Cantitate * payload.PretUnitar;
            _detaliiFacturaRepository.Update(detaliiFactura);
            _detaliiFacturaRepository.Save();
        }
    }
}
