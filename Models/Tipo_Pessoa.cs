namespace TesteEngegraph.Models
{
    public class Tipo_Pessoa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
