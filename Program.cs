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

// getting the Processing server name  eg: IIS - Inprocess, Kestrel - OutOfProcess
app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName);

app.MapGet("/user", () => "User Endpoint");

// Configuration
// AppSettings -> AppSettings.development -> User Secrets -> Env Variables -> Cmd line Args.
// cmd ex: dotnet run MyKey="Value from CMD"

app.MapGet("/Key", () => config["MyKey"]);

app.Run();
