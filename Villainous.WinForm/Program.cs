using Microsoft.Extensions.DependencyInjection;
using Villainous.Client;

namespace Villainous.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var services = new ServiceCollection();
            services.AddSingleton<GameClient>();
            services.AddSingleton<MainMenu>();
            var serviceProvider = services.BuildServiceProvider();
            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetService<MainMenu>());
        }
    }
}