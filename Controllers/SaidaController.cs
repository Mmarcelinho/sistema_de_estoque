namespace ApiEstoque.Controllers;

public class SaidaController : ControllerBase
{

    [Produces(typeof(SaidaOutput))]
    [ProducesResponseType(typeof(SaidaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/saida")]
    public async Task<ActionResult<List<SaidaOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaSaida = await context.Saida.Select(x => new SaidaOutput
         (
          x.Id,
          x.Total,
          x.Frete,
          x.Imposto,
          x.LojaId,
          x.TransportadoraId
         )).ToListAsync();

        return Ok(listaSaida);
    }


    [Produces(typeof(SaidaOutput))]
    [ProducesResponseType(typeof(SaidaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/saida/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        return await context.Saida.FindAsync(id)
        is Saida saida ? Ok(new SaidaOutput
        (
         saida.Id,
         saida.Total,
         saida.Frete,
         saida.Imposto,
         saida.LojaId,
         saida.TransportadoraId
        )) : NotFound();
    }
    

    [Produces(typeof(ListSaidaViewModels))]
    [ProducesResponseType(typeof(ListSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/loja/saida/id/{id:int}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaLojaDeSaidas = await context.Saida
        .Where(x => x.LojaId == id)
        .Select(x => new ListSaidaViewModels
        (
         x.Id,
         x.Total,
         x.Frete,
         x.Imposto,
         x.LojaId,
         x.TransportadoraId,
         x.Loja.Nome,
         x.Transportadora.Nome
        )).ToListAsync();

        if (!listaLojaDeSaidas.Any())
            return NotFound($"Não existe loja com o id {id}");

        return Ok(listaLojaDeSaidas);
    }


    [Produces(typeof(ListSaidaViewModels))]
    [ProducesResponseType(typeof(ListSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora/saida/id/{id:int}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaTransportadoraDeSaidas = await context.Saida
        .Where(x => x.Transportadora.Id == id)
        .Select(x => new ListSaidaViewModels
        (
          x.Id,
          x.Total,
          x.Frete,
          x.Imposto,
          x.LojaId,
          x.TransportadoraId,
          x.Loja.Nome,
          x.Transportadora.Nome

        )).ToListAsync();

        if (!listaTransportadoraDeSaidas.Any())
            return NotFound($"Não existe transportadora com o id {id}");

        return Ok(listaTransportadoraDeSaidas);
    }


    [Produces(typeof(ListSaidaViewModels))]
    [ProducesResponseType(typeof(ListSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/loja/saida/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorNomeUmParaMuitos([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaLojaDeSaidas = await context.Saida
        .Where(x => x.Loja.Nome.Contains(nome))
        .Select(x => new ListSaidaViewModels
        (
          x.Id,
          x.Total,
          x.Frete,
          x.Imposto,
          x.LojaId,
          x.TransportadoraId,
          x.Loja.Nome,
          x.Transportadora.Nome
        )).ToListAsync();

        if (!listaLojaDeSaidas.Any())
            return NotFound($"Não existem lojas com o nome {nome}");

        return Ok(listaLojaDeSaidas);
    }


    [Produces(typeof(ListSaidaViewModels))]
    [ProducesResponseType(typeof(ListSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora/saida/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorNomeUmParaMuitosv2([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaTransportadoraDeSaidas = await context.Saida
        .Where(x => x.Transportadora.Nome.Contains(nome))
        .Select(x => new ListSaidaViewModels
        (
          x.Id,
          x.Total,
          x.Frete,
          x.Imposto,
          x.LojaId,
          x.TransportadoraId,
          x.Loja.Nome,
          x.Transportadora.Nome

        )).ToListAsync();

        if (!listaTransportadoraDeSaidas.Any())
            return NotFound($"Não existem transportadoras com o nome {nome}");

        return Ok(listaTransportadoraDeSaidas);
    }


    [Produces(typeof(SaidaOutput))]
    [ProducesResponseType(typeof(SaidaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]                                                                      
    [HttpPost("/saida")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] SaidaInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var saida = new Saida
        (
          model.Id,
          model.Total,
          model.Frete,
          model.Imposto,
          model.LojaId,
          model.TransportadoraId
        );

        await context.Saida.AddAsync(saida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/saida/{saida.Id}", new SaidaOutput
        (
         saida.Id,
         saida.Total,
         saida.Frete,
         saida.Imposto,
         saida.LojaId,
         saida.TransportadoraId
        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(SaidaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/saida/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] SaidaInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var saida = await context.Saida.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (saida is null)
            return NotFound();

        saida = new Saida
        (
         saida.Id,
         model.Total,
         model.Frete,
         model.Imposto,
         model.LojaId,
         model.TransportadoraId
        );

        context.Saida.Update(saida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(SaidaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/saida/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var saida = await context.Saida.FindAsync(id);

        if (saida is null)
            return NotFound();

        context.Saida.Remove(saida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
