using AppDemo.Models;

namespace AppDemo.Data.Repository
{
    public class JogosRepository : Repository<Jogos>, IJogosRepository
    {
        public JogosRepository(localContext context)
            : base(context)
        {

        }
    }
}
