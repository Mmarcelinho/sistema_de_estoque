using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings
{
    public static class CidadeMap
    {
        public static Cidade ConverterParaEntidade(InsercaoCidadeRequest insercaoCidade) =>
        
            new Cidade
            (
             insercaoCidade.Id,
             insercaoCidade.Nome,
             insercaoCidade.Uf
            );
        public static Cidade ConverterParaEntidade(AtualizacaoCidadeRequest atualizacaoCidade) =>

            new Cidade
            (
             atualizacaoCidade.Id,
             atualizacaoCidade.Nome,
             atualizacaoCidade.Uf
            );

        public static CidadeResponse ConverterParaResponse(this Cidade cidade) =>

        new CidadeResponse(cidade.Id, cidade.Nome, cidade.Uf);
    }
}