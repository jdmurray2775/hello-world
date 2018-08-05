using HelloWorldAPI.Interfaces;
using HelloWorldAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldAPI.Tests
{
    public class HelloWorldControllerUnitTests
    {
        [Fact]
        public void EmptyTest()
        {
            HelloWorldRepository repo = TestRepo();

            var result = repo.ListAll();

            Assert.Empty(result);
        }

        [Fact]
        public void SingleItemTest()
        {
            HelloWorldRepository repo = TestRepo();

            repo.Add();

            var result = repo.ListAll();

            Assert.Single(result);
        }

        [Fact]
        public void ReturnsHelloWorldItemTest()
        {
            HelloWorldRepository repo = TestRepo();

            repo.Add();

            var result = repo.Get(1);

            Assert.Equal("Hello World", result.Text);
        }

        private static HelloWorldRepository TestRepo()
        {
            var builder = new DbContextOptionsBuilder<HelloWorldContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestRepo");

            var context = new HelloWorldContext(builder.Options);
            var repo = new HelloWorldRepository(context);

            return repo;
        }


    }
}
