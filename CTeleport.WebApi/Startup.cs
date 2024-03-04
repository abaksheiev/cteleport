using CTeleport.WebApi.Services;
using CTeleport.Domain.MeasurementConverter;
using CTeleport.Contracts.Configurations;
using CTeleport.Domain.Caching;

namespace CTeleport.WebApi
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
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSingleton<IHttpAirportService, HttpAiroportService>();
            services.AddSingleton<IMeasurementConverterFactory, MeasurementConverterFactory>();
            services.AddSingleton<ICacheProvider, CacheMemoryProvider>();

            services.AddScoped<IAirportService, AirportService>();


            // Middleware
            services.AddHttpClient();

            // Configurations
            services.Configure<PlacesDevConfig>(Configuration.GetSection(PlacesDevConfig.SectionName));
            services.Configure<AirportServiceConfig>(Configuration.GetSection(AirportServiceConfig.SectionName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
