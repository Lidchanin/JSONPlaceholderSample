using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace JSONPlaceholderSample.Services
{
    public class ServiceClient : IServiceClient
    {
        public static ServiceClient Instance => _instance ?? (_instance = new ServiceClient());

        private readonly IUserDialogs _userDialog = UserDialogs.Instance;

        private const string BaseUrl = ConstantHelper.ServiceUrl;
        private static ServiceClient _instance;
        private readonly HttpClient _client;

        private ServiceClient()
        {
            _client = new HttpClient(new HttpClientHandler())
            {
                Timeout = ConstantHelper.ServiceTimeout,
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<User>> GetUsers()
        {
            return await GetAsync<List<User>>("users");
        }

        private async Task<T> GetAsync<T>(string url) where T : new()
        {
            try
            {
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    return new T();
                }
            }
            catch (WebException e)
            {
                _userDialog.Alert(e.Status == WebExceptionStatus.RequestCanceled
                    ? ConnectivityHelper.TimeOutErrorMessage
                    : ConnectivityHelper.ConnectionErrorMessage);
            }
            catch (HttpListenerException ex)
            {
                _userDialog.Alert(ex.Message);
            }
            catch (Exception ex)
            {
                _userDialog.Alert(ex.Message);
            }
            return new T();
        }
    }
}