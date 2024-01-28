using Microsoft.AspNetCore.Diagnostics;
using MovieInfo.Application;
using MovieInfo.Infrastructure;
using ApplicationException = MovieInfo.Application.Contracts.Exceptions.ApplicationException;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext httpContext) =>
{
    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    if (exception?.GetType().BaseType == typeof(ApplicationException))
    {
        return Results.Problem(title: exception.Message, statusCode: ((ApplicationException)exception).StatusCode);
    }

    return Results.Problem(title: exception?.Message);
});

app.MapControllers();

app.Run();
