using Acr.UserDialogs;
using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> GetAlbumsCountForCurrentUser(int userId)
        {
            return (await GetAlbums(userId)).Count;
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await GetAsync<List<Album>>("albums");
        }

        public async Task<List<Album>> GetAlbums(int userId)
        {
            return await GetAsync<List<Album>>($"albums?userId={userId}");
        }

        public async Task<int> GetPostsCountForCurrentUser(int userId)
        {
            return (await GetPosts(userId)).Count;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await GetAsync<List<Post>>("posts");
        }

        public async Task<List<Post>> GetPosts(int userId)
        {
            return await GetAsync<List<Post>>($"posts?userId={userId}");
        }

        public async Task<int> GetTodosCountForCurrentUser(int userId)
        {
            return (await GetTodos(userId)).Count;
        }

        public async Task<List<Todo>> GetTodos()
        {
            return await GetAsync<List<Todo>>("todos");
        }

        public async Task<List<Todo>> GetTodos(int userId)
        {
            return await GetAsync<List<Todo>>($"todos?userId={userId}");
        }

        public async Task<int> AddTodo(Todo todo)
        {
            var result = await PostAsync(BaseUrl + "todos", todo);
            if (string.IsNullOrEmpty(result.Title))
                return -1;

            return result.Id;
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            return await PutAsync($"{BaseUrl}todos/{todo.Id}", todo);
        }

        public async Task<bool> DeleteTodo(Todo todo)
        {
            return await DeleteAsync($"{BaseUrl}todos?id={todo.Id}");
        }

        public async Task<List<Photo>> GetPhotos()
        {
            return await GetAsync<List<Photo>>("photos");
        }

        public async Task<List<Photo>> GetPhotos(int albumId)
        {
            return await GetAsync<List<Photo>>($"photos?albumId={albumId}");
        }

        #region Private methods

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

        private async Task<T> PostAsync<T>(string url, T data) where T : new()
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);

                    return result;
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

        private async Task<bool> PutAsync<T>(string url, T data)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
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

            return false;
        }

        private async Task<bool> DeleteAsync(string url)
        {
            try
            {
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
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

            return false;
        }

        #endregion
    }
}