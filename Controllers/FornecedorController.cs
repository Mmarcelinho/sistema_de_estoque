namespace ApiEstoque.Controllers
{
    public class FornecedorController : ControllerBase
    {
        [HttpGet("/fornecedor")]
        public async Task<ActionResult<List<FornecedorOutput>>> ObterTodos([FromServices] DataContext context)
        {

            var fornecedor = await context.Fornecedor.Select(x => new FornecedorOutput
             (
              x.Id,
              x.Nome,
              x.Endereco,
              x.Numero,
              x.Bairro,
              x.Cep,
              x.Contato,
              x.Cnpj,
              x.Inscricao,
              x.CidadeId
             ))
            .ToListAsync();

            return Ok(fornecedor);

        }

        [HttpGet("/fornecedor/{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            return await context.Fornecedor.FindAsync(id)
            is Fornecedor fornecedor ? Ok(new FornecedorOutput
            (
             fornecedor.Id,
             fornecedor.Nome,
             fornecedor.Endereco,
             fornecedor.Numero,
             fornecedor.Bairro,
             fornecedor.Cep,
             fornecedor.Contato,
             fornecedor.Cnpj,
             fornecedor.Inscricao,
             fornecedor.CidadeId

            )) : NotFound();
        }

        [HttpGet("/cidade/fornecedor/{id}")]
        public async Task<ActionResult<List<ListFornecedorViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var fornecedorCidade = await context.Fornecedor
            .Where(x => x.Cidade.Id == id)
            .Select(x => new ListFornecedorViewModels
            (
             x.Id,
             x.Nome,
             x.Endereco,
             x.Numero,
             x.Bairro,
             x.Cep,
             x.Contato,
             x.Cnpj,
             x.Inscricao,
             x.CidadeId,
             x.Cidade.Nome

            )).ToListAsync();

            if (fornecedorCidade == null)
                return NotFound();

            return Ok(fornecedorCidade);
        }

        [HttpPost("/fornecedor")]
        public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] FornecedorInput model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var fornecedor = new Fornecedor
            (
             model.Id,
             model.Nome,
             model.Endereco,
             model.Numero,
             model.Bairro,
             model.Cep,
             model.Contato,
             model.Cnpj,
             model.Inscricao,
             model.CidadeId
            );

            await context.Fornecedor.AddAsync(fornecedor);
            var result = await context.SaveChangesAsync();

            return result > 0 ? Created($"/fornecedor/{fornecedor.Id}", new FornecedorOutput
            (
             fornecedor.Id,
             fornecedor.Nome,
             fornecedor.Endereco,
             fornecedor.Numero,
             fornecedor.Bairro,
             fornecedor.Cep,
             fornecedor.Contato,
             fornecedor.Cnpj,
             fornecedor.Inscricao,
             fornecedor.CidadeId

            )) : BadRequest("Houve um problema ao salvar o registro");

        }

        [HttpPut("/fornecedor/{id}")]
        public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] FornecedorInput model, int id)
        {

            if (id == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var fornecedor = await context.Fornecedor.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor == null)
                return NotFound();

            fornecedor = new Fornecedor
            (
             fornecedor.Id,
             model.Nome,
             model.Endereco,
             model.Numero,
             model.Bairro,
             model.Cep,
             model.Contato,
             model.Cnpj,
             model.Inscricao,
             model.CidadeId
            );

            context.Fornecedor.Update(fornecedor);
            var result = await context.SaveChangesAsync();

            return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

        }

        [HttpDelete("/fornecedor/{id}")]
        public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var fornecedor = await context.Fornecedor.FindAsync(id);

            if (fornecedor == null)
                return NotFound();

            context.Fornecedor.Remove(fornecedor);
            var result = await context.SaveChangesAsync();

            return result > 0 ? NoContent() : BadRequest("Houve um problema ao salvar o registro");

        }

    }
}