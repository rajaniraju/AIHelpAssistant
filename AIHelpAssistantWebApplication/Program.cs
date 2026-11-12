
using AIHelpAssistantWebApplication.Data;
using AIHelpAssistantWebApplication.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<PdfTextExtractor>();
builder.Services.AddScoped<WordTextExtractor>();
builder.Services.AddScoped<ExcelTextExtractor>();
builder.Services.AddScoped<PlainTextExtractor>();


builder.Services.AddScoped<DocumentExtractionService>();
builder.Services.AddScoped<TextChunkingServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
        app.UseSwagger();
        app.UseSwaggerUI();
    
    app.MapOpenApi();
}

app.UseHttpsRedirection();
 
app.UseAuthorization();


app.MapControllers();

app.Run();
