using SocialMediaLinks.ConfigurationOptions;
namespace SocialMediaLinks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.Configure<SocialMediaLinksOptions>(builder.Configuration.GetSection("SocialMediaLinks"));
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    
                });
            });

            var app = builder.Build();

            app.UseStaticFiles();   
            app.UseRouting();
            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
