using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.DAL
{
    class LoginDalComandos
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool verificarLogin(String login, String senha)
        {
            // Verificar se o login existe no Banco de Dados
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }
                con.Desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com banco de dados!";
            }
            return tem;
        }

        public String cadastrar(String email, String senha, String confirmarSenha)
        {
            tem = false;

            // Verificar se o usuário já está cadastrado no banco de dados
            string query = "SELECT COUNT(*) FROM logins WHERE email = @email";
            using (SqlCommand command = new SqlCommand(query, con.Conectar()))
            {
                command.Parameters.AddWithValue("@email", email);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    con.Desconectar();
                    return "Este email já está cadastrado. Por favor, tente outro.";
                }
            }

            // Sem informações

            if (string.IsNullOrEmpty(email))
            {
                return "Por favor, informe o seu email.";
            }

            if (string.IsNullOrEmpty(senha))
            {
                return "Por favor, informe a sua senha.";
            }

            if (string.IsNullOrEmpty(confirmarSenha))
            {
                return "Por favor, confirme a sua senha.";
            }

            // Cadastrar usuário no banco de dados
            if (senha == confirmarSenha)
            {
                cmd.CommandText = "insert into logins values (@email, @senha)";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();
                    con.Desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro com Banco de Dados";
                }
            }
            else
            {
                this.mensagem = "As senhas não coincidem.";
            }
            return mensagem;
        }
    }
}
