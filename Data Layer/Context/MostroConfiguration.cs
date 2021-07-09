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
    public class MostroConfiguration : IEntityTypeConfiguration<Mostro>
    {
        Random r = new Random();
        public void Configure(EntityTypeBuilder<Mostro> builder)
        {
            builder.HasKey(k => k.id);
            builder.Property(k => k.Categoria).IsRequired();
            builder.HasOne(k => k.arma).WithMany(c => c.mostri).HasForeignKey(k => k.idArma);
            builder.HasData(
                new Mostro
                {
                    id = 1,
                    Categoria = "Lucifer",
                    idArma = r.Next(9, 12)
                },
                new Mostro
                {
                    id = 2,
                    Categoria = "Ghost",
                    idArma = r.Next(7, 8)
                }
            ); 
        }
    }
}
