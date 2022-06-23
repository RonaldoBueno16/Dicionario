using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicionario.Model
{
    internal class Node
    {
        public Node proximo { get; set; }
        public string word { get; set; }

        public Node(string value)
        {
            this.word = value;
        }
    }
}
