global using System.Data;
global using System.Reflection;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using MySqlConnector;
global using Dapper;
global using FluentMigrator;
global using FluentMigrator.Runner;
global using FluentMigrator.Builders.Create.Table;
global using Microsoft.EntityFrameworkCore;
global using SistemaDeEstoque.Domain.Entidades;
global using SistemaDeEstoque.Domain.Enum;
global using SistemaDeEstoque.Domain.Extension;
global using SistemaDeEstoque.Domain.Repositorios;
global using SistemaDeEstoque.Infrastructure.AcessoRepositorio;
global using SistemaDeEstoque.Infrastructure.AcessoRepositorio.Repositorio;
global using SistemaDeEstoque.Infrastructure.AcessoRepositorio.Queries;
global using SistemaDeEstoque.Domain.Repositorios.Admin;
global using BC = BCrypt.Net.BCrypt;
global using SistemaDeEstoque.Domain.Security.Criptografia;
global using SistemaDeEstoque.Infrastructure.Criptografia;










