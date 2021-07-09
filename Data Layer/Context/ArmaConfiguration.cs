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
            builder.HasData(
                new Arma
                {
                    id=1,
                    Nome="Ascia",
                    Danno=8,
                    TipoPersonaggio="Soldier"
                }, new Arma
                {
                    id = 2,
                    Nome = "Mazza",
                    Danno = 5,
                    TipoPersonaggio = "Soldier"
                },new Arma
                {
                    id = 3,
                    Nome = "Spada",
                    Danno = 10,
                    TipoPersonaggio = "Soldier"
                }, new Arma
                {
                    id = 4,
                    Nome = "Arco e frecce",
                    Danno = 8,
                    TipoPersonaggio = "Wizard"
                }, new Arma
                {
                    id = 5,
                    Nome = "Bacchetta",
                    Danno = 5,
                    TipoPersonaggio = "Wizard"
                }, new Arma
                {
                    id = 6,
                    Nome = "Bastone Magico",
                    Danno = 10,
                    TipoPersonaggio = "Wizard"
                }, new Arma
                {
                    id = 7,
                    Nome = "Arco",
                    Danno = 7,
                    TipoPersonaggio = "Ghost"
                }, new Arma
                {
                    id = 8,
                    Nome = "Clava",
                    Danno = 5,
                    TipoPersonaggio = "Ghost"
                }, new Arma
                {
                    id = 9,
                    Nome = "Divinazione",
                    Danno = 15,
                    TipoPersonaggio = "Lucifer"
                }, new Arma
                {
                    id = 10,
                    Nome = "Fulmine",
                    Danno = 10,
                    TipoPersonaggio = "Lucifer"
                }, new Arma
                {
                    id = 11,
                    Nome = "Tempesta",
                    Danno = 8,
                    TipoPersonaggio = "Lucifer"
                }, new Arma
                {
                    id = 12,
                    Nome = "Tempesta oscura",
                    Danno = 15,
                    TipoPersonaggio = "Lucifer"
                }
            );
        }
    }
}
