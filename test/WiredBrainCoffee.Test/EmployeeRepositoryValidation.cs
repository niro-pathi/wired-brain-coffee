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
            AddEmployee(employeeRepository);
            var employee = employeeRepository.GetById(2);

            Assert.Equal("Anna", employee.Firstname);

        }

        private static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Firstname = "Julia" });
            employeeRepository.Add(new Employee { Firstname = "Anna" });
            employeeRepository.Add(new Employee { Firstname = "Thomas" });
        }

        [Fact]
        public void ValidateOrganizationEntitiy()
        {
            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
            var organization = organizationRepository.GetById(2);

            Assert.Equal("Pluralsight", organization.Name);

        }

        private static void AddOrganization(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
        }
    }
}
