
using DefaultCorsPolicyNugetPackage;
using E_RandevuApplication;
using E_RandevuDomain.Entities;
using E_RandevuInfrastructure;
using Microsoft.AspNetCore.Identity;

namespace E_Randevu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDefaultCors();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

           
            Helper.CreateUserAsync(app).Wait(); 

            app.Run();
        }
    }
}