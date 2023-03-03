namespace ApiEstoque.Controllers;

public class ItemSaidaController : ControllerBase
{
    [HttpGet("/itemSaida")]
    public async Task<ActionResult<List<ItemSaidaOutput>>> ObterTodos([FromServices] DataContext Context)
    {

        var itemSaida = await Context.ItemSaida.Select(x => new ItemSaidaOutput
         (
          x.Id,
          x.Lote,
          x.Quantidade,
          x.Valor,
          x.SaidaId,
          x.ProdutoId

         ))
        .ToListAsync();

        return Ok(itemSaida);

    }

    [HttpGet("/itemSaida/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        return await context.ItemSaida.FindAsync(id)
        is ItemSaida itemSaida ? Ok(new ItemSaidaOutput
        (
         itemSaida.Id,
         itemSaida.Lote,
         itemSaida.Quantidade,
         itemSaida.Valor,
         itemSaida.SaidaId,
         itemSaida.ProdutoId

        )) : NotFound();
    }

    [HttpGet("/saida/itemSaida/{id}")]
    public async Task<ActionResult<List<ListItemSaidaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var itemSaidaSaida = await context.ItemSaida
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

        if (itemSaidaSaida == null)
            return NotFound();

        return Ok(itemSaidaSaida);
    }

    [HttpGet("/produto/itemSaida/{id}")]
    public async Task<ActionResult<List<ListItemSaidaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var itemSaidaSaida = await context.ItemSaida
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

        if (itemSaidaSaida == null)
            return NotFound();

        return Ok(itemSaidaSaida);
    }

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

        )) : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpPut("/itemSaida/{id}")]
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

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/itemSaida/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var itemSaida = await context.ItemSaida.FindAsync(id);

        if (itemSaida == null)
            return NotFound();

        context.ItemSaida.Remove(itemSaida);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }


}
