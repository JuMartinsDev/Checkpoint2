using Microsoft.EntityFrameworkCore;
using nac2_estoque.Data;
using nac2_estoque.Services;

var builder = WebApplication.CreateBuilder(args);

//banco em memória
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("EstoqueDB"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<MovimentacaoService>();
builder.Services.AddScoped<RelatorioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
