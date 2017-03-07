using NUnit.Framework;
using RestSharp;

namespace CSharpTests.API
{
    [TestFixture]
    public class APITests
    {
        private RestClient client;

        [SetUp]
        protected void setUp()
        {
            // Create the client for execute a request
            client = new RestClient("http://127.0.0.1:8080/");
        }

        [TearDown]
        protected void tearDown()
        {
        }

        [Test]
        [Ignore("Ignore this")]
        public void testExample()
        {
            // Create the client for execute a request
            // var client = new RestClient("");

            // Set authentication for client connection
            // client.Authenticator = new HttpBasicAuthenticator("user", "password");

            // Create a request
            // var request = new RestRequest("passed", Method.GET);

            // Add header in request
            //request.AddHeader("header", "value");

            // Add parameter in request
            //request.AddParameter("param", "value");

            // Add file to upload
            //request.AddFile("file name", "file path");

            // Execute the request
            // IRestResponse response = client.Execute(request);

            // Check status code from response
            // Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void tesGetPassed()
        {
            // Create a request
            var request = new RestRequest("passed", Method.GET);

            // Execute the request
            IRestResponse response = client.Execute(request);

            // Check status code from response
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void tesGetFailed()
        {
            // Create a request
            var request = new RestRequest("failed", Method.GET);

            // Execute the request
            IRestResponse response = client.Execute(request);

            // Check status code from response
            Assert.AreEqual(401, (int)response.StatusCode);
        }
    }
}
