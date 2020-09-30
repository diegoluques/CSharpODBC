using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace ODBC
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("Digite o número da opção desejada:                    -");
				Console.WriteLine("[1] Cadastrar Editora                                 -");
				Console.WriteLine("[2] Cadastrar Livro                                   -");
				Console.WriteLine("[3] Sair                                              -");
				Console.WriteLine("-------------------------------------------------------");
				
				Console.Write("Opção: ");
				string opcaoInformada = Console.ReadLine(); 
				Console.WriteLine("-------------------------------------------------------");

				TipoOperacao(opcaoInformada);

			}
			catch (Exception ex)
			{
				Console.WriteLine("");
				Console.WriteLine("Erro: " + ex);
				Console.ReadLine();
				throw;
			}
		}

		public static void TipoOperacao(string op)
		{
			switch (op)
			{
				case "1":
					Console.WriteLine("[1] Cadastrar Editora                                 -");
					Editora insereEditor = new Editora();
					insereEditor.InsereRegistro();
					break;
				case "2":
					Console.WriteLine("Livro");
					Livro insereLivro = new Livro();
					insereLivro.InsereRegistro();
					break;
				case "3":
					Console.WriteLine("Sair");
					break;
			}
		}
	}
}
