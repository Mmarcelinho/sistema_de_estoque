namespace ApiEstoque.Controllers;

public class ItemEntradaController : ControllerBase
{

    [Produces(typeof(ItemEntradaOutput))]
    [ProducesResponseType(typeof(ItemEntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/itemEntrada")]
    public async Task<ActionResult<List<ItemEntradaOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaItemEntrada = await context.ItemEntrada.Select(x => new ItemEntradaOutput
         (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.EntradaId,
          x.ProdutoId

         ))
        .ToListAsync();

        if (!listaItemEntrada.Any())
            return NotFound($"Não existem itens");

        return Ok(listaItemEntrada);
    }


    [Produces(typeof(ItemEntradaOutput))]
    [ProducesResponseType(typeof(ItemEntradaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/itemEntrada/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var itemEntrada = await context.ItemEntrada.FindAsync(id);

        if (itemEntrada is null)
            return NotFound($"Não existe itens com o id {id}");

        return Ok(new ItemEntradaOutput
        (
         itemEntrada.Id,
         itemEntrada.Lote,
         itemEntrada.Quantidade,
         itemEntrada.Valor,
         itemEntrada.EntradaId,
         itemEntrada.ProdutoId
        ));
    }


    [Produces(typeof(ListItemEntradaViewModels))]
    [ProducesResponseType(typeof(ListItemEntradaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/entrada/itemEntrada/id/{id:int}")]
    public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaEntradaDeItensEntrada = await context.ItemEntrada
        .Where(x => x.Entrada.Id == id)
        .Select(x => new ListItemEntradaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.EntradaId,
          x.ProdutoId,
          x.Entrada.NumeroNotaFiscal,
          x.Produto.Nome

        )).ToListAsync();

        if (listaEntradaDeItensEntrada.Count == 0)
            return NotFound($"Não existe entrada com o id {id}");

        return Ok(listaEntradaDeItensEntrada);
    }


    [Produces(typeof(ListItemEntradaViewModels))]
    [ProducesResponseType(typeof(ListItemEntradaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/itemEntrada/id/{id:int}")]
    public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context,int id)
    {
        if (id == 0)
            return BadRequest();

        var listaProdutoDeItensEntrada = await context.ItemEntrada
        .Where(x => x.Produto.Id == id)
        .Select(x => new ListItemEntradaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.EntradaId,
          x.ProdutoId,
          x.Entrada.NumeroNotaFiscal,
          x.Produto.Nome
        )).ToListAsync();

        if (listaProdutoDeItensEntrada.Count == 0)
            return NotFound($"Não existe produto com o id {id}");

        return Ok(listaProdutoDeItensEntrada);
    }


    [Produces(typeof(ListItemEntradaViewModels))]
    [ProducesResponseType(typeof(ListItemEntradaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/entrada/itemEntrada/notafiscal/{notaFiscal:int}")]
    public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorNumeroUmParaMuitos([FromServices] DataContext context, int notaFiscal)
    {
        if (notaFiscal == 0)
            return BadRequest();

        var listaEntradaDeItensEntrada = await context.ItemEntrada
        .Where(x => x.Entrada.NumeroNotaFiscal == notaFiscal)
        .Select(x => new ListItemEntradaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.EntradaId,
          x.ProdutoId,
          x.Entrada.NumeroNotaFiscal,
          x.Produto.Nome

        )).ToListAsync();

        if (listaEntradaDeItensEntrada.Count == 0)
            return NotFound($"Não existe entrada com a Nota Fiscal {notaFiscal}");

        return Ok(listaEntradaDeItensEntrada);
    }


    [Produces(typeof(ListItemEntradaViewModels))]
    [ProducesResponseType(typeof(ListItemEntradaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/produto/itemEntrada/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorNomeUmParaMuitos([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaProdutoDeItensEntrada = await context.ItemEntrada
        .Where(n => n.Produto.Nome.Contains(nome))
        .Select(x => new ListItemEntradaViewModels
        (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.EntradaId,
          x.ProdutoId,
          x.Entrada.NumeroNotaFiscal,
          x.Produto.Nome
        )).ToListAsync();

        if (!listaProdutoDeItensEntrada.Any())
            return NotFound($"Não existem produtos com o nome {nome}");

        return Ok(listaProdutoDeItensEntrada);
    }

    [Produces(typeof(ItemEntradaOutput))]
    [ProducesResponseType(typeof(ItemEntradaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/itemEntrada")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] ItemEntradaInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var itemEntrada = new ItemEntrada
        (
         model.Id,
         model.Lote,
         model.Quantidade,
         model.Valor,
         model.EntradaId,
         model.ProdutoId
        );

        await context.ItemEntrada.AddAsync(itemEntrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/itemEntrada/{itemEntrada.Id}", new ItemEntradaOutput
        (
         itemEntrada.Id,
         itemEntrada.Lote,
         itemEntrada.Quantidade,
         itemEntrada.Valor,
         itemEntrada.EntradaId,
         itemEntrada.ProdutoId

        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Produces(typeof(ItemEntradaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/itemEntrada/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] ItemEntradaInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var itemEntrada = await context.ItemEntrada.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (itemEntrada is null)
            return NotFound();

        itemEntrada = new ItemEntrada
        (
         itemEntrada.Id,
         model.Lote,
         model.Quantidade,
         model.Valor,
         model.EntradaId,
         model.ProdutoId
        );

        context.ItemEntrada.Update(itemEntrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(ItemEntradaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/itemEntrada/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var itemEntrada = await context.ItemEntrada.FindAsync(id);

        if (itemEntrada is null)
            return NotFound();

        context.ItemEntrada.Remove(itemEntrada);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
