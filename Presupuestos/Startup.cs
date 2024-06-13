using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ipresupuesto;
using presupuesto;
using SoapCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace presupuesto_final
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var keysDirectory = Path.Combine(Directory.GetCurrentDirectory(), "keys");

            // Asegúrate de que el directorio exista
            if (!Directory.Exists(keysDirectory))
            {
                Directory.CreateDirectory(keysDirectory);
            }

            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(keysDirectory));

            services.AddSoapCore();
            services.TryAddSingleton<iPresupuesto, Presupuesto>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<iPresupuesto>("/Presupuesto.equipo3", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
            });
        }
    }
}