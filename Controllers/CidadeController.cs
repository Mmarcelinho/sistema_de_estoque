namespace ApiEstoque.Controllers;

public class CidadeController : ControllerBase
{
    [HttpGet("/cidade")]
    public async Task<ActionResult<List<CidadeOutput>>> ObterTodos([FromServices] DataContext context)
    {

        var cidade = await context.Cidade.Select(x => new CidadeOutput(x.Id, x.Nome, x.Uf)).ToListAsync();

        return Ok(cidade);

    }

    [HttpGet("/cidade/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        return await context.Cidade.FindAsync(id)
        is Cidade cidade ? Ok(new CidadeOutput(cidade.Id, cidade.Nome, cidade.Uf)) : NotFound();
    }


    [HttpPost("/cidade")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] CidadeInput model)
    {

        if (!ModelState.IsValid)
            return BadRequest();

        var cidade = new Cidade(model.Id, model.Nome, model.Uf);

        await context.Cidade.AddAsync(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/Cidade/{cidade.Id}", new CidadeOutput(cidade.Id, cidade.Nome, cidade.Uf)) : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpPut("/cidade/{id}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] CidadeInput model, int id)
    {

        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var cidade = await context.Cidade.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (cidade == null)
            return NotFound();

        cidade = new Cidade(model.Id, model.Nome, model.Uf);

        context.Cidade.Update(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/cidade/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var cidade = await context.Cidade.FindAsync(id);

        if (cidade == null)
            return NotFound();

        context.Cidade.Remove(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

}
