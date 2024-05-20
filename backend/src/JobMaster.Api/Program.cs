using JobMaster.Api;
using JobMaster.Api.Common.Cors;
using JobMaster.Application;
using JobMaster.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi()
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCorsPolicy();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}