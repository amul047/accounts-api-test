using Accounts.Api.Controllers;
using Accounts.Api.Repositories;
using Accounts.Api.Repositories.Interfaces;
using Accounts.Api.Services;
using Accounts.Api.Services.Interfaces;
using Accounts.Api.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Accounts.Api
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

            services.AddValidatorsFromAssembly(typeof(AccountValidator).Assembly);

            services.AddAutoMapper(typeof(AccountMappingProfile).Assembly);
            
            services.AddDbContext<AccountsDbContext>(builder =>
                builder.UseSqlServer(
                    "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Accounts; Integrated Security=true"));

            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseMvc();
        }
    }
}
