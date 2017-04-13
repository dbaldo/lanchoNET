using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Domain.Entities
{
    /// <summary>
    /// Representação da entidade Lanche
    /// </summary>
    public class Lanche
    {
        #region .:Construtores:.
        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public Lanche()
        {

        }
        #endregion
        #region .:Propriedades:.

        public int LancheID { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public double Preco { get; set; }
        [NotMapped]
        public IList<Ingrediente> Ingredientes { get; set; }
        public virtual ICollection<IngredienteLanche> IngredientesLanche { get; set; }

        #endregion
    }
}
