using System;
using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private DataContext _context;
        private IMapper _mapper;
        public CinemaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ConsultarCinemaDTO> RecuperarCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if(cinemas == null)
            {
                return null;
            }
            if(!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                where cinema.Sessoes.Any(sessao =>
                sessao.Filme.Titulo == nomeDoFilme)
                select cinema;
                cinemas = query.ToList();
            }
           return _mapper.Map<List<ConsultarCinemaDTO>>(cinemas);
        }

        public ConsultarCinemaDTO RecuperarCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ConsultarCinemaDTO cinemaDto = _mapper.Map<ConsultarCinemaDTO>(cinema);
                return cinemaDto;
            }
            return null;
        }

        public ConsultarCinemaDTO AdicionarCinema(CriarCinemaDTO cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ConsultarCinemaDTO>(cinema);
        }

        public Result AtualizarCinema(int id, AtualizarCinemaDTO cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Não foi possível realizar a operação");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}