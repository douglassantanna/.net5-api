using apiRestDotNet5.Data;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace apiRestDotNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public CinemaController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Cinema> RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ConsultarCinemaDTO cinemaDto = _mapper.Map<ConsultarCinemaDTO>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CriarCinemaDTO cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] AtualizarCinemaDTO cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
