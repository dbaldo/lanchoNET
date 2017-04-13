using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;

namespace TesteDextra.Infra.Data.EntityConfig
{
    /// <summary>
    /// Configuração do entityframework para o IngredienteLanche
    /// </summary>
    public class IngredienteLancheConfig : EntityTypeConfiguration<IngredienteLanche>
    {
        public IngredienteLancheConfig()
        {
            HasKey(il => new { il.IngredienteID,il.LancheID });

            Property(il => il.Quantidade)
                .IsRequired();
            
            //Relacionamento Lanche
            HasRequired(il => il.Lanche)
                .WithMany(l => l.IngredientesLanche)
                .HasForeignKey(il => il.LancheID);
            //Relacionamento Ingrediente
            HasRequired(il => il.Ingrediente)
                .WithMany(i => i.IngredientesLanche)
                .HasForeignKey(il => il.IngredienteID);

        }
    }
}
