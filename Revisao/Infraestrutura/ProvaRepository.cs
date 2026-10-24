using Microsoft.Data.Sqlite;
using Revisao.Dominio;
using System.Text.Json;

namespace Revisao.Infraestrutura
{
    public class ProvaRepository
    {
        private const string MeuBanco = "Data Source= Escola.db";
        public static void Inicializar()
        {
            using var conexao = new SqliteConnection(MeuBanco);
            conexao.Open();
            using var comando = conexao.CreateCommand();
            comando.CommandText = @"
                CREATE TABLE IF NOT EXISTS Provas(
                    Id INTEGER PRIMARY KEY, 
                    Disciplina TEXT NOT NULL,
                    Nota INTEGER NOT NULL,
                    Questoes TEXT NOT NULL,
                    Gabarito TEXT NOT NULL
                );
             ";
            comando.ExecuteNonQuery();
        }
        public static void Adicionar(Prova prova)
        {
            using var conexao = new SqliteConnection(MeuBanco);
            conexao.Open();
            using var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Provas(Disciplina, Nota, Questoes, Gabarito)
                VALUES ($disciplina, $nota, $questoes, $gabarito)
             ";
            comando.Parameters.AddWithValue("$disciplina", prova.Disciplina);
            comando.Parameters.AddWithValue("$nota", prova.Nota);
            comando.Parameters.AddWithValue("$questoes", JsonSerializer.Serialize(prova.Questoes));
            comando.Parameters.AddWithValue("$gabarito", JsonSerializer.Serialize(prova.Gabarito));
            comando.ExecuteNonQuery();
        }
        public static List<Prova> Listar()
        {
            using var conexao = new SqliteConnection(MeuBanco);
            conexao.Open();
            using var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT Id, Disciplina, Nota, Questoes, Gabarito FROM Provas ORDER BY Id;
             ";
            using var leitor = comando.ExecuteReader();
            List<Prova> provas = new List<Prova>();
            while (leitor.Read())
            {
                Prova p = new Prova();
                p.Id = leitor.GetInt32(0);
                p.Disciplina = leitor.GetString(1);
                p.Nota = leitor.GetInt32(2);
                p.Questoes = JsonSerializer.Deserialize<List<string>>(leitor.GetString(3)) ?? new List<string>();
                p.Gabarito = JsonSerializer.Deserialize<List<char>>(leitor.GetString(4)) ?? new List<char>();

                provas.Add(p);
            }
            return provas;
        }
    }
}
