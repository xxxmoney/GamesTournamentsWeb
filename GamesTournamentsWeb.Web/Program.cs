using GamesTournamentsWeb.Infrastructure.Ioc;
using GamesTournamentsWeb.Web;
using GamesTournamentsWeb.Web.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = ""
    });

    options.CustomSchemaIds(type => type.ToString());
});

//builder.Services.AddSpaStaticFiles(options => options.RootPath = $"{Constants.ClientAppFolder}/dist");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyMethod().AllowAnyOrigin();
        });
});

// TODO: set account authentication
// builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
// builder.Services.AddHttpContextAccessor();

DependencyResolver.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

//app.UseSpaStaticFiles();
// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = Constants.ClientAppFolder;
//     if (app.Environment.IsDevelopment())
//     {
//         // Launch development server for Nuxt
//         spa.UseNuxtDevelopmentServer();
//     }
// });

app.Run();