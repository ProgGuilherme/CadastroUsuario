using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ClsConexao
    {
        protected MySqlConnection Conexao;
        protected MySqlCommand Comando;
        protected MySqlDataReader Reader;

        protected string DadosConexao()
        {            
            /*
            string db_Server = "#";
            string db_Port = "#";
            string db_UID = "#";
            string db_PWD = "#";
            string db_Database = "#";
            */
            string strinConexao = "server=" + db_Server + ";port=" + db_Port + ";uid=" + db_UID + ";pwd=" + db_PWD + ";database=" + db_Database + "";
            return strinConexao;

        }
        protected void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection();
                Conexao.ConnectionString = DadosConexao();
                Conexao.Open();
            }
            catch (Exception er)
            {
                throw new Exception("ERRO AO ABRIR CONEXAO..." + er.Message);
            }
        }
        protected void FecharConexao()
        {
            try
            {
                Conexao.Dispose();
                Conexao.Close();
            }
            catch (Exception er)
            {
                throw new Exception("ERRO AO FECHAR CONEXAO..." + er.Message);
            }
        }
    }
}
