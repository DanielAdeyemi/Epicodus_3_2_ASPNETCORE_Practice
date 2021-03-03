using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FriendLetter
{
  public class Startup
  {
		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
      app.UseDeveloperExceptionPage();
			app.UseRouting();
			app.UseEndpoints(routes =>
			{
				routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});

			app.Run(async(context) => //write this if a proper MVC route cannot be found
			{
				await context.Response.WriteAsync("Hello, world!");
			});
		}
  }
}
