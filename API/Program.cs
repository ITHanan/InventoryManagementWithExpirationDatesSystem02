using API.Authorazation;
using API.Swagger;
using ApplicationLayer;
using ApplicationLayer.Users.Queries.UsersLogin;
using infrastructureLayer;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace API
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

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);


            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Services.AddSwaggerWithJwt();
            builder.Services.AddAuthorization();


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
