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

namespace AppDemo.Areas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        readonly IRepository<Jogos> _jogosRepository;
        public PontosController(IRepository<Jogos> jogosRepository)
        {
            _jogosRepository = jogosRepository;
        }

        // POST api/values
        [HttpPost("input")]
        [AllowAnonymous]
        public void LancaPontos([FromBody] PontosVM pontos)
        {
            _jogosRepository.Add(new Jogos { DataJogo = pontos.DataJogo, Pontos = pontos.Pontos });
        }

        // POST api/values
        [HttpGet("get")]
        [AllowAnonymous]
        public ResultadoVM Resultados()
        {
            var bd = _jogosRepository.GetAll().ToList();
            ResultadoVM resultado = new ResultadoVM();
            int recorde = 0;

            resultado.JogosDisputados = bd.Count();
            resultado.TotalDePontos = Convert.ToInt32(bd.Select(x => x.Pontos).Sum());
            resultado.DataInicio = bd.Select(x => x.DataJogo).Min();
            resultado.DataFim = bd.Select(x => x.DataJogo).Max();
            resultado.MaiorPontuacaoPorJogo = bd.Select(x => x.Pontos).Max() == null ? 0 : Convert.ToInt32(bd.Select(x => x.Pontos).Max());
            resultado.MenorPontuacaoPorJogo = bd.Select(x => x.Pontos).Min() == null ? 0 : Convert.ToInt32(bd.Select(x => x.Pontos).Min());
            resultado.MediaPorJogo = bd.Select(x => x.Pontos).Average() == null ? 0 : Convert.ToInt32(bd.Select(x => x.Pontos).Average());
            foreach (var item in bd)
            {
                if (item.Pontos > recorde)
                {
                    recorde = Convert.ToInt32(item.Pontos);
                    resultado.Recorde++;
                }
            }

            return resultado;
        }
    }
}
