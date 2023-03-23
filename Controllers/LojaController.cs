namespace ApiEstoque.Controllers;
public class LojaController : ControllerBase
{

    [Produces(typeof(LojaOutput))]
    [ProducesResponseType(typeof(LojaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/loja")]
    public async Task<ActionResult<List<LojaOutput>>> ObterTodos([FromServices] DataContext Context)
    {
        var listaLoja = await Context.Loja
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
         )).ToListAsync();

        if (!listaLoja.Any())
            return NotFound();

        return Ok(listaLoja);
    }


    [Produces(typeof(LojaOutput))]
    [ProducesResponseType(typeof(LojaOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/loja/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var loja = await context.Loja.FindAsync(id);

        if (loja is null)
            return NotFound();

        return Ok(new LojaOutput
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
        ));
    }


    [Produces(typeof(ListLojaViewModels))]
    [ProducesResponseType(typeof(ListLojaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade/loja/id/{id:int}")]
    public async Task<ActionResult<List<ListLojaViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listCidadeDeLojas = await context.Loja
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

        if (!listCidadeDeLojas.Any())
            return NotFound();

        return Ok(listCidadeDeLojas);
    }


    [Produces(typeof(ListLojaViewModels))]
    [ProducesResponseType(typeof(ListLojaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/loja/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListLojaViewModels>>> ObterPorNome([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaLoja = await context.Loja
        .Where(n => n.Nome.Contains(nome))
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

        if (!listaLoja.Any())
            return NotFound($"Não existem lojas com o nome {nome}");

        return Ok(listaLoja);
    }


    [Produces(typeof(ListLojaViewModels))]
    [ProducesResponseType(typeof(ListLojaViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("cidade/loja/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListLojaViewModels>>> ObterPorNomeV2([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaCidadeDeLojas = await context.Loja
        .Where(n => n.Cidade.Nome.Contains(nome))
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

        if (!listaCidadeDeLojas.Any())
            return NotFound($"Não existem cidades com o nome {nome}");

        return Ok(listaCidadeDeLojas);
    }


    [Produces(typeof(LojaOutput))]
    [ProducesResponseType(typeof(LojaOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/loja")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] LojaInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

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

        )) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(LojaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/loja/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] LojaInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var loja = await context.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (loja is null)
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

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(LojaOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/loja/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var loja = await context.Loja.FindAsync(id);

        if (loja is null)
            return NotFound();

        context.Loja.Remove(loja);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }

}
