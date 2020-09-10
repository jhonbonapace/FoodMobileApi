using Application.DTO;
using Application.DTO.Auth;
using CrossCutting.Util;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enumerators.Enumerator;


namespace AppTest
{
    class Auth
    {
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:44368/") };
        private const string endpoint = "/Auth/Authenticate";

        [Test]
        public async Task AuthenticateUserExists()
        {
            AuthenticateRequest user = new AuthenticateRequest()
            {
                Email = "Steakhouse@gmail.com",
                Password = "&N0zogVVU9%p"
            };

            var response = await GetResponse(user);

            Assert.IsTrue(response.Success);

            Assert.NotNull(response.Data);
            Assert.IsTrue(response.Data.Id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Data.Token));
        }

        [Test]
        public async Task AuthenticateUserDontExists()
        {
            AuthenticateRequest user = new AuthenticateRequest()
            {
                Email = "MarieRWright@teste.com",
                Password = "&N0zogVVU9%p"
            };

            var response = await GetResponse(user);

            Assert.IsFalse(response.Success);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Message));
        }


        public async Task<ResponseModel<AuthenticateResponse>> GetResponse(AuthenticateRequest user)
        {
            var json = Serializer.Serialize(user);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(endpoint, content);

            ResponseModel<AuthenticateResponse> response = new ResponseModel<AuthenticateResponse>();

            response = JsonConvert.DeserializeObject<ResponseModel<AuthenticateResponse>>(result.Content.ReadAsStringAsync().Result);

            return response;
        }
    }
}
