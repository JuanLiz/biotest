using Biotest.Context;
using Biotest.Repositories;
using Biotest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Set connection string
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scoped repositories
builder.Services.AddScoped<IAnalysisRepository, AnalysisRepository>();
builder.Services.AddScoped<IAnalysisTypeRepository, AnalysisTypeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IGeneticTestRepository, GeneticTestRepository>();
builder.Services.AddScoped<IGeneticTestTypeRepository, GeneticTestTypeRepository>();
builder.Services.AddScoped<IGeneticVariantRepository, GeneticVariantRepository>();
builder.Services.AddScoped<IGeneticVariantTypeRepository, GeneticVariantTypeRepository>();
builder.Services.AddScoped<IGenotypeRepository, GenotypeRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPredictedEffectRepository, PredictedEffectRepository>();
builder.Services.AddScoped<ISampleRepository, SampleRepository>();
builder.Services.AddScoped<ISampleSourceRepository, SampleSourceRepository>();
builder.Services.AddScoped<ISampleTypeRepository, SampleTypeRepository>();

// Add scoped services
builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<IAnalysisTypeService, AnalysisTypeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeePositionService, EmployeePositionService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGeneticTestService, GeneticTestService>();
builder.Services.AddScoped<IGeneticTestTypeService, GeneticTestTypeService>();
builder.Services.AddScoped<IGeneticVariantService, GeneticVariantService>();
builder.Services.AddScoped<IGeneticVariantTypeService, GeneticVariantTypeService>();
builder.Services.AddScoped<IGenotypeService, GenotypeService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPredictedEffectService, PredictedEffectService>();
builder.Services.AddScoped<ISampleService, SampleService>();
builder.Services.AddScoped<ISampleSourceService, SampleSourceService>();
builder.Services.AddScoped<ISampleTypeService, SampleTypeService>();

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

app.Run();
