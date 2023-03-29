using SistemaDeLogin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";
        public bool acessar(String login, String senha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            tem = loginDal.verificarLogin(login, senha);
            if (!loginDal.mensagem.Equals(""))
            {
                this.mensagem = loginDal.mensagem;
            }
            return tem;
        }

        public String cadastrar(String email, String senha, String confirmarSenha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            this.mensagem = loginDal.cadastrar(email, senha, confirmarSenha);
            if (loginDal.tem)
            {
                return mensagem;
            }
            this.tem = true;
            return mensagem;
        }
    }
}
