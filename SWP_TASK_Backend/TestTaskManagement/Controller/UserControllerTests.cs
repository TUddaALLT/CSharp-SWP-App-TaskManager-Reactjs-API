using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Controllers;
using TaskManagement.Interface;
using TaskManagement.Models;
using TaskManagement.Utils;

namespace TestTaskManagement.Controller
{
    public class UserControllerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly TaskManagementContext _context;
        //private readonly IMapper _mapper;
        public UserControllerTests()
        {
            _userRepository = A.Fake<IUserRepository>();
            _context = A.Fake<TaskManagementContext>();
            //_mapper = A.Fake<Mapper>(); 
        }
        [Fact]
        public void Login_ReturnOK()
        {
            var res = A.Fake<ResponseObject>();
            var user = new User { UserName = "SWP@gmail.com", Password = "SWP391" };
            var userRepositoryMock =  A.Fake<IUserRepository>();
            //userRepositoryMock.Setup(repo => repo.Login(user)).Returns(true);
            A.CallTo(() => userRepositoryMock.Login(user)).Returns(res);
            var controller = new UserController(userRepositoryMock);

            // Act
            var result = controller.Login(user) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            //Assert.True((bool)result.Value);
        }
        [Fact]
        public void Register_ReturnsOkResult_WhenUserIsValid()
        {
            // Arrange
            var res = A.Fake<ResponseObject>();
            var user = new User { UserName = "SWP@gmail.com", Password = "SWP391" };
            var userRepositoryMock = A.Fake<IUserRepository>();
            A.CallTo(() => userRepositoryMock.CreateUser(user)).Returns(res);
            var controller = new UserController(userRepositoryMock);
            // Act
            var result = controller.Register(user) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            //Assert.Equal(user.Id, result.Value);
        }
    }
}
