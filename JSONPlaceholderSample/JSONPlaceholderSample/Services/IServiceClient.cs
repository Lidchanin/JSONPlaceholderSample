using JSONPlaceholderSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.Services
{
    public interface IServiceClient
    {
        Task<List<User>> GetUsers();
    }
}