using AppDemo.Models;
using AppDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Data.Repository
{
    public class JogosRepository : Repository<Jogos>, IJogosRepository
    {
        public JogosRepository(localContext context)
            : base(context)
        {

        }

        public ResultadoVM Get()
        {
            
            var resultado = Query<ResultadoVM>(@"SELECT Count(Id) as JogosDisputados, SUM(Pontos) as TotalDePontos, Min(DataJogo) as DataInicio, Max(DataJogo) as DataFim,
                    Max(Pontos) as MaiorPontuacaoPorJogo, Min(Pontos) as MenorPontuacaoPorJogo, AVG(Pontos) as MediaPorJogo 
                    FROM dbo.Jogos");
            var modelVM = QueryList<RecordeVM>(@"SELECT TOP (1000) Pontos FROM dbo.Jogos ORDER BY DataJogo;");
            int recorde = (modelVM != null) ? modelVM.Select(x=>x.Pontos).FirstOrDefault() : 0;
            foreach (var item in modelVM)
            {
                if (item.Pontos > recorde)
                {
                    recorde = item.Pontos;
                    resultado.Recorde++;
                }
            }
            return resultado;
        }
    }
}
