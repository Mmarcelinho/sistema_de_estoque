namespace ApiEstoque.Controllers;

    public class LojaController:ControllerBase
    {
        [HttpGet("/loja")]
    public async Task<ActionResult<List<LojaOutput>>> ObterTodos([FromServices] DataContext Context)
    {

        var loja = await Context.Loja
        .Select(x => new LojaOutput
         (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Telefone,
          x.Inscricao,
          x.Cnpj,
          x.CidadeId 

         ))
        .ToListAsync();

        return Ok(loja);

    }

    [HttpGet("/loja/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        return await context.Loja.FindAsync(id)
        is Loja loja ? Ok(new LojaOutput
        (
         loja.Id,
         loja.Nome,
         loja.Endereco,
         loja.Numero,
         loja.Bairro,
         loja.Telefone,
         loja.Inscricao,
         loja.Cnpj,
         loja.CidadeId

        )) : NotFound();
    }

    [HttpGet("/cidade/loja/{id}")]
    public async Task<ActionResult<List<ListLojaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var lojaCidade = await context.Loja
        .Where(x => x.Cidade.Id == id)
        .Select(x => new ListLojaViewModels
        (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Telefone,
          x.Inscricao,
          x.Cnpj,
          x.CidadeId,
          x.Cidade.Nome

        )).ToListAsync();

        if (lojaCidade == null)
            return NotFound();

        return Ok(lojaCidade);
    }

    [HttpPost("/loja")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] LojaInput model)
    {

        if (!ModelState.IsValid)
            return BadRequest();

        var loja = new Loja
        (
         model.Id,
         model.Nome,
         model.Endereco,
         model.Numero,
         model.Bairro,
         model.Telefone,
         model.Inscricao,
         model.Cnpj,
         model.CidadeId

        );

        await context.Loja.AddAsync(loja);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/loja/{loja.Id}", new LojaOutput
        (
         loja.Id,
         loja.Nome,
         loja.Endereco,
         loja.Numero,
         loja.Bairro,
         loja.Telefone,
         loja.Inscricao,
         loja.Cnpj,
         loja.CidadeId

        )) : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpPut("/loja/{id}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] LojaInput model, int id)
    {

        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var loja = await context.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (loja == null)
            return NotFound();

        loja = new Loja
        (
         loja.Id,
         model.Nome,
         model.Endereco,
         model.Numero,
         model.Bairro,
         model.Telefone,
         model.Inscricao,
         model.Cnpj,
         model.CidadeId

        );

        context.Loja.Update(loja);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/loja/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var loja = await context.Loja.FindAsync(id);

        if (loja == null)
            return NotFound();

        context.Loja.Remove(loja);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }
        
    }
