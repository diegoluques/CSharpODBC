using System;
using System.Data.Odbc; 

namespace ODBC
{
	public class Livro
	{
		public void InsereRegistro()
		{
			Console.Write("Digite um título de um livro: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o valor do livro: ");
			string preco = Console.ReadLine();

			Console.Write("Digite o Id da editora: ");
			string editora = Console.ReadLine();

			string textoInsere = @"INSERT INTO Livro (titulo, preco, idEditora) VALUES (?, ?, ?)";

			using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
			{
				OdbcCommand command = new OdbcCommand(textoInsere, conexao);

				command.Parameters.AddWithValue("@titulo", titulo);
				command.Parameters.AddWithValue("@preco", preco);
				command.Parameters.AddWithValue("@idEditora", editora);

				conexao.Open();
				command.ExecuteNonQuery();

				Console.WriteLine("-".PadRight(69, '-'));
				Console.WriteLine("Registro salvo com sucesso".PadRight(68, ' ') + "-");
			}
		}

		public void ListaRegistro()
		{
			using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
			{
				string scriptLista = String.Concat(
													"SELECT Livro.*, Editora.nomeEditora FROM Livro ",
													"JOIN Editora ON Livro.idEditora = Editora.idEditora"
												  );
				OdbcCommand command = new OdbcCommand(scriptLista, conexao);
				conexao.Open();

				OdbcDataReader resultado = command.ExecuteReader();

				Console.WriteLine("|Id   |Título                       |Valor    |Editora              |");

				while (resultado.Read())
				{
					int idLivro = Convert.ToInt16(resultado["idLivro"]);
					string titulo = resultado["titulo"] as string;
					double valor = Convert.ToDouble(resultado["preco"]);
					int idEditora = Convert.ToInt16(resultado["idEditora"]);
					string nomeEditora = resultado["nomeEditora"] as string;

					string idEnomeEditora = idEditora.ToString() + " - " + nomeEditora;

					Console.WriteLine("|{0}|{1}|{2}|{3}", idLivro.ToString().PadRight(5, ' '), titulo.PadRight(29, ' '), valor.ToString().PadRight(9, ' '), idEnomeEditora.PadRight(21, ' ') + "|");
				}
			}
		}

		internal void DeletaRegistro()
		{
			Console.Write("Preencha com o Id do Livro para exclusão: ");
			string idLivro = System.Console.ReadLine();

			string textoDelete = @"DELETE FROM Livro WHERE idLivro = " + idLivro;

			using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
			{
				OdbcCommand command = new OdbcCommand(textoDelete, conexao);

				conexao.Open();
				command.ExecuteNonQuery();

				Console.WriteLine("-".PadRight(69, '-'));
				Console.WriteLine("Registro excluído com sucesso".PadRight(68, ' ') + "-");
			}
		}
	}
}