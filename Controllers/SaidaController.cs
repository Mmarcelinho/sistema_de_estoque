namespace ApiEstoque.Controllers;

public class saidaController : ControllerBase
{

    [HttpGet("/saida")]
    public async Task<ActionResult<List<SaidaOutput>>> ObterTodos([FromServices] DataContext context)
    {

        var saida = await context.Saida.Select(x => new SaidaOutput
         (
          x.Id,
          x.Total,
          x.Frete,
          x.Imposto,
          x.LojaId,
          x.TransportadoraId

         ))
        .ToListAsync();

        return Ok(saida);

    }

    [HttpGet("/saida/{id}")]
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

    [HttpGet("/loja/saida/{id}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var saidaEntrada = await context.Saida
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

        if (saidaEntrada == null)
            return NotFound();

        return Ok(saidaEntrada);
    }


    [HttpGet("/transportadora/saida/{id}")]
    public async Task<ActionResult<List<ListSaidaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var saidaEntrada = await context.Saida
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

        if (saidaEntrada == null)
            return NotFound();

        return Ok(saidaEntrada);
    }

    [HttpPost("/saida")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] SaidaInput model)
    {

        if (!ModelState.IsValid)
            return BadRequest();

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

        )) : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpPut("/saida/{id}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] SaidaInput model, int id)
    {

        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var saida = await context.Saida.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (saida == null)
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

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/saida/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var saida = await context.Saida.FindAsync(id);

        if (saida == null)
            return NotFound();

        context.Saida.Remove(saida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

}
