using Mahta.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddMahtaScalar(builder.Configuration, "Scalar");

var app = builder.Build();


app.UseMahtaScalar();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
