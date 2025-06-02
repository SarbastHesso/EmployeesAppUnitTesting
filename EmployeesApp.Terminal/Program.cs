//using EmployeesApp.Application.Employees.Services;
//using EmployeesApp.Domain.Entities;
//using EmployeesApp.Infrastructure.Persistance;
//using EmployeesApp.Infrastructure.Persistance.Repositories;

//namespace EmployeesApp.Terminal;
//internal class Program
//{
//    static readonly EmployeeService employeeService = new(new EmployeeRepository());

//    static void Main(string[] args)
//    {

//        ListAllEmployees();
//        ListEmployee(562);
//    }

//    private static void ListAllEmployees()
//    {
//        foreach (var item in employeeService.GetAll())
//            Console.WriteLine(item.Name);

//        Console.WriteLine("------------------------------");
//    }

//    private static void ListEmployee(int employeeID)
//    {
//        Employee? employee;

//        try
//        {
//            employee = employeeService.GetById(employeeID);
//            Console.WriteLine($"{employee?.Name}: {employee?.Email}");
//            Console.WriteLine("------------------------------");
//        }
//        catch (ArgumentException e)
//        {
//            Console.WriteLine($"EXCEPTION: {e.Message}");
//        }
//    }
//}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IMyService, MyService>();
            })
            .Build();

        var myService = host.Services.GetRequiredService<IMyService>();
        myService.Run();
    }
}

public interface IMyService
{
    void Run();
}

public class MyService : IMyService
{
    public void Run()
    {
        Console.WriteLine("Service is running!");
    }
}