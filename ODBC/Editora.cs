using System;
using System.Data.Odbc; 

namespace ODBC
{
	public class Editora
	{
		public void InsereRegistro()
		{
			Console.Write("Digite o nome de uma Editora: ");
			string nome = System.Console.ReadLine();

			System.Console.Write("Digite o E-mail da Editora: ");
			string email = System.Console.ReadLine();

			string textoInsere = @"INSERT INTO Editora (nomeEditora, emailEditora) VALUES(?, ?)";

			using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
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
			using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
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

		internal void DeletaRegistro()
		{

			Console.Write("Preencha com o Id da Editora para exclusão: ");
			string idEditora = System.Console.ReadLine();

			string textoDelete = @"DELETE FROM Editora WHERE idEditora = " + idEditora;

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