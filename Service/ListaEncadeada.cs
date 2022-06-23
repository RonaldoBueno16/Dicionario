using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicionario.Model;

namespace Dicionario.Service
{
    internal class ListaEncadeada : Model.ListaEncadeada
    {
        public void InsertNode(Node node)
        {
            if (this.tamanho == 0)
                this.primeiro = node;
            else
                this.ultimo.proximo = node;

            this.tamanho++;
            this.ultimo = node;
        }

        public int Length()
        {
            return this.tamanho;
        }

        public void Append(string word)
        {
            Node node = new Node(word);

            this.InsertNode(node);
        }

        public bool Remove(int index)
        {
            var no = this.primeiro;
            var no_anterior = no;
            for (int i = 0; i < this.tamanho; i++)
            {
                if (i == index)
                {
                    if (i == 0 && tamanho == 1)
                        this.primeiro = this.ultimo = no = null;
                    else if (i == 0)
                    {
                        var no_zerar = no;
                        no = no.proximo;
                        this.primeiro = no;
                        no_zerar = null;
                    }
                    else
                    {
                        var no_zerar = no;
                        no = no.proximo;
                        no_anterior.proximo = no;
                        no_zerar = null;
                    }
                    tamanho--;
                    return true;
                }
                else
                {
                    if (no.proximo == null)
                        return false;
                    no_anterior = no;
                    no = no.proximo;
                }
            }
            return false;
        }
        public bool SetValueForNode(int index, string word)
        {
            var no = this.primeiro;
            for (int i = 0; i < this.tamanho; i++)
            {
                if (i == index)
                {
                    no.word = word;
                    return true;
                }
                else
                    no = no.proximo;
            }
            return false;
        }

        public int GetIndexWord(string word, bool ignore_case = true)
        {
            if (ignore_case)
                word = word.ToUpper();

            var no = this.primeiro;

            if (no == null) return -1;

            int count = 0;
            int index = -1;

            while (true)
            {
                if (no == null)
                    break;

                string word_compare = ignore_case ? (no.word.ToUpper()) : (no.word);

                if (word == word_compare)
                {
                    index = count;
                    break;
                }

                no = no.proximo;
                count++;
            }

            return index;
        }

        public override string ToString()
        {
            string retornar = "[ ";

            var no = this.primeiro;

            if (no != null)
            {
                while (true)
                {
                    retornar += no.word + " ";

                    no = no.proximo;
                    if (no == null)
                        break;
                }
            }
            retornar += "]";

            return retornar;
        }
    }
}
