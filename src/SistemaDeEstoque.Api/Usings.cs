global using System.Net;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using MediatR;

global using SistemaDeEstoque.Domain.Extension;

global using SistemaDeEstoque.Infrastructure;
global using SistemaDeEstoque.Infrastructure.Migrations;

global using SistemaDeEstoque.Application;
global using SistemaDeEstoque.Application.UseCases.Login.FazerLogin;
global using SistemaDeEstoque.Application.UseCases.Admin.RecuperarPerfil;
global using SistemaDeEstoque.Application.UseCases.Admin.AlterarSenha;
global using SistemaDeEstoque.Application.UseCases.Admin.Registrar;

global using SistemaDeEstoque.Comunicacao.Requisicoes.Admin;
global using SistemaDeEstoque.Comunicacao.Respostas.Admin;
global using SistemaDeEstoque.Comunicacao.Respostas;

global using SistemaDeEstoque.Exceptions.ErrorMessages;
global using SistemaDeEstoque.Exceptions.ExceptionsBase;
global using SistemaDeEstoque.Api.Filtros;





