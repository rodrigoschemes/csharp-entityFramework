using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using csharp_entityFramework;

namespace csharp_entityFramework.Migrations
{
    [DbContext(typeof(EntidadesContext))]
    [Migration("20171108182919_TipoPessoa")]
    partial class TipoPessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("csharp_entityFramework.Entidades.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaID");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.ProdutoVenda", b =>
                {
                    b.Property<int>("VendaID");

                    b.Property<int>("ProdutoID");

                    b.HasKey("VendaID", "ProdutoID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Usuario");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.Venda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.PessoaFisica", b =>
                {
                    b.HasBaseType("csharp_entityFramework.Entidades.Usuario");

                    b.Property<string>("CPF");

                    b.HasAnnotation("Relational:DiscriminatorValue", "PessoaFisica");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.PessoaJuridica", b =>
                {
                    b.HasBaseType("csharp_entityFramework.Entidades.Usuario");

                    b.Property<string>("CNPJ");

                    b.HasAnnotation("Relational:DiscriminatorValue", "PessoaJuridica");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.Produto", b =>
                {
                    b.HasOne("csharp_entityFramework.Entidades.Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.ProdutoVenda", b =>
                {
                    b.HasOne("csharp_entityFramework.Entidades.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");

                    b.HasOne("csharp_entityFramework.Entidades.Venda")
                        .WithMany()
                        .HasForeignKey("VendaID");
                });

            modelBuilder.Entity("csharp_entityFramework.Entidades.Venda", b =>
                {
                    b.HasOne("csharp_entityFramework.Entidades.Usuario")
                        .WithMany()
                        .HasForeignKey("ClienteID");
                });
        }
    }
}
