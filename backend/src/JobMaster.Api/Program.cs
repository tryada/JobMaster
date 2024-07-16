using JobMaster.Api;
using JobMaster.Api.Common.Cors;
using JobMaster.Application;
using JobMaster.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.ApplyMigrations();
    app.UseCorsPolicy();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    
    app.MapControllers();
    app.Run();
}