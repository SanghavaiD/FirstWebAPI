// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;

Console.WriteLine("API Client!");
EmployeeAPIClient.CallGetEmployees().Wait();
Console.ReadLine();
