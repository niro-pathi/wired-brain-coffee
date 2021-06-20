using System;
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
            var employeeRepository = new GenericRepository<Employee>();
            employeeRepository.Add(new Employee { Firstname = "Julia" });
            employeeRepository.Add(new Employee { Firstname = "Anna" });
            employeeRepository.Add(new Employee { Firstname = "Thomas" });
            var employee = employeeRepository.GetById(2);

            Assert.Equal(3, employeeRepository.Count());
            Assert.Equal("Anna", employee.Firstname);

        }

        [Fact]
        public void ValidateOrganizationEntitiy()
        {
            var organizationRepository = new GenericRepository<Organization>();
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            var organization = organizationRepository.GetById(2);

            Assert.Equal(2, organizationRepository.Count());
            Assert.Equal("Pluralsight", organization.Name);

        }
    }
}
