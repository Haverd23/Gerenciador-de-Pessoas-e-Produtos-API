using Refit;
using WebApplication1.Integracao.Interface;
using WebApplication1.Integracao;
using WebApplication1.Integracao.Response.Refit;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositorio.Interfaces;
using WebApplication1.Repositorio;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br"));
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();
            builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
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

            app.Run();
        }
    }
}