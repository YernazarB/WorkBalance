using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using WorkBalance.Core;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;
using WorkBalance.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(o =>
{
    o.InvalidModelStateResponseFactory = context =>
    {
        var errorMessage = string.Join(" ", context.ModelState
                .SelectMany(x => x.Value?.Errors ?? []).Select(x => x.ErrorMessage));

        var result = BaseHandlerResult.ErrorResult(HandlerErrorCode.BadRequest, errorMessage);
        return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.BadRequest };
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
    Assembly.GetAssembly(typeof(ICoreAssembly)) ?? 
    Assembly.GetExecutingAssembly()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
