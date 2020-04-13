
using KAIS.Interactive.DSPC_EXPLORER.API.Utilities;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace KAIS.Interactive.DSPC_EXPLOERER.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            services.AddDbContext<DSPC_ExplorerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DSPC_ExplorerDbContext>();
            services.AddScoped<IDSPC_Repository, DSPC_Repository>();

            services.AddSwaggerGen(sgen =>
            {
                sgen.SwaggerDoc("v1", new OpenApiInfo { Title = "KAIS Solutions - DSPC Explorer API", Version = "v1" });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerConfiguration = new SwaggerConfiguration();
            Configuration.GetSection(nameof(SwaggerConfiguration)).Bind(swaggerConfiguration);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerConfiguration.JsonRoute;
            });

            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint(swaggerConfiguration.UiEndpoint, swaggerConfiguration.Description);
                option.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(options =>
            {
                options
                        .WithOrigins("http://localhost")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

            });
            app.UseMvc();
        }
    }
}
