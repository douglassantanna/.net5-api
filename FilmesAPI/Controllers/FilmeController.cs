using System.Collections.Generic;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmerService)
        {
            _filmeService = filmerService;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ConsultarFilmeDTO consultarFilmeDTO = _filmeService.RecuperarFilmesPorId(id);
            if(consultarFilmeDTO != null) return Ok(consultarFilmeDTO);
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ConsultarFilmeDTO> consultarFilmeDTOs = _filmeService.RecuperarFilmes(classificacaoEtaria);
            if(consultarFilmeDTOs != null) return Ok(consultarFilmeDTOs);
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] CriarFilmeDTO filmeDTO)
        {
            ConsultarFilmeDTO consultarFilmeDTO =  _filmeService.AdicionarFilme(filmeDTO);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = consultarFilmeDTO.Id }, consultarFilmeDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] AtualizarFilmeDTO filmeDTO)
        {
            Result result = _filmeService.AtualizarFilme(id, filmeDTO);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result result = _filmeService.DeletarFilme(id);
           if(result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}