using _1015bookstore.application.System.Users;
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
    public class ForgotPasswordTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public ForgotPasswordTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }

        [Theory]
        [InlineData("21520208.gm.uit.edu.vn")]
        [InlineData("")]
        public async Task ForgotPassword_ShouldReturnStatus400_WhenEmailIsInvalid(string email)
        {
            //Arrange
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.ForgotPassword(email) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }
        [Theory]
        [InlineData("21530208@gm.uit.edu.vn")]
        public async Task ForgotPassword_ShouldReturnStatus400_WhenEmailIsUsed(string email)
        {
            //Arrange
            var response = new ResponseService<string>
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.ForgotPassword(email)).ReturnsAsync(response);
            // Act
            var result = await _sut.ForgotPassword(email) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
        [Theory]
        [InlineData("21520208@gm.uit.edu.vn")]
        public async Task ForgotPassword_ShouldReturnStatus400_WhenEmailIsValid(string email)
        {
            //Arrange
            var response = new ResponseService<string>
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.ForgotPassword(email)).ReturnsAsync(response);
            // Act
            var result = await _sut.ForgotPassword(email) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }
    }
}
