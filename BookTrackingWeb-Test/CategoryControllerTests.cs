using BookTrackingWeb;
using BookTrackingWebAPI;
using System.Net.Http;
using Xunit;
namespace BookTrackingWeb
{
    public class CategoryControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CategoryControllerTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }


        [Fact]
        public async void fetchCategories_ReturnsAllCategories()
        {
            // Arrange
            var request = "categories";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}