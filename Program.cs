// Author:         Adam Verissimo
// Course:         COMP?003B
// Faculty Name:   Jonathan Cruz
// Purpose:        Demonstrate CRUD operations via ASP.NET Core Web API
// https://localhost:7180/swagger/index.html
namespace COMP003B.Assignment5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
