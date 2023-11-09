using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MockingExample.Library.Models;
using MockingExample.Library.Services;



// Register services for Dependency Injection. In this way, instead of creating a new instance of TransactionService, the DI framework will
// give us the instance with the concrete dependencies that it requires.
//
// In other words, we are telling the DI to use DatabaseService
// for all the services that depend on IDatabaseService:
var serviceProvider = new ServiceCollection()
     .AddLogging()
     .AddTransient<IDatabaseService, DatabaseService>()
     .AddTransient<TransactionService>()
     .BuildServiceProvider();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

// Configure console logging
var logger = loggerFactory.CreateLogger<Program>();

logger.LogDebug("Starting application");

// Instead of creating a new instance of TransactionService, the DI framework will
// give us the instance with the concrete implementation DatabaseService
var transactionService = serviceProvider.GetService<TransactionService>();

bool endProgram = false;

while (!endProgram)
{
    Console.Write("Please enter the name of the customer (hints: \"joe biden\", \"pikachu\", \"slash\") : ");
    var customerName = Console.ReadLine();

    var request = new CustomerRequest
    {
        Name = customerName
    };

    Console.WriteLine();
    Console.WriteLine("Calculating result...");
    Console.WriteLine();

    var result = transactionService.CustomerCareResult(request);

    Console.WriteLine($"Result: {result.Data}");
    Console.WriteLine();

    Console.Write("Do you want to exit (Y/N)? ");

    endProgram = Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase);
    Console.WriteLine();

}


