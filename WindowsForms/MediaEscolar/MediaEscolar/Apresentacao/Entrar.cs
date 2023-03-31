using MediaEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaEscolar.Apresentacao
{
    public partial class Entrar : Form
    {
        public Entrar()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txbMatricula.Text, txbSenha.Text);
            int tipoUsuario = controle.getTipoUsuario(txbMatricula.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (tipoUsuario == 1)
                    {
                        FormProfessor formProfessor = new FormProfessor(); 
                        formProfessor.Show();
                    }
                    else
                    {
                        BemVindo bv = new BemVindo(); 
                        bv.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Conta não encontrada. Verifique sua matrícula e sua senha", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
