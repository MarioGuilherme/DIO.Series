using System;

namespace DIO.Series{
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args){
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o nosso serviço.");
            Console.ReadLine();
        }

        private static void ExcluirSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        private static void VisualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(idSerie, (Genero)genero, titulo, ano, descricao);

            repositorio.Atualiza(idSerie, novaSerie);
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)genero, titulo, ano, descricao);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries(){
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma Série Cadastrada.");
                return;
            }
            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: {serie.retornaTitulo()} {(excluido ? "\"Excluído\"" : "")}");
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe as opções desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}