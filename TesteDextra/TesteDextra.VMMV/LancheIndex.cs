using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.VMMV
{
    public class LancheIndex
    {
        public IList<LancheListViewModel> Cardapio { get; set; }
        public IList<IngredienteListViewModel> Ingredientes { get; set; }
    }
}
