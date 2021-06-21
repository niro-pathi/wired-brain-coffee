using System;
using WiredBrainCoffee.Data;
using WiredBrainCoffee.Entities;
using WiredBrainCoffee.Repositories;

namespace WiredBrainCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDBContext());
            AddEmployeeType(employeeRepository);
            AddManagers(employeeRepository);
            DisplayAllRecords(employeeRepository);
            GetRecordById(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizationType(organizationRepository);
            DisplayAllRecords(organizationRepository);
            GetRecordById(organizationRepository);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { Firstname = "Sara" });
            managerRepository.Add(new Manager { Firstname = "Sara" });
            managerRepository.Save();
        }

        private static void DisplayAllRecords(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);

            }
        }

        private static void GetRecordById(IReadRepository<IEntity> repository)
        {
            var item = repository.GetById(2);
            Console.WriteLine($"Requested Record is {item}");
        }

        private static void AddEmployeeType(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Firstname = "Julia" });
            employeeRepository.Add(new Employee { Firstname = "Anna" });
            employeeRepository.Add(new Employee { Firstname = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganizationType(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Save();
        }
    }
}
