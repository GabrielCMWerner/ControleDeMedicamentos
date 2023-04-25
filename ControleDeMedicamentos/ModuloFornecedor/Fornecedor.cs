using ControleDeMedicamentos.Compartilhados;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {

        public string Endereco;

        public Fornecedor(int id, string nome, string endereco)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Fornecedor fornecedor = (Fornecedor)registroAtualizado;

            Nome = fornecedor.Nome;
            Endereco = fornecedor.Endereco;

        }
    }
}