using DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cadastro.Models
{
    public class ClsUsuario : ClsConexao
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Favor informar o campo nome")]
        [StringLength(50, ErrorMessage = "Tamanho maxímo excedido, de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Favor Digitar o e-mial")]
        [Required(ErrorMessage = "Favor informar o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Favor informar a date de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Favor inserir seu login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Favor inserir sua senha")]
        public string Senha { get; set; }
        public List<ClsUsuario> ListaUsuario { get; set; }

        public string Grava(ClsUsuario objUsuario)
        {
            string erro = string.Empty;
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand();
                Comando.Connection = Conexao;
                Comando.Parameters.AddWithValue("@1", objUsuario.Nome);
                Comando.Parameters.AddWithValue("@2", objUsuario.Email);
                Comando.Parameters.AddWithValue("@3", objUsuario.DtNascimento);
                Comando.Parameters.AddWithValue("@4", objUsuario.Login);
                Comando.Parameters.AddWithValue("@5", objUsuario.Senha);
                Comando.CommandText = "INSERT INTO `TbUsuario`(`Nome`, `Email`, `DtNascimento`, `Login`, `Senha`) VALUES (@1,@2,@3,@4,@5)";
                Comando.ExecuteNonQuery();
                return erro;

            }
            catch (Exception er)
            {
                return erro = new Exception("ERRO AO GRAVAR USUÁRIO NO BANCO DE DADOS..." + er.Message).ToString();
            }
            finally
            {
                FecharConexao();
            }
        }
        public string Editar(ClsUsuario objUsuario)
        {
            string erro = string.Empty;
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand();
                Comando.Connection = Conexao;
                Comando.Parameters.AddWithValue("@1", objUsuario.IdUsuario);
                Comando.Parameters.AddWithValue("@2", objUsuario.Nome);
                Comando.Parameters.AddWithValue("@3", objUsuario.Email);
                Comando.Parameters.AddWithValue("@4", objUsuario.DtNascimento);
                Comando.Parameters.AddWithValue("@5", objUsuario.Login);
                Comando.Parameters.AddWithValue("@6", objUsuario.Senha);
                Comando.CommandText = "UPDATE `TbUsuario` SET `Nome`= @2,`Email`= @3,`DtNascimento`= @4,`Login`= @5,`Senha`= @6 WHERE `IdUsuario`= @1";
                Comando.ExecuteNonQuery();
                return erro;

            }
            catch (Exception er)
            {
                return erro = new Exception("ERRO AO EDITAR USUÁRIO NO BANCO DE DADOS..." + er.Message).ToString();
            }
            finally
            {
                FecharConexao();
            }
        }
        public string Excluir(int idUsuario)
        {
            string erro = string.Empty;
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand();
                Comando.Connection = Conexao;
                Comando.Parameters.AddWithValue("@1", idUsuario);
                Comando.CommandText = "DELETE FROM `TbUsuario` WHERE `IdUsuario`= @1";
                Comando.ExecuteNonQuery();
                return erro;

            }
            catch (Exception er)
            {
                return erro = new Exception("ERRO AO EXCLUIR USUÁRIO NO BANCO DE DADOS..." + er.Message).ToString();
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<ClsUsuario> BusaLIstaUsuario()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand();
                Comando.Connection = Conexao;
                Comando.CommandText = "SELECT `IdUsuario`, `Nome`, `Email`, `DtNascimento`, `Login` FROM `TbUsuario`";
                Reader = Comando.ExecuteReader();
                ClsUsuario objUsuario = null;
                ListaUsuario = new List<ClsUsuario>();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        objUsuario = new ClsUsuario();
                        objUsuario.IdUsuario = (int)Reader["IdUsuario"];
                        objUsuario.Nome = Reader["Nome"].ToString();
                        objUsuario.Email = Reader["Email"].ToString();
                        objUsuario.DtNascimento = Convert.ToDateTime(Reader["DtNascimento"]);
                        objUsuario.Login = Reader["Login"].ToString();
                        ListaUsuario.Add(objUsuario);
                    }
                    Reader.Dispose();
                    Reader.Close();
                    return ListaUsuario;
                }
                else
                {
                    Reader.Dispose();
                    Reader.Close();
                    return ListaUsuario;
                }
            }
            catch (Exception er)
            {
                throw new Exception("ERRO AO BUSCAR UMA LISTA DE USUÁRIO..." + er.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public ClsUsuario BuscaUsuario(int idUsuario)
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand();
                Comando.Connection = Conexao;
                Comando.Parameters.AddWithValue("@1", idUsuario);
                Comando.CommandText = "SELECT `IdUsuario`, `Nome`, `Email`, `DtNascimento`, `Login`, `Senha` FROM `TbUsuario` WHERE `IdUsuario` = @1";
                Reader = Comando.ExecuteReader();
                ClsUsuario objUsuario = null;
                if (Reader.Read())
                {
                    objUsuario = new ClsUsuario();
                    objUsuario.IdUsuario = (int)Reader["IdUsuario"];
                    objUsuario.Nome = Reader["Nome"].ToString();
                    objUsuario.Email = Reader["Email"].ToString();
                    objUsuario.DtNascimento = Convert.ToDateTime(Reader["DtNascimento"]);
                    objUsuario.Login = Reader["Login"].ToString();
                    Reader.Dispose();
                    Reader.Close();
                    return objUsuario;
                }
                else
                {
                    Reader.Dispose();
                    Reader.Close();
                    return objUsuario;
                }
            }
            catch (Exception er)
            {
                throw new Exception("ERRO AO BUSCAR O USUÁRIO..." + er.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}