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
    internal class SvcContato
    {
        public static List<Contato> ListarContato()
        {
            List<Contato> lista = new List<Contato>();
            
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
           
                string sql = "SELECT id, nome, email, telefone FROM Contato ORDER BY nome";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contato contato = new Contato
                        {
                            Id = dr.GetInt32(dr.GetOrdinal("Id")),
                            Nome = dr.GetString(dr.GetOrdinal("Nome")),
                            Email = dr.GetString(dr.GetOrdinal("Email")),
                            Telefone = dr.GetString(dr.GetOrdinal("Telefone"))
                        };

                        lista.Add(contato);
                    }
                }
               
            }
                return lista;
        }

        public static void InserirContato(Contato contato)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {           
                string sql = "INSERT INTO contato (id, nome, email, telefone) VALUES (seq_contato_id.NEXTVAL, :nome, :email, :telefone)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":nome", OracleDbType.Varchar2).Value = contato.Nome;
                    cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = contato.Email;
                    cmd.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = contato.Telefone;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AtualizarContato(Contato contato)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {        
                string sql = "UPDATE contato SET nome = :nome, email = :email, telefone = :telefone WHERE id = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":nome", OracleDbType.Varchar2).Value = contato.Nome;
                    cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = contato.Email;
                    cmd.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = contato.Telefone;
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = contato.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletarContato(Contato contato)
        {
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
                string sql = "DELETE FROM contato WHERE id = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = contato.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

