using Application;
using Evaluacion.API.Filters;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Infraestructure.Persistence;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddControllers(opt => opt.Filters.Add<ApiExceptionFilterAttribute>())
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;


    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        await ApplicationDbContextSeed.SeedSampleDataAsync(context);

        if (context.Database.IsSqlServer())
        {
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.UseAuthorization();

app.MapControllers();

app.Run();
