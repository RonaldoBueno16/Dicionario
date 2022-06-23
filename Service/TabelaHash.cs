using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Dicionario.Service
{
    internal class TabelaHash
    {
        private ListaEncadeada[] tabela_hash = new ListaEncadeada[997];

        public void AddWord(string word)
        {
            int index = HashString(word.ToUpper());

            if (tabela_hash[index] == null) tabela_hash[index] = new ListaEncadeada();
            tabela_hash[index].Append(word);

            this.RegistrarPalavra(word);
        }

        private void RegistrarPalavra(string word)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Path.GetFullPath("palavras.txt"), append:true);
                sw.WriteLine(word);
                sw.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool exists(string word)
        {
            int index = HashString(word.ToUpper());

            if (tabela_hash[index] == null) return false;

            int slot = tabela_hash[index].GetIndexWord(word);

            return slot != -1;
        }

        private int HashString(string word)
        {
            int index = 0;

            byte[] caracteres = new byte[Encoding.ASCII.GetByteCount(word)];
            caracteres = Encoding.ASCII.GetBytes(word);
            foreach (byte caractere in caracteres)
                index += caractere;

            return index % 997;
        }

        public override string ToString()
        {
            string palavras = "";
            foreach(ListaEncadeada encadeada in tabela_hash)
            {
                if (encadeada == null) continue;

                palavras += encadeada.ToString();
            }
            return palavras;
        }
    }
}
