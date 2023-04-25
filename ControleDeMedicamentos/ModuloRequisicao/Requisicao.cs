using ControleDeMedicamentos.Compartilhados;
using ControleDeMedicamentos.ModuloFuncionário;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    public class Requisicao : Entidade
    {
        public Paciente Paciente;
        public Medicamento Medicamento;
        public Funcionario Funcionario;
        public string Data;
        public int QuantidadeMedicamento;

        public Requisicao(int id, Paciente paciente, Medicamento medicamento, Funcionario funcionario, string data, int quantidadeMedicamento)
        {
            Id = id;
            Paciente = paciente;
            Medicamento = medicamento;
            Funcionario = funcionario;
            Data = data;
            QuantidadeMedicamento = quantidadeMedicamento;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Requisicao requisicao = (Requisicao)registroAtualizado;

            Paciente = requisicao.Paciente;
            Medicamento = requisicao.Medicamento;
            Funcionario = requisicao.Funcionario;
            Data = requisicao.Data;
            QuantidadeMedicamento = requisicao.QuantidadeMedicamento;
        }
    }
}