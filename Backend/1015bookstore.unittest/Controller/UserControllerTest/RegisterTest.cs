using _1015bookstore.application.System.Users;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using _1015bookstore.webapi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.unittest.Controller.UserControllerTest
{
    public class RegisterTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public RegisterTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData("1Nguyen", "1Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc@12345", "Abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "neit", "Abc@12345", "Abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "neit@123", "Abc@12345", "Abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc@1", "Abc@1")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "abc@12345", "abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc12345", "Abc12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc@pnmk", "Abc@pnmk")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "ABC@12345", "ABC@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc@12345", "abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208gm.uit.edu.vn", "Neit1410", "Abc@12345", "Abc@12345")]
        public async Task Register_ShouldReturnStatus400_WhenDataIsInvalid(string firstname, string lastname, string email, string username, string password, string confirmpassword)
        {
            //Arrange
            var registerRequest = new RegisterRequest
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                username = username,
                password = password,
                confirmpassword = confirmpassword
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.Register(registerRequest) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("Nguyen", "Duy", "21530208@gm.uit.edu.vn", "Neit1410", "Abc@12345", "Abc@12345")]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "admin123", "Abc@12345", "Abc@12345")]
        public async Task Register_ShouldReturnStatus400_WhenUsernameOrEmailIsUsed(string firstname, string lastname, string email, string username, string password, string confirmpassword)
        {
            //Arrange
            var registerRequest = new RegisterRequest
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                username = username,
                password = password,
                confirmpassword = confirmpassword
            };
            var response =  new ResponseService()
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.Register(registerRequest)).ReturnsAsync(response);
            // Act
            var result = await _sut.Register(registerRequest) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("Nguyen", "Duy", "21520208@gm.uit.edu.vn", "Neit1410", "Abc@12345", "Abc@12345")]
        public async Task Register_ShouldReturnStatus200_WhenDataValid(string firstname, string lastname, string email, string username, string password, string confirmpassword)
        {
            //Arrange
            var registerRequest = new RegisterRequest
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                username = username,
                password = password,
                confirmpassword = confirmpassword
            };
            var response = new ResponseService()
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.Register(registerRequest)).ReturnsAsync(response);
            // Act
            var result = await _sut.Register(registerRequest) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }
    }
}
