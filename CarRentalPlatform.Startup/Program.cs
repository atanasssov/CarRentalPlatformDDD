using CarRentalPlatform.Application;
using CarRentalPlatform.Infrastructure;
using CarRentalPlatform.Startup;
using CarRentalPlatform.Web;
using CarRentalPlatform.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDomain();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebComponents();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Initialize();

app.Run();
