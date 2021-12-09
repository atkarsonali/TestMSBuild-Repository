using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Logging;

public class Startup{
public void ConfigureServices(IServiceCollection services)
{
    services.AddCors();
    services.AddControllers();
    services.AddSpaStaticFiles(configuration =>
    {
        configuration.RootPath = "frontend-project/dist";
    });
    
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseHttpsRedirection();
    app.UseCors(builder =>
        builder.WithOrigins("http://localhost:4200"));
          app.UseStaticFiles();
    if (!env.IsDevelopment())
    {
        app.UseSpaStaticFiles();
    }
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.UseSpa(spa =>
    {
    spa.Options.SourcePath = "frontend-project";
    if(env.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
    });
}
}