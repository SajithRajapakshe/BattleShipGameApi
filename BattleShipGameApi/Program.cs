using BattleShipGameApi.Extensions;
using BattleShipGameApi.Middlewares;
using BattleShipGameBL.Middlewares;
using BattleShipGameBL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extension to add dependencies to the pipeline. We can create custom services and inject within this static class.
builder.Services.InjectDependencies();

var app = builder.Build();


//custom middeleware to handle api exceptions.
app.UseMiddleware<ExceptionMiddleware>();

//Authentication middleware
//app.UseMiddleware<AuthenticationMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
