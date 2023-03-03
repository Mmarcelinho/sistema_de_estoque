namespace ApiEstoque.Controllers;

    public class ItemEntradaController:ControllerBase
    {
        [HttpGet("/itemEntrada")]
        public async Task<ActionResult<List<ItemEntradaOutput>>> ObterTodos([FromServices] DataContext context)
        {

            var itemEntrada = await context.ItemEntrada.Select(x => new ItemEntradaOutput
             (
              x.Id,
              x.Lote,
              x.Quantidade,
              x.Valor,
              x.EntradaId,
              x.ProdutoId
              
             ))
            .ToListAsync();

            return Ok(itemEntrada);

        }

        [HttpGet("/itemEntrada/{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            return await context.ItemEntrada.FindAsync(id)
            is ItemEntrada itemEntrada ? Ok(new ItemEntradaOutput
            (
             itemEntrada.Id,
             itemEntrada.Lote,
             itemEntrada.Quantidade,
             itemEntrada.Valor,
             itemEntrada.EntradaId,
             itemEntrada.ProdutoId

            )) : NotFound();
        }

        [HttpGet("/entrada/itemEntrada/{id}")]
        public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var itemEntradaEntrada = await context.ItemEntrada
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
              x.Produto.Descricao

            )).ToListAsync();

            if (itemEntradaEntrada == null)
                return NotFound();

            return Ok(itemEntradaEntrada);
        }


         [HttpGet("/produto/itemEntrada/{id}")]
        public async Task<ActionResult<List<ListItemEntradaViewModels>>> ObterPorIdUmParaMuitosv2([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var itemEntradaEntrada = await context.ItemEntrada
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
              x.Produto.Descricao

            )).ToListAsync();

            if (itemEntradaEntrada == null)
                return NotFound();

            return Ok(itemEntradaEntrada);
        }

        [HttpPost("/itemEntrada")]
        public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] ItemEntradaInput model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

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

            )) : BadRequest("Houve um problema ao salvar o registro");

        }

        [HttpPut("/itemEntrada/{id}")]
        public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] ItemEntradaInput model, int id)
        {

            if (id == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var itemEntrada = await context.ItemEntrada.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (itemEntrada == null)
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

            return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

        }

        [HttpDelete("/itemEntrada/{id}")]
        public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var itemEntrada = await context.ItemEntrada.FindAsync(id);

            if (itemEntrada == null)
                return NotFound();

            context.ItemEntrada.Remove(itemEntrada);
            var result = await context.SaveChangesAsync();

            return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

        }
    }
