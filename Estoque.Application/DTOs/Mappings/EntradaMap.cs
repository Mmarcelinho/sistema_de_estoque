using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

public static class EntradaMap
{
    public static Entrada ConverterParaEntidade(InsercaoEntradaRequest insercaoEntrada) =>

    new Entrada(
        insercaoEntrada.Id,
        insercaoEntrada.Total,
        insercaoEntrada.Frete,
        insercaoEntrada.NumeroNotaFiscal,
        insercaoEntrada.Imposto,
        insercaoEntrada.IdTransportadora);

    public static Entrada ConverterParaEntidade(AtualizacaoEntradaRequest atualizacaoEntrada) =>

    new Entrada(
        atualizacaoEntrada.Id,
        atualizacaoEntrada.Total,
        atualizacaoEntrada.Frete,
        atualizacaoEntrada.NumeroNotaFiscal,
        atualizacaoEntrada.Imposto,
        atualizacaoEntrada.IdTransportadora);


    public static EntradaResponse ConverterParaReponse(this Entrada entrada) =>
     new EntradaResponse
     (
        entrada.Id,
        entrada.DataPedido,
        entrada.DataEntrada,
        entrada.Total,
        entrada.Frete,
        entrada.NumeroNotaFiscal,
        entrada.Imposto,
       new TransportadoraResponseEntrada
       ( 
        entrada.Transportadora.Nome,
        entrada.Transportadora.Cep,
        entrada.Transportadora.Cnpj,
        entrada.Transportadora.Telefone
        )
     );
}
