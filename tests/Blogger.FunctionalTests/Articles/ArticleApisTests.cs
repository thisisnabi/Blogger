using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using System.Threading.Tasks;


namespace Blogger.FunctionalTests.Articles
{
    public class ArticleApisTests
    {
        private readonly HttpClient _httpClient;

        public ArticleApisTests()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("http://localhost:5138/") };
        }

        [Fact]
        public async Task Create_Draft_Article_Should_Return_OkStatus()
        {
            // Arrange
            var sampleData = new List<object>
            {
                new ArticleDto
                {
                    title = "Mastering Dependency Injection in .NET Core",
                    body = "Explore the power of dependency injection in .NET Core applications, learn best practices, and implement a clean, modular design.",
                    summary = "A comprehensive guide to leveraging dependency injection for building scalable and maintainable .NET Core applications.",
                    tags = ["dotnet-core", "dependency-injection", "design-patterns", "architecture"]
                },
                new ArticleDto
                {
                    title = "Optimizing Performance in .NET Core Web APIs",
                    body = "Discover techniques to improve the performance and scalability of your .NET Core web APIs, including caching, asynchronous programming, and resource management.",
                    summary = "Maximize the performance and efficiency of your .NET Core web services with these proven optimization strategies.",
                    tags = ["dotnet-core", "web-api", "performance", "scalability"]
                },
                new ArticleDto
                {
                    title = "Implementing Microservices with .NET Core and Docker",
                    body = "Learn how to build and deploy microservices using .NET Core and Docker, including service discovery, communication patterns, and orchestration.",
                    summary = "A practical guide to building and deploying scalable, distributed .NET Core applications using microservices and Docker.",
                    tags = ["dotnet-core", "microservices", "docker", "architecture"]
                },
                new ArticleDto
                {
                    title = "Secure Coding Practices for .NET Core Applications",
                    body = "Explore best practices and techniques for writing secure .NET Core applications, including input validation, authentication, authorization, and encryption.",
                    summary = "Ensure the security and integrity of your .NET Core applications with these proven secure coding practices.",
                    tags = ["dotnet-core", "security", "authentication", "authorization"]
                },
                new ArticleDto
                {
                    title = "Migrating Legacy Applications to .NET Core",
                    body = "Discover strategies and best practices for migrating existing .NET Framework applications to the .NET Core platform, including .NET Standard compatibility and deployment considerations.",
                    summary = "A step-by-step guide to successfully migrating your legacy .NET applications to the modern .NET Core ecosystem.",
                    tags = ["dotnet-core", "migration", "legacy-applications", "compatibility"]
                },
                new ArticleDto
                {
                    title = "Implementing Real-Time Communication in .NET Core Apps",
                    body = "Learn how to build real-time, bidirectional communication features in your .NET Core applications using technologies like WebSockets, SignalR, and gRPC.",
                    summary = "Explore the latest real-time communication techniques and technologies for building modern, responsive .NET Core applications.",
                    tags = ["dotnet-core", "real-time", "websockets", "signalr", "grpc"]
                },
                new ArticleDto
                {
                    title = "Integrating Serverless Functions with .NET Core",
                    body = "Discover how to leverage serverless computing with .NET Core, including building and deploying Azure Functions, AWS Lambda, and Google Cloud Functions.",
                    summary = "Harness the power of serverless computing to build scalable, event-driven .NET Core applications.",
                    tags = ["dotnet-core", "serverless", "azure-functions", "aws-lambda", "google-cloud-functions"]
                },
                new ArticleDto
                {
                    title = "Building Blazor Applications with .NET Core",
                    body = "Explore the Blazor framework, a new way to build interactive client-side web applications using C# and .NET Core, and learn how to create rich, responsive user interfaces.",
                    summary = "Dive into the world of Blazor, a revolutionary approach to building modern web applications with .NET Core.",
                    tags = ["dotnet-core", "blazor", "web-development", "client-side"]
                },
                new ArticleDto
                {
                    title = "Scaling .NET Core Applications with Kubernetes",
                    body = "Learn how to deploy and manage .NET Core applications using Kubernetes, including container orchestration, service discovery, and scaling strategies.",
                    summary = "Harness the power of Kubernetes to build and scale highly available and resilient .NET Core applications.",
                    tags = ["dotnet-core", "kubernetes", "container-orchestration", "scalability"]
                },
                new ArticleDto
                {
                    title = "Implementing Distributed Tracing in .NET Core Microservices",
                    body = "Explore techniques for implementing distributed tracing in .NET Core microservices, including the use of tools like OpenTracing, Jaeger, and Zipkin, to gain visibility into complex, distributed systems.",
                    summary = "Improve observability and troubleshooting capabilities in your .NET Core microservices architecture with distributed tracing.",
                    tags = ["dotnet-core", "microservices", "distributed-tracing", "observability"]
                }
            };

            foreach (var article in sampleData)
            {
                var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

                // Act
                var response = await _httpClient.PostAsync("articles/draft", content);

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }

    public class ArticleDto
    {
        public string title { get; set; } = null!;
        public string body { get; set; } = null!;
        public string summary { get; set; } = null!;
        public string[] tags { get; set; } = null!;
    }
}

