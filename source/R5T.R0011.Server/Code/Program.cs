using System;

using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Builder;


namespace R5T.R0011.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }

            // Needed, even though a hard-refresh of Chrome after commenting out causes no problems.
            // The problem occurs when your computer is restarted (and thus the Chrome cache is *really* emptied out!). Blazor will not work and the Chrome console will be full of errors.
            app.UseBlazorFrameworkFiles();

            // Needed, since the Blazor framework files are serverd as static files. Else, the index.html page just renders as HTML.
            app.UseStaticFiles();

            // Set the default file to be the Blazor client index.html file.
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
