
using ControleDeMedicamentos.ModuloAquisicao;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionário;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;

namespace ControleDeMedicamentos
{
    public class program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            TelaPaciente telaPaciente = new TelaPaciente();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            TelaRequisicao telaRequisicao = new TelaRequisicao();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            TelaAquisicao telaAquisicao = new TelaAquisicao();

            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao();

            menu.telaPaciente = telaPaciente;
            menu.telaRemedio = telaMedicamento;
            menu.telaFornecedor = telaFornecedor;
            menu.telaFuncionario = telaFuncionario;
            menu.telaRequisicao = telaRequisicao;
            menu.telaAquisicao = telaAquisicao;

            telaPaciente.repositorioPaciente = repositorioPaciente;
            telaFornecedor.repositorioFornecedor = repositorioFornecedor;
            telaMedicamento.repositorioMedicamento = repositorioMedicamento;
            telaMedicamento.repositorioFornecedor = repositorioFornecedor;
            telaFuncionario.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioRequisicao = repositorioRequisicao;
            telaRequisicao.repositorioPaciente = repositorioPaciente;
            telaRequisicao.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioMedicamento = repositorioMedicamento;
            telaAquisicao.repositorioFuncionario = repositorioFuncionario;
            telaAquisicao.repositorioMedicamento = repositorioMedicamento;
            telaAquisicao.repositorioFornecedor = repositorioFornecedor;
            telaAquisicao.repositorioAquisicao = repositorioAquisicao;

            menu.ExecutarMenuPrincipal();


        }
    }
}