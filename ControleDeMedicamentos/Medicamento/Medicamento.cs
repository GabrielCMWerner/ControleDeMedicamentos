using ControleDeMedicamentos.Compartilhados;
using ControleDeMedicamentos.Fornecedor;

namespace ControleDeMedicamentos.Medicamento
{
    public class Medicamento : Entidade
    {
        public string Nome;
        public decimal Quantidade;
        public string Descricao;
        public int QuantidadeLimite;
        public Fornecedor Fornecedor;

        public Medicamento(int id, string nome, decimal quantidade, string descricao, int quantidadeLimite, Fornecedor fornecedor)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Descricao = descricao;
            QuantidadeLimite = quantidadeLimite;
            Fornecedor = fornecedor;
        }
        public override void Atualizar(Entidade registroAtualizado)
        {
            Medicamento medicamento = (Medicamento)registroAtualizado;

            Nome = medicamento.Nome;
            Quantidade = medicamento.Quantidade;
            Descricao = medicamento.Descricao;
            QuantidadeLimite = medicamento.QuantidadeLimite;
            Fornecedor = medicamento.Fornecedor;
        }

        public void ValidarQuantidadeLimite()
        {
            if (Quantidade > QuantidadeLimite)
            {
                decimal quantidadeSobrando = Quantidade - QuantidadeLimite;
                Quantidade = QuantidadeLimite;
                Console.WriteLine($"Essa quantidade excederá o limite! {quantidadeSobrando} remédios não serão adicionados!");
                Console.ReadLine();
            }
        }

        public void SubtrairQuantidade(int quantidadeSubtrair)
        {
            Quantidade = Quantidade - quantidadeSubtrair;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade = Quantidade + quantidade;
        }
    }
}