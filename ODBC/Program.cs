using System;

namespace ODBC
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				OpcoesDoMenu();
				TipoOperacao(Console.ReadLine());
			}
			catch (Exception ex)
			{
				Console.WriteLine("");
				Console.WriteLine("Erro: " + ex);
				Console.ReadLine();
				throw;
			}
		}

		private static void OpcoesDoMenu()
		{
			Console.WriteLine("---------------------------------------------------------");
			Console.WriteLine("Digite o número da opção desejada:                      -");
			Console.WriteLine("> [1] Cadastrar Editora                                 -");
			Console.WriteLine("> [2] Cadastrar Livro                                   -");
			Console.WriteLine("> [3] Limpar                                            -");
			Console.WriteLine("> [4] Sair                                              -");
			Console.WriteLine("---------------------------------------------------------");
			Console.Write("Opção: ");
		}

		public static void TipoOperacao(string op)
		{
			bool sair = false;
			while (op != "")
			{
				switch (op)
				{
					case "1":
						Console.WriteLine("> [1] Cadastrar Editora                                 -");
						Editora insereEditor = new Editora();
						insereEditor.InsereRegistro();
						break;
					case "2":
						Console.WriteLine("> [2] Cadastrar Livro                                   -");
						Livro insereLivro = new Livro();
						insereLivro.InsereRegistro();
						break;
					case "3":
						Console.WriteLine("> [3] Limpar                                            -");
						Console.Clear();
						break;
					case "4":
						Console.WriteLine("> [4] Sair                                              -");
						System.Threading.Thread.Sleep(300);
						sair = true;
						break;
				}

				if (!sair)
				{
					OpcoesDoMenu();
					op = Console.ReadLine();
				}
			}
		}
	}
}