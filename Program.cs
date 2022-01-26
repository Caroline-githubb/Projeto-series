using System;

namespace SeriesFavoritas
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static UsuariosRepositorio repositorio2 = new UsuariosRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarUsuarios();
                        break;

                    case "2":
                        CadastrarUsuario();
                        break;

                    case "3":
                        EscolherUsuario();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void EscolherUsuario()
        {
            Console.WriteLine("Digite o codigo do usuario");
            int id = int.Parse(Console.ReadLine());

            var listaUsuarios = repositorio2.ListaUsuarios();
            Pessoa usuarioSelecionado = null;

            foreach (var usuario in listaUsuarios)
            {
                if (usuario.Id == id)
                {
                    usuarioSelecionado = usuario;
                }
            }

            if (usuarioSelecionado is null)
            {
                Console.WriteLine("Usuario nao encontrado");
            }
            else
            {
                Console.WriteLine(usuarioSelecionado.retornaNome());
                string opcaoUsuario = ObterOpcaoSerie();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            InserirSerie();
                            break;
                        case "2":
                            ListarSeries();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            VisualizarSerie();
                            break;
                        case "5":
                            ExcluirSerie();
                            break;




                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario = ObterOpcaoSerie();
                }
            }
        }

        private static void ListarUsuarios()
        {
            Console.WriteLine("Listar usuários");

            var listaNome = repositorio2.ListaUsuarios();

            if (listaNome.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var pessoa in listaNome)
            {
                var excluido = pessoa.retornaExcluido();
                var excluidoExtenso = (excluido ? "*Excluído*" : "");
                var nome = pessoa.retornaNome();

                Console.WriteLine("#ID {0}: - {1}", nome, excluidoExtenso);
            }
        }

        private static void CadastrarUsuario()
        {
            Console.WriteLine("Cadastrar novo usuário");
            Console.WriteLine("Digite o seu nome: ");
            string entradaNome = Console.ReadLine();


            Pessoa novoUsuario = new Pessoa(id: repositorio2.ProximoId(),
                                            nome: entradaNome);

            repositorio2.InsereNome(novoUsuario);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite as Quantidades de Temporadas: ");
            int entradaTemporadas = int.Parse(Console.ReadLine());

            Series atualizaSerie = new Series(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao,
            temporadas: entradaTemporadas);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite as Quantidades de Temporadas: ");
            int entradaTemporadas = int.Parse(Console.ReadLine());

            Series novaSerie = new Series(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao,
            temporadas: entradaTemporadas);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Séries Favoritas!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar usuários");
            Console.WriteLine("2- Cadastrar novo usuário ");
            Console.WriteLine("3- Escolha um usuário");
            Console.WriteLine("X- Sair");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


        private static string ObterOpcaoSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Séries Favoritas!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Inserir nova série");
            Console.WriteLine("2- Listar séries");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Visualizar série");
            Console.WriteLine("5- Excluir série");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }


}
