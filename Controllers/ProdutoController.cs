namespace ApiEstoque.Controllers;
public class ProdutoController : ControllerBase
{
    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(typeof(ProdutoOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto")]
    public async Task<ActionResult<List<ProdutoOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaProduto = await context.Produto.Select(x => new ProdutoOutput(x.Id, x.Nome, x.Descricao, x.Peso, x.Controlado, x.QuantMinima)).ToListAsync();

        if (listaProduto.Count == 0)
            return NotFound();

        return Ok(listaProduto);
    }


    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(typeof(ProdutoOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var produto = await context.Produto.FindAsync(id);

        if (produto == null)
            return NotFound();

        return Ok(new ProdutoOutput
        (
         produto.Id,
         produto.Nome,
         produto.Descricao,
         produto.Peso,
         produto.Controlado,
         produto.QuantMinima
        ));
    }


    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(typeof(ProdutoOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/nome/{nome:alpha}")]
    public async Task<ActionResult<List<Produto>>> ObterPorNome([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaProduto = await context.Produto
        .Where(n => n.Nome.Contains(nome))
        .Select(x => new ProdutoOutput
            (
             x.Id,
             x.Nome,
             x.Descricao,
             x.Peso,
             x.Controlado,
             x.QuantMinima

            )).ToListAsync();

        if (listaProduto.Count == 0)
            return NotFound($"Não existem produtos com o nome {nome}");

        return Ok(listaProduto);
    }


    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(typeof(ProdutoOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/produto")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] ProdutoInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var produto = new Produto
        (
         model.Id,
         model.Nome,
         model.Descricao,
         model.Peso,
         model.Controlado,
         model.QuantMinima
        );

        await context.Produto.AddAsync(produto);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/produto/{produto.Id}", new ProdutoOutput
        (
         produto.Id,
         produto.Nome,
         produto.Descricao,
         produto.Peso,
         produto.Controlado,
         produto.QuantMinima
        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/produto/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] ProdutoInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var produto = await context.Produto.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (produto == null)
            return NotFound();

        produto = new Produto
        (
         produto.Id,
         model.Nome,
         model.Descricao,
         model.Peso,
         model.Controlado,
         model.QuantMinima);

        context.Produto.Update(produto);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Produces(typeof(ProdutoOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/produto/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var produto = await context.Produto.FindAsync(id);

        if (produto == null)
            return NotFound();

        context.Produto.Remove(produto);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
