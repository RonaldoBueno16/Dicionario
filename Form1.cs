using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Dicionario.Service;
using System.IO;

namespace Dicionario
{
    public partial class Form1 : Form
    {
        TabelaHash tabelaHash = new TabelaHash();

        public Form1()
        {
            InitializeComponent();
        }


        private void Change_visible(Label toBeChanged, bool visible) //ATUALIZA A VISIBILIDADE DA LABEL
        {
            toBeChanged.Visible = visible;
            toBeChanged.Refresh();
            return;
        }

        private void LabelInserirPalavra(object sender, EventArgs e)
        {
            
        }

        public void InserirPalavra(object sender, EventArgs e)
        {
            string palavra = textBox1.Text;

            if(palavra != "")
            {
                bool exists = this.tabelaHash.exists(palavra);

                if(exists)
                {
                    this.label1.Text = "A palavra já existe no dicionário!";
                    this.label1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string message = "Essa palavra não está no dicionário, deseja inseri-la?";
                    string caption = "Inserir palavra";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);
                    if(result == DialogResult.Yes)
                    {
                        this.AddWord(palavra);

                        this.label1.Text = "Palavra inserida com sucesso!";
                        this.label1.ForeColor = System.Drawing.Color.Green;
                    }
                    else if(result == DialogResult.No)
                    {
                        Change_visible(this.label1, false);
                        return;
                    }
                }

                Change_visible(this.label1, true);
            }
            else
            {
                this.label1.Text = "Você precisa digitar uma palavra!";
                this.label1.ForeColor = System.Drawing.Color.Red;

                Change_visible(this.label1, true);
            }
        }
  
        private void AddWord(string word, bool update = true)
        {
            this.tabelaHash.AddWord(word);
            this.AtualizarTexto();
        }

        private void AtualizarTexto()
        {
            this.label2.Text = tabelaHash.ToString();
            this.Change_visible(label2, true);
        }

        private void AbrirArquivo(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            DialogResult result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                string file = ofd.FileName;
                Console.WriteLine(file);
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    
                    foreach(string line in lines)
                    {
                        if(!tabelaHash.exists(line))
                            this.AddWord(line, false);
                    }

                    this.AtualizarTexto();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desenvolvido por Guilherme Rudio e Ronaldo Bueno");
        }

        public void labelSure(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
