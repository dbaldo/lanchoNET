using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Domain.Entities
{
    /// <summary>
    /// Representação da entidade IngredienteLanche
    /// </summary>
    public class IngredienteLanche
    {
        #region .:Construtores:.
        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public IngredienteLanche()
        {

        }
        #endregion
        #region .:Propriedades:.
        public int IngredienteID { get; set; }
        public int LancheID { get; set; }
        public int Quantidade { get; set; }
        public virtual Lanche Lanche { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        #endregion
    }
}
