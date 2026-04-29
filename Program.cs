using Backender.AppDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContexts>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DbConnectionString"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DbConnectionString"))
    ));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.UseRouting();
app.Run();