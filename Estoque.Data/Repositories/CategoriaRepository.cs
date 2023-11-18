using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

    public class CategoriaRepository(DataContext dataContext) : RepositoryBase<Categoria>(dataContext),ICategoriaRepository
    {
    public async Task<Categoria?> ObterPorTituloAsync(string titulo) => 

    await Context.Categorias.FirstOrDefaultAsync(c => c.Titulo.Contains(titulo));
}
