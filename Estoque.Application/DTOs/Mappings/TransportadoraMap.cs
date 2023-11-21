using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

    public static class TransportadoraMap
    {
        public static Transportadora ConverterParaEntidade(InsercaoTransportadoraRequest insercaoTransportadora) =>
        new
        (
            insercaoTransportadora.Id,
            insercaoTransportadora.Nome,
            insercaoTransportadora.Endereco,
            insercaoTransportadora.Numero,
            insercaoTransportadora.Bairro,
            insercaoTransportadora.Cep,
            insercaoTransportadora.Cnpj,
            insercaoTransportadora.Inscricao,
            insercaoTransportadora.Contato,
            insercaoTransportadora.Telefone,
            insercaoTransportadora.IdCidade
        );

        public static Transportadora ConverterParaEntidade(AtualizacaoTransportadoraRequest atualizacaoTransportadora) =>
        new
        (
          atualizacaoTransportadora.Id,
          atualizacaoTransportadora.Nome,
          atualizacaoTransportadora.Endereco,
          atualizacaoTransportadora.Numero,
          atualizacaoTransportadora.Bairro,
          atualizacaoTransportadora.Cep,
          atualizacaoTransportadora.Cnpj,
          atualizacaoTransportadora.Inscricao,
          atualizacaoTransportadora.Contato,
          atualizacaoTransportadora.Telefone,
          atualizacaoTransportadora.IdCidade
        );

        public static TransportadoraResponse ConverterParaResponse(this Transportadora transportadora) =>
        new
        (
          transportadora.Id,
          transportadora.Nome,
          transportadora.Endereco,
          transportadora.Numero,
          transportadora.Bairro,
          transportadora.Cep,
          transportadora.Cnpj,
          transportadora.Inscricao,
          transportadora.Contato,
          transportadora.Telefone,
          new CidadeResponse
          (
            transportadora.Cidade.Id,
            transportadora.Cidade.Nome,
            transportadora.Cidade.Uf
          )
        );
    }
