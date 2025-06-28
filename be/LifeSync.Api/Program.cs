using LifeSync.Api.DependencyInjection;
using LifeSync.Api.EndpointMapping;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LifeSync.Application.Auth.Services;
using LifeSync.Application.Auth.Interfaces;
using LifeSync.Infrastructure.Users;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký localization
builder.Services.AddLocalizationServices();

// Đăng ký DbContext
builder.Services.AddDatabase(builder.Configuration);

// Đăng ký FluentValidation
builder.Services.AddValidationServices();

// Đăng ký DI cho các module
builder.Services.AddBookServices();
builder.Services.AddFinanceServices();
builder.Services.AddLifeServices();

// Đăng ký Auth services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetSection("Redis")["Configuration"];
});

builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Cấu hình JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"] ?? "your-super-secret-key-with-at-least-32-characters")
            ),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "LifeSync",
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "LifeSync",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Cấu hình Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LifeSync API",
        Version = "v1",
        Description = "API cho ứng dụng LifeSync - Quản lý sách, tài chính và cuộc sống",
        Contact = new OpenApiContact
        {
            Name = "LifeSync",
            Email = "luonghoantrongct2004@gmail.com"
        }
    });

    // Cấu hình JWT cho Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new string[] {}
        }
    });

    // Đọc XML documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Cấu hình RequestLocalization
var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("vi") };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures.ToList(),
    SupportedUICultures = supportedCultures.ToList()
};
app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LifeSync API V1");
        c.RoutePrefix = string.Empty; // Đặt Swagger UI làm trang chủ
    });
}

app.UseHttpsRedirection();

// Thêm Authentication middleware trước Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapControllers();
app.MapBooksModule();
app.MapFinanceModule();
app.MapLifeEndpoints();

app.Run();