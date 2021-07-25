using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SaltpayBank.Application.Commands;
using SaltpayBank.Infrastructure.Data;
using SaltpayBank.Infrastructure.Data.Repositories;
using SaltpayBank.Seedwork;
using MediatR;
using SaltpayBank.Api.Mappers;
using SaltpayBank.Application.Mappers;

namespace SaltpayBank.Api
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

            services.AddControllers();

            // TODO: Improve DI
            services
                .AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("SaltpayBankConnectionString")));
            services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddMediatR(cfg => { }, typeof(AddNewBankAccountToCustomerCommandHandler).Assembly);


            services.AddAutoMapper(typeof(ApiProfile), typeof(ApplicationProfile));
            // #############################################################

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaltpayBank.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaltpayBank.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
