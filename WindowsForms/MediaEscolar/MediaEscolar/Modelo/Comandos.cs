using MediaEscolar.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaEscolar.Modelo
{
    class Comandos
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;


        public bool verificarLogin(String matricula, String senha)
        {
            // Verificar se o login existe no Banco de Dados
            cmd.CommandText = "select * from logins where matricula = @matricula and senha = @senha";
            cmd.Parameters.AddWithValue("@matricula", matricula);
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

        public string cadastrar(String matricula, String senha, String confirmarSenha, bool isProfessor)
        {
            tem = false;
            int tipoUsuario = isProfessor ? 1 : 0; // 1 para professor, 0 para aluno

            // Verificar se o usuário já está cadastrado no banco de dados
            string query = "SELECT COUNT(*) FROM logins WHERE matricula = @matricula AND tipo = @tipoUsuario";
            using (SqlCommand command = new SqlCommand(query, con.Conectar()))
            {
                command.Parameters.AddWithValue("@matricula", matricula);
                command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                int count = (int)command.ExecuteScalar();

                // Verificando se a matrícula existe no banco de dados
                if (count == 0)
                {
                    con.Desconectar();
                    this.mensagem = "Matrícula não encontrada. O aluno deve entrar em contato com a escola.";
                    return mensagem;
                }

                if (string.IsNullOrEmpty(matricula))
                {
                    return "Por favor, informe a sua senha.";
                }

                if (string.IsNullOrEmpty(senha))
                {
                    return "Por favor, informe a sua senha.";
                }

                if (string.IsNullOrEmpty(confirmarSenha))
                {
                    return "Por favor, confirme a sua senha.";
                }

                // Atualizar senha do usuário no banco de dados
                if (senha == confirmarSenha)
                {
                    query = "UPDATE logins SET senha = @senha WHERE matricula = @matricula AND tipo = @tipoUsuario";
                    using (SqlCommand updateCommand = new SqlCommand(query, con.Conectar()))
                    {
                        updateCommand.Parameters.AddWithValue("@matricula", matricula);
                        updateCommand.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                        updateCommand.Parameters.AddWithValue("@senha", senha);

                        try
                        {
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                this.mensagem = "Cadastro realizado com sucesso!";
                                tem = true;
                            }
                            else
                            {
                                this.mensagem = "Erro ao atualizar a senha.";
                            }
                        }
                        catch (SqlException)
                        {
                            this.mensagem = "Erro com Banco de Dados";
                        }
                    }
                }
                else
                {
                    this.mensagem = "As senhas não coincidem.";
                }

                con.Desconectar();
                return mensagem;
            }
        }
    }
}


