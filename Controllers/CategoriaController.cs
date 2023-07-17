namespace ApiEstoque.Controllers;

public class CategoriaController : ControllerBase
{

    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(typeof(CategoriaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/categoria")]
    public async Task<ActionResult<List<CategoriaOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaCategoria = await context.Categoria.Select(x => new CategoriaOutput(x.Id, x.Titulo)).ToListAsync();

        if (listaCategoria.Count == 0)
            return NotFound();

            return Ok(listaCategoria);
    }


    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(typeof(CategoriaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/categoria/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var categoria = await context.Categoria.FindAsync(id);

        if (categoria is null)
            return NotFound();

        return Ok(new CategoriaOutput(categoria.Id, categoria.Titulo));
    }


    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(typeof(CategoriaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/categoria/{nome:alpha}")]
    public async Task<ActionResult<List<Categoria>>> ObterPorNome([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaCategoria = await context.Categoria
        .Where(n => n.Titulo.Contains(nome))
        .Select(x => new CategoriaOutput(x.Id, x.Titulo))
        .ToListAsync();

        if (listaCategoria.Count == 0)
            return NotFound($"Não existem categorias com o nome {nome}");

        return Ok(listaCategoria);
    }


    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(typeof(CategoriaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/categoria")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] CategoriaInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoria = new Categoria(model.Id, model.Titulo);

        await context.Categoria.AddAsync(categoria);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/Categoria/{categoria.Id}", new CategoriaOutput(categoria.Id, categoria.Titulo)) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/categoria/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] CategoriaInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoria = await context.Categoria.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (categoria is null)
            return NotFound($"Não existe categoria com o id {id}");

        categoria = new Categoria(categoria.Id, model.Titulo);

        context.Categoria.Update(categoria);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpDelete("/categoria/id/{id:int}")]
    [Produces(typeof(CategoriaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var categoria = await context.Categoria.FindAsync(id);

        if (categoria is null)
            return NotFound($"Não existe categoria com o id {id}");

        context.Categoria.Remove(categoria);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
