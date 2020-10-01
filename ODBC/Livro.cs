using System;
using System.Data.Odbc; 

namespace ODBC
{
	public class Livro
	{
		public void InsereRegistro()
		{
			string stringConexao = @"driver={SQL Server};
				server =nameserve; database=namedatabase; uid=sa; pwd=password; ";

			Console.Write("Digite um título de um livro: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o valor do livro: ");
			string preco = Console.ReadLine();

			Console.Write("Digite o Id da editora: ");
			string editora = Console.ReadLine();

			string textoInsere = @"INSERT INTO Livro (titulo, preco, idEditora) VALUES (?, ?, ?)";

			using (OdbcConnection conexao = new OdbcConnection(stringConexao))
			{
				OdbcCommand command = new OdbcCommand(textoInsere, conexao);

				command.Parameters.AddWithValue("@titulo", titulo);
				command.Parameters.AddWithValue("@preco", preco);
				command.Parameters.AddWithValue("@idEditora", editora);

				conexao.Open();
				command.ExecuteNonQuery();

				Console.WriteLine("---------------------------------------------------------");
				Console.WriteLine("Registro salvo com sucesso                              -");
			}
		}

		public void ListaRegistro()
		{
			string stringConexao = @"driver={SQL Server};
				server =nameserve; database=namedatabase; uid=sa; pwd=password; ";

			using (OdbcConnection conexao = new OdbcConnection(stringConexao))
			{
				string scriptLista = @"SELECT * FROM Livro";
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

					Console.WriteLine("|{0}|{1}|{2}|{3}", idLivro.ToString().PadRight(5, ' '), titulo.PadRight(29, ' '), valor.ToString().PadRight(9, ' '), idEditora.ToString().PadRight(21, ' ') + "|");
				}
			}
		}
	}
}