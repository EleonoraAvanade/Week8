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
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.HasKey(k => k.Nick);
            builder.Property(k => k.Password).IsRequired().HasMaxLength(10);
            builder.HasMany(k => k.eroi);
        }
    }
}
