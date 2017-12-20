using csharp_entityFramework.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework.DAO
{
    public class CategoriaDAO
    {
        private EntidadesContext ctx;

        public CategoriaDAO()
        {
            this.ctx = new EntidadesContext();
        }

        public void Adiciona(Categoria c)
        {
            this.ctx.Categorias.Add(c);
            this.ctx.SaveChanges();
        }

        public void Remove(Categoria c)
        {
            this.ctx.Categorias.Remove(c);
            this.ctx.SaveChanges();
        }

        public Categoria BuscaPorId(int id)
        {
            return this.ctx.Categorias.FirstOrDefault(c => c.ID == id);
        }
    }
}
