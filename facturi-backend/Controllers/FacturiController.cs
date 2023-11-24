using facturi_backend.Models.DTOs;
using facturi_backend.Services.DetaliiFacturaService;
using facturi_backend.Services.FacturaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace facturi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturiController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturiController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _facturaService.GetFacturaById(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturi = await _facturaService.GetAll();
            if (facturi == null)
                return NotFound();
            return Ok(facturi);
        }


        [HttpPost]
        public IActionResult CreateFactura([FromBody] FacturaReceiveDTO factura)
        {
            int facturaId = _facturaService.AddFactura(factura);
            return Ok(facturaId);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFactura(int id, [FromBody] FacturaReceiveDTO payload)
        {
            if(_facturaService.GetFacturaById == null)
                return NotFound(id);
            int detaliiId = _facturaService.UpdateFacturaById(id, payload);
            return Ok(detaliiId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFactura(int id)
        {
            if (_facturaService.GetFacturaById == null)
                return NotFound();
            _facturaService.DeleteFacturaById(id);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAll()
        {
            var facturi = await _facturaService.GetAll();
            if (facturi == null)
                return Ok();
            foreach(FacturaResponseDTO factura in facturi)
            {
                _facturaService.DeleteFacturaById(factura.IdFactura);
            }
            if (_facturaService.GetFacturaById == null)
                return NotFound();
            return Ok();
        }
    }
}
