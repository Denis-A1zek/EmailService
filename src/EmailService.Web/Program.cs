using EmailService.Core;
using EmailService.Infrastructure;
using EmailService.Web.Common.Definitions;
using EmailService.Web.Middleware.Extensions;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPostgreSql(builder.Configuration);
builder.Services.AddCore(builder.Configuration);

builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
