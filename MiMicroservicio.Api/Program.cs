using MiMicroservicio.Infrastructure.Data;
using MiMicroservicio.Infrastructure.Repositories;
using MiMicroservicio.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoSettings
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<MongoDbContext>();

// Repos
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

















