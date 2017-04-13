using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;

namespace TesteDextra.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface do Serviços responsável pela regra de negócio do Lanche
    /// </summary>
    public interface ILancheService : IServiceBase<Lanche>
    {
        IList<Lanche> Cardapio();
        Lanche CalculaPrecoLanchePersonalizado(IList<IngredienteLanche> igredientes);
    }
   
}
