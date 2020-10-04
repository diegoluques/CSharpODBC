using System.Data.Odbc;
using System.Text;

namespace ODBC
{
	static class ConnectionFactory
	{
		public static OdbcConnection CreateConnection()
		{
			string driver = @"SQL Server";
			string servidor = @"nomeservidor";
			string baseDeDados = @"nomebanco ";
			string usuario = @"usuario";
			string senha = @"senha";

			StringBuilder connectionString = new StringBuilder();
			connectionString.Append("driver=");
			connectionString.Append(driver);
			connectionString.Append("; server=");
			connectionString.Append(servidor);
			connectionString.Append("; database=");
			connectionString.Append(baseDeDados);
			connectionString.Append("; uid=");
			connectionString.Append(usuario);
			connectionString.Append("; pwd=");
			connectionString.Append(senha);

			return new OdbcConnection(connectionString.ToString());
		}
	}
}