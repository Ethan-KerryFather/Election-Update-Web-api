
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using System.Xml;

namespace WebApplication1
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
            // db 설정
            builder.Services.AddDbContext<ElectionContext>(
                options => options.UseSqlServer("Server=D662-ETHANLIM;Database=Test07;Trusted_Connection=True;TrustServerCertificate=True"));

            // xml로 내보내기 설정
            builder.Services.AddControllers().AddXmlSerializerFormatters();

            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
