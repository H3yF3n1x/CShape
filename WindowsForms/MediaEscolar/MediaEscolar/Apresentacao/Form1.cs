using MediaEscolar.Apresentacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaEscolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Entrar entrar = new Entrar();
            entrar.Show();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            Cadastro cadastrar = new Cadastro();
            cadastrar.Show();
        }
    }
}
