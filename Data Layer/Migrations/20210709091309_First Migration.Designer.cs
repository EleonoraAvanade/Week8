﻿// <auto-generated />
using Data_Layer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Layer.Migrations
{
    [DbContext(typeof(FinalFantasyContext))]
    [Migration("20210709091309_First Migration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data_Layer.Models.Arma", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Danno")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPersonaggio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Armi");
                });

            modelBuilder.Entity("Data_Layer.Models.Eroe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Esperienza")
                        .HasColumnType("int");

                    b.Property<int>("Livello")
                        .HasColumnType("int");

                    b.Property<string>("NickUtente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idArma")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NickUtente");

                    b.HasIndex("idArma");

                    b.ToTable("Eroi");
                });

            modelBuilder.Entity("Data_Layer.Models.Mostro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idArma")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idArma");

                    b.ToTable("Mostri");
                });

            modelBuilder.Entity("Data_Layer.Models.Utente", b =>
                {
                    b.Property<string>("Nick")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Nick");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("Data_Layer.Models.Eroe", b =>
                {
                    b.HasOne("Data_Layer.Models.Utente", "utente")
                        .WithMany("eroi")
                        .HasForeignKey("NickUtente");

                    b.HasOne("Data_Layer.Models.Arma", "arma")
                        .WithMany("eroi")
                        .HasForeignKey("idArma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("arma");

                    b.Navigation("utente");
                });

            modelBuilder.Entity("Data_Layer.Models.Mostro", b =>
                {
                    b.HasOne("Data_Layer.Models.Arma", "arma")
                        .WithMany("mostri")
                        .HasForeignKey("idArma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("arma");
                });

            modelBuilder.Entity("Data_Layer.Models.Arma", b =>
                {
                    b.Navigation("eroi");

                    b.Navigation("mostri");
                });

            modelBuilder.Entity("Data_Layer.Models.Utente", b =>
                {
                    b.Navigation("eroi");
                });
#pragma warning restore 612, 618
        }
    }
}