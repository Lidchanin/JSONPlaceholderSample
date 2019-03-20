using JSONPlaceholderSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.Services
{
    public interface IServiceClient
    {
        Task<List<User>> GetUsers();

        Task<int> GetAlbumsCountForCurrentUser(int userId);

        Task<List<Album>> GetAlbums();

        Task<List<Album>> GetAlbums(int userId);

        Task<int> GetPostsCountForCurrentUser(int userId);

        Task<List<Post>> GetPosts();

        Task<List<Post>> GetPosts(int userId);

        Task<int> GetTodosCountForCurrentUser(int userId);

        Task<List<Todo>> GetTodos();

        Task<List<Todo>> GetTodos(int userId);

        /// <summary>
        /// Adds the <see cref="Todo"/>.
        /// </summary>
        /// <param name="todo"><see cref="Todo"/> to add.</param>
        /// <returns>Added <see cref="Todo"/>.Id or <value>-1</value> (if adding fails).</returns>
        Task<int> AddTodo(Todo todo);

        /// <summary>
        /// Updates the <see cref="Todo"/>.
        /// </summary>
        /// <param name="todo"><see cref="Todo"/> to update.</param>
        /// <returns>true if the update was successful, false - wasn't</returns>
        Task<bool> UpdateTodo(Todo todo);

        /// <summary>
        /// Delete the <see cref="Todo"/>.
        /// </summary>
        /// <param name="todo"><see cref="Todo"/> to delete.</param>
        /// <returns>true if the delete was successful, false - wasn't</returns>
        Task<bool> DeleteTodo(Todo todo);
    }
}