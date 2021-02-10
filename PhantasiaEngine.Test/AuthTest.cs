using AutoMapper;
using NUnit.Framework;
using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Profiles;
using PhantasiaEngine.Auth.Requests;

namespace PhantasiaEngine.Test
{
    public class AuthTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestAuthMapper()
        {
            var createUserRequest = new CreateUserRequest()
            {
                Username = "User",
                Email = "user@user.com",
                Password = "user"
            };

            var mapper = new Mapper(new MapperConfiguration(expression => expression.AddProfile(new UserProfile())));
            var user = mapper.Map<CreateUserRequest, User>(createUserRequest);
            
            TestContext.Out.WriteLine(user.Token);
        }
    }
}