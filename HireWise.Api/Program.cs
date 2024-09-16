using HireWise.Api.Extensions;
using HireWise.BLL.Logic.Authorization;
using HireWise.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AuthOptions authOptions = new();
builder.Configuration.GetSection("AuthOptions").Bind(authOptions);
builder.Services.AddSingleton(authOptions);

builder.AddFluentValidationEndpointFilter();

builder.Services.ConfigureDALDependencies();
builder.Services.ConfigureBLLDependencies();
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureValidationDependencies();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<HireWiseDBContext>(options =>
    options.UseNpgsql(connection));

var app = builder.Build();

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
