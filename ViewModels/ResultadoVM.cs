using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.ViewModels
{
    public class ResultadoVM
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int JogosDisputados { get; set; }
        public int TotalDePontos { get; set; }
        public int MediaPorJogo { get; set; }
        public int MaiorPontuacaoPorJogo { get; set; }
        public int MenorPontuacaoPorJogo { get; set; }
        public int Recorde { get; set; }
    }
}
