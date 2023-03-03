namespace ApiEstoque.Controllers;

public class TransportadoraController : ControllerBase
{
    [HttpGet("/transportadora")]
    public async Task<ActionResult<List<TransportadoraOutput>>> ObterTodos([FromServices] DataContext context)
    {

        var transportadora = await context.Transportadora.Select(x => new TransportadoraOutput
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

        return Ok(transportadora);

    }

    [HttpGet("/transportadora/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        return await context.Transportadora.FindAsync(id)
        is Transportadora transportadora ? Ok(new TransportadoraOutput
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

        )) : NotFound();
    }

    [HttpGet("/cidade/transportadora/{id}")]
    public async Task<ActionResult<List<ListTransportadoraViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var transportadoraEntrada = await context.Transportadora
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

        if (transportadoraEntrada == null)
            return NotFound();

        return Ok(transportadoraEntrada);
    }


    [HttpPost("/transportadora")]
    public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] TransportadoraInput model)
    {

        if (!ModelState.IsValid)
            return BadRequest();

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

         )) : BadRequest("Houve um problema ao salvar o registro");
    }


    [HttpPut("/transportadora/{id}")]
    public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] TransportadoraInput model, int id)
    {

        if (id == 0)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        var transportadora = await context.Transportadora.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (transportadora == null)
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

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }

    [HttpDelete("/transportadora/{id}")]
    public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
    {

        if (id == 0)
            return BadRequest();

        var transportadora = await context.Transportadora.FindAsync(id);

        if (transportadora == null)
            return NotFound();

        context.Transportadora.Remove(transportadora);
        var result = await context.SaveChangesAsync();

        return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

    }
}
