using CommandLine;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Villainous.DataAccess;
using Villainous.DataAccess.Migrations;

string connectionString = null;
var options = new Options();
Parser.Default.ParseArguments<Options>(args).WithParsed(opts =>
{
    connectionString = opts.ConnectionString;
    options = opts;
}).WithNotParsed((errs) => throw new ArgumentException(string.Join(Environment.NewLine, errs)));
var serviceProvider = CreateServices(connectionString, options);

using (var scope = serviceProvider.CreateScope())
{
    UpdateDatabase(scope.ServiceProvider);
}

static IServiceProvider CreateServices(string connectionString, Options options)
{
    return new ServiceCollection()
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(M001_Initial).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .AddSingleton(options)
    .BuildServiceProvider(false);
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    var options = serviceProvider.GetRequiredService<Options>();
    if (options.Reset)
    {
        Retry(() => runner.MigrateDown(0), 5);
    }
    runner.MigrateUp();
}

static void Retry(Action action, int count)
{
    for (var i = 0; i < count; i++)
    {
        try
        {
            action();
            break;
        }
        catch (Exception)
        {
            if (i == count)
            {
                throw;
            }
        }
    }
}