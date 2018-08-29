using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Course https://app.pluralsight.com/player?course=aspdotnet-mvc5-fundamentals
namespace KatanaSample
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8086";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping!");
            }

        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(async (env, next) =>
            //{
            //    foreach (var pair in env.Environment)
            //    {
            //        Console.WriteLine($"{pair.Key}: {pair.Value}");
            //    }
            //    await next();
            //});

            app.Use(async (env, next) =>
            {
                Console.WriteLine($"Requesting: {env.Request.Path}");
                await next();
                Console.WriteLine($"Response: {env.Response.StatusCode}");
            });

            app.UseHelloWorld();

            //app.Run(ctx => {
            //    return ctx.Response.WriteAsync("Hello world!!");
            //});
        }
    }
    
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;

            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
