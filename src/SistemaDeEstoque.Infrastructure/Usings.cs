global using System.Data;
global using System.Reflection;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using BC = BCrypt.Net.BCrypt;

global using MySqlConnector;
global using Dapper;
global using FluentMigrator;
global using FluentMigrator.Runner;
global using FluentMigrator.Builders.Create.Table;
global using Microsoft.EntityFrameworkCore;

global using SistemaDeEstoque.Domain.Entidades.Base;
global using SistemaDeEstoque.Domain.Entidades;
global using SistemaDeEstoque.Domain.Enum;
global using SistemaDeEstoque.Domain.Extension;
global using SistemaDeEstoque.Domain.Repositorios;
global using SistemaDeEstoque.Domain.Repositorios.Admin;
global using SistemaDeEstoque.Domain.Servicos.AdminLogado;
global using SistemaDeEstoque.Domain.Security.Tokens;
global using SistemaDeEstoque.Domain.Security.Criptografia;

global using SistemaDeEstoque.Infrastructure.AcessoRepositorio;
global using SistemaDeEstoque.Infrastructure.AcessoRepositorio.Repositorio;
global using SistemaDeEstoque.Infrastructure.AcessoRepositorio.Queries;
global using SistemaDeEstoque.Infrastructure.Servicos.AdminLogado;
global using SistemaDeEstoque.Infrastructure.Security.Criptografia;
global using SistemaDeEstoque.Infrastructure.Security.Tokens;














