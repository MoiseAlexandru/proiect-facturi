using facturi_backend.Models.DTOs;
using facturi_backend.Services.DetaliiFacturaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace facturi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaliiFacturiController : ControllerBase
    {
        private readonly IDetaliiFacturaService _detaliiFacturaService;
        public DetaliiFacturiController(IDetaliiFacturaService detaliiFacturaService)
        {
            _detaliiFacturaService = detaliiFacturaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detaliiFacturi = await _detaliiFacturaService.GetAll();
            if (detaliiFacturi == null)
                return NotFound();
            return Ok(detaliiFacturi);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _detaliiFacturaService.GetDetaliiFacturaById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("factura/{id}")]
        public IActionResult GetByFacturaId(int id)
        {
            var result = _detaliiFacturaService.GetDetaliiFacturaByFacturaId(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFactura(int id, [FromBody] DetaliiFacturaReceiveDTO payload)
        {
            if (_detaliiFacturaService.GetDetaliiFacturaById(id) == null)
                return NotFound(id);
            _detaliiFacturaService.UpdateDetaliiFactura(id, payload);
            return Ok();
        }

    }
}
