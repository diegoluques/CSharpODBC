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
				if (ex.Message.Contains("constraint"))
				{
					Console.WriteLine("".PadRight(69, '-'));
					Console.WriteLine("Ops!".PadRight(68, ' ') + "-");
					Console.WriteLine("Registro não pode ser excluído, a Editora tem vínculos com Livro(s).".PadRight(68, ' ') + "-");
					Console.WriteLine("".PadRight(68, ' ') + "-");
					OpcoesDoMenu();
					TipoOperacao(Console.ReadLine());
				}
				else
				{
					Console.WriteLine("");
					Console.WriteLine("Erro: " + ex);
					Console.ReadLine();
					throw;
				}
			}
		}

		private static void OpcoesDoMenu()
		{
			Console.WriteLine("-".PadRight(69, '-'));
			Console.WriteLine("-                               MENU                                -");
			Console.WriteLine("-".PadRight(69, '-'));
			Console.WriteLine("> [1] Cadastrar Editora".PadRight(68, ' ') + "-");
			Console.WriteLine("> [2] Listar Editoras".PadRight(68, ' ') + "-");
			Console.WriteLine("> [3] Excluir Editora".PadRight(68, ' ') + "-");
			Console.WriteLine("> [4] Cadastrar Livro".PadRight(68, ' ') + "-");
			Console.WriteLine("> [5] Listar Livros".PadRight(68, ' ') + "-");
			Console.WriteLine("> [6] Excluir Livro".PadRight(68, ' ') + "-");
			Console.WriteLine("> [7] Limpar".PadRight(68, ' ') + "-");
			Console.WriteLine("> [8] Sair".PadRight(68, ' ') + "-");
			Console.WriteLine("-".PadRight(69, '-'));
			Console.Write("Opção: ");
		}

		public static void TipoOperacao(string op)
		{
			bool sair = false;
			Editora editora = new Editora();
			Livro livro = new Livro();
			while (op != "")
			{
				switch (op)
				{
					case "1":
						Console.WriteLine("> [1] Cadastrar Editora".PadRight(68, ' ') + "-");
						editora.InsereRegistro();
						break;
					case "2":
						Console.WriteLine("> [2] Listar Editoras".PadRight(68, ' '));
						Console.WriteLine("-".PadRight(69, '-'));
						editora.ListaRegistro();
						break;
					case "3":
						Console.WriteLine("> [3] Excluir Editora".PadRight(68, ' ') + "-");
						editora.DeletaRegistro();
						break;
					case "4":
						Console.WriteLine("> [4] Cadastrar Livro".PadRight(68, ' ') + "-");
						livro.InsereRegistro();
						break;
					case "5":
						Console.WriteLine("> [5] Listar Livros".PadRight(68, ' '));
						Console.WriteLine("-".PadRight(69, '-'));
						livro.ListaRegistro();
						break;
					case "6":
						Console.WriteLine("> [6] Excluir Livro".PadRight(68, ' ') + "-");
						livro.DeletaRegistro();
						break;
					case "7":
						Console.WriteLine("> [7] Limpar".PadRight(68, ' ') + "-");
						Console.Clear();
						break;
					case "8":
						Console.WriteLine("> [8] Sair".PadRight(68, ' ') + "-");
						Environment.Exit(-1);
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