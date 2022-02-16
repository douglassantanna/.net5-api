using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public EnderecoController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ConsultarEnderecoDTO enderecoDto = _mapper.Map<ConsultarEnderecoDTO>(endereco);

                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CriarEnderecoDTO enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecosPorId), new { Id = endereco.Id }, endereco);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] AtualizarEnderecoDTO enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}