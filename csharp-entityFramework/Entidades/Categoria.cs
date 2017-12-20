using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework.Entidades
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public IList<Produto> Produtos { get; set; }

    }
}
