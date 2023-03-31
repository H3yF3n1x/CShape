using MediaEscolar.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaEscolar.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";
        public bool acessar(String matricula, String senha)
        {
            Comandos comando = new Comandos();
            tem = comando.verificarLogin(matricula, senha);
            if (!comando.mensagem.Equals(""))
            {
                this.mensagem = comando.mensagem;
            }
            return tem;
        }

        public String cadastrar(String matricula, String senha, String confirmarSenha, bool isProfessor)
        {
            Comandos comando = new Comandos();
            this.mensagem = comando.cadastrar(matricula, senha, confirmarSenha, isProfessor);
            if (comando.tem)
            {
                return mensagem;
            }
            this.tem = true;
            return mensagem;
        }
        public int getTipoUsuario(string matricula)
        {
            int tipo = -1;
            try
            {
                Conexao con = new Conexao();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT tipo FROM logins WHERE matricula = @matricula";
                cmd.Parameters.AddWithValue("@matricula", matricula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    tipo = Convert.ToInt32(dr["tipo"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao buscar tipo de usuário: " + ex.Message;
            }
            finally
            {
                Conexao con = new Conexao();
                con.Close();
            }
            return tipo;
        }
    }
}
