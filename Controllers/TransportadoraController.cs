namespace ApiEstoque.Controllers;

public class TransportadoraController : ControllerBase
{   
    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(typeof(TransportadoraOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora")]
    public async Task<ActionResult<List<TransportadoraOutput>>> ObterTodos([FromServices] DataContext context)
    {
        var listaTransportadora = await context.Transportadora.Select(x => new TransportadoraOutput
         (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Cep,
          x.Cnpj,
          x.Inscricao,
          x.Contato,
          x.Telefone,
          x.CidadeId

         ))
        .ToListAsync();

        if(!listaTransportadora.Any())
        return NotFound();

        return Ok(listaTransportadora);
    }


    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(typeof(TransportadoraOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora/id/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var transportadora = await context.Transportadora.FindAsync(id);

        if(transportadora is null)
        return NotFound();

        return Ok(new TransportadoraOutput
        (
         transportadora.Id,
         transportadora.Nome,
         transportadora.Endereco,
         transportadora.Numero,
         transportadora.Bairro,
         transportadora.Cep,
         transportadora.Cnpj,
         transportadora.Inscricao,
         transportadora.Contato,
         transportadora.Telefone,
         transportadora.CidadeId
        ));
    }


    [Produces(typeof(ListTransportadoraViewModels))]
    [ProducesResponseType(typeof(ListTransportadoraViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade/transportadora/id/{id:int}")]
    public async Task<ActionResult<List<ListTransportadoraViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var listaCidadeDeTransportadoras = await context.Transportadora
        .Where(x => x.CidadeId == id)
        .Select(x => new ListTransportadoraViewModels
        (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Cep,
          x.Cnpj,
          x.Inscricao,
          x.Contato,
          x.Telefone,
          x.CidadeId,
          x.Cidade.Nome
        )).ToListAsync();

        if (!listaCidadeDeTransportadoras.Any())
            return NotFound();

        return Ok(listaCidadeDeTransportadoras);
    }


    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(typeof(TransportadoraOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/transportadora/nome/{nome:alpha}")]
    public async Task<ActionResult<List<Transportadora>>> ObterPorNome([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaTransportadora = await context.Transportadora
        .Where(n => n.Nome.Contains(nome))
        .Select(x => new ListTransportadoraViewModels
        (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Cep,
          x.Cnpj,
          x.Inscricao,
          x.Contato,
          x.Telefone,
          x.CidadeId,
          x.Cidade.Nome
        ))
        .ToListAsync();

        if (listaTransportadora is null)
            return NotFound($"Não existem transportadoras com o nome {nome}");

        return Ok(listaTransportadora);
    }


    [Produces(typeof(ListTransportadoraViewModels))]
    [ProducesResponseType(typeof(ListTransportadoraViewModels), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("/cidade/transportadora/nome/{nome:alpha}")]
    public async Task<ActionResult<List<ListTransportadoraViewModels>>> ObterPorNomeUmParaMuitos([FromServices] DataContext context, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest();

        var listaCidadeDeTransportadoras = await context.Transportadora
        .Where(x => x.Cidade.Nome.Contains(nome))
        .Select(x => new ListTransportadoraViewModels
        (
          x.Id,
          x.Nome,
          x.Endereco,
          x.Numero,
          x.Bairro,
          x.Cep,
          x.Cnpj,
          x.Inscricao,
          x.Contato,
          x.Telefone,
          x.CidadeId,
          x.Cidade.Nome
        )).ToListAsync();

        if (listaCidadeDeTransportadoras is null)
            return NotFound($"Não existem cidades com o nome {nome}");

        return Ok(listaCidadeDeTransportadoras);
    }


    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(typeof(TransportadoraOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/transportadora")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] TransportadoraInput model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var transportadora = new Transportadora
        (
         model.Id,
         model.Nome,
         model.Endereco,
         model.Numero,
         model.Bairro,
         model.Cep,
         model.Cnpj,
         model.Inscricao,
         model.Contato,
         model.Telefone,
         model.CidadeId
        );

        await context.Transportadora.AddAsync(transportadora);
        var result = await context.SaveChangesAsync();

        return result > 0 ? Created($"/entrada/{transportadora.Id}",
         new TransportadoraOutput
        (
         transportadora.Id,
         transportadora.Nome,
         transportadora.Endereco,
         transportadora.Numero,
         transportadora.Bairro,
         transportadora.Cep,
         transportadora.Cnpj,
         transportadora.Inscricao,
         transportadora.Contato,
         transportadora.Telefone,
         transportadora.CidadeId
         )) : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("/transportadora/id/{id:int}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] TransportadoraInput model, int id)
    {
        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var transportadora = await context.Transportadora.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (transportadora is null)
            return NotFound();

        transportadora = new Transportadora
        (
         model.Id,
         model.Nome,
         model.Endereco,
         model.Numero,
         model.Bairro,
         model.Cep,
         model.Cnpj,
         model.Inscricao,
         model.Contato,
         model.Telefone,
         model.CidadeId
        );

        context.Transportadora.Update(transportadora);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }


    [Produces(typeof(TransportadoraOutput))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("/transportadora/id/{id:int}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {
        if (id == 0)
            return BadRequest();

        var transportadora = await context.Transportadora.FindAsync(id);

        if (transportadora is null)
            return NotFound();

        context.Transportadora.Remove(transportadora);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
    }
    
}
