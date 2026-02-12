using CsharpBackend.Data;
using CsharpBackend.Models;
using CsharpBackend.Data; 
using CsharpBackend.Models;
using System.Text;
using System.Text.Json;

public class AnaliseService 
{
    private readonly AppDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;

    public AnaliseService(AppDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AnaliseCredito> ProcessarSolicitacao(SolicitacaoCredito solicitacao)
    {

        if (solicitacao.Idade < 18)
        {
            return await SalvarERetornarRejeicao(solicitacao, "Menor de idade");
        }

        
        decimal limiteParcela = solicitacao.Renda * 0.3m;
        if (solicitacao.ValorParcela > limiteParcela)
        {
            return await SalvarERetornarRejeicao(solicitacao, "Parcela excede 30% da renda");
        }

        try
        {
            var client = _httpClientFactory.CreateClient();

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(solicitacao),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("http://localhost:5000/predict", jsonContent);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseBody);

            double scoreDouble = doc.RootElement.GetProperty("score").GetDouble();
            decimal scoreFinal = (decimal)scoreDouble;

            bool aprovado = scoreFinal <= 0.6m;
            string mensagem = aprovado ? "Aprovado via IA" : "Risco Alto detectado";

            var analiseFinal = new AnaliseCredito
            {
                Nome = solicitacao.Nome,
                CPF = solicitacao.CPF,
                ValorSolicitado = solicitacao.ValorSolicitado,
                Score = scoreFinal,
                Aprovado = aprovado,
                Mensagem = mensagem,
                DataAnalise = DateTime.Now
            };

            _context.Analises.Add(analiseFinal);
            await _context.SaveChangesAsync();

            return analiseFinal;
        }
        catch (Exception ex)
        {
            return await SalvarERetornarRejeicao(solicitacao, $"Erro na IA: {ex.Message}");
        }
    }

    private async Task<AnaliseCredito> SalvarERetornarRejeicao(SolicitacaoCredito sol, string motivo)
    {
        var analise = new AnaliseCredito
        {
            Nome = sol.Nome,
            CPF = sol.CPF,
            ValorSolicitado = sol.ValorSolicitado,
            Aprovado = false,
            Mensagem = motivo,
            DataAnalise = DateTime.Now,
            Score = 0 
        };

        _context.Analises.Add(analise);
        await _context.SaveChangesAsync();
        return analise;
    }
}