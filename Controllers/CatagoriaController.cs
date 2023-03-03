namespace ApiEstoque.Controllers;

    [ApiController]
    [Route("v1")]
    public class CatagoriaController:ControllerBase
    {

    [HttpGet("/categoria")]
    public async Task<ActionResult<List<CategoriaOutput>>> ObterTodos([FromServices]DataContext context){

        var categoria = await context.Categoria.Select(x => new CategoriaOutput(x.Id, x.Titulo)).ToListAsync();
        
        return Ok(categoria);

    }

    [HttpGet("/categoria/{id}")]
    public async Task<IActionResult> ObterPorId([FromServices]DataContext context, int id){
        
        if(id == 0)
        return BadRequest();

        return await context.Categoria.FindAsync(id)
        is Categoria categoria ?  Ok(new CategoriaOutput(categoria.Id, categoria.Titulo)) : NotFound();
    }


    [HttpPost("/categoria")]
    public async Task<IActionResult> Criar([FromServices]DataContext context,[FromBody] CategoriaInput model){
    
    if(!ModelState.IsValid)
    return BadRequest();

    var categoria = new Categoria(model.Id, model.Titulo);

    await context.Categoria.AddAsync(categoria);
    var result = await context.SaveChangesAsync();

    return result > 0? Created($"/Categoria/{categoria.Id}", new CategoriaOutput(categoria.Id, categoria.Titulo)) : BadRequest("Houve um problema ao salvar o registro");
    
    }

    [HttpPut("/categoria/{id}")]
    public async Task<IActionResult> Atualizar([FromServices]DataContext context,[FromBody] CategoriaInput model, int id){
    
    if(id == 0)
    return BadRequest();

    if(!ModelState.IsValid)
    return BadRequest();

    var categoria = await context.Categoria.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);

    if (categoria== null)
    return NotFound();

    categoria = new Categoria(categoria.Id, model.Titulo);

    context.Categoria.Update(categoria);
    var result = await context.SaveChangesAsync();

    return result > 0? NoContent() : BadRequest("Houve um problema ao salvar o registro");
    
    }


    [HttpDelete("/categoria/{id}")]
    public async Task<IActionResult> Remover([FromServices]DataContext context, int id){
    
    if(id == 0)
    return BadRequest();

    var categoria = await context.Categoria.FindAsync(id);

    if (categoria== null)
    return NotFound();

    context.Categoria.Remove(categoria);
    var result = await context.SaveChangesAsync();

    return result > 0? NoContent() : BadRequest("Houve um problema ao salvar o registro");
    
    }

}
