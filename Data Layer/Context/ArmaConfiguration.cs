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
    public class ArmaConfiguration : IEntityTypeConfiguration<Arma>
    {
        public void Configure(EntityTypeBuilder<Arma> builder)
        {
            builder.HasKey(k => k.id);
            builder.Property(k => k.Nome).IsRequired();
            builder.Property(k => k.Danno).IsRequired();
            builder.Property(k => k.TipoPersonaggio).IsRequired();
        }
    }
}
