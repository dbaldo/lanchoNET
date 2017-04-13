using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.VMMV
{
    public class LancheListViewModel
    {
        #region .:Propriedades:.

        [DisplayName("Código")]
        public int LancheID { get; set; }
        public string Nome { get; set; }
        [DisplayName("Preço em R$ ")]
        public double Preco { get; set; }
        public virtual ICollection<IngredienteLancheListViewModel> IngredientesLanche { get; set; }

        #endregion


    }
}
