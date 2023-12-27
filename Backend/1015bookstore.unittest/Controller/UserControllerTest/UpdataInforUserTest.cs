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
    public class UpdataInforUserTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public UpdataInforUserTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }
        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("1Nguyen", "1Duy", "2003/10/23", false, "0907448146")]
        [InlineData("Nguyen", "Duy", "2023/12/27", false, "0907448146")]
        [InlineData("Nguyen", "Duy", "1923/10/23", false, "0907448146")]
        [InlineData("Nguyen", "Duy", "2003/10/23", false, "090a744814")]
        [InlineData("Nguyen", "Duy", "2003/10/23", false, "090744814")]
        [InlineData("Nguyen", "Duy", "2003/10/23", false, "a907448146")]
        public async Task UpdataInforUser_ShouldReturnStatus400_WhenDataIsInvalid(string firstname, string lastname, DateTime dob, bool sex, string phonenumber)
        {
            //Arrange
            var request = new UserUpdateRequest
            {
                firstname = firstname,
                lastname = lastname,
                dob = dob,
                sex = sex,
                phonenumber = phonenumber,
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.UpdateUser(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("Nguyen", "Duy", "2003/10/23", false, "0907448146")]
        public async Task UpdataInforUser_ShouldReturnStatus200_WhenDataIsValid(string firstname, string lastname, DateTime dob, bool sex, string phonenumber)
        {
            //Arrange
            var request = new UserUpdateRequest
            {
                firstname = firstname,
                lastname = lastname,
                dob = dob,
                sex = sex,
                phonenumber = phonenumber,
            };
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.UpdateInforUser(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.UpdateUser(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }
    }
}
