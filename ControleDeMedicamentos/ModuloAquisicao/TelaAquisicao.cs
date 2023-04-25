using System.Collections;
using ControleDeMedicamentos.Compartilhados;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionário;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.ModuloAquisicao
{
    public class TelaAquisicao : Tela
    {
        public RepositorioAquisicao repositorioAquisicao = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();

                Console.WriteLine("/ --------------------- /");
                Console.WriteLine("/ Cadastro de Aquisição /");
                Console.WriteLine("/ --------------------- /");

                Console.WriteLine();

                Console.WriteLine("(1) Criar Aquisição");

                Console.WriteLine("(2) Editar Aquisição");

                Console.WriteLine("(3) Deletar Aquisição");

                Console.WriteLine("(4) Listar Aquisição");

                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }

        public void SelecionarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1": Inserir(); break;
                case "2": Editar(); break;
                case "3": Deletar(); break;
                case "4": Listar(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }

        public void Inserir()
        {
            Listar();
            Aquisicao novoAquisicao = ObterAquisicao();

            repositorioAquisicao.Criar(novoAquisicao);

            ApresentarMensagem("Aquisição criada com sucesso!", ConsoleColor.Green);
        }

        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Aquisicao aquisicaoAtualizada = ObterAquisicao();

            repositorioAquisicao.Editar(idSelecionado, aquisicaoAtualizada);

            ApresentarMensagem("Aquisição editada com sucesso!", ConsoleColor.Green);
        }

        public void Listar()
        {
            ArrayList listaAquisicao = repositorioAquisicao.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("ID   |    FORNECEDOR    |   REMEDIO   |    FUNCIONARIO    |  DATA  | QUANTIDADE DE REMÉDIOS |");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            if (listaAquisicao.Count == 0)
            {
                ApresentarMensagem("Nenhuma aquisição cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Aquisicao aquisicao in listaAquisicao)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-13}|{3,-10}|{4,-12}|{5,-12}|", aquisicao.Id, aquisicao.Fornecedor.Nome, aquisicao.Medicamento.Nome, aquisicao.Funcionario.Nome, aquisicao.Data, aquisicao.QuantidadeMedicamento);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioAquisicao.Deletar(idSelecionado);
            ApresentarMensagem("Aquisição excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da Aquisição: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioAquisicao.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Aquisicao ObterAquisicao()
        {
            Console.WriteLine("Digite o id do fornecedor da Aquisição: ");
            int fornecedorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id do remédio da Aquisição: ");
            int remedioId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id funcionario da Aquisição: ");
            int funcionarioId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data da Aquisição: ");
            string data = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de remédios: ");
            int quantidadeRemedio = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.SelecionarPorId(fornecedorId);
            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarPorId(remedioId);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(funcionarioId);

            Aquisicao aquisicao = new Aquisicao(repositorioAquisicao.ContadorId, fornecedor, medicamento, funcionario, data, quantidadeRemedio);

            medicamento.AdicionarQuantidade(quantidadeRemedio);
            medicamento.ValidarQuantidadeLimite();

            return aquisicao;
        }
    }
}