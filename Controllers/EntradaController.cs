namespace ApiEstoque.Controllers;

public class EntradaController : ControllerBase
{   

    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(typeof(EntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/entrada")]
    public async Task<ActionResult<List<EntradaOutput>>> ObterTodos([FromServices] DataContext context)
    {

        var listaEntrada = await context.Entrada.Select(x => new EntradaOutput
        (
         x.Id,
         x.Total,
         x.DataPedido,
         x.DataEntrada,
         x.Frete,
         x.NumeroNotaFiscal,
         x.Imposto,
         x.TransportadoraId
        ))
        .ToListAsync();

        if(listaEntrada.Count == 0)
        return NotFound();

        return Ok(listaEntrada);
    }


    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(typeof(EntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/entrada/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
         if (id == 0)
            return BadRequest();

        var entrada = await context.Entrada.FindAsync(id);

        if(entrada == null)
        return NotFound();

        return Ok(new EntradaOutput
        (
         entrada.Id,
         entrada.Total,
         entrada.DataPedido,
         entrada.DataEntrada,
         entrada.Frete,
         entrada.NumeroNotaFiscal,
         entrada.Imposto,
         entrada.TransportadoraId
        ));
    }

    [Produces(typeof(ListEntradaViewModels))]
    [ProducesResponseType(typeof(ListEntradaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora/entrada/id/{id:int}")]
    public async Task<ActionResult<List<ListEntradaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {   
        if (id == 0)
            return BadRequest();

        var listaTransportadoraDeEntradas = await context.Entrada
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

        if (listaTransportadoraDeEntradas.Count == 0)
            return NotFound($"Não existe transportadora com o id {id}");

        return Ok(listaTransportadoraDeEntradas);
    }


    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(typeof(EntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/entrada/notafiscal/{notaFiscal:int}")]
    public async Task<IActionResult> ObterPorNotaFiscal([FromServices] DataContext context, int notaFiscal)
    {
        if (notaFiscal == 0)
            return BadRequest();

        var entrada = await context.Entrada.Where(n => n.NumeroNotaFiscal == notaFiscal).FirstOrDefaultAsync();

        if(entrada == null)
        return NotFound($"Não existe nota fiscal com os dígitos {notaFiscal}");

        return Ok(new EntradaOutput
        (
         entrada.Id,
         entrada.Total,
         entrada.DataPedido,
         entrada.DataEntrada,
         entrada.Frete,
         entrada.NumeroNotaFiscal,
         entrada.Imposto,
         entrada.TransportadoraId
        ));
    }


    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(typeof(EntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("transportadora/entrada/nome/{nome:alpha}")]
    public async Task<ActionResult<List<Entrada>>> ObterPorNomeParaMuitos([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaTransportadoraDeEntradas = await context.Entrada
        .Where(x => x.Transportadora.Nome.Contains(nome))
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

        if (listaTransportadoraDeEntradas.Count == 0)
            return NotFound($"Não existem transportadoras com o nome {nome}");

        return Ok(listaTransportadoraDeEntradas);
    }


    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(typeof(EntradaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/entrada/id/{id:int}")]
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

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Produces(typeof(EntradaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/entrada/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var entrada = await context.Entrada.FindAsync(id);

        if (entrada == null)
            return NotFound();

        context.Entrada.Remove(entrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }
}
