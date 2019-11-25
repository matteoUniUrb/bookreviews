using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdgt.BookApi.Configurations;
using Pdgt.BookApi.Data;
using Pdgt.BookApi.Http;
using Pdgt.BookApi.Mapping;
using Pdgt.BookApi.Repositories;
using Pdgt.BookApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Pdgt.BookApi
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
            //configuration from appsettings
            services.Configure<OpenLibraryConfig>(Configuration.GetSection("OpenLibraryApi"));
            services.Configure<ReviewsRepositoryConfig>(Configuration.GetSection("ReviewsDatabase"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Title = "Book API", Version = "V1" });

                var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Pdgt.BookApi.xml");

                if (File.Exists(filePath))
                {
                    options.IncludeXmlComments(filePath);
                    options.DescribeAllEnumsAsStrings();
                }
            });

            //add automapper
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //inject services
            services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            services.AddTransient<IOpenLibraryService, OpenLibraryService>();
            services.AddTransient<IBookReviewService, BookReviewService>();
            services.AddTransient<IRepository<BookReviews>, ReviewsRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API V1");
            });
        }
    }
}
