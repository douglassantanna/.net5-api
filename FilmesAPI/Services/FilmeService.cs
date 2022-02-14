using System.Collections.Generic;
using System.Linq;
using apiRestDotNet5.Data;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;
using FluentResults;

namespace apiRestDotNet5.Services
{
    public class FilmeService
    {
        private DataContext _context;
        private IMapper _mapper;
        public FilmeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ConsultarFilmeDTO RecuperarFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme != null)
            {
                ConsultarFilmeDTO filmeDTO = _mapper.Map<ConsultarFilmeDTO>(filme);
                return filmeDTO;
            }
            return null;
        }

        public ConsultarFilmeDTO AdicionarFilme(CriarFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ConsultarFilmeDTO>(filme);
        }

        public List<ConsultarFilmeDTO> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context
                .Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                List<ConsultarFilmeDTO> filmeDTO = _mapper.Map<List<ConsultarFilmeDTO>>(filmes);
                return filmeDTO;
            }
            return null;
        }

        public Result AtualizarFilme(int id, AtualizarFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme is null)
            {
                return Result.Fail("filme não encontrado");
            }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme is null)
            {
                return Result.Fail("Algo deu errado");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}