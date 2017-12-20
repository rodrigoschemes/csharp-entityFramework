using csharp_entityFramework.DAO;
using csharp_entityFramework.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            EntidadesContext contexto = new EntidadesContext();

            PessoaFisica pf = new PessoaFisica()
            {
                Nome = "Guilherme",
                CPF = "123456",
                Senha = "123"
            };

            contexto.PessoasFisicas.Add(pf);

            PessoaJuridica pj = new PessoaJuridica()
            {
                Nome = "Alura",
                CNPJ = "789",
                Senha = "123"
            };

            contexto.PessoasJuridicas.Add(pj);

            contexto.SaveChanges();
        }

        private static void BuscaManyToManyLINQ()
        {
            EntidadesContext contexto = new EntidadesContext();

            Venda venda = contexto
                .Vendas
                .Include(v => v.ProdutoVenda)
                .ThenInclude(pv => pv.Produto)
                .FirstOrDefault(v => v.ID == 1);

            foreach (var pv in venda.ProdutoVenda)
            {
                Console.WriteLine(pv.Produto.Nome);
            }
            Console.ReadLine();
        }

        private static void CriaProdutoVenda()
        {
            EntidadesContext contexto = new EntidadesContext();
            UsuarioDAO dao = new UsuarioDAO();
            Usuario renan = dao.BuscaPorId(1);

            Venda v = new Venda()
            {
                Cliente = renan
            };

            Produto p = contexto.Produtos.FirstOrDefault(prod => prod.ID == 1);
            Produto p2 = contexto.Produtos.FirstOrDefault(prod => prod.ID == 2);

            ProdutoVenda pv = new ProdutoVenda()
            {
                Venda = v,
                Produto = p
            };

            ProdutoVenda pv2 = new ProdutoVenda()
            {
                Venda = v,
                Produto = p2
            };

            contexto.Vendas.Add(v);
            contexto.ProdutoVenda.Add(pv);
            contexto.ProdutoVenda.Add(pv2);

            contexto.SaveChanges();

            Console.ReadLine();
        }

        private static void BuscaProdutoDinamicaLINQ()
        {
            ProdutoDAO dao = new ProdutoDAO();
            var resultado = dao.BuscaPorNomePrecoCategoria(null, 0, "informatica");

            foreach (var p in resultado)
            {
                Console.WriteLine(p.Nome);
            }
            Console.ReadLine();
        }

        private static void BuscaProdutosCondicaoComplexaLINQ()
        {
            EntidadesContext contexto = new EntidadesContext();
            decimal precoMinimo = 60;
            string categoria = "Vestuário";

            var busca = from p in contexto.Produtos
                        where p.Categoria.Nome.ToUpper() == categoria.ToUpper() &&
                              p.Preco > precoMinimo
                        select p;
            IList<Produto> resultado = busca.ToList();
            foreach (var produto in resultado)
            {
                Console.WriteLine(produto.Nome + " - " + produto.Preco);
            }
            Console.ReadLine();
        }

        private static void BuscaProdutosCondicaoLINQ()
        {
            EntidadesContext contexto = new EntidadesContext();
            decimal precoMinimo = 60;

            var busca = from p in contexto.Produtos
                        where p.Preco > precoMinimo
                        select p;
            IList<Produto> resultado = busca.ToList();
            foreach (var produto in resultado)
            {
                Console.WriteLine(produto.Nome + " - " + produto.Preco);
            }
            Console.ReadLine();
        }

        private static void BuscaProdutosOrdemLINQ()
        {
            EntidadesContext contexto = new EntidadesContext();

            var busca = from p in contexto.Produtos
                        orderby p.Nome
                        select p;
            IList<Produto> resultado = busca.ToList();
            foreach (var produto in resultado)
            {
                Console.WriteLine(produto.Nome);
            }
            Console.ReadLine();
        }

        private static void BuscaProdutosLINQ()
        {
            EntidadesContext contexto = new EntidadesContext();

            var busca = from p in contexto.Produtos select p;
            IList<Produto> resultado = busca.ToList();

            foreach (var produto in resultado)
            {
                Console.WriteLine(produto.Nome);
            }
            Console.ReadLine();
        }

        private static void BuscaProdutosPorCategoria()
        {
            EntidadesContext contexto = new EntidadesContext();

            var categoria = contexto.Categorias.Include(c => c.Produtos).FirstOrDefault(c => c.ID == 1);

            foreach (var p in categoria.Produtos)
            {
                Console.WriteLine(p.Nome);
            }

            Console.ReadLine();
        }

        private static void BuscaProdutoECategoria()
        {
            EntidadesContext contexto = new EntidadesContext();

            Produto p = contexto
                .Produtos
                .Include(produto => produto.Categoria)
                .FirstOrDefault(produto => produto.ID == 1);

            Console.WriteLine($"Produto: {p.Nome} Categoria: {p.Categoria.Nome}");
            Console.ReadLine();
        }

        private static void CriaProdutoPorCategoriaID()
        {
            ProdutoDAO dao = new ProdutoDAO();

            Produto p = new Produto()
            {
                Nome = "Moletom",
                Preco = 150,
                CategoriaID = 2
            };

            Produto p1 = new Produto()
            {
                Nome = "Jaqueta",
                Preco = 200,
                CategoriaID = 2
            };

            dao.Adiciona(p);
            dao.Adiciona(p1);

            Console.ReadLine();
        }

        private static void CriaProdutoECategoria()
        {
            CategoriaDAO daoCategoria = new CategoriaDAO();
            ProdutoDAO daoProduto = new ProdutoDAO();

            Categoria c = new Categoria()
            {
                Nome = "Vestuário"
            };

            daoCategoria.Adiciona(c);

            Produto p = new Produto()
            {
                Nome = "Agasalho",
                Preco = 100,
                Categoria = c
            };

            daoProduto.Adiciona(p);

            Console.ReadLine();
        }

        private static void UsuarioCRUD()
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usu1 = new PessoaFisica()
            {
                Nome = "Rodrigo",
                Senha = "456"
            };

            dao.Salvar(usu1);
            Console.WriteLine($"salvou usuário...{usu1.Nome}");

            Usuario usu2 = dao.BuscaPorId(1);
            Console.WriteLine($"buscou usuário...{usu2.Nome}");

            Usuario usu3 = dao.BuscaPorId(8);
            dao.Remove(usu3);
            Console.WriteLine($"exclui usuário...{usu3.Nome}");

            Usuario usu4 = dao.BuscaPorId(1);
            usu4.Nome = "Renan Boga10";
            dao.SaveChanges();
            Console.WriteLine($"atualizou usuário...{usu4.Nome}");

            Console.ReadLine();
        }
    }
}
