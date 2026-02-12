using System.Text;
using System.Text.Json;
using CsharpBackend.Models;

namespace CsharpBackend.Services
{
    public class AnaliseService
    {
        private readonly HttpClient _httpClient;

        public AnaliseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AnaliseCredito> ProcessarSolicitacao(SolicitacaoCredito solicitacao)
        {
            
            var payloadPython = new
            {
                person_age = solicitacao.Idade,
                person_income = solicitacao.Renda,
                person_emp_length = 5.0, 
                loan_amnt = solicitacao.ValorSolicitado,
                loan_int_rate = 10.0, 
                loan_percent_income = (double)solicitacao.ValorSolicitado / (double)solicitacao.Renda,
                cb_person_cred_hist_length = 2, 
                person_home_ownership = "RENT", 
                loan_intent = "PERSONAL", 
                loan_grade = "B", 
                cb_person_default_on_file = "N" 
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(payloadPython),
                Encoding.UTF8,
                "application/json");

            try
            {
                
                var response = await _httpClient.PostAsync("http://localhost:8000/avaliar", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    
                    return GerarAnaliseFallback(solicitacao, "Erro na IA: " + response.StatusCode);
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                
                using var doc = JsonDocument.Parse(jsonResponse);
                double probabilidadeCalote = doc.RootElement.GetProperty("risco").GetDouble();

                
                bool aprovado = probabilidadeCalote < 0.5;

                return new AnaliseCredito
                {
                    Nome = solicitacao.Nome,
                    CPF = solicitacao.CPF,
                    ValorSolicitado = solicitacao.ValorSolicitado,
                    Aprovado = aprovado,
                    LimiteAprovado = aprovado ? solicitacao.Renda * 0.3m : 0,
                    Mensagem = aprovado ? "Aprovado pela Inteligência Artificial" : "Reprovado por Alto Risco (IA)",
                    DataAnalise = DateTime.Now,
                    Score = (int)((1 - probabilidadeCalote) * 1000) 
                };
            }
            catch (Exception ex)
            {
                
                return GerarAnaliseFallback(solicitacao, "IA Indisponível: " + ex.Message);
            }
        }

        private AnaliseCredito GerarAnaliseFallback(SolicitacaoCredito s, string motivo)
        {
            
            bool aprovado = s.Renda >= (s.ValorSolicitado / 3);
            return new AnaliseCredito
            {
                Aprovado = aprovado,
                LimiteAprovado = aprovado ? s.Renda * 0.1m : 0,
                Mensagem = $"Análise de Contingência ({motivo})",
                DataAnalise = DateTime.Now,
                Score = 500
            };
        }
    }
}