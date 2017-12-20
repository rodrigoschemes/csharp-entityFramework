using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_entityFramework.Entidades
{
    public class PessoaJuridica : Usuario
    {
        public string CNPJ { get; set; }
    }
}
