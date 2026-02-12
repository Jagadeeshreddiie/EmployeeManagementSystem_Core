//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore;

//namespace EmployeeManagement
//{
//    public class Program
//    {
//        public static void Main(string[] strings)
//        {
//            CreateWebHostBuilder.Build().Run();
//        }
//        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>;
//    }
//}

// Commented above approach as it is before .NET Core 6.x version

using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

var app=builder.Build();

// IConfiguration is the builtin service to read the Configuration.
IConfiguration config = app.Configuration;

/* Minimal APIs Based on Endpoint

// getting the Processing server name  eg: IIS - Inprocess, Kestrel - OutOfProcess
//app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName);

//app.MapGet("/user", () => "User Endpoint");

//// Configuration
//// AppSettings -> AppSettings.development -> User Secrets -> Env Variables -> Cmd line Args.
//// cmd ex: dotnet run MyKey="Value from CMD"

//app.MapGet("/Key", () => config["MyKey"]);

*/

// Minimal Universal API with context delegate.
//app.Use(async (context,next) => {
//    // Use with next parameter will pass the control to next middleware, otherwise it will be terminated.

//    // logger

//    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

//    logger.LogInformation("MW1 : Request Processing");

//    await context.Response.WriteAsync(context.Request.Path + "  " + config["MyKey"]);

//    await next();

//    logger.LogInformation("MW1 : Response Processing");

//});

//app.Run( async (context) => { await context.Response.WriteAsync(context.Request.Method +"  "+ config["MyKey"]); });


// adding the DefaultFileOptions to render custom html as default page.

//DefaultFilesOptions options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("Foo.html");

// adding FileServerOptions for combined usage of UseDirectoryBrowser middleware, by replacing both UseDefaultFiles, UseStaticFiles Middlewares

//app.UseDefaultFiles(options);
//app.UseStaticFiles();

FileServerOptions options = new FileServerOptions();
options.DefaultFilesOptions.DefaultFileNames.Clear();
options.DefaultFilesOptions.DefaultFileNames.Add("foo.html");

app.UseFileServer(options);

app.Run( async (context) => {
    await context.Response.WriteAsync("Hello World!");
});


app.Run();
