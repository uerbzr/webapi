using webapi.Data.DataStore;
using webapi.Data.Services;
using webapi.Endpoints;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IPerson, Person>();
builder.Services.AddScoped<IPersonDataStore, PersonDataStore>();
builder.Services.AddScoped<IPersonDataService, PersonDataService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureStaffApi();
app.ConfigurePeopleApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
