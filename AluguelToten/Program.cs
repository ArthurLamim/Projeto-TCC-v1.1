using AluguelToten.Repositorios.Interfaces;
using AluguelToten.Repositorios;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using Aluguelcompra.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AluguelToten.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
              );
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IAluguelRepositorio, AluguelRepositorio>();
builder.Services.AddScoped<ICarroRepositorio, CarroRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
builder.Services.AddScoped<ICompraRepositorio, CompraRepositorio>();
builder.Services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
builder.Services.AddScoped<ITotenRepositorio, TotenRepositorio>();
builder.Services.AddScoped<IEmailService, EmailService>();




builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DataContext>();

var secretKey = builder.Configuration.GetConnectionString("Jwt:JwtSecurityKey");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration.GetConnectionString("Jwt:JwtIssuer"),
           ValidAudience = builder.Configuration.GetConnectionString("Jwt:JwtAudience"),
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:JwtSecurityKey"))
       };
   });
builder.Services.AddControllersWithViews();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors("AllowOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
