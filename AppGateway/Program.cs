using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SmartAttend.Application.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false);
var environment = builder.Environment.EnvironmentName;


var ocelotConfigFile = environment == "Development" ? "ocelot.json" : "ocelotServer.json";


builder.Configuration.AddJsonFile(ocelotConfigFile, optional: false, reloadOnChange: false);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowOrigins");
app.UseAuthorization();

app.UseMiddleware<CorrelationIdMiddleware>();

await app.UseOcelot(); 

app.MapControllers(); 

app.Run();
