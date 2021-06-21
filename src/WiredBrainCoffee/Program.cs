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
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;

            AddEmployee(employeeRepository);
            AddManagers(employeeRepository);
            DisplayAllRecords(employeeRepository);
            GetRecordById(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
            DisplayAllRecords(organizationRepository);
            GetRecordById(organizationRepository);
        }

        private static void EmployeeRepository_ItemAdded(object sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.Firstname}");
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

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {

            var saraManager = new Manager { Firstname = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if(saraManagerCopy is not null)
            {
                saraManagerCopy.Firstname += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

            managerRepository.Add(new Manager { Firstname = "Henry" });
            managerRepository.Save();
        }

        private static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { Firstname = "Julia" },
                new Employee { Firstname = "Anna" },
                new Employee { Firstname = "Thomas" }
            };
           
            employeeRepository.AddBatch(employees);

        }

        private static void AddOrganization(IRepository<Organization> organizationRepository)
        {

            var organizations = new[]
            {
                new Organization { Name = "Microsoft" },
                new Organization { Name = "Pluralsight" }
            };

            organizationRepository.AddBatch(organizations);

        }

       
    }
}
