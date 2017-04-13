using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteDextra.Domain.Interfaces.Repositories;
using Moq;
using TesteDextra.Domain.Services;
using TesteDextra.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TesteDextra.Domain.Test
{
    [TestClass]
    public class LancheTest
    {
        #region.:Variáveis:.
        private Mock<ILancheRepository> mockLancheRepository;
        private Mock<IIngredienteRepository> mockIngredienteRepository;
        private LancheService lancheService;
        #endregion

        #region .:Listas para Mockar

        /// <summary>
        /// Traz todos os Ingredientes de forma virtual
        /// </summary>
        private List<Ingrediente> Ingredientes_GetAll()
        {
            return new List<Ingrediente>()
            {
                new Ingrediente() { IngredienteID = 1,Descricao = "Alface",Valor = 0.4} ,
                new Ingrediente() { IngredienteID = 2,Descricao = "Bacon",Valor = 2} ,
                new Ingrediente() { IngredienteID = 3,Descricao = "Hamburgue de carne",Valor = 3} ,
                new Ingrediente() { IngredienteID = 4,Descricao = "Ovo",Valor = 0.8} ,
                new Ingrediente() { IngredienteID = 5,Descricao = "Queijo",Valor = 1.5} 
            };
        }
        /// <summary>
        /// Traz todos os Lanches de forma virtual
        /// </summary>
        private List<Lanche> Lanches_GetAll()
        {
            return new List<Lanche>()
            {
                new Lanche() { LancheID = 1,Nome = "X-Bacon",Preco = 0,
                IngredientesLanche = new List<IngredienteLanche>()
                {
                    new IngredienteLanche() {LancheID = 1,Quantidade = 1,IngredienteID = 2 },
                    new IngredienteLanche() {LancheID = 1,Quantidade = 1,IngredienteID = 3 },
                    new IngredienteLanche() {LancheID = 1,Quantidade = 1,IngredienteID = 5 }
                }},
                new Lanche() { LancheID = 2,Nome = "X-Burger",Preco = 0,
                IngredientesLanche = new List<IngredienteLanche>()
                {
                    new IngredienteLanche() {LancheID = 2,Quantidade = 1,IngredienteID = 3 },
                    new IngredienteLanche() {LancheID = 2,Quantidade = 1,IngredienteID = 5 }
                }},
                new Lanche() { LancheID = 3,Nome = "X-Egg",Preco = 0,
                IngredientesLanche = new List<IngredienteLanche>()
                {
                    new IngredienteLanche() {LancheID = 3,Quantidade = 1,IngredienteID = 3 },
                    new IngredienteLanche() {LancheID = 3,Quantidade = 1,IngredienteID = 4 },
                    new IngredienteLanche() {LancheID = 3,Quantidade = 1,IngredienteID = 5 }
                }},
                new Lanche() { LancheID = 4,Nome = "X-Egg Bacon",Preco = 0,
                IngredientesLanche = new List<IngredienteLanche>()
                {
                    new IngredienteLanche() {LancheID = 4,Quantidade = 1,IngredienteID = 2 },
                    new IngredienteLanche() {LancheID = 4,Quantidade = 1,IngredienteID = 3 },
                    new IngredienteLanche() {LancheID = 4,Quantidade = 1,IngredienteID = 4 },
                    new IngredienteLanche() {LancheID = 4,Quantidade = 1,IngredienteID = 5 }
                }}
            };
        }
        /// <summary>
        ///Simula buscar lanche por id
        /// </summary>
        private Ingrediente Ingredientes_GetByID(int id)
        {
            return Ingredientes_GetAll().Where(x => x.IngredienteID == id).FirstOrDefault();
        }

        #endregion

        #region .:Setup:.
        /// <summary>
        /// Configuração incial onde se faz os Mock do repositório
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            //Instancia os mocks
            mockLancheRepository = new Mock<ILancheRepository>();
            mockIngredienteRepository = new Mock<IIngredienteRepository>();

            //Mock para ingredientes
            mockIngredienteRepository.Setup(i => i.GetAll()).Returns(Ingredientes_GetAll());
            for (int cont = 1; cont <= 5; cont++)
                mockIngredienteRepository.Setup(i => i.GetById(cont)).Returns(Ingredientes_GetByID(cont));

            //Mock para lanches
            mockLancheRepository.Setup(l => l.GetAll()).Returns(Lanches_GetAll());

            //Instancia da camada de serviço
            lancheService = new LancheService(mockLancheRepository.Object, mockIngredienteRepository.Object);
        }

        #endregion
        
        #region .:Testes:.
        [TestMethod]
        public void Preco_Do_Cardapio_Esta_Certo()
        {
            var lanches = lancheService.Cardapio();

            //Verifica X-Bacon
            VerificarPreco(lanches.Where(x => x.LancheID == 1).First(), 6.5);
            //Verifica X-Burguer
            VerificarPreco(lanches.Where(x => x.LancheID == 2).First(), 4.5);
            //Verifica X-Egg
            VerificarPreco(lanches.Where(x => x.LancheID == 3).First(), 5.3);
            //Verifica X-Egg Bacon
            VerificarPreco(lanches.Where(x => x.LancheID == 4).First(), 7.3);

        }

        [TestMethod]
        public void Desconto_Light_Esta_Certo()
        {
            var lanche = lancheService.CalculaPrecoLanchePersonalizado(IngredientesLancheLight());
            VerificarPreco(lanche, 5.13);
        }

        [TestMethod]
        public void Desconto_Mais_Carne_Esta_Certo()
        {
            var lanche = lancheService.CalculaPrecoLanchePersonalizado(IngredientesMuitaCarne());
            VerificarPreco(lanche, 20.3);
        }

        [TestMethod]
        public void Desconto_Mais_Queijo_Esta_Certo()
        {
            var lanche = lancheService.CalculaPrecoLanchePersonalizado(IngredientesMuitoQueijo());
            VerificarPreco(lanche, 11.3);
        }

        [TestMethod]
        public void Desconto_Mais_Carne_E_Mais_Queijo_Esta_Certo()
        {
            var lanche = lancheService.CalculaPrecoLanchePersonalizado(IngredientesMuitaCarneEMuitoQueijo());
            VerificarPreco(lanche, 31.3);
        }

        [TestMethod]
        public void Desconto_Mais_Carne_E_Mais_Queijo_E_Light_Esta_Certo()
        {
            var lanche = lancheService.CalculaPrecoLanchePersonalizado(IngredientesMuitaCarneEMuitoQueijoELight());
            VerificarPreco(lanche, 26.73);
        }

        #endregion

        #region .: Funções Auxililares

        private void VerificarPreco(Lanche lanche, double prechoCerto)
        {
            var precoEstaCerto = (Math.Round(lanche.Preco,2) == prechoCerto);
            Assert.IsTrue(precoEstaCerto);
        }
        private List<IngredienteLanche> IngredientesLancheLight()
        {
            return new List<IngredienteLanche>()
                {
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 1,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 3,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 4,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 5,
                       Quantidade = 1
                   }
                };
        }
        private List<IngredienteLanche> IngredientesMuitaCarne()
        {
            return new List<IngredienteLanche>()
                {
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 3,
                       Quantidade = 8
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 4,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 5,
                       Quantidade = 1
                   }
                };
        }
        private List<IngredienteLanche> IngredientesMuitoQueijo()
        {
            return new List<IngredienteLanche>()
                {
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 3,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 4,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 5,
                       Quantidade = 7
                   }
                };
        }
        private List<IngredienteLanche> IngredientesMuitaCarneEMuitoQueijo()
        {
            return new List<IngredienteLanche>()
                {
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 2,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 3,
                       Quantidade = 10
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 4,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 5,
                       Quantidade = 7
                   }
                };
        }
        private List<IngredienteLanche> IngredientesMuitaCarneEMuitoQueijoELight()
        {
            return new List<IngredienteLanche>()
                {
                    new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 1,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 3,
                       Quantidade = 10
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 4,
                       Quantidade = 1
                   },
                   new IngredienteLanche()
                   {
                       LancheID = 5,
                       IngredienteID = 5,
                       Quantidade = 7
                   }
                };
        }
        
        #endregion


    }
}
