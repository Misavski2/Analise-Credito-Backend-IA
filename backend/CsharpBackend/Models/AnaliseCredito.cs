namespace CsharpBackend.Models
{
    public class AnaliseCredito
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; } 
        public decimal ValorSolicitado { get; set; } 
        public bool Aprovado { get; set; }
        public decimal LimiteAprovado { get; set; }
        public int Score { get; set; } 
        public string Mensagem { get; set; }
        public DateTime DataAnalise { get; set; }


    }
}
