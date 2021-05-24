using System;

namespace DIO_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoMenu = "";
            do 
            {   
                opcaoMenu = ObterOpcaoUsuario();

                switch (opcaoMenu)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        //AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;  
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();            
                }
            } while (opcaoMenu != "X");

            Console.WriteLine("Obrigado por utilizar nossos serviços\n");
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries:");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach(var seriado in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", seriado.retornaID(), seriado.retornaTitulo());
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}}", i, Enum.GetName(typeof(Genero), i) );
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            if (!int.TryParse(Console.ReadLine(), out int entradaGenero))
            {
                return;
            }

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            if (!int.TryParse(Console.ReadLine(), out int entradaAno))
            {
                return;
            }

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(mco_id: repositorio.ProximoId(),
                                        mco_genero: (Genero)entradaGenero,
                                        mco_titulo: entradaTitulo,
                                        mco_ano: entradaAno,
                                        mco_descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {   
            Console.WriteLine("\nDIO Series a seu dispor !");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova ´série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoMenu;
        }
    }
}
