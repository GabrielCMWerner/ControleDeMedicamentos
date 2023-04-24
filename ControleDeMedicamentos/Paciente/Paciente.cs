using ControleDeMedicamentos.Compartilhados;

namespace ControleDeMedicamentos.Paciente
{
    public class Paciente : Entidade
    {
        public string Telefone;
        public string CPF;
        public string Endereco;
        public string CartaoSus;

        public Paciente(int id, string nome, string telefone, string cPF, string endereco, string cartaoSus)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CPF = cPF;
            Endereco = endereco;
            CartaoSus = cartaoSus;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Paciente paciente = (Paciente)registroAtualizado;

            Nome = paciente.Nome;
            Telefone = paciente.Telefone;
            CPF = paciente.CPF;
            Endereco = paciente.Endereco;
            CartaoSus = paciente.CartaoSus;
        }
    }
}