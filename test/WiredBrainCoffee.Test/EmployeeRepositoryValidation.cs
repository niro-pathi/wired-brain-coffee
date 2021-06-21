using System;
using WiredBrainCoffee.Data;
using WiredBrainCoffee.Entities;
using WiredBrainCoffee.Repositories;
using Xunit;

namespace WiredBrainCoffee.Test
{
    public class EmployeeRepositoryValidation
    {
        [Fact]
        public void ValidateEmployeeEntitiy()
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDBContext());
            AddEmployees(employeeRepository);
            var employee = employeeRepository.GetById(2);

            Assert.Equal("Anna", employee.Firstname);

        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
             {
                new Employee { Firstname = "Julia" },
                new Employee { Firstname = "Anna" },
                new Employee { Firstname = "Thomas" }
            };

            employeeRepository.AddBatch(employees);
        }

        [Fact]
        public void ValidateOrganizationEntitiy()
        {
            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            var organization = organizationRepository.GetById(2);

            Assert.Equal("Pluralsight", organization.Name);

        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
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
