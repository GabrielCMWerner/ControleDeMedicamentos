namespace ControleDeMedicamentos.Compartilhados
{
    public class Entidade
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public virtual void Atualizar(Entidade registroAtualizado)
        {
            Id = registroAtualizado.Id;
        }
    }
}