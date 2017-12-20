using csharp_entityFramework.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework.DAO
{
    public class UsuarioDAO
    {
        private EntidadesContext ctx;

        public UsuarioDAO()
        {
            this.ctx = new EntidadesContext();
        }
        public void Salvar(Usuario u)
        {
            this.ctx.Usuarios.Add(u);
            this.ctx.SaveChanges();
        }

        public void SaveChanges()
        {
            ctx.SaveChanges();
        }

        public Usuario BuscaPorId(int id)
        {
            return this.ctx.Usuarios.FirstOrDefault(u => u.ID == id);
        }

        public void Remove(Usuario u)
        {
            this.ctx.Usuarios.Remove(u);
            this.ctx.SaveChanges();
        }
    }
}
