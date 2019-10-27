using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using ClockHackaInsight.Backend.Services;
using ClockHackInsight.Backend;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace ClockHackaInsight.Backend
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                       .AllowAnyMethod()
                                                                       .AllowAnyHeader()));
            services.AddControllers();

            services.AddSingleton<IHeartbeatHelper, HeartbeatHelper>();
            services.AddSingleton<IMessageBroadcastService, MessageBroadcastService>();
            services.AddSingleton<IMotivationalQuotesService, MotivationalQuotesService>();
            services.AddSingleton<IEventService, EventService>();

            services.AddSingleton<IDocumentDBRepository<User>>(new DocumentDBRepository<User>("Users"));
            services.AddSingleton<IDocumentDBRepository<MotivationalQuote>>(new DocumentDBRepository<MotivationalQuote>("Quotes"));
            services.AddSingleton<IDocumentDBRepository<Event>>(new DocumentDBRepository<Event>("Events"));

            services.AddTransient<IUserService, UserService>();
            
            services.AddHostedService<MotivationalWorker>();
            services.AddHostedService<HeartbeatWorker>();
            services.AddHostedService<EventWorker>();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Insight Investment Clockwork Backend", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Insight Investment Backend API V1");
            //});
        }
    }
}
