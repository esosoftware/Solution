using Esoft.Documents.Common.Middleware;
using Esoft.Documents.DocumentsWebApi.Extension.Middleware;
using Esoft.Documents.Service.Interface.Services.FileStorages;
using Esoft.Documents.Service.Interface.Services.Query;
using Esoft.Documents.Service.Interface.Services.Validator;
using Esoft.Documents.Service.Services.FileStorages;
using Esoft.Documents.Service.Services.Query;
using Esoft.Documents.Service.Services.Validator;
using Microsoft.AspNetCore.Builder;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
        logging.AddNLog();
    });


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDocumentQueryService, DocumentQueryService>();
builder.Services.AddScoped<IDocumentValidatorService, DocumentValidatorService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documents API V1");
});

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseMiddleware<BasicAuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
