using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paylocity.Controllers;
using Paylocity.Models;
using Paylocity.Repositories;
using Xunit;

public class EmployeesControllerTests
{
    private readonly Mock<IEmployeeRepository> _mockRepo;
    private readonly EmployeeController _controller;
    public EmployeesControllerTests()
    {
        _mockRepo = new Mock<IEmployeeRepository>();
        _controller = new EmployeeController(_mockRepo.Object);
    }
    [Fact]
    public async void GetAll_ActionExecutes_ReturnsActionResulyt()
    {
        var result = await _controller.GetEmployees();
        Assert.IsType<OkObjectResult>(result);
    }
    [Fact]
    public async void GetOne_ActionExecutes_ReturnsActionResulyt()
    {
        var result = await _controller.GetEmployee(Guid.NewGuid());
        Assert.IsType<OkObjectResult>(result);

    }
    [Fact]
    public async void GetAll_ActionExecutes_ReturnsExactNumberOfEmployees()
    {
        _mockRepo.Setup(repo => repo.GetEmployees())
            .ReturnsAsync(new List<Employee>() { new Employee(), new Employee() });
        var result = await _controller.GetEmployees();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var employees = Assert.IsType<List<Employee>>(okResult);
        Assert.Equal(2, employees.Count);
    }
    [Fact]
    public async void Create_CheckIfCreatedEmployeeHasCorrectPropertyDetails()
    {
        var employee = new Employee {LastName="Johnson", Discount=0, ID=Guid.NewGuid(), Dependents= null, BenefitCost=1000 };

        var result = await _controller.CreateEmployee(employee);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var testEmployee = Assert.IsType<Employee>(okResult);

        Assert.Equal(employee.Discount, testEmployee.Discount);
        Assert.Equal(employee.BenefitCost, testEmployee.BenefitCost);
    }
}