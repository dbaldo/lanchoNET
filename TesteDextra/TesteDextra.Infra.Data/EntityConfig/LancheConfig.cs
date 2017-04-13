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
    /// Configuração do entityframework para o Lanche
    /// </summary>
    public class LancheConfig : EntityTypeConfiguration<Lanche>
    {
        public LancheConfig()
        {
            HasKey(l => l.LancheID);

            Property(l => l.Nome)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
