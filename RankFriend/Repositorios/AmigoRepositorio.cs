using MySql.Data.MySqlClient;
using RankingAmigos.Dados;
using RankingAmigos.Modelos;
using System.Collections.Generic;
using System;

namespace RankingAmigos.Repositorios
{
    public class AmigoRepositorio
    {
        private readonly Conexao conexao = new Conexao();

        public List<Amigo> Listar()
        {
            List<Amigo> amigos = new List<Amigo>();

            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                string sql = "SELECT Id, Nome, Posicao FROM Amigos ORDER BY Posicao";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        amigos.Add(new Amigo
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Posicao = reader.GetInt32("Posicao")
                        });
                    }
                }
            }

            return amigos;
        }

        public void Adicionar(Amigo amigo)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                string sql = "INSERT INTO Amigos (Nome, Posicao) VALUES (@Nome, @Posicao)";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", amigo.Nome);
                    command.Parameters.AddWithValue("@Posicao", amigo.Posicao);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Amigo amigo)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                string sql = "UPDATE Amigos SET Nome = @Nome, Posicao = @Posicao WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", amigo.Nome);
                    command.Parameters.AddWithValue("@Posicao", amigo.Posicao);
                    command.Parameters.AddWithValue("@Id", amigo.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarVarios(List<Amigo> amigos)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE Amigos SET Nome = @Nome, Posicao = @Posicao WHERE Id = @Id";

                        foreach (Amigo amigo in amigos)
                        {
                            using (MySqlCommand command = new MySqlCommand(sql, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Nome", amigo.Nome);
                                command.Parameters.AddWithValue("@Posicao", amigo.Posicao);
                                command.Parameters.AddWithValue("@Id", amigo.Id);

                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void AdicionarComReordenacao(Amigo novo, List<Amigo> amigos)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlAtualizar = "UPDATE Amigos SET Posicao = @Posicao WHERE Id = @Id";

                        foreach (Amigo amigo in amigos)
                        {
                            using (MySqlCommand command = new MySqlCommand(sqlAtualizar, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Posicao", amigo.Posicao);
                                command.Parameters.AddWithValue("@Id", amigo.Id);

                                command.ExecuteNonQuery();
                            }
                        }

                        string sqlInserir = "INSERT INTO Amigos (Nome, Posicao) VALUES (@Nome, @Posicao)";

                        using (MySqlCommand command = new MySqlCommand(sqlInserir, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nome", novo.Nome);
                            command.Parameters.AddWithValue("@Posicao", novo.Posicao);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ExcluirEAtualizar(int id, List<Amigo> amigos)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlExcluir = "DELETE FROM Amigos WHERE Id = @Id";

                        using (MySqlCommand command = new MySqlCommand(sqlExcluir, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        string sqlAtualizar = "UPDATE Amigos SET Nome = @Nome, Posicao = @Posicao WHERE Id = @Id";

                        foreach (Amigo amigo in amigos)
                        {
                            using (MySqlCommand command = new MySqlCommand(sqlAtualizar, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Nome", amigo.Nome);
                                command.Parameters.AddWithValue("@Posicao", amigo.Posicao);
                                command.Parameters.AddWithValue("@Id", amigo.Id);

                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection connection = conexao.CriarConexao())
            {
                connection.Open();

                string sql = "DELETE FROM Amigos WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}