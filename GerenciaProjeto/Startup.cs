using GerenciaProjeto.Data;
using GerenciaProjeto.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto
{
    public class Startup
    {
        private string _connection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SqlConnectionStringBuilder builder = new(Configuration.GetConnectionString("DefaultConnection"))
            {
                Password = Configuration["DbPassword"]
            };
            _connection = builder.ConnectionString;

            services.AddDbContext<GerenciaProjetoContext>(options => options.UseSqlServer(_connection));
            services.AddControllersWithViews();

            services.AddScoped<TarefaEmpresaService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<TarefaClienteService>();
            services.AddScoped<SistemaService>();
            services.AddScoped<VersaoService>();
            services.AddScoped<AtualizacaoClienteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Inicio}/{id?}");
            });
        }
    }
}
