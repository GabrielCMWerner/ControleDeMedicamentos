using ControleDeMedicamentos.Compartilhados;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    public class RepositorioMedicamento : Repositorio
    {
        public void AdicionarMedicamento(int idSelecionado, int quantidade)
        {
            Medicamento medicamento = (Medicamento)SelecionarPorId(idSelecionado);
            medicamento.AdicionarQuantidade(quantidade);
            medicamento.ValidarQuantidadeLimite();
        }

        public void SubtrairRemedio(int idSelecionado, int quantidadeSubtrair)
        {
            Medicamento medicamento = (Medicamento)SelecionarPorId(idSelecionado);
            medicamento.SubtrairQuantidade(quantidadeSubtrair);
        }
    }
}