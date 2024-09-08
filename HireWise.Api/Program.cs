using FluentValidation.AspNetCore;
using HireWise.Api.Extensions;
using HireWise.BLL.Logic.Authorization;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.TestManagement.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
