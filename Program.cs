using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var bilder = WebApplication.CreateBuilder(args);

bilder.Services.AddControllers();
bilder.Services.AddEndpointsApiExplorer();

bilder.Services.AddSwaggerGen();

var app  = bilder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();