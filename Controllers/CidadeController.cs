namespace ApiEstoque.Controllers;

public class CidadeController : ControllerBase
{

    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(typeof(CidadeOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade")]
    public async Task<ActionResult<List<CidadeOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaCidade = await context.Cidade.Select(x => new CidadeOutput(x.Id, x.Nome, x.Uf)).ToListAsync();

        if (listaCidade.Count == 0)
            return NotFound();

        return Ok(listaCidade);
    }


    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(typeof(CidadeOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        var cidade = await context.Cidade.FindAsync(id);

        if (cidade == null)
            return NotFound();

        return Ok(new CidadeOutput(cidade.Id, cidade.Nome, cidade.Uf));
    }


    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(typeof(CidadeOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade/nome/{nome:alpha}")]
    public async Task<ActionResult<List<Cidade>>> ObterPorNome([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaCidade = await context.Cidade
        .Where(n => n.Nome.Contains(nome))
        .Select(x => new CidadeOutput(x.Id, x.Nome, x.Uf))
        .ToListAsync();

        if (listaCidade.Count == 0)
            return NotFound($"Não existem cidades com o nome {nome}");
    
        return Ok(listaCidade);
    }


    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(typeof(CidadeOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/cidade")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] CidadeInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var cidade = new Cidade(model.Id, model.Nome, model.Uf);

        await context.Cidade.AddAsync(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/Cidade/{cidade.Id}", new CidadeOutput(cidade.Id, cidade.Nome, cidade.Uf)) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/cidade/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] CidadeInput model, int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var cidade = await context.Cidade.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (cidade == null)
            return NotFound();

        cidade = new Cidade(cidade.Id, model.Nome, model.Uf);

        context.Cidade.Update(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Produces(typeof(CidadeOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/cidade/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var cidade = await context.Cidade.FindAsync(id);

        if (cidade == null)
            return NotFound();

        context.Cidade.Remove(cidade);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
