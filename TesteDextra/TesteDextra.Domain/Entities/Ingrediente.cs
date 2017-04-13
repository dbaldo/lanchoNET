using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Domain.Entities
{
    /// <summary>
    /// Representação da entidade Ingrediente
    /// </summary>
    public class Ingrediente
    {
        #region .:Construtores:.
        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public Ingrediente()
        {

        }
        #endregion
        #region .:Propriedades:.

        public int IngredienteID { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public virtual ICollection<IngredienteLanche> IngredientesLanche { get; set; }
        #endregion
    }
}
