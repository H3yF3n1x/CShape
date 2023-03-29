using SistemaDeLogin.DAL;
using SistemaDeLogin.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeLogin.Apresentacao
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void lblSenha_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.cadastrar(txtLogin.Text, txtSenha.Text, txtConfirmarSenha.Text);
            if (controle.tem)
            {
                MessageBox.Show(controle.mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
