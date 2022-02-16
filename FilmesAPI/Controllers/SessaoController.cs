using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public SessaoController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_context.Sessoes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ConsultarSessaoDTO sessaoDto = _mapper.Map<ConsultarSessaoDTO>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CriarSessaoDTO sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id }, sessao);
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
