using System;
using System.Data.Odbc;

namespace ODBC
{
	public class Editora
	{
		public void InsereRegistro()
		{
			string stringConexao = @"driver={SQL Server};
				server =nameserve; database=namedatabase; uid=sa; pwd=password; ";

			Console.Write("Digite o nome de uma Editora: ");
			string nome = System.Console.ReadLine();

			System.Console.Write("Digite o E-mail da Editora: ");
			string email = System.Console.ReadLine();

			string textoInsere = @"INSERT INTO Editora (nomeEditora, emailEditora) VALUES(?, ?)";

			using (OdbcConnection conexao = new OdbcConnection(stringConexao))
			{ 
				OdbcCommand command = new OdbcCommand(textoInsere, conexao);

				command.Parameters.AddWithValue("@nomeEditora", nome);
				command.Parameters.AddWithValue("@emailEditora", email);

				conexao.Open();
				command.ExecuteNonQuery();

				Console.WriteLine("-".PadRight(69, '-'));
				Console.WriteLine("Registro salvo com sucesso".PadRight(68, ' ') + "-");
			}
		}

		public void ListaRegistro()
		{
			string stringConexao = @"driver={SQL Server};
				server =nameserve; database=namedatabase; uid=sa; pwd=password; ";

			using (OdbcConnection conexao = new OdbcConnection(stringConexao))
			{
				string scriptLista = @"SELECT * FROM Editora";
				OdbcCommand command = new OdbcCommand(scriptLista, conexao);
				conexao.Open();

				OdbcDataReader resultado = command.ExecuteReader();

				Console.WriteLine("|Id   |Nome da Editora               |E-mail da Editora             |");

				while (resultado.Read())
				{
					int idEditora = Convert.ToInt16(resultado["idEditora"]);
					string nomeEditora = resultado["nomeEditora"] as string;
					string emailEditora = resultado["emailEditora"] as string;

					Console.WriteLine("|{0}|{1}|{2}", idEditora.ToString().PadRight(5, ' '), nomeEditora.PadRight(30, ' '), emailEditora.PadRight(30, ' ') + "|");
				}
			}
		}
	}
}
