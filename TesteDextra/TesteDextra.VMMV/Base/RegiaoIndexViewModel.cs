//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace TesteDextra.VMMV
//{
//    /// <summary>
//    /// View Model Responsável por tipar a tela de cadastro de Regiões
//    /// </summary>
//    public class IngredienteIndexViewModel
//    {
//        #region .:Construtores:.
//        /// <summary>
//        /// Construtor para instânciar as listas
//        /// </summary>
//        public IngredienteIndexViewModel(IList<IngredienteLancheListViewModel> IngredienteLanches)
//        {
//            IngredienteLanches = IngredienteLanches;
//            Inclusao = true;
//        }
//        #endregion
//        #region .:Propriedades:.
//        public int IngredienteID { get; set; }
//        public bool Inclusao { get; set; }
//        [Required(ErrorMessage = "O campo IngredienteLanche é obrigatório")]
//        [DisplayName("UF")]
//        public int IngredienteLancheID { get; set; }
//        [Required(ErrorMessage = "O campo descrição é obrigatório")]
//        [DisplayName("Descrição")]
//        //[Remote("ExisteIngredienteCadastrada","Ingrediente",AdditionalFields = "IngredienteID",HttpMethod ="POST",ErrorMessage ="Essa região já está cadastrada")]
//        public string Descricao { get; set; }
//        public IList<IngredienteLancheListViewModel> IngredienteLanches { get; set;}
//        #endregion
//        #region .:Componetes Auxiliares

//        public IList<SelectListItem> IngredienteLancheListItem
//        {
//            get
//            {
//                var itens = new List<SelectListItem>();
//                itens.Add(new SelectListItem
//                {
//                    Value = "null",
//                    Text = "::Selecione::",
//                    Selected = true
//                });
//                itens.AddRange(IngredienteLanches.Select(x => new
//                SelectListItem
//                {
//                    Value = x.IngredienteLancheID.ToString(),
//                    Text = x.Descricao
//                }));
//                return itens;
//            }
//        }

//        #endregion
//    }
//}
