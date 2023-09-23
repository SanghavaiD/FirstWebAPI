// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;

//Console.WriteLine("API Client!");
//Console.WriteLine("Listing Employee");
//EmployeeAPIClient.CallGetEmployees().Wait();
//Console.ReadLine();
//Console.WriteLine("Added Employee");
//EmployeeAPIClient.AddNewEmployee().Wait();
//Console.ReadLine();
//Console.WriteLine("Modifying id 10");
//int id = 10;
//EmployeeAPIClient.UpdateEmployee(id).Wait();
//Console.ReadLine();
Console.WriteLine("Deleting id 10");
int id = 10;
EmployeeAPIClient.DeleteEmployee(id).Wait();
Console.ReadLine();

