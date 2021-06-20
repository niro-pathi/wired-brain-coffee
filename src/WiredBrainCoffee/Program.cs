using System;
using WiredBrainCoffee.Entities;
using WiredBrainCoffee.Repositories;

namespace WiredBrainCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            AddEmployeeType(employeeRepository);
            GetEmployeeById(employeeRepository);
            
            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizationType(organizationRepository);
            
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with id 2 {employee.Firstname}");
        }

        private static void AddOrganizationType(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Save();
        }

        private static void AddEmployeeType(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Firstname = "Julia" });
            employeeRepository.Add(new Employee { Firstname = "Anna" });
            employeeRepository.Add(new Employee { Firstname = "Thomas" });
            employeeRepository.Save();
        }
    }
}
