//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace TesteDextra.VMMV
//{
//    public class LancheIndexViewModel
//    {
//        public LancheIndexViewModel(IList<LancheListViewModel> Lanchees)
//        {
//            Lanchees = Lanchees;
//        }
//        public int LancheID { get; set; }
//        public IList<LancheListViewModel> Lanchees { get; set; }

//        #region .:Componetes Auxiliares

//        public IList<SelectListItem> LancheesListItem
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
//                itens.AddRange(Lanchees.Select(x => new
//                SelectListItem
//                {
//                    Value = x.LancheID.ToString(),
//                    Text = x.Nome
//                }));
//                return itens;
//            }
//        }

//        #endregion
//    }
//}
