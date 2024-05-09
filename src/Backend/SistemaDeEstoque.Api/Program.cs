using MediatR;
using SistemaDeEstoque.Application.UseCases.Login.FazerLogin;
using SistemaDeEstoque.Comunicacao.Respostas.Admin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AdicionarInfrastructure(builder.Configuration);
builder.Services.AdicionarApplication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

AtualizarBaseDeDados();

app.MapPost("admin/", async (IMediator _mediator, LoginAdminUseCaseCommand request) => 
{
    var resposta = await _mediator.Send(request);

    return Results.Ok(resposta);
})
.Produces<RespostaLoginAdminJson>(StatusCodes.Status200OK);

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConexao();

    var nomeDatabase = builder.Configuration.GetNomeDatabase();

    Database.CriarDatabase(conexao, nomeDatabase);

    app.MigrateBancoDeDados();
}