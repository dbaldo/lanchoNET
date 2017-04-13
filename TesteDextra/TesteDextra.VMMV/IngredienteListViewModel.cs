using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TesteDextra.VMMV
{
    public class IngredienteListViewModel
    {
        public int IngredienteID { get; set; }
        [DisplayName("Descrição ")]
        public string Descricao { get; set; }
        [DisplayName("Preço em R$ ")]
        public double Valor { get; set; }
        
    }
}
