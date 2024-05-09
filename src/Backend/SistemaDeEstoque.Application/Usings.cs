global using System.Reflection;
global using System.Text;
global using System.Security.Cryptography;

global using MediatR;
global using FluentValidation;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;

global using SistemaDeEstoque.Application.Servicos.Validation;
global using SistemaDeEstoque.Application.Servicos.Criptografia;

global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using Microsoft.IdentityModel.Tokens;

global using Microsoft.AspNetCore.Http;
global using SistemaDeEstoque.Domain.Entidades;
global using SistemaDeEstoque.Domain.Repositorios.Admin;
global using SistemaDeEstoque.Application.Servicos.Token;
global using SistemaDeEstoque.Application.Servicos.UsuarioLogado;




