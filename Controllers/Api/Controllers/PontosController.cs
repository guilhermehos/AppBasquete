using AppDemo.Data.Repository;
using AppDemo.Models;
using AppDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AppDemo.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        readonly IJogosRepository _jogosRepository;
        readonly IRepository<Jogos> _repository;
        public PontosController(IJogosRepository jogosRepository, IRepository<Jogos> repository)
        {
            _jogosRepository = jogosRepository;
            _repository = repository;
        }

        // POST api/values
        [HttpPost("input")]
        [AllowAnonymous]
        public void LancaPontos([FromBody] PontosVM pontos)
        {
            _repository.Add(new Jogos { DataJogo = pontos.DataJogo, Pontos = pontos.Pontos });
        }

        // POST api/values
        [HttpGet("get")]
        [AllowAnonymous]
        public ResultadoVM Resultados()
        //public void Resultados()
        {
            return _jogosRepository.Get();
        }
    }
}
