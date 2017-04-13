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
    /// Configuração do entityframework para o Ingrediente
    /// </summary>
    public class IngredienteConfig : EntityTypeConfiguration<Ingrediente>
    {
        public IngredienteConfig()
        {
            HasKey(i => i.IngredienteID);

            Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(150);
            Property(i => i.Valor)
                .IsRequired();

        }
    }
}
