namespace ApiEstoque.Controllers;

    public class ProdutoController:ControllerBase
    {
        [HttpGet("/produto")]
    public async Task<ActionResult<List<ProdutoOutput>>> ObterTodos([FromServices]DataContext context){

        var produto = await context.Produto.Select(x => new ProdutoOutput(x.Id, x.Descricao, x.Peso, x.Controlado, x.QuantMinima)).ToListAsync();
        
        return Ok(produto);

    }

    [HttpGet("/produto/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices]DataContext context, int id){
        
        if(id == 0)
        return BadRequest();

        return await context.Produto.FindAsync(id)
        is Produto produto ?  Ok(new ProdutoOutput
        (
         produto.Id, 
         produto.Descricao, 
         produto.Peso, 
         produto.Controlado, 
         produto.QuantMinima
         
        )) : NotFound();
    }


    [HttpPost("/produto")]
    public async Task<IActionResult> Criar([FromServices]DataContext context,[FromBody] ProdutoInput model){
    
    if(!ModelState.IsValid)
    return BadRequest();

    var produto = new Produto
    ( 
     model.Id, 
     model.Descricao, 
     model.Peso, 
     model.Controlado, 
     model.QuantMinima);

    await context.Produto.AddAsync(produto);
    var result = await context.SaveChangesAsync();

    return result > 0? Created($"/produto/{produto.Id}", new ProdutoOutput
    (
     produto.Id, 
     produto.Descricao, 
     produto.Peso, 
     produto.Controlado, 
     produto.QuantMinima

    )) : BadRequest("Houve um problema ao salvar o registro");
    
    }

    [HttpPut("/produto/{id}")]
    public async Task<IActionResult> Atualizar([FromServices]DataContext context,[FromBody] ProdutoInput model, int id){
    
    if(id == 0)
    return BadRequest();

    if(!ModelState.IsValid)
    return BadRequest();

    var produto = await context.Produto.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);

    if (produto== null)
    return NotFound();

    produto = new Produto
    ( 
     produto.Id, 
     model.Descricao, 
     model.Peso, 
     model.Controlado, 
     model.QuantMinima);

    context.Produto.Update(produto);
    var result = await context.SaveChangesAsync();

    return result > 0? NoContent() : BadRequest("Houve um problema ao salvar o registro");
    
    }


    [HttpDelete("/produto/{id}")]
    public async Task<IActionResult> Remover([FromServices]DataContext context, int id){
    
    if(id == 0)
    return BadRequest();

    var produto = await context.Produto.FindAsync(id);

    if (produto== null)
    return NotFound();

    context.Produto.Remove(produto);
    var result = await context.SaveChangesAsync();

    return result > 0? NoContent() : BadRequest("Houve um problema ao salvar o registro");
    
    }
        
    }
