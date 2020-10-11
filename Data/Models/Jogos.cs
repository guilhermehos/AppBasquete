using System;
using System.Collections.Generic;

namespace AppDemo.Models
{
    public partial class Jogos
    {
        public int Id { get; set; }
        public DateTime? DataJogo { get; set; }
        public int? Pontos { get; set; }
    }
}
