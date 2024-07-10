global using System.Reflection;
global using System.Text.RegularExpressions;

global using Microsoft.Extensions.DependencyInjection;

global using MediatR;
global using FluentValidation;

global using SistemaDeEstoque.Domain.Enum;
global using SistemaDeEstoque.Domain.Repositorios;
global using SistemaDeEstoque.Domain.Repositorios.Admin;
global using SistemaDeEstoque.Domain.Security.Tokens;
global using SistemaDeEstoque.Domain.Security.Criptografia;
global using SistemaDeEstoque.Domain.Servicos.AdminLogado;
global using SistemaDeEstoque.Application.Servicos.Validation;

global using SistemaDeEstoque.Communication.Requisicoes.Admin;
global using SistemaDeEstoque.Communication.Respostas.Admin;

global using SistemaDeEstoque.Exceptions.ExceptionsBase;
global using SistemaDeEstoque.Exceptions.ErrorMessages;




