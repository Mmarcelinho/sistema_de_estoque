using System.Net;

namespace SistemaDeEstoque.Exceptions.ExceptionsBase;

    public abstract class SistemaDeEstoqueException : SystemException
    {
        protected SistemaDeEstoqueException(string mensagem) : base(mensagem) { }

        public abstract int StatusCode { get; }

        public abstract List<string> RecuperarErros();
    }
