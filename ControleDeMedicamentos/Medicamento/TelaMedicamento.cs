using ControleDeMedicamentos.Compartilhados;
using ControleDeMedicamentos.Fornecedor;
using System.Collections;

namespace ControleDeMedicamentos.Medicamento
{
    public class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Medicamento");

                Console.WriteLine("(2) Editar Medicamento");

                Console.WriteLine("(3) Deletar Medicamento");

                Console.WriteLine("(4) Listar Medicamentos");

                Console.WriteLine("(5) Gerenciar quantidade de Medicamentos");

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
                case "5": GerenciarQuantidade(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }

        public void Inserir()
        {
            Listar();
            Medicamento medicamento = ObterRemedio();

            repositorioMedicamento.Criar(medicamento);

            ApresentarMensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }

        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberId();
            Medicamento medicamentoAtualizado = ObterRemedio();

            repositorioMedicamento.Editar(idSelecionado, medicamentoAtualizado);

            ApresentarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green);
        }

        public void Listar()
        {
            ArrayList listaMedicamentos = repositorioMedicamento.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    | QUANTIDADE | QUANTIDADE LIMITE |  DESCRIÇÃO  |  FORNECEDOR  |");
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (listaMedicamentos.Count == 0)
            {
                ApresentarMensagem("Nenhum remédio cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Medicamento medicamento in listaMedicamentos)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-12}|{3,-19}|{4,-13}|{5,-14}|", medicamento.Id, medicamento.Nome, medicamento.Quantidade, medicamento.QuantidadeLimite, medicamento.Descricao, medicamento.Fornecedor.Nome);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberId();
            repositorioMedicamento.Deletar(idSelecionado);
            ApresentarMensagem("Medicamento excluído com sucesso!", ConsoleColor.Green);
        }

        public int ReceberId()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do medicamento: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioMedicamento.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Medicamento ObterRemedio()
        {
            Console.WriteLine("Digite o nome do Medicamento: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade do Medicamento: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao do Medicamento: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite a quantidade limite do Medicamento: ");
            int qtdLimite = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o id do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = null;
            foreach (Fornecedor f in repositorioFornecedor.Cadastros)
            {
                if (idFornecedor == f.Id)
                {
                    fornecedor = f;
                    break;
                }
            }

            Medicamento medicamento = new Medicamento(repositorioMedicamento.ContadorId, nome, quantidade, descricao, qtdLimite, fornecedor);

            medicamento.AdicionarQuantidade(quantidade);
            medicamento.ValidarQuantidadeLimite();

            return medicamento;
        }

        private void GerenciarQuantidade()
        {
            Listar();
            int idSelecionado = ReceberId();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(1) Adicionar Remédio");
                Console.WriteLine("(2) Remover Remédio");
                Console.WriteLine("(S) Voltar ao Menu");
                Console.WriteLine("-------------------------------------");
                string opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": AdicionarQuantidadeRemedio(idSelecionado); break;
                    case "2": SubtrairQuantidadeMedicamento(idSelecionado); break;
                    case "S": Menu.VoltarAoMenu(); return;
                }
            }
        }

        public void SubtrairQuantidadeMedicamento(int idSelecionado)
        {
            Console.WriteLine("Digite a quantidade de medicamentos para subtrair");
            int quantidadeSubtrair = int.Parse(Console.ReadLine());
            repositorioMedicamento.SubtrairRemedio(idSelecionado, quantidadeSubtrair);
        }

        public void AdicionarQuantidadeRemedio(int idSelecionado)
        {
            Console.WriteLine("Digite a quantidade de medicamentos a adicionar");
            int quantidade = int.Parse(Console.ReadLine());
            repositorioMedicamento.AdicionarMedicamento(idSelecionado, quantidade);
        }

        public void ListarRemédiosEmFalta()
        {
            ArrayList listaMedicamentos = repositorioMedicamento.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("REMÉDIOS EM FALTA: \n");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID   |    NOME    | QUANTIDADE |");
            Console.WriteLine("--------------------------------");

            if (listaMedicamentos.Count == 0)
            {
                ApresentarMensagem("Nenhum remédio em cadastrado!", ConsoleColor.DarkYellow);
                return;
            }
            foreach (Medicamento medicamento in listaMedicamentos)
            {
                if (medicamento.Quantidade < 15)
                {
                    Console.WriteLine("{0,-5}|{1,-12}|{2,-12}|", medicamento.Id, medicamento.Nome, medicamento.Quantidade);
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}