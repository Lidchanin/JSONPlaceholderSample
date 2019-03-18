using JSONPlaceholderSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.Services
{
    public interface IServiceClient
    {
        Task<List<User>> GetUsers();

        Task<int> GetAlbumsCountForCurrentUser(int userId);

        Task<int> GetPostsCountForCurrentUser(int userId);

        Task<int> GetTodosCountForCurrentUser(int userId);
    }
}