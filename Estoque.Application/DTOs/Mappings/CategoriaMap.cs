using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings
{
    public static class CategoriaMap
    {
        public static Categoria ConverterParaEntidade( InsercaoCategoriaRequest insercaoCategoria) =>
        new Categoria(insercaoCategoria.Id,insercaoCategoria.Titulo);

        public static Categoria ConverterParaEntidade(AtualizacaoCategoriaRequest atualizacaoCategoria) =>
        new Categoria(atualizacaoCategoria.Id,atualizacaoCategoria.Titulo);

        public static CategoriaResponse ConverterParaResponse
        (this Categoria categoria) =>
        new CategoriaResponse(categoria.Id,categoria.Titulo);
    }
}