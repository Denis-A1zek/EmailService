using EmailService.Core;
using EmailService.Infrastructure;
using EmailService.Web;
using EmailService.Web.Middleware.Extensions;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPostgreSql(builder.Configuration);
builder.Services.AddCore(builder.Configuration);

builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
