using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using proj1.Data;
using proj1.Dtos.BusinessDtos.BusinessDtoValidators;
using proj1.Dtos.FamiliyDtos.FamilyDtoValidators;
using proj1.Dtos.PersonDtos.PersonDtoValidators;
using proj1.Dtos.RelationsDtos.RelationsDtoValidators;
using proj1.Entity;
using proj1.Repos;
using proj1.Repos.BusinessRepos;
using proj1.Repos.FamilyRepos;
using proj1.Repos.PersonRepos;
using proj1.Repos.RelationsRepos;
using proj1.Service;
using proj1.Service.Business;
using proj1.Service.Family;
using proj1.Service.Person;
using proj1.Service.Relations;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and OpenAPI generation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// AutoMapper kaydı eklensin:
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Program).Assembly);
});
// Use PostgreSQL (Docker). Connection string should be in appsettings.json under "ConnectionStrings:DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonRepo, PersonRepository>();
builder.Services.AddScoped<IBusinessRepo, BusinessRepository>();
builder.Services.AddScoped<IFamilyRepo, FamilyRepository>();
builder.Services.AddScoped<IRelationsRepo, RelationsRepository>();

//validators
builder.Services.AddValidatorsFromAssemblyContaining<PersonCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PersonUpdateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<FamilyCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<FamilyUpdateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RelationsCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RelationsUpdateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BusinessCreateDtoValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<BusinessUpdateDtoValidator>();


var app = builder.Build();

app.MapOpenApi();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
