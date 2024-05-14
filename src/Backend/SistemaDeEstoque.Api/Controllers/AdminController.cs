namespace SistemaDeEstoque.Api.Controllers;

public class AdminController : SistemaDeEstoqueController
{
    [HttpGet]
    [ProducesResponseType(typeof(RespostaPerfilAdminJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPerfil([FromServices] Mediator _mediator)
    {
        var resposta = await _mediator.Send(new RecuperarPerfilAdminQuery());

        return Ok(resposta);
    }
}
