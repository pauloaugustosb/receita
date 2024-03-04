using ProjetoReceita.Infrastructure.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoReceita.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            AtualizaBaseDeDados();
            app.Run();

            void AtualizaBaseDeDados()
            {
                var conexao = builder.Configuration.GetConnectionString("Conexao");
                var nomeDataBase = builder.Configuration.GetConnectionString("NomeDataBase");
                Database.CriarDataBase(conexao, nomeDataBase);
            }
        }
    }
}
