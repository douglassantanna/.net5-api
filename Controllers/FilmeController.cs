using System.Linq;
using apiRestDotNet5.Data;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiRestDotNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        DataContext _context;
        private IMapper _mapper;
        public FilmeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme != null)
            {
                ConsultarFilmeDTO filmeDTO = _mapper.Map<ConsultarFilmeDTO>(filme);
                return Ok(filmeDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }
        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CriarFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] AtualizarFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme is null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme is null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}