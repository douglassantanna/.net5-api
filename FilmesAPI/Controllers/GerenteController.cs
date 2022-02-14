using apiRestDotNet5.Data;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace apiRestDotNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public GerenteController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            return Ok(_context.Gerentes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ConsultarGerenteDTO gerenteDto = _mapper.Map<ConsultarGerenteDTO>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CriarGerenteDTO gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id }, gerente);
        }

        // [HttpPut("{id}")]
        // public IActionResult AtualizarGerente(int id, [FromBody] AtualizarGerenteDTO gerenteDto)
        // {
        //     Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        //     if (gerente == null)
        //     {
        //         return NotFound();
        //     }
        //     _mapper.Map(gerenteDto, gerente);
        //     _context.SaveChanges();
        //     return NoContent();
        // }


        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
