namespace SistemaDeEstoque.Api.Controllers;

public class LoginController : SistemaDeEstoqueController
{
    [HttpPost]
    [Route("admin/")]
    [ProducesResponseType(typeof(RespostaLoginAdminJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginAdmin([FromServices] IMediator _mediator, [FromBody] LoginAdminUseCaseCommand requisicao)
    {
        var resposta = await _mediator.Send(requisicao);

        return Ok(resposta);
    }
}
