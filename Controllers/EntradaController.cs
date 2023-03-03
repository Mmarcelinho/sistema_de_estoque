namespace ApiEstoque.Controllers;

public class EntradaController : ControllerBase
{
    [HttpGet("/entrada")]
    public async Task<ActionResult<List<EntradaOutput>>> ObterTodos([FromServices] DataContext context)
    {

        var entrada = await context.Entrada.Select(x => new EntradaOutput(
         x.Id,
         x.Total,
         x.DataPedido,
         x.DataEntrada,
         x.Frete,
         x.NumeroNotaFiscal,
         x.Imposto,
         x.TransportadoraId))
        .ToListAsync();

        return Ok(entrada);

    }

    [HttpGet("/entrada/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        return await context.Entrada.FindAsync(id)
        is Entrada entrada ? Ok(new EntradaOutput
        (
         entrada.Id,
         entrada.Total,
         entrada.DataPedido,
         entrada.DataEntrada,
         entrada.Frete,
         entrada.NumeroNotaFiscal,
         entrada.Imposto,
         entrada.TransportadoraId

        )) : NotFound();
    }

    [HttpGet("/transportadora/entrada/{id}")]
    public async Task<ActionResult<List<ListEntradaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var entradaTransportadora = await context.Entrada
        .Where(x => x.Transportadora.Id == id)
        .Select(x => new ListEntradaViewModels
        (
         x.Id,
         x.DataPedido,
         x.DataEntrada,
         x.Total,
         x.Frete,
         x.NumeroNotaFiscal,
         x.Imposto,
         x.TransportadoraId,
         x.Transportadora.Nome

        )).ToListAsync();

        if (entradaTransportadora == null)
            return NotFound();

        return Ok(entradaTransportadora);
    }

    [HttpPost("/entrada")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] EntradaInput model)
    {

        if (!ModelState.IsValid)
            return BadRequest();

        var entrada = new Entrada
        (
         model.Id,
         DateTime.Now,
         DateTime.Now,
         model.Total,
         model.Frete,
         model.NumeroNotaFiscal,
         model.Imposto,
         model.TransportadoraId
        );

        await context.Entrada.AddAsync(entrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/entrada/{entrada.Id}", new EntradaOutput
        (
         entrada.Id,
         entrada.Total,
         entrada.DataPedido,
         entrada.DataEntrada,
         entrada.Frete,
         entrada.NumeroNotaFiscal,
         entrada.Imposto,
         entrada.TransportadoraId

        )) : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpPut("/entrada/{id}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] EntradaInput model, int id)
    {

        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var entrada = await context.Entrada.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (entrada == null)
            return NotFound();

        entrada = new Entrada
        (
         entrada.Id,
         DateTime.Now,
         DateTime.Now,
         model.Total,
         model.Frete,
         model.NumeroNotaFiscal,
         model.Imposto,
         model.TransportadoraId
        );

        context.Entrada.Update(entrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/entrada/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var entrada = await context.Entrada.FindAsync(id);

        if (entrada == null)
            return NotFound();

        context.Entrada.Remove(entrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }
}
