using CsharpBackend.Models;
using Microsoft.AspNetCore.Mvc;
using CsharpBackend.Models; 
 

[ApiController]
[Route("api/[controller]")]
public class AnaliseController : ControllerBase
{
    private readonly AnaliseService _service;

    
    public AnaliseController(AnaliseService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SolicitarAnalise([FromBody] SolicitacaoCredito solicitacao)
    {
        if (solicitacao == null) return BadRequest("Dados inválidos.");

        var resultado = await _service.ProcessarSolicitacao(solicitacao);

        return Ok(resultado);
    }
}