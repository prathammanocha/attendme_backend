using DEKODE.AttendMe.Api.Commands;
using DEKODE.AttendMe.Api.Configurations;
using DEKODE.AttendMe.Api.MappingConfigurations;
using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Queries;
using DEKODE.AttendMe.Api.Repositories;
using DEKODE.AttendMe.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DEKODE.AttendMe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // register the service in our ConfigureServices method with the AddProblemDetails()
            // You should add this early in the pipeline, to ensure it catches errors from any subsequent middleware:
            //services.AddProblemDetails(setup =>
            //{
            //    setup.IncludeExceptionDetails = (ctx, env) => CurrentEnvironment.IsDevelopment() || CurrentEnvironment.IsStaging();

            //    //setup.Map<ProductCustomException>(exception => new ProductCustomDetails
            //    //{
            //    //    Title = exception.Title,
            //    //    Detail = exception.Detail,
            //    //    Status = StatusCodes.Status500InternalServerError,
            //    //    Type = exception.Type,
            //    //    Instance = exception.Instance,
            //    //    AdditionalInfo = exception.AdditionalInfo
            //    //});
            //});

            /******************************** DbContext ***************************************************************************/

            // Ordinarily, the DbContext will be added to the dependency injection container in Startup.ConfigureServices()
            // Add DbContext to the injection container

            // Configure db context using ServiceCollectionExtension
            // services.AddAttendMeDbContext(Configuration.GetConnectionString("AttendMeDb"));

            // Configure db context to connect to SQL Server database.
            //services.AddDbContext<SchoolContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<AttendMeDbContext>(options =>
            //    options.UseSqlite(Configuration.GetConnectionString("AttendMeDb")));

            //services.AddDbContext<AttendMeDbContext>(options =>
            //    options.UseLazyLoadingProxies()
            //            .UseSqlite(Configuration.GetConnectionString("AttendMeDb")));

            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<AttendMeDbContext>
                (options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddCors(feature =>
                feature.AddPolicy(
                    "CorsPolicy",
                    apiPolicy => apiPolicy
                                    //.AllowAnyOrigin()
                                    //.WithOrigins("http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .SetIsOriginAllowed(host => true)
                                    .AllowCredentials()
                                ));

            /*********************************************************************************************************************/

            // JWT authentication service
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    // https://www.youtube.com/watch?v=nqs_ZZ2bUYg
                    ClockSkew = System.TimeSpan.Zero, // immediate expiration of the token, otherwise by default token is valid for 5 mins after expiration.
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddControllers();

            // Add Swagger generator to the services collection.
            services.AddSwaggerGen();

            // Configure AutoMapper for the project.
            services.AddAutoMapper(typeof(Startup));
            //services.AddHttpContextAccessor();

            //services.AddScoped<IAccountQueries, AccountQueries>();
            services.AddScoped<IAccountCommands, AccountCommands>();
            services.AddScoped<IUserQueries, UserQueries>();
            //services.AddScoped<IAccountUserQueries, AccountUserQueries>();
            services.AddScoped<IUserQueries, UserQueries>();
            services.AddScoped<IUserCommands, UserCommands>();
            services.AddScoped<IStaffQueries, StaffQueries>();
            services.AddScoped<IStudentLogRepository, StudentLogRepository>();
            services.AddScoped<IStaffCommands, StaffCommands>();
            services.AddScoped<IPatronQueries, PatronQueries>();
            services.AddScoped<IPatronCommands, PatronCommands>();
            services.AddScoped<IAccountUserCommands, AccountUserCommands>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<ITokenService, TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AttendMeDbContext context)
        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // add the middleware to our request processing pipeline by calling UseProblemDetails()
            // app.UseProblemDetails();

            /******************************** DbContext ***************************************************************************/

            // If you are using migrations there is context.Database.Migrate().
            // If you don't want migrations and just want a quick database (usually for testing) then use context.Database.EnsureCreated()/EnsureDeleted().

            //using (var scope = app.ApplicationServices.CreateScope())
            //using (var context = scope.ServiceProvider.GetService<AttendMeDbContext>())
            //    context.Database.Migrate();

            // In order to call Database.EnsureCreated() or Database.Migrate(), we can, and want to,
            // have the DbContext resolve automatically in Startup.Configure(), where our configured services are now available through DI

            //  Configure using ApplicationBuilderExtensions
            //if (env.IsDevelopment())
            //    app.MigrateDb(true);

            if (env.IsDevelopment())
            {
                context.Database.Migrate();
            }

            /*********************************************************************************************************************/

            //// Add Swagger middleware to Http processing pipeline.
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AttendMe API V1");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "AttendMe API V1");
                });
            }

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            
            app.UseAuthentication(); // This need to be added for JWT
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}