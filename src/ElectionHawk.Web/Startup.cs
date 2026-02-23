using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ElectionHawk.Common.AppSettings;
using ElectionHawk.Service.Extensions;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.AspNetCore.Mvc.Versioning;
using ElectionHawk.Web.Helpers;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.FileProviders;
using System.IdentityModel.Tokens.Jwt;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ElectionHawk.Web
{
    public class Startup
    {
        //public static IHostingEnvironment _hostingEnv;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Configuration2 = configuration;
            //_hostingEnv = env;
        }

        public static IConfiguration Configuration { get; set; }
        //public IConfiguration Configuration2 { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Identity         
            services.AddDbContext<ElectionHawkIdentityContext>(options => {
                options.UseSqlServer(Configuration["AppSettings:DataBaseSettings:ConnectionString"]);
                options.UseOpenIddict();
                });
            services.AddIdentity<ElectionHawkIdentityUser, ElectionHawkIdentityRole>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                //// Password settings

                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                
                //    //// Lockout settings
                //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //    //options.Lockout.MaxFailedAccessAttempts = 10;

                
            })
          .AddEntityFrameworkStores<ElectionHawkIdentityContext>()
          .AddDefaultTokenProviders();
            // Enable Dual Authentication 

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var secret = Configuration["AppSettings:JWTSettings:Secret"];
            var audience = Configuration["AppSettings:JWTSettings:Audience"];
            var issuer = Configuration["AppSettings:JWTSettings:Issuer"];

            //var audienceConfig = Configuration2.GetSection("AppSettings:JWTSettings");

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {                            
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            var keyByteArray = Encoding.UTF8.GetBytes(secret);
            var signKey = new SymmetricSecurityKey(keyByteArray);

            // Register the OpenIddict services.
            services.AddOpenIddict(options =>
            {
                // Register the Entity Framework stores.
                options.AddEntityFrameworkCoreStores<ElectionHawkIdentityContext>();
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                options.AddMvcBinders();
                // Enable the token endpoint.
                // Form password flow (used in username/password login requests)
                options.EnableTokenEndpoint("/connect/token");
                // Enable the authorization endpoint.
                // Form implicit flow (used in social login redirects)
                options.EnableAuthorizationEndpoint("/connect/authorize");
                // Enable the password and the refresh token flows.
                options.AllowPasswordFlow()
                       .AllowRefreshTokenFlow()
                       .AllowImplicitFlow(); // To enable external logins to authenticate

                options.SetAccessTokenLifetime(TimeSpan.FromMinutes(30));
                options.SetIdentityTokenLifetime(TimeSpan.FromMinutes(30));
                options.SetRefreshTokenLifetime(TimeSpan.FromMinutes(60));
                // During development, you can disable the HTTPS requirement.
                options.DisableHttpsRequirement();

                //options.UseRollingTokens(); //Uncomment to renew refresh tokens on every refreshToken request
                //options.AddSigningKey(new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(audienceConfig["Secret"])));

                // Note: to use JWT access tokens instead of the default
                // encrypted format, the following lines are required:
                //
                options.UseJsonWebTokens();
                options.AddSigningKey(signKey);
                options.AddEphemeralSigningKey();           
            });

            //if (this.environment.IsDevelopment())
            //{
            //    options.DisableHttpsRequirement();
            //    options.AddEphemeralSigningKey();
            //}

            services.AddAuthentication(options =>
            {
                // This will override default cookies authentication scheme
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
               {
                   options.Authority = audience;
                   options.Audience = audience;
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;

                   options.TokenValidationParameters = new TokenValidationParameters
                   {

                       NameClaimType = OpenIdConnectConstants.Claims.Subject,
                       RoleClaimType = OpenIdConnectConstants.Claims.Role,
                       ValidIssuer = issuer,
                       ValidAudience = audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                   };
                   options.Configuration = new OpenIdConnectConfiguration();
                   options.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           if (context.Request.Path.Value.StartsWith("/api"))
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                           }
                           return Task.CompletedTask;
                       }
                   };
               })
               // https://console.developers.google.com/projectselector/apis/library?pli=1
               .AddGoogle(options =>
               {
                   options.ClientId = Startup.Configuration["Authentication:Google:ClientId"];
                   options.ClientSecret = Startup.Configuration["Authentication:Google:ClientSecret"];
               })
               // https://developers.facebook.com/apps
               .AddFacebook(options =>
               {
                   options.AppId = Startup.Configuration["Authentication:Facebook:AppId"];
                   options.AppSecret = Startup.Configuration["Authentication:Facebook:AppSecret"];
               })
               // https://apps.twitter.com/
               .AddTwitter(options =>
               {
                   options.ConsumerKey = Startup.Configuration["Authentication:Twitter:ConsumerKey"];
                   options.ConsumerSecret = Startup.Configuration["Authentication:Twitter:ConsumerSecret"];
               })
               // https://apps.dev.microsoft.com/?mkt=en-us#/appList
               .AddMicrosoftAccount(options =>
               {
                   options.ClientId = Startup.Configuration["Authentication:Microsoft:ClientId"];
                   options.ClientSecret = Startup.Configuration["Authentication:Microsoft:ClientSecret"];
               });
               
               
               
               


            //.AddOAuthValidation() will throw exceptionsScheme already exists: Bearer
            //./*AddOpenIdConnect(options => { options.SaveTokens = true;});*/          
            //services.AddAuthentication()
            //  .AddCookie(cfg => cfg.SlidingExpiration = true)
            //  .AddJwtBearer(cfg =>
            //  {
            //      cfg.RequireHttpsMetadata = false;
            //      cfg.SaveToken = true;

            //      cfg.TokenValidationParameters = new TokenValidationParameters()
            //      {
            //          ValidIssuer = audienceConfig["Issuer"],
            //          ValidAudience = audienceConfig["Audience"],
            //          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]))
            //      };
            //  });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //connections local
            //var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IAppSettings, AppSettings>();
            services.AddSingleton(c => new ConnectionString(Configuration["AppSettings:DataBaseSettings:ConnectionString"]));
            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddCElectionHawkService();
            //services.AddAutoMapper();not working 
            //work arround 
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ElectionHawkProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);               
            });


            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new Info {
                    Title = "My API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new Contact { Name = "Nadeem", Email = "", Url = "ElectionHawk.com" }
                });

                // Set the comments path for the Swagger JSON and UI.
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "ElectionHawk.Web.xml");
                //c.IncludeXmlComments(xmlPath);
            });

            /* 
            //Cache Store. will use later  
            //services.AddResponseCaching();

            //services.AddHttpCacheHeaders(
            //    (expirationModelOptions)
            //    =>
            //    {
            //        expirationModelOptions.MaxAge = 600;
            //    },
            //    (validationModelOptions)
            //    =>
            //    {
            //        validationModelOptions.AddMustRevalidate = true;
            //    });

            */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementEndpoint = "/dist/__webpack_hmr"
                });
            }

            app.UseStaticFiles();

            //node_modules not available in production
            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                    RequestPath = "/node_modules"
                });
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
           
            // Serialize all exceptions to JSON
            var jsonExceptionMiddleware = new JsonExceptionMiddleware(
                app.ApplicationServices.GetRequiredService<IHostingEnvironment>());
            app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = jsonExceptionMiddleware.Invoke });

            /* 
             * //maybe use later 
            //app.UseResponseCaching();
            //app.UseHttpCacheHeaders();
            */


            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //  name: "default_route",
                //  template: "{controller}/{action}/{id?}");
                routes.MapRoute("default_route", "{controller}/{action}/{id?}");

                routes.MapRoute("default", "{controller=Home}/{action=About}/{id?}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=About}/{id?}");





                // when the user types in a link handled by client side routing to the address bar 
                // or refreshes the page, that triggers the server routing. The server should pass 
                // that onto the client, so Angular can handle the route

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
                // Catch all Route - catches anything not caught be other routes
                routes.MapRoute(
                    name: "catch-all",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" });
            });     
            
        }
    }
}
