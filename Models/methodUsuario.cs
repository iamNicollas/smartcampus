using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace smartCampos.Models
{
    public class methodUsuario
    {
        private string connectionString = @"Data Source=LAPTOP-HU2QITS1\SQLEXPRESS;Initial Catalog=smartcampus;Integrated Security=True";

        public async Task<List<objUsuario>> BuscarTodosUsuario()
        {
            List<objUsuario> usuarios = new List<objUsuario>();

            string query = @"SELECT * FROM tb_usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objUsuario user = new objUsuario
                            {
                                idUsuario = Convert.ToInt32(reader["id_Usuario"]),
                                Nome = reader["ds_Nome"].ToString(),
                                CPF = reader["ds_CPF"].ToString(),
                                Login = reader["ds_Email"].ToString(),
                                Senha = reader["ds_Login"].ToString(),
                                Email = reader["ds_Senha"].ToString(),
                                dta_Cadastro = Convert.ToDateTime(reader["dt_Cadastro"])
                            };

                            usuarios.Add(user);
                        }
                    }
                }
            }

            return usuarios;
        }

        public void CadastrarUsuario(objUsuario usuario)
        {
            string query = @"INSERT INTO tb_usuario (ds_Nome, ds_CPF, ds_Email, ds_Login, ds_Senha, dt_Cadastro) 
                             VALUES (@nomeUsuario, @cpf, @email, @login, @senha, @dtCadastro)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@nomeUsuario", SqlDbType.NVarChar, 100).Value = usuario.Nome;
                        command.Parameters.Add("@cpf", SqlDbType.NVarChar, 20).Value = usuario.CPF;
                        command.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = usuario.Email;
                        command.Parameters.Add("@login", SqlDbType.NVarChar, 100).Value = usuario.Login;
                        command.Parameters.Add("@senha", SqlDbType.NVarChar, 500).Value = usuario.Senha;
                        command.Parameters.Add("@dtCadastro", SqlDbType.DateTime).Value = usuario.dta_Cadastro;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao cadastrar o usuario: {ex.Message}");
                }
            }
        }

        public void AtualizarUsuario(objUsuario usuario)
        {
            string query = @"UPDATE tb_usuario
                     SET ds_Nome = @nomeUsuario,
                         ds_CPF = @cpf,
                         ds_Email = @email,
                         ds_Login = @login,
                         ds_Senha = @senha,
                         dt_Cadastro = @dtCadastro
                     WHERE id_Usuario = @idUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@nomeUsuario", SqlDbType.NVarChar, 100).Value = usuario.Nome;
                        command.Parameters.Add("@cpf", SqlDbType.NVarChar, 20).Value = usuario.CPF;
                        command.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = usuario.Email;
                        command.Parameters.Add("@login", SqlDbType.NVarChar, 100).Value = usuario.Login;
                        command.Parameters.Add("@senha", SqlDbType.NVarChar, 500).Value = usuario.Senha;
                        command.Parameters.Add("@dtCadastro", SqlDbType.DateTime).Value = usuario.dta_Cadastro;
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuario.idUsuario;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao atualizar o produto: {ex.Message}");
                }
            }
        }

        public void ExcluirCliente(int idUsuario)
        {
            string query = "DELETE FROM tb_usuario WHERE id_Usuario = @idUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao excluir o usuário: {ex.Message}");
                }
            }
        }
    }
}