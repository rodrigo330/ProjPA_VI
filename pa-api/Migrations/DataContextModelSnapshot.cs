﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pa_api.Data;

namespace pa_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("pa_api.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("Date");

                    b.Property<string>("Nome");

                    b.Property<int>("livrosDoados");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("pa_api.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlunoID");

                    b.Property<DateTime>("Data_Da_Doacao")
                        .HasColumnType("Date");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("AlunoID");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("pa_api.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("pa_api.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MarcaId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("pa_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("pa_api.Models.Livro", b =>
                {
                    b.HasOne("pa_api.Models.Aluno", "Aluno")
                        .WithMany("Livros")
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("pa_api.Models.Produto", b =>
                {
                    b.HasOne("pa_api.Models.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("MarcaId");
                });
#pragma warning restore 612, 618
        }
    }
}
