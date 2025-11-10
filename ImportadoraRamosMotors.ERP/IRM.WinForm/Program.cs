using IRM.Core.DependencyInjection;
using IRM.WinForm.Organization.Users;
using IRM.WinForm.Utils.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp = System.Windows.Forms.Application;
namespace IRM.WinForm;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        // ✅ Building Host
        var host = CreateHostBuilder().Build();
         
        // ✅ Initialize app
        ApplicationConfiguration.Initialize();
        var frmMainView = host.Services.GetRequiredService<FrmMainView>();
        var frmLoginView = host.Services.GetRequiredService<FrmLoginView>();

        if (frmLoginView.ShowDialog() == DialogResult.OK)
        {
            WinFormsApp.Run(frmMainView);
        }
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) =>
             {

                 // ✅ Build configuration
                 IConfiguration configuration = context.Configuration;

                 // ✅ Add services Core (Supabase, etc.)
                 CoreDependencyInjection.AddCoreServices(services, configuration);

                 // ✅ Add services Presentation (Application Layer services, Forms, etc.)
                 PresentationDependencyInjections.AddServices(services);


             });
    }

}