namespace Estoque.Application.DTOs.Entities;

public record InsercaoFornecedorRequest
(
     int Id,
     string Nome,
     string Endereco,
     int Numero,
     string Bairro,
     string Cep,
     string Contato,
     string Cnpj,
     string Inscricao,
     int IdCidade
);
   
public record AtualizacaoFornecedorRequest
(
     int Id,
     string Nome,
     string Endereco,
     int Numero,
     string Bairro,
     string Cep,
     string Contato,
     string Cnpj,
     string Inscricao,
     int IdCidade
);

public record FornecedorResponse
(
     int Id,
     string Nome,
     string Endereco,
     int Numero,
     string Bairro,
     string Cep,
     string Contato,
     string Cnpj,
     string Inscricao,
     CidadeResponse Cidade
);