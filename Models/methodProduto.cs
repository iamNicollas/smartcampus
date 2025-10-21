using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smartCampos.Models;
using System.Data;
using System.Data.SqlClient;

namespace smartCampos.Models
{
    public class methodProduto
    {
        private string connectionString = @"Data Source=NII\MSSQLSERVER01;Initial Catalog=smartcampus;User ID=nicollas;Password=lala1219";

        public List<objProduto> ListarProduto()
        {
            List<objProduto> produtos = new List<objProduto>();

            string query = @"SELECT p.id_produto, p.ds_nome, p.int_quantidade, p.dm_valor, 
                            p.id_categoria, c.ds_nome AS categoriaNome, p.ds_observacao, 
                            p.dt_cadastro, p.dt_validade 
                             FROM tb_produto p
                             JOIN tb_categoria c ON p.id_categoria = c.id_categoria";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objProduto p = new objProduto
                            {
                                idProduto = Convert.ToInt32(reader["id_produto"]),
                                nomeProduto = reader["ds_nome"].ToString(),
                                quantidadeEstoque = Convert.ToInt32(reader["int_quantidade"]),
                                preco = Convert.ToDecimal(reader["dm_valor"]),
                                idCategoria = Convert.ToInt32(reader["id_categoria"]),
                                nomeCategoria = reader["categoriaNome"].ToString(),
                                descricao = reader["ds_observacao"].ToString(),
                                dta_cadastro = Convert.ToDateTime(reader["dt_cadastro"]),
                                dta_validade = Convert.ToDateTime(reader["dt_validade"])
                            };

                            produtos.Add(p);
                        }
                    }
                }
            }

            return produtos;
        }


        public void CadastroProduto(objProduto produto)
        {
            string query = @"INSERT INTO tb_produto (ds_nome, int_quantidade, dt_validade, dt_cadastro, dm_valor, ds_observacao, id_categoria) 
                             VALUES (@nomeProduto, @quantidade, @validade, @cadastro, @valor, @observacao, @idCategoria)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@nomeProduto", SqlDbType.NVarChar, 100).Value = produto.nomeProduto;
                        command.Parameters.Add("@quantidade", SqlDbType.Int).Value = produto.quantidadeEstoque;
                        command.Parameters.Add("@validade", SqlDbType.DateTime).Value = produto.dta_validade;
                        command.Parameters.Add("@cadastro", SqlDbType.DateTime).Value = produto.dta_cadastro;
                        command.Parameters.Add("@valor", SqlDbType.Decimal).Value = produto.preco;
                        command.Parameters.Add("@observacao", SqlDbType.NVarChar, 500).Value = produto.descricao ?? (object)DBNull.Value;
                        command.Parameters.Add("@idCategoria", SqlDbType.Int).Value = produto.idCategoria;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao cadastrar o produto: {ex.Message}");
                }
            }
        }

        public void AtualizarProduto(objProduto produto)
        {
            string query = @"UPDATE tb_produto
                     SET ds_nome = @nomeProduto,
                         int_quantidade = @quantidade,
                         dt_validade = @validade,
                         dt_cadastro = @cadastro,
                         dm_valor = @valor,
                         ds_observacao = @observacao,
                         id_categoria = @idCategoria
                     WHERE id_produto = @idProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@nomeProduto", SqlDbType.NVarChar, 100).Value = produto.nomeProduto;
                        command.Parameters.Add("@quantidade", SqlDbType.Int).Value = produto.quantidadeEstoque;
                        command.Parameters.Add("@validade", SqlDbType.DateTime).Value = produto.dta_validade;
                        command.Parameters.Add("@cadastro", SqlDbType.DateTime).Value = produto.dta_cadastro;
                        command.Parameters.Add("@valor", SqlDbType.Decimal).Value = produto.preco;
                        command.Parameters.Add("@observacao", SqlDbType.NVarChar, 500).Value = produto.descricao ?? (object)DBNull.Value;
                        command.Parameters.Add("@idCategoria", SqlDbType.Int).Value = produto.idCategoria;
                        command.Parameters.Add("@idProduto", SqlDbType.Int).Value = produto.idProduto;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao atualizar o produto: {ex.Message}");
                }
            }
        }

        public void ExcluirProduto(int idProduto)
        {
            string query = "DELETE FROM tb_produto WHERE id_produto = @idProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro ao excluir o produto: {ex.Message}");
                }
            }
        }

        // --- Categoria --- 
        public List<objCategoria> ListarCategorias()
        {
            var lista = new List<objCategoria>();
            string query = "SELECT id_categoria, ds_nome FROM tb_categoria ORDER BY ds_nome";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new objCategoria
                        {
                            idCategoria = reader.GetInt32(0),
                            nomeCategoria = reader.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }

    }
}