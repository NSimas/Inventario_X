using Inventario_X.Data;
using Inventario_X.Repositorios.Interfaces;
using Inventario_X.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Inventario_X;
using Microsoft.OpenApi.Models;

public class Program
{
    private static void Main(string[] args)
    {
        //setar as variáveis
        var key = Encoding.ASCII.GetBytes(Key.Secret);
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Inventario_XDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

        builder.Services.AddControllers();

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();

        //Configurando o Swagger pra usar a autenticação JWT
        builder.Services.AddSwaggerGen(c =>
        {

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"

            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                    },
                    new List<string> ()
                }

            });

        });

        builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

        //Configurando a autenticação JWT
        builder.Services.AddAuthentication(x =>
        {

            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {

            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        builder.Services.AddAuthorization();
        //relacionando as implementações
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IItemRepositorio, ItemRepositorio>();

        var app = builder.Build();

        //Configurando a pipeline das requisições HTTP
        if (app.Environment.IsDevelopment())
        {

            app.UseSwagger();
            app.UseSwaggerUI();

        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}