using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using System.Threading.Tasks;
using Blogger.FunctionalTests.Helper;
using Blogger.Domain.ArticleAggregate;
using Blogger.APIs.Endpoints.Articles.CreateArticle;


namespace Blogger.FunctionalTests.Articles
{
    public class ArticleApisTests
    {
        private readonly HttpClient _httpClient;

        public ArticleApisTests()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("http://localhost:5138/") };
        }

        #region [Tests]

        [Fact]
        public async Task Create_Draft_Article_Should_Return_OkStatus()
        {
            // Arrange
            var sampleData = new List<ArticleDto>
            {
                new ArticleDto
                {
                    Title = "Mastering Dependency Injection in .NET Core",
                    Body = "Explore the power of dependency injection in .NET Core applications, learn best practices, and implement a clean, modular design.",
                    Summary = "A comprehensive guide to leveraging dependency injection for building scalable and maintainable .NET Core applications.",
                    Tags = ["dotnet-core", "dependency-injection", "design-patterns", "architecture"]
                },
                new ArticleDto
                {
                    Title = "Optimizing Performance in .NET Core Web APIs",
                    Body = "Discover techniques to improve the performance and scalability of your .NET Core web APIs, including caching, asynchronous programming, and resource management.",
                    Summary = "Maximize the performance and efficiency of your .NET Core web services with these proven optimization strategies.",
                    Tags = ["dotnet-core", "web-api", "performance", "scalability"]
                },
                new ArticleDto
                {
                    Title = "Implementing Microservices with .NET Core and Docker",
                    Body = "Learn how to build and deploy microservices using .NET Core and Docker, including service discovery, communication patterns, and orchestration.",
                    Summary = "A practical guide to building and deploying scalable, distributed .NET Core applications using microservices and Docker.",
                    Tags = ["dotnet-core", "microservices", "docker", "architecture"]
                },
                new ArticleDto
                {
                    Title = "Secure Coding Practices for .NET Core Applications",
                    Body = "Explore best practices and techniques for writing secure .NET Core applications, including input validation, authentication, authorization, and encryption.",
                    Summary = "Ensure the security and integrity of your .NET Core applications with these proven secure coding practices.",
                    Tags = ["dotnet-core", "security", "authentication", "authorization"]
                },
                new ArticleDto
                {
                    Title = "Migrating Legacy Applications to .NET Core",
                    Body = "Discover strategies and best practices for migrating existing .NET Framework applications to the .NET Core platform, including .NET Standard compatibility and deployment considerations.",
                    Summary = "A step-by-step guide to successfully migrating your legacy .NET applications to the modern .NET Core ecosystem.",
                    Tags = ["dotnet-core", "migration", "legacy-applications", "compatibility"]
                },
                new ArticleDto
                {
                    Title = "Implementing Real-Time Communication in .NET Core Apps",
                    Body = "Learn how to build real-time, bidirectional communication features in your .NET Core applications using technologies like WebSockets, SignalR, and gRPC.",
                    Summary = "Explore the latest real-time communication techniques and technologies for building modern, responsive .NET Core applications.",
                    Tags = ["dotnet-core", "real-time", "websockets", "signalr", "grpc"]
                },
                new ArticleDto
                {
                    Title = "Integrating Serverless Functions with .NET Core",
                    Body = "Discover how to leverage serverless computing with .NET Core, including building and deploying Azure Functions, AWS Lambda, and Google Cloud Functions.",
                    Summary = "Harness the power of serverless computing to build scalable, event-driven .NET Core applications.",
                    Tags = ["dotnet-core", "serverless", "azure-functions", "aws-lambda", "google-cloud-functions"]
                },
                new ArticleDto
                {
                    Title = "Building Blazor Applications with .NET Core",
                    Body = "Explore the Blazor framework, a new way to build interactive client-side web applications using C# and .NET Core, and learn how to create rich, responsive user interfaces.",
                    Summary = "Dive into the world of Blazor, a revolutionary approach to building modern web applications with .NET Core.",
                    Tags = ["dotnet-core", "blazor", "web-development", "client-side"]
                },
                new ArticleDto
                {
                    Title = "Scaling .NET Core Applications with Kubernetes",
                    Body = "Learn how to deploy and manage .NET Core applications using Kubernetes, including container orchestration, service discovery, and scaling strategies.",
                    Summary = "Harness the power of Kubernetes to build and scale highly available and resilient .NET Core applications.",
                    Tags = ["dotnet-core", "kubernetes", "container-orchestration", "scalability"]
                },
                new ArticleDto
                {
                    Title = "Implementing Distributed Tracing in .NET Core Microservices",
                    Body = "Explore techniques for implementing distributed tracing in .NET Core microservices, including the use of tools like OpenTracing, Jaeger, and Zipkin, to gain visibility into complex, distributed systems.",
                    Summary = "Improve observability and troubleshooting capabilities in your .NET Core microservices architecture with distributed tracing.",
                    Tags = ["dotnet-core", "microservices", "distributed-tracing", "observability"]
                }
            };

            foreach (var article in sampleData)
            {
                article.Title = $"{article.Title} -{StringGenerator.GenerateRandomString(8)}";

                var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

                // Act
                var response = await _httpClient.PostAsync("articles/draft", content);

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_draft_Article_Should_Return_BadRequest_WhenUsingSameTitle()
        {
            // Arrange

            var article = GetArticleDto();

            var firstContent = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

            // Act
            var firstCall = await _httpClient.PostAsync("articles/draft", firstContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, firstCall.StatusCode);

            var secondContent = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

            // Act
            var secondCall = await _httpClient.PostAsync("articles/draft", secondContent);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, secondCall.StatusCode);
        }

        [Fact]
        public async Task Update_draft_Article_Should_Return_OkStatus()
        {
            // Arrange
            var createdResponse = await InitializeAsync();

            var updateArticle = UpdateArticleDto(createdResponse.DraftId);

            var updateArticleContent = new StringContent(JsonConvert.SerializeObject(updateArticle), Encoding.UTF8, "application/json");

            // Act
            var secondCall = await _httpClient.PutAsync("articles/draft", updateArticleContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, secondCall.StatusCode);
        }

        [Fact]
        public async Task Pushlish_draft_Article_Should_Return_OkStatus()
        {
            // Arrange
            var createdResponse = await InitializeAsync();

            // Assert
            var publishContent = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PatchAsync($"articles/{createdResponse.DraftId}/publish", publishContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Tags_Should_Return_Valid_Response()
        {
            // Arrange
            var createdResponse = await InitializeAsync();

            // Act
            var response = await _httpClient.GetAsync("articles/tags");

            string result = await response.Content.ReadAsStringAsync();

            List<TagResponse> tagResponses = JsonConvert.DeserializeObject<List<TagResponse>>(result)!;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, tagResponses.Count);
        }


        [Fact]
        public async Task Get_Tagged_Should_Return_Valid_Response()
        {
            // Arrange
            var createdResponse = await InitializeAsync();

            // Act
            var response = await _httpClient.GetAsync($"articles/tagged?tag=architecture");

            string result = await response.Content.ReadAsStringAsync();

            List<TaggedResponse> taggedResponses = JsonConvert.DeserializeObject<List<TaggedResponse>>(result)!;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion [Tests]


        #region [Private Method]

        /// <summary>
        /// Reusuable method for creating draft article
        /// </summary>
        /// <returns></returns>
        public async Task<ArticleDraftResponse> InitializeAsync()
        {
            var article = GetArticleDto();

            var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

            // Act
            var firstCall = await _httpClient.PostAsync("articles/draft", content);

            string response = await firstCall.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ArticleDraftResponse>(response)!;
        }

        /// <summary>
        /// Return an Article Dto
        /// </summary>
        /// <returns></returns>
        private static ArticleDto GetArticleDto()
        {
            return new ArticleDto
            {
                Title = $"Mastering .NET Core - {StringGenerator.GenerateRandomString(10)}",
                Body = "Explore the power of .NET Core applications.",
                Summary = "A comprehensive for building scalable and maintainable .NET Core applications.",
                Tags = ["dotnet-core", "architecture"]
            };
        }

        /// <summary>
        /// Return update draft dto
        /// </summary>
        /// <param name="id">Draft Id</param>
        /// <returns></returns>
        private static UpdateDraftDto UpdateArticleDto(string id)
        {
            return new UpdateDraftDto
            {
                DraftId = id,
                Title = $"Mastering .NET Core - {StringGenerator.GenerateRandomString(10)}",
                Body = ".NET Core applications.",
                Summary = "Building scalable and maintainable .NET Core applications.",
                Tags = ["dotnet-core", "architecture", "technology"]
            };
        }
        
        #endregion [Private Method]

    }


    #region [Classes]

    public class ArticleDto
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [JsonProperty("body")]
        public string Body { get; set; } = null!;

        [JsonProperty("summary")]
        public string Summary { get; set; } = null!;

        [JsonProperty("tags")]
        public string[] Tags { get; set; } = null!;
    }

    public class UpdateDraftDto : ArticleDto
    {
        [JsonProperty("draftId")]
        public string DraftId { get; set; } = null!;
    }

    public class ArticleDraftResponse
    {
        [JsonProperty("draftId")]
        public string DraftId { get; set; } = null!;
    }

    public class TagResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("count")]
        public int Count { get; set; }

    }

    public class TaggedResponse : ArticleDto
    {
        [JsonProperty("publishedOnUtc")]
        public DateTime PublishedOnUtc { get; set; }

        [JsonProperty("readOnMinutes")]
        public int ReadOnMinutes { get; set; }
    }

    #endregion [Classes]

}
