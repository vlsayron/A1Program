using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileHandlerTests
{
    [TestClass]
    public class HandlerTests
    {

        private static HttpClient _httpClient;

        private static Uri _uri;
        //private static HttpRequestMessage _request;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _httpClient = new HttpClient();
            _uri = new Uri("https://localhost:44347");
        }

        [TestMethod]
        public async Task TestStatus()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = _uri,
                Method = HttpMethod.Get
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public async Task TestFileType_Xml()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = _uri,
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            using (var response = await _httpClient.SendAsync(request))
            {
                Assert.IsTrue(response.Content.Headers.ToString().Contains(".xml"));
            }
        }

        [TestMethod]
        public async Task TestFileType_Excel()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = _uri,
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue(
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

            using (var response = await _httpClient.SendAsync(request))
            {
                Assert.IsTrue(response.Content.Headers.ToString().Contains(".xlsx"));
            }
        }

        [TestMethod]
        public async Task TestFileType_Default()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = _uri,
                Method = HttpMethod.Get
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                Assert.IsTrue(response.Content.Headers.ToString().Contains(".xlsx"));
            }
        }
    }
}
