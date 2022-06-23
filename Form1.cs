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

namespace Dicionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Change_visible(Label toBeChanged) //ATUALIZA A VISIBILIDADE DA LABEL
        {
            if (toBeChanged.Visible == false)
            {
                toBeChanged.Visible = true;
                toBeChanged.Refresh();
                return;
            }
            if (toBeChanged.Visible == true)
            {
                toBeChanged.Visible = false;
                toBeChanged.Refresh();
                return;
            }
        }

        private void LabelInserirPalavra(object sender, EventArgs e)
        {
            
        }

        public void InserirPalavra(object sender, EventArgs e)
        {
            Debug.WriteLine("Voce clicou em inserir palavra");
            string gravarPalavra = textBox1.ToString();
            MessageBox.Show(gravarPalavra);

            //Label 1 - PALAVRA ADICIONADA COM SUCESSO
            // LABEL 2 - PALAVRA JA EXISTE NO DICIONARIO
            //LABEL 3 - VALOR NULO
            Debug.WriteLine(" - "+gravarPalavra);
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                Change_visible(label3);
            }
            else
            {
                Change_visible(label2);
            }
        }
  

        private void AbrirArquivo(object sender, EventArgs e)
        {
            MessageBox.Show("Arquivo abrindo");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feito por Guilherme Rudio e Ronaldo Bueno");
        }

        public void labelSure(object sender, EventArgs e)
        {


        }
    }
}
