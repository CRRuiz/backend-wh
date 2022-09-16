using System.Text;
using interfaces;
using concretes;
using concretes.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using models.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BdContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
    });

// Agregar configuraciones env
var jwtConfig = new JwtConfig
{
    Key = builder.Configuration["JWT:Key"]
};

builder.Services.AddSingleton(jwtConfig);

// Implementación del JWT
var key = Encoding.UTF8.GetBytes(jwtConfig.Key);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    // x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Agregar interfaces
builder.Services.AddTransient<IUsuario, UsuarioConcrete>();
builder.Services.AddTransient<IAuth, AuthConcrete>();
builder.Services.AddScoped<IArea, AreaConcrete>();
builder.Services.AddScoped<ITipoDocumento, TipoDocumentoConcrete>();
builder.Services.AddScoped<ISubarea, SubareaConcrete>();
builder.Services.AddScoped<IEmpleado, EmpleadoConcrete>();

builder.Services.AddSingleton<IJwtGenerate, JwtGenerate>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option => {
    option.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();