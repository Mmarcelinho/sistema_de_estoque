var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

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

app.MapControllers();

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConexao();

    var nomeDatabase = builder.Configuration.GetNomeDatabase();

    Database.CriarDatabase(conexao, nomeDatabase);

    app.MigrateBancoDeDados();
}