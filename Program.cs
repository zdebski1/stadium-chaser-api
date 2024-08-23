using Microsoft.EntityFrameworkCore;
using stadiumChaserApi.Repositories;
using stadiumChaserApi.Services.Interfaces;
using stadiumChaserApi.Services;
using stadium_chaser_api.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddScoped<IStadiumService, StadiumService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();