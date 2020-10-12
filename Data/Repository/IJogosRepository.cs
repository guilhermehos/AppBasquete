using AppDemo.Models;
using AppDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Data.Repository
{
    public interface IJogosRepository : IRepository<Jogos>
    {
        public ResultadoVM Get();
    }
}
