 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Domain.Interfaces.Services;

namespace TesteDextra.Domain.Services
{
    /// <summary>
    /// Serviços responsável pela regra de negócio do LancheService
    /// </summary>
    public class LancheService : ServiceBase<Lanche>,ILancheService
    {
        #region .:Propriedades:.
        private readonly ILancheRepository _LancheRepository;
        private readonly IIngredienteRepository _IngredienteRepository;

        #endregion
        #region .:Consturoes:.
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public LancheService(ILancheRepository LancheRepository,
                             IIngredienteRepository IngredienteRepository)
            :base(LancheRepository)
        {
            _LancheRepository = LancheRepository;
            _IngredienteRepository = IngredienteRepository;
        }

        #endregion
        #region .:Métodos:.
        /// <summary>
        /// Retorna um lanche com seu preço calculado com desconto.
        /// </summary>
        public Lanche CalculaPrecoLanchePersonalizado(IList<IngredienteLanche> ingredientes)
        {
            var lanchePersonalizado = new Lanche()
            {
                Nome = "Personalizado",
                IngredientesLanche = ingredientes
            };
            IList<Lanche> lista = new List<Lanche>();
            lista.Add(lanchePersonalizado);
            lista = calculaPrecoEDesconto(lista);
            return lista.FirstOrDefault();

        }
        /// <summary>
        /// Retorna cadápio cadastrado no banco com o preços e descontos atualizados.
        /// </summary>
        public IList<Lanche> Cardapio()
        {
            IList<Lanche> lanches = _LancheRepository.GetAll().ToList();
            return calculaPrecoEDesconto(lanches);
        }
        #endregion
        #region .:Funções Auxiliares:.
        /// <summary>
        /// Calcula o preço de cada lanche
        /// </summary>
        private IList<Lanche> calculaPrecoDeCadaLanche(IList<Lanche> lanches)
        {
            //Busca igredientes do banco para ver preço atual
            var ingredientesNoBanco = _IngredienteRepository.GetAll();

            lanches.ToList().ForEach(l =>
            {
                //Inicia cálculo do preço zerado
                double preco = 0;
                //Perco igredientes do lanche calculando preco do lanche
                foreach (var il in l.IngredientesLanche)
                {
                    preco += il.Quantidade * ingredientesNoBanco.Where(i => i.IngredienteID == il.IngredienteID).Select(i => i.Valor).First();
                }
                //Quarda o preço do lanche na propriedade correspondente
                l.Preco = preco;
            });
            return lanches;
        }
        /// <summary>
        /// Aplica desconto em cima de lanches já com preços calculados
        /// </summary>
        private IList<Lanche> aplicaDescontoNosLanches(IList<Lanche> lanches)
        {
            lanches.ToList().ForEach(l =>
            {
                //Promoção 1 é light
                var temDescontoLight = ehLight(l);
                
                //Prmoção 2 Muita Carne
                var descontoMuitaCarne = valorDescontoMuitaCarne(l);
                
                //Prmoção 2 Muita Carne
                var descontoMuitoQuejo = valorDescontoMuitoQueijo(l);
                
                //Aplicar desconto muita carne
                l.Preco -= descontoMuitaCarne;

                //Aplicar desconto muito queijo
                l.Preco -= descontoMuitoQuejo;

                //Aplicar desconto light se tiver
                if (temDescontoLight)
                    l.Preco = l.Preco * 0.9;

            });
            

            return lanches;
        }
        /// <summary>
        /// Recebe uma lista de lanches e retorna a mesma com preço calculado já com desconto.
        /// </summary>
        private IList<Lanche> calculaPrecoEDesconto(IList<Lanche> lanches)
        {
            lanches = calculaPrecoDeCadaLanche(lanches);
            lanches = aplicaDescontoNosLanches(lanches);
            return lanches;
        }
        /// <summary>
        /// Verificar se um lanche é light se ele tiver alface e não tiver bacon
        /// </summary>
        private bool ehLight(Lanche lanche)
        {
            //Verifica se tem alface
            var temAlface = (lanche.IngredientesLanche.Where(x=>x.IngredienteID == 1).Count() > 0);
            //Verifica se não tem bacon
            var naoTemBanco = (lanche.IngredientesLanche.Where(x => x.IngredienteID == 2).Count() == 0);

            //Retorna true se o lanche tiver alface e não tiver bancon
            return (temAlface && naoTemBanco);
        }
        /// <summary>
        /// Devolve valor do desconto de um lanche pelo critério muita carne
        /// </summary>
        private double valorDescontoMuitaCarne(Lanche lanche)
        {
            //Calcula desconto da carne
            return calculadorDeDesconto(lanche, 3, 3);
        }
        /// <summary>
        /// Devolve valor do desconto de um lanche pelo critério muito queijo
        /// </summary>
        private double valorDescontoMuitoQueijo(Lanche lanche)
        {
            //Calcula desconto da carne
            return calculadorDeDesconto(lanche, 5, 3);
        }
        /// <summary>
        /// Calculador genérico para desconto por quantidade passando como parametro o Lanche, Id do Ingrediente a calcular o desconto, e a cada quantos um ficará de graça
        /// 
        /// </summary>
        private double calculadorDeDesconto(Lanche lanche,int IngredienteID,int DescontoACada)
        {
            //Busca preço atual do ingrediente
            double precoIngrediente = _IngredienteRepository.GetById(IngredienteID).Valor;

            //Valor desconto incia em zero
            double valorDesconto = 0;

            //Verificar se tem o ingrediente
            var temIngrediente = (lanche.IngredientesLanche.Where(x => x.IngredienteID == IngredienteID).Count() > 0);
            
            //CalculaDesconto só se tiver o igrediente no lanche
            if (temIngrediente)
            {
                //quantidade de carne que lanche tem
                int quantidadeIngrediente = lanche.IngredientesLanche.Where(x => x.IngredienteID == IngredienteID).Select(x => x.Quantidade).First();
                
                //quantidade de unidades que devem ser descontadas
                int quantidadeUnidadesDescontar = quantidadeIngrediente / DescontoACada;
                
                //calcula desconto final
                valorDesconto = precoIngrediente * quantidadeUnidadesDescontar;
            }
            return valorDesconto;
        }
        #endregion
    }
}
