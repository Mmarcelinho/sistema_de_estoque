using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

public static class LojaMap
{
    public static Loja ConverterParaEntidade(InsercaoLojaRequest insercaoLoja) =>
    new(
        insercaoLoja.Id,
        insercaoLoja.Nome,
        insercaoLoja.Endereco,
        insercaoLoja.Numero,
        insercaoLoja.Bairro,
        insercaoLoja.Telefone,
        insercaoLoja.Inscricao,
        insercaoLoja.Cnpj,
        insercaoLoja.IdCidade
    );

    public static Loja ConverterParaEntidade(AtualizacaoLojaRequest atualizacaoLoja) =>
   new
    (
       atualizacaoLoja.Id,
       atualizacaoLoja.Nome,
       atualizacaoLoja.Endereco,
       atualizacaoLoja.Numero,
       atualizacaoLoja.Bairro,
       atualizacaoLoja.Telefone,
       atualizacaoLoja.Inscricao,
       atualizacaoLoja.Cnpj,
       atualizacaoLoja.IdCidade
    );

    public static LojaResponse ConverterParaResponse(this Loja loja) =>
    new
    (
      loja.Id,
      loja.Nome,
      loja.Endereco,
      loja.Numero,
      loja.Bairro,
      loja.Telefone,
      loja.Inscricao,
      loja.Cnpj,
       new CidadeResponse
       (
        loja.Cidade.Id,
        loja.Cidade.Nome,
        loja.Cidade.Uf
       )
    );
}
