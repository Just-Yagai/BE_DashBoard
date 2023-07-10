using BE_DashBoard.Interfaces;
using BE_DashBoard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios
builder.Services.AddScoped<IMarcasService, MarcasService>();
builder.Services.AddScoped<IContribuyentesService, ContribuyentesService>();
builder.Services.AddScoped<ICanalService, CanalService>();
builder.Services.AddScoped<IAmbienteService, AmbienteService>();
builder.Services.AddScoped<IDelegaciones, DelegacionesService>();
builder.Services.AddScoped<ISecuencuasService, SecuenciasService>();
builder.Services.AddScoped<IrncEstado,RncEstadosService>();



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

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});

app.Run();
