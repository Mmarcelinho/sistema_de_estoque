namespace ApiEstoque.Controllers;

public class ItemSaidaController : ControllerBase
{   
    [Produces(typeof(ItemSaidaOutput))]
    [ProducesResponseType(typeof(ItemSaidaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/itemSaida")]
    public async Task<ActionResult<List<ItemSaidaOutput>>> ObterTodos([FromServices] DataContext Context)
    {
        var listaItemSaida = await Context.ItemSaida.Select(x => new ItemSaidaOutput
         (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.SaidaId,
          x.ProdutoId
         ))
        .ToListAsync();

        if(listaItemSaida.Count == 0)
            return NotFound();

        return Ok(listaItemSaida);
    }


    [Produces(typeof(ItemSaidaOutput))]
    [ProducesResponseType(typeof(ItemSaidaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/itemSaida/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var itemSaida = await context.ItemSaida.FindAsync(id);

        if(itemSaida == null)
            return NotFound();

        return Ok(new ItemSaidaOutput
        (
         itemSaida.Id,
         itemSaida.Lote,
         itemSaida.Quantidade,
         itemSaida.Valor,
         itemSaida.SaidaId,
         itemSaida.ProdutoId
        ));
    }


    [Produces(typeof(ListItemSaidaViewModels))]
    [ProducesResponseType(typeof(ListItemSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/saida/itemSaida/id/{id:int}")]
    public async Task<ActionResult<List<ListItemSaidaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaSaidaDeItensSaida = await context.ItemSaida
        .Where(x => x.Saida.Id == id)
        .Select(x => new ListItemSaidaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.SaidaId,
          x.ProdutoId,
          x.Saida.Total,
          x.Produto.Descricao

        )).ToListAsync();

        if (listaSaidaDeItensSaida.Count == 0)
            return NotFound();

        return Ok(listaSaidaDeItensSaida);
    }


    [Produces(typeof(ListItemSaidaViewModels))]
    [ProducesResponseType(typeof(ListItemSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/itemSaida/id/{id:int}")]
    public async Task<ActionResult<List<ListItemSaidaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaProdutoDeItensSaida = await context.ItemSaida
        .Where(x => x.Produto.Id == id)
        .Select(x => new ListItemSaidaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.SaidaId,
          x.ProdutoId,
          x.Saida.Total,
          x.Produto.Descricao

        )).ToListAsync();

        if (listaProdutoDeItensSaida.Count == 0)
            return NotFound();

        return Ok(listaProdutoDeItensSaida);
    }


    [Produces(typeof(ListItemSaidaViewModels))]
    [ProducesResponseType(typeof(ListItemSaidaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/itemSaida/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListItemSaidaViewModels>>> ObterPorNomeUmParaMuitos([FromServices] DataContext context, string nome)
    {

        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaProdutoDeItensSaida = await context.ItemSaida
        .Where(x => x.Produto.Nome.Contains(nome))
        .Select(x => new ListItemSaidaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.SaidaId,
          x.ProdutoId,
          x.Saida.Total,
          x.Produto.Nome

        )).ToListAsync();

        if (listaProdutoDeItensSaida.Count == 0)
            return NotFound();

        return Ok(listaProdutoDeItensSaida);
    }


    [Produces(typeof(ItemSaidaOutput))]
    [ProducesResponseType(typeof(ItemSaidaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/itemSaida")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] ItemSaidaInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var itemSaida = new ItemSaida
        (
         model.Id,
         model.Lote,
         model.Quantidade,
         model.Valor,
         model.SaidaId,
         model.ProdutoId
        );

        await context.ItemSaida.AddAsync(itemSaida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/itemSaida/{itemSaida.Id}", new ItemSaidaOutput
        (
         itemSaida.Id,
         itemSaida.Lote,
         itemSaida.Quantidade,
         itemSaida.Valor,
         itemSaida.SaidaId,
         itemSaida.ProdutoId

        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }

    
    [Produces(typeof(ItemSaidaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/itemSaida/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] ItemSaidaInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var itemSaida = await context.ItemSaida.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (itemSaida == null)
            return NotFound();

        itemSaida = new ItemSaida
        (
         itemSaida.Id,
         model.Lote,
         model.Quantidade,
         model.Valor,
         model.SaidaId,
         model.ProdutoId
        );

        context.ItemSaida.Update(itemSaida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(ItemSaidaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/itemSaida/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var itemSaida = await context.ItemSaida.FindAsync(id);

        if (itemSaida == null)
            return NotFound();

        context.ItemSaida.Remove(itemSaida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


}
