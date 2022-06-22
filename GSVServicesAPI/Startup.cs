using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GSVServicesAPI.Busniness;
using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories;
using GSVServicesAPI.Repositories.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GSVServicesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IDapperOperacoes, DapperOperacoes>();
            services.AddSingleton<HttpClient>();
            //Repositories
            services.AddTransient<LoginRepository, LoginRepository>();
            services.AddTransient<IRepository<Pedido>, PedidosRepository>();
            //Busniness
            services.AddTransient<BusninessPedido, BusninessPedido>();

            var sqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDbContext"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
