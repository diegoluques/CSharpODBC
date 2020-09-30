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

			System.Console.Write("Digite o nome de uma Editora: ");
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

				Console.WriteLine("---------------------------------------------------------");
				Console.WriteLine("Registro salvo com sucesso                              -");
			}
		}
	}
}
