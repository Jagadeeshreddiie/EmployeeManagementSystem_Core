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


app.UseDefaultFiles();
app.UseStaticFiles();

app.Run( async (context) => {
    await context.Response.WriteAsync("Hello World!");
});


app.Run();
