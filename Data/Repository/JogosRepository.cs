using AppDemo.Models;
using AppDemo.ViewModels;
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
            resultado.Recorde = Query<int>(@"BEGIN
	                                            DECLARE @Recorde INT
	                                            SELECT @Recorde = (SELECT TOP (1) Pontos 
		                                            FROM dbo.Jogos  ORDER BY DataJogo);
	
	                                            SELECT COUNT(*) AS Recorde FROM 
                                                (SELECT Pontos FROM Jogos WHERE Pontos > @Recorde) Recorde
                                            END");
            return resultado;
        }
    }
}
