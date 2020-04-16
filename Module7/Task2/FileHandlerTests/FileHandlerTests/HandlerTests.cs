using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;

namespace FileHandlerTests
{
    [TestClass]
    public class HandlerTests
    {
        private static HttpClient _httpClient;

        private static Uri _uri;
        
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
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
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

        [TestMethod]
        public async Task TestCustomRequest_GetByCustomer()
        {
            var newUrl = $"{_uri}/report?customer=REGGC&take=5";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(newUrl),
                Method = HttpMethod.Get
            };
           
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            using (var response = await _httpClient.SendAsync(request))
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var compareResult = "<OrderDate>1998-04-30T00:00:00</OrderDate>";

                Assert.IsTrue(content.Contains(compareResult));

                Console.WriteLine(content);
            }
        }

        [TestMethod]
        public async Task TestCustomRequest_GetByDate()
        {
            var newUrl = $"{_uri}/report?dateFrom=07-10-1996&dateTo=15-10-1996";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(newUrl),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            using (var response = await _httpClient.SendAsync(request))
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var compareResult = "<OrderDate>1996-10-10T00:00:00</OrderDate>";

                Assert.IsTrue(content.Contains(compareResult));

                Console.WriteLine(content);
            }
        }
    }
}
