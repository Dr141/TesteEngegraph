namespace TesteEngegraph.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Dt_nascimento { get; set; }
        public string Sexo { get; set; }
        public virtual Tipo_Pessoa Tipo_Pessoa { get; set; }
        public bool Validacao { get; set; } 
    }
}
