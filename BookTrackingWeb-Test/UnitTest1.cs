﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace Book_Tracking_Application_Test
{
    [TestClass]
    public class UnitTest
    {
        private readonly HttpClient _client;


        public UnitTest()
        {
            var appFactory = new WebApplicationFactory<BookTrackingWebAPI.Startup>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public void TestMethod()
        {

        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/About")]
        [InlineData("/Privacy")]
        [InlineData("/Contact")]
        public async Task GetEndpointsReturnSuccessAndCorrectContentType(string url)
        {

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }


    }
}
