using System;
using Xunit;
using FakeItEasy;
using WEB_API.Controllers;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LOGIC.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using System.Linq;

namespace WEB_API.TESTS
{
    public class UserControllerTests
    {

        [Fact]
        public async Task GetAllUsers_Returns_TheCorrectNumberOfUsersAsync()
        {
            var set = new Generic_ResultSet<List<User_ResultSet>>();
            var list = new List<User_ResultSet> { new User_ResultSet(), new User_ResultSet() };
            set.result_set = list;
            var fakeUsers = A.CollectionOfDummy<User_ResultSet>(3).ToList();
            var fakeUserService = A.Fake<IUser_Service>();
            A.CallTo(() => fakeUserService.GetAllUsers()).Returns(set);
                
            var userController = new UserController(fakeUserService);
            var result = await userController.GetAllUsers();
            var userResult = Assert.IsType<ObjectResult>(result);
            var returnUsers = userResult.Value as Generic_ResultSet<List<User_ResultSet>>;
            var resultList = returnUsers.result_set;
            Assert.Equal(2, resultList.Count());
            

        }
    }
}
