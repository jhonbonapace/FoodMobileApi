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
    public class Register
    {
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:44368/") };
        private const string endpoint = "/Register/Register";

        [Test]
        public async Task RegisterPersonalUser()
        {
            UserDTO user = new UserDTO()
            {
                Name = "Marie R. Wright",
                Email = "MarieRWright@jourrapide.com",
                Identity = "20763821004",
                Telephone = "5551989190858",
                UserType = UserType.Personal,
                Password = "&N0zogVVU9%p",
                PasswordConfirmed = "&N0zogVVU9%p",
                Gender = Gender.Famale
            };

            var response = await GetResponse(user);

            if (response.Success)
            {
                Assert.IsTrue(response.Success);

                Assert.NotNull(response.Data);
                Assert.IsTrue(response.Data.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Data.Token));
            }
            else
            {
                Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Message));
            }
        }

        [Test]
        public async Task RegisterEstablishmentUser()
        {
            UserDTO user = new UserDTO()
            {
                Name = "Morton's The Steakhouse - San Juan",
                Email = "luc-diogo@hotmail12.com",
                Identity = "55286666000140",
                Telephone = "5551989190858",
                UserType = UserType.Establishment,
                Password = "&N0zogVVU9%p",
                PasswordConfirmed = "&N0zogVVU9%p",
            };

            var response = await GetResponse(user);

            if (response.Success)
            {
                Assert.IsTrue(response.Success);

                Assert.NotNull(response.Data);
                Assert.IsTrue(response.Data.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Data.Token));
            }
            else
            {
                Assert.IsTrue(!string.IsNullOrWhiteSpace(response.Message));
            }

        }

        public async Task<ResponseModel<AuthenticateResponse>> GetResponse(UserDTO user)
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