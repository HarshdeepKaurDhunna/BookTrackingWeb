using BookTrackingWebAPI;
using System.Net.Http;
using Xunit;
namespace Book_Tracking_Application_Test
{
    public class ApiIntegrationTestsForControlleres : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ApiIntegrationTestsForControlleres(TestFixture<Startup> fixture)
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

        [Fact]
        public async void fetchCategoryTypes_ReturnsAllCategoryTypes()
        {
            // Arrange
            var request = "categoryTypes";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async void fetchBooks_ReturnsAllBooks()
        {
            // Arrange
            var request = "books";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void fetchBookReadTrack_ReturnsAllBookReadTracks()
        {
            // Arrange
            var request = "bookReadTrack";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void fetchBookQuote_ReturnsAllBookQuotes()
        {
            // Arrange
            var request = "bookQuote";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}