using _1015bookstore.application.System.Users;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using _1015bookstore.webapi.Controllers;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _1015bookstore.unittest.Controller.UserControllerTest
{
    public class LoginTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public LoginTest() {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "Abcd1234$")]
        [InlineData("admin", null)]
        public async Task Login_ShouldReturnStatus400_WhenUsernameOrPasswordIsInvalid(string username, string password)
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                username = username,
                password = password
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.Authenticate(loginRequest) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("admin", "Abcd1234$")]
        public async Task Login_ShouldReturnStatus200_WhenUsernameAndPasswordIsValid(string username, string password)
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                username = username,
                password = password
            };
            var loginResponse = new ResponseService<LoginRespone>
            { 
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.Authencate(loginRequest)).ReturnsAsync(loginResponse);
            // Act
            var result = await _sut.Authenticate(loginRequest) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("admin", "abcd1234$")]
        [InlineData("duy113kg123", "Abcd1234$")]
        public async Task Login_ShouldReturnStatus400_WhenUsernameOrPassordIsWrong(string username, string password)
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                username = username,
                password = password
            };
            var loginResponse = new ResponseService<LoginRespone>
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.Authencate(loginRequest)).ReturnsAsync(loginResponse);
            // Act
            var result = await _sut.Authenticate(loginRequest) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
