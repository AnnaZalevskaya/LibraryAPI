namespace PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .ConfigurePostgreSQL(builder.Configuration)
                .ConfigureSwagger()
                .ConfigureControllers()
                .ConfigureApiExplorer()
                .ConfigureRepositoryWrapper()
                .ConfigureAuth(builder.Configuration)
                .ConfigureAppServices()
                .ConfigureMapperProfiles();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("cors");
            app.MapControllers();

            app.Run();
        }
    }
}