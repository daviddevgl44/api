using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DfvApiPrueba.Models.dfv2Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SISMEDICAERP"));
    });

var app = builder.Build();

//configure the http request pipeline
//TODO validate if debug enviroment
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/produc", () => "Hello produc!");
app.Run();
