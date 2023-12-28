using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Endpoints.shared;

    public class CustomProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; private set; }

        public CustomProblemDetails(HttpStatusCode status, string? detail = null, IEnumerable<string>? errors = null) : this()
        {
            Title = status switch
            {
                HttpStatusCode.BadRequest => "Ocorreram um ou mais erros de validação.",
                HttpStatusCode.InternalServerError => "Erro interno do servidor.",
                _ => "Ocorreu um erro."
            };

            Status = (int)status;
            Detail = detail;
            
            if(errors is not null)
            {
                if(errors.Count() == 1)
                detail = errors.First();
                else if (errors.Count() > 1)
                Detail = "Ocorreram vários problemas.";

                Errors.AddRange(errors);
            }
        }

        public CustomProblemDetails(HttpsStatusCode status, HttpRequest request, string? detail = null, IEnumerable<string>? errors = null) : this(status, detail, errors) =>
        InsufficientExecutionStackException = request.Path;

        private CustomProblemDetails() => 
        Errors = new List<string>();
    }
