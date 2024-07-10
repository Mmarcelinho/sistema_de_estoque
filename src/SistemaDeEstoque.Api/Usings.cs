global using System.Text;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;

global using MediatR;

global using SistemaDeEstoque.Domain.Extension;
global using SistemaDeEstoque.Domain.Security.Tokens;

global using SistemaDeEstoque.Infrastructure;
global using SistemaDeEstoque.Infrastructure.Migrations;

global using SistemaDeEstoque.Application;
global using SistemaDeEstoque.Application.UseCases.Login.Commands.FazerLogin;
global using SistemaDeEstoque.Application.UseCases.Admin.Queries.RecuperarPerfil;
global using SistemaDeEstoque.Application.UseCases.Admin.Commands.AlterarSenha;
global using SistemaDeEstoque.Application.UseCases.Admin.Commands.Registrar;

global using SistemaDeEstoque.Comunicacao.Respostas.Admin;

global using SistemaDeEstoque.Api.Token;





