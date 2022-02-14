using apiRestDotNet5.Data;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using apiRestDotNet5.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace apiRestDotNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
           _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<ConsultarCinemaDTO> consultarCinemaDTO = _cinemaService.RecuperarCinemas(nomeDoFilme);
            if(consultarCinemaDTO != null) return Ok(consultarCinemaDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemasPorId(int id)
        {
            ConsultarCinemaDTO consultarCinemaDTO = _cinemaService.RecuperarCinemaPorId(id);
            if(consultarCinemaDTO != null) return Ok(consultarCinemaDTO);
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CriarCinemaDTO cinemaDto)
        {
            ConsultarCinemaDTO consultarCinemaDTO = _cinemaService.AdicionarCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperarCinemasPorId), new { Id = consultarCinemaDTO.Id }, consultarCinemaDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] AtualizarCinemaDTO cinemaDto)
        {
            Result result = _cinemaService.AtualizarCinema(id, cinemaDto);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result result = _cinemaService.DeletarCinema(id);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
