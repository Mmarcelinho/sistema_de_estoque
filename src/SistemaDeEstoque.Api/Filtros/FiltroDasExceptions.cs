namespace SistemaDeEstoque.Api.Filtros;

public class FiltroDasExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SistemaDeEstoqueException)
            TratarSistemaDeEstoqueException(context);

        else
            LancarErroDesconhecido(context);
    }

    private static void TratarSistemaDeEstoqueException(ExceptionContext context)
    {
        if (context.Exception is ErrosDeValidacaoException)
            TratarErrosDeValidacaoException(context);

        else if (context.Exception is LoginInvalidoException)
            TratarLoginException(context);

    }

    private static void TratarErrosDeValidacaoException(ExceptionContext context)
    {
        var erroDeValidacaoException = context.Exception as ErrosDeValidacaoException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new RespostaErroJson(erroDeValidacaoException.MensagemDeErro));
    }

    private static void TratarLoginException(ExceptionContext context)
    {
        var erroLogin = context.Exception as LoginInvalidoException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new ObjectResult(new RespostaErroJson(erroLogin.Message));
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new RespostaErroJson(ModelMensagensDeErro.ERRO_DESCONHECIDO));
    }


}
