using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetEscapades.AspNetCore.SecurityHeaders;
using WebEssentials.AspNetCore.Pwa;

namespace trill {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices (IServiceCollection services) {
            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton (typeof (IHttpContextAccessor), typeof (HttpContextAccessor));
            WebEssentials.AspNetCore.Pwa.PwaOptions opt = new WebEssentials.AspNetCore.Pwa.PwaOptions ();

            opt.OfflineRoute = "/";
            opt.RegisterServiceWorker = true;
            opt.RegisterWebmanifest = true;

            services.AddProgressiveWebApp (opt, "manifest.json");
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            var policyCollection = new HeaderPolicyCollection ()
                .AddXssProtectionEnabled ()
                .AddFrameOptionsDeny ()
                .AddXssProtectionBlock ()
                .AddContentTypeOptionsNoSniff ()
                .AddReferrerPolicyStrictOriginWhenCrossOrigin ()
                .RemoveServerHeader ()
                .AddContentSecurityPolicy (builder => {
                    builder.AddFrameAncestors ().None ();
                });

            app.UseSecurityHeaders (policyCollection);
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}