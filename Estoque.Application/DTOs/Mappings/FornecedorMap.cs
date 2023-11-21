using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

public static class FornecedorMap
{
    public static Fornecedor ConverterParaEntidade(InsercaoFornecedorRequest insercaoFornecedor) =>
    new Fornecedor
    (
        insercaoFornecedor.Id, insercaoFornecedor.Nome, insercaoFornecedor.Endereco, insercaoFornecedor.Numero, insercaoFornecedor.Bairro, insercaoFornecedor.Cep, insercaoFornecedor.Contato,
        insercaoFornecedor.Cnpj,
        insercaoFornecedor.Inscricao,
        insercaoFornecedor.IdCidade
    );

    public static Fornecedor ConverterParaEntidade(AtualizacaoFornecedorRequest atualizacaoFornecedor) =>
    new Fornecedor
    (
        atualizacaoFornecedor.Id, atualizacaoFornecedor.Nome, atualizacaoFornecedor.Endereco, atualizacaoFornecedor.Numero, atualizacaoFornecedor.Bairro, atualizacaoFornecedor.Cep, atualizacaoFornecedor.Contato,
        atualizacaoFornecedor.Cnpj,
        atualizacaoFornecedor.Inscricao,
        atualizacaoFornecedor.IdCidade
    );

    public static FornecedorResponse ConverterParaResponse(this Fornecedor fornecedor) =>
    new FornecedorResponse
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
    new CidadeResponse(
        fornecedor.Cidade.Id,
        fornecedor.Cidade.Nome,
        fornecedor.Cidade.Uf)
    );
}
