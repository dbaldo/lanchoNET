using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;
using TesteDextra.VMMV;

namespace TesteDextra.Application.Interfaces
{
    /// <summary>
    /// Interface da Aplicação para o Lanche responsável pelo tratamento de dados e chamadas dos serviços para a controller
    /// </summary>
    public interface ILancheAppService :IAppServiceBase<Lanche>
    { 
        IList<LancheListViewModel> Cardapio();
        LancheListViewModel CalculaPrecoLanchePersonalizado(LancheListViewModel lanche);
        LancheIndex TrazObjetoTelaIncial();
    }
}
