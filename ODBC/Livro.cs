using System;
using System.Data.Odbc;

namespace ODBC
{
	public class Livro
	{
		public void InsereRegistro()
		{
			string stringConexao = @"driver={SQL Server};
				server=nameserve; database=namedatabase; uid=sa; pwd=password;";

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

				System.Console.WriteLine("");
				System.Console.WriteLine("Registro salvo com sucesso");
				System.Console.ReadLine();
			}
		} 
	}
}
