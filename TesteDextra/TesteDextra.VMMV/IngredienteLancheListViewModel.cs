using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.VMMV
{
    public class IngredienteLancheListViewModel
    {
        public int IngredienteID { get; set; }
        public int LancheID { get; set; }
        public int Quantidade { get; set; }
        public virtual IngredienteListViewModel Ingrediente { get; set; }
    }
}
