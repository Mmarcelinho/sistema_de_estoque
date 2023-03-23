namespace ApiEstoque.Controllers
{
    public class FornecedorController : ControllerBase
    {
        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(typeof(FornecedorOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/fornecedor")]
        public async Task<ActionResult<List<FornecedorOutput>>> ObterTodos([FromServices] DataContext context)
        {
            var listaFornecedor = await context.Fornecedor.Select(x => new FornecedorOutput
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

            if (!listaFornecedor.Any())
                return NotFound();

            return Ok(listaFornecedor);
        }


        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(typeof(FornecedorOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/fornecedor/id/{id:int}")]
        public async Task<IActionResult> ObterPorId([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var fornecedor = await context.Fornecedor.FindAsync(id);

            if (fornecedor is null)
                return NotFound($"Não existe fornecedor com o id {id}");

            return Ok(new FornecedorOutput
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

            ));
        }


        [Produces(typeof(ListFornecedorViewModels))]
        [ProducesResponseType(typeof(ListFornecedorViewModels), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/cidade/fornecedor/id/{id:int}")]
        public async Task<ActionResult<List<ListFornecedorViewModels>>> ObterPorIdUmParaMuitos([FromServices] DataContext context, int id)
        {
            if (id == 0)
                return BadRequest();

            var listaCidadeDeFornecedores = await context.Fornecedor
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

            if (!listaCidadeDeFornecedores.Any())
                return NotFound($"Não existe cidade com o id {id}");

            return Ok(listaCidadeDeFornecedores);
        }


        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(typeof(FornecedorOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/fornecedor/nome/{nome:alpha}")]
        public async Task<ActionResult<List<FornecedorOutput>>> ObterPorNome([FromServices] DataContext context, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest();

            var listaFornecedor = await context.Fornecedor
            .Include(x => x.Cidade)
            .Where(n => n.Nome.Contains(nome))
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

            if (!listaFornecedor.Any())
                return NotFound($"Não existem fornecedores com o nome {nome}");

            return Ok(listaFornecedor);
        }


        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(typeof(FornecedorOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/cidade/fornecedor/nome/{nome:alpha}")]
        public async Task<ActionResult<List<ListFornecedorViewModels>>> ObterPorNomeUmParaMuitos([FromServices] DataContext context, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest();

            var listaCidadeDeFornecedores = await context.Fornecedor
            .Where(x => x.Cidade.Nome.Contains(nome))
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

            if (!listaCidadeDeFornecedores.Any())
            return NotFound($"Não existem cidades com o nome {nome}");

            return Ok(listaCidadeDeFornecedores);
        }


        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(typeof(FornecedorOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/fornecedor")]
        public async Task<IActionResult> Criar([FromServices] DataContext context, [FromBody] FornecedorInput model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

            )) : StatusCode(StatusCodes.Status500InternalServerError);
        }


        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/fornecedor/id/{id:int}")]
        public async Task<IActionResult> Atualizar([FromServices] DataContext context, [FromBody] FornecedorInput model, int id)
        {
            if (id == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var fornecedor = await context.Fornecedor.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor is null)
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

            return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Produces(typeof(FornecedorOutput))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/fornecedor/id/{id:int}")]
        public async Task<IActionResult> Remover([FromServices] DataContext context, int id)
        {

            if (id == 0)
                return BadRequest();

            var fornecedor = await context.Fornecedor.FindAsync(id);

            if (fornecedor is null)
                return NotFound();

            context.Fornecedor.Remove(fornecedor);
            var result = await context.SaveChangesAsync();

            return result > 0 ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);

        }

    }
}