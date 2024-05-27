using System.Collections.Generic;

namespace SistemaDeEstoque.Exceptions.ExceptionsBase;

    public class ErrosDeValidacaoException : SistemaDeEstoqueException
    {
        public List<string> MensagemDeErro { get; set; }

        public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty) => MensagemDeErro = mensagensDeErro;
    }
