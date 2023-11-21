using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

    public static class SaidaMap
    {
        public static Saida ConverterParaEntidade(InsercaoSaidaRequest insercaoSaida) =>
        new
        (
            insercaoSaida.Id,
            insercaoSaida.Total,
            insercaoSaida.Frete,
            insercaoSaida.Imposto,
            insercaoSaida.IdLoja,
            insercaoSaida.IdTransportadora
        );

         public static Saida ConverterParaEntidade(AtualizacaoSaidaRequest atualizacaoSaida) =>
        new
        (
          atualizacaoSaida.Id,
          atualizacaoSaida.Total,
          atualizacaoSaida.Frete,
          atualizacaoSaida.Imposto,
          atualizacaoSaida.IdLoja,
          atualizacaoSaida.IdTransportadora
        );

        public static SaidaResponse ConverterParaResponse(Saida saida) =>
        new
        (
            saida.Id,
            saida.Total,
            saida.Frete,
            saida.Imposto,
            new LojaResponseSaida
            (
                saida.Loja.Nome,
                saida.Loja.Endereco,
                saida.Loja.Telefone,
                saida.Loja.Cnpj
            ),
            new TransportadoraResponseSaida
            (
                saida.Transportadora.Nome,
                saida.Transportadora.Cep,
                saida.Transportadora.Cnpj,
                saida.Transportadora.Telefone
            )
        );
    }
