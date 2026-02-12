namespace CsharpBackend.Models
{
    public class SolicitacaoCredito
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal Renda { get; set; }
        public decimal ValorSolicitado { get; set; } 
        public int Parcelas { get; set; }
        public decimal ValorParcela => Parcelas > 0 ? ValorSolicitado / Parcelas : 0;
        public int Idade { get; set; }
        public double TempoEmprego { get; set; } 
        public string Finalidade { get; set; } 
        public string TipoMoradia { get; set; }
        public int AnosHistoricoCredito { get; set; }
        public string JaDeuCalote { get; set; }

    }
}
