using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OOauthApi.Interfaces;
using OOauthApi.Models;
using OOauthApi.Operationalfilters;
using OOauthApi.Services;


var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IHouse, Sqlhousedb>();
//this is responsible for handling the sqlserver and it's operations involved, that;s from creating the databse
builder.Services.AddDbContextPool<Housemodelcontext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("HouseDbConnectionstring"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));


//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://login.microsoftonline.com/7493ef9e-db24-45d8-91b5-9c36018d6d52/oauth2/v2.0/authorize"),
                TokenUrl = new Uri("https://login.microsoftonline.com/7493ef9e-db24-45d8-91b5-9c36018d6d52/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string>
            {
                { "api://29a02307-5a1b-460c-85ba-9e9abb75e48d/Read.WeatherForecast", "Reads the Weather forecast" }
            }
            }
        }
    });
    options.OperationFilter<AuthorizeOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = Configuration["Authentication:Authority"];
        options.Audience = "api";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", builder =>
    {
        builder.RequireAuthenticatedUser();
        builder.RequireClaim("scope", "api");
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

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
