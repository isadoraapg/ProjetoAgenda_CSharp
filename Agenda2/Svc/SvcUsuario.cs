using Agenda.Mdl;
using Agenda.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Svc
{
    internal class SvcUsuario
    {

        public static List<Usuarios> ListarUsuario()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (OracleConnection conn = new Conexao().AbrirConexao())
            {

                string sql = "SELECT id, email, nome, senha FROM usuario ORDER BY nome";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuarios usuario = new Usuarios
                        {
                            Id = dr.GetInt32(dr.GetOrdinal("id")),
                            Email = dr.GetString(dr.GetOrdinal("email")),
                            Nome = dr.GetString(dr.GetOrdinal("nome")),
                            Senha = dr.GetString(dr.GetOrdinal("senha"))
                        };

                        lista.Add(usuario);
                    }
                }

            }
            return lista;
        }

        public static void InserirUsuario(Usuarios usuario)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
                string sql = "INSERT INTO usuario (id, email, nome, senha) VALUES (seq_usuario_id.NEXTVAL, :email, :nome, :senha)";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = usuario.Email;
                    cmd.Parameters.Add(":nome", OracleDbType.Varchar2).Value = usuario.Nome;
                    cmd.Parameters.Add(":senha", OracleDbType.Varchar2).Value = usuario.Senha;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AtualizarUsuario(Usuarios usuario)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
                string sql = "UPDATE usuario SET nome = :nome, senha = :senha, email = :email WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":nome", OracleDbType.Varchar2).Value = usuario.Nome;
                    cmd.Parameters.Add(":senha", OracleDbType.Varchar2).Value = usuario.Senha;
                    cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = usuario.Email;
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = usuario.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletarUsuario(Usuarios usuario)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
                string sql = "DELETE FROM usuario WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = usuario.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
