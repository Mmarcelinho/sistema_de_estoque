namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio.Repositorio.Ef;

public class AdminEfRepositorio : IAdminWriteOnlyRepositorio, IAdminUpdateOnlyRepositorio
{
    private readonly SistemaDeEstoqueContext _contexto;

    public AdminEfRepositorio(SistemaDeEstoqueContext contexto, SqlFactory sqlFactory) => _contexto = contexto;

    public async Task Adicionar(Admin admin) => await _contexto.Admins.AddAsync(admin);

    public void Atualizar(Admin admin) => _contexto.Admins.Update(admin);

    public async Task<Admin> RecuperarPorId(long id) => await _contexto.Admins.FirstOrDefaultAsync(admin => admin.Id == id);
}
