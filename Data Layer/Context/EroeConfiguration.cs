using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Context
{
    public class EroeConfiguration: IEntityTypeConfiguration<Eroe>
     {
        public void Configure(EntityTypeBuilder<Eroe> builder)
        {
            builder.HasKey(k => k.id);
            builder.Property(k => k.Categoria).IsRequired();
            builder.Property(k => k.Nome).IsRequired();
            builder.Property(k => k.Esperienza).IsRequired();
            builder.Property(k => k.Livello).IsRequired();
            builder.HasOne(k => k.utente).WithMany(c => c.eroi).HasForeignKey(k => k.NickUtente);
            builder.HasOne(k => k.arma).WithMany(c => c.eroi).HasForeignKey(k => k.idArma);
        }
    }
}
