using System.Text;
using Cinema.Infrastructure.Authentication;
using Film_PProject.Infrastructure.Dal.EntityFramework;
using Film_PProject.Infrastructure.Dal.Repositories;
using Film_PProject.Infrastructure.Settings;
using Films_PProject.Application.Interfaces;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Film_PProject.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IActorRepository, ActorRepository>();
        builder.Services.AddScoped<IAwardRepository, AwardRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserActorRepository, UserActorRepository>();
        builder.Services.AddScoped<IUserMovieRepository, UserMovieRepository>();
        builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();
        builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        builder.Services.AddScoped<HashingService>();
        builder.Services.AddScoped<ActorService>();
        builder.Services.AddScoped<AwardService>();
        builder.Services.AddScoped<MovieService>();
        builder.Services.AddScoped<MovieActorService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<UserActorService>();
        builder.Services.AddScoped<UserMovieService>();

        // Add controllers and API Explorer
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Configure JWT settings
        builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection(nameof(JwtSetting)));

        var key = builder.Configuration.GetValue<string>("JwtSetting:Secret");

        // Add JWT authentication
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSetting:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        // Add Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema API", Version = "v1" });
            
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter 'Bearer {token}'",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        // Add DbContext
        builder.Services.AddDbContext<DataContext>(option =>
        {
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; // Swagger будет доступен по корню
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
