using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SKL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;

namespace SKL
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
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.Add(new RequireHttpsAttribute());
            })
                .AddSessionStateTempDataProvider();

            services.AddSession();

            // auterar conexões do banco de dados dos usuarios do sistema
            services.AddDbContext<SkldbMainContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConexaoNoteCintiaDB")));
            
            // adicionar modulo de autenticação via cookeis
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                // adicionar telas de validação de login e role
                options.AccessDeniedPath = "";
                options.LoginPath = "/Shared/ErroUsuarioNaoLogado";
            });

            // adicionar roles politica de autenticação de usuario
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", p => p.RequireAuthenticatedUser().RequireRole("Admin"));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // para tunelamento caso necessario realizar testes na internet publica com o ngrok
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // bloqueia http, assegura que a somente serão aceitos https
            app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());

            app.UseXXssProtection(options => options.EnabledWithBlockMode());

            app.UseXContentTypeOptions();

            app.UseStaticFiles();

            // define uso de authenticação via cookies
            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
