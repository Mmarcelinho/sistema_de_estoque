using Carter;
using Hellang.Middleware.ProblemDetails;
using Estoque.Api.Extensions;
using Estoque.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiProblemDetails();
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddCarter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();
app.MapControllers();
app.MapCarter();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

