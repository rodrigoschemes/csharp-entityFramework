using csharp_entityFramework.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework.DAO
{
    public class ProdutoDAO
    {
        private EntidadesContext ctx;

        public ProdutoDAO()
        {
            this.ctx = new EntidadesContext();
        }

        public void Adiciona(Produto p)
        {
            this.ctx.Produtos.Add(p);
            this.ctx.SaveChanges();
        }

        public void Remove(Produto p)
        {
            this.ctx.Produtos.Remove(p);
            this.ctx.SaveChanges();
        }

        public Produto BuscaPorId(int id)
        {
            return this.ctx.Produtos.FirstOrDefault(p => p.ID == id);
        }

        public IList<Produto> BuscaPorNomePrecoCategoria(string nome, decimal preco, string nomeCategoria)
        {
            var busca = from p in ctx.Produtos
                        select p;

            if (!String.IsNullOrEmpty(nome))
            {
                busca = busca.Where(p => p.Nome == nome);
            }

            if (preco > 0.0m)
            {
                busca = busca.Where(p => p.Preco == preco);
            }

            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                busca = busca.Where(p => p.Categoria.Nome == nomeCategoria);
            }

            return busca.ToList();
        }
    }
}
