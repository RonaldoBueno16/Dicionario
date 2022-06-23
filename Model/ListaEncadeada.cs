using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicionario.Model
{
    internal class ListaEncadeada
    {
        public Node primeiro { get; set; }
        public Node ultimo { get; set; }
        public int tamanho { get; set; }

        public ListaEncadeada()
        {
            this.tamanho = 0;
            this.primeiro = null;
            this.ultimo = null;
        }
    }
}
