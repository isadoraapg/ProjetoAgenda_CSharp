using Agenda.Mdl;
using Agenda.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Svc
{
    public class SvcContato
    {
        public static List<Contato> ListarContato()
        {
            List<Contato> lista = new List<Contato>();
            
            using (OracleConnection conn = new Conexao().AbrirConexao())
            {
           
                string sql = "SELECT * FROM Contato";
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

    }
}

