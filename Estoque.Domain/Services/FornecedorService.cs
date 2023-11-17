using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository) { }
    }
