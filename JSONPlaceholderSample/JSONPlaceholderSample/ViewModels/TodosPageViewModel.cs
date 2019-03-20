using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Plugin.Connectivity;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.ViewModels
{
    public class TodosPageViewModel : BaseViewModel
    {
        public ObservableCollection<Todo> CompletedTodos { get; set; }
        public ObservableCollection<Todo> UnfinishedTodos { get; set; }
        public bool IsChangeEnabled { get; set; }
        public string NewTodoText { get; set; }
        public string PageTitle { get; set; }

        private bool _isInit;
        private readonly User _user;

        public TodosPageViewModel()
        {
            _user = null;
            PageTitle = ConstantHelper.Users;
            IsChangeEnabled = true;
        }

        public TodosPageViewModel(User user)
        {
            _user = user;
            PageTitle = $"{_user.Username}'s todos";
            IsChangeEnabled = true;
        }

        public async Task InitData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                UserDialog.ShowLoading(ConstantHelper.Loading);

                var todos = _user != null
                    ? await ApiService.GetTodos(_user.Id)
                    : await ApiService.GetTodos();

                CompletedTodos = new ObservableCollection<Todo>(todos.Where(todo => todo.Completed));
                UnfinishedTodos = new ObservableCollection<Todo>(todos.Where(todo => !todo.Completed));

                UserDialog.HideLoading();

                _isInit = true;
            }
            else
            {
                await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.ConnectionErrorMessage,
                    ConstantHelper.Ok);

                CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
                {
                    if (CrossConnectivity.Current.IsConnected && !_isInit)
                        await InitData();
                };
            }
        }

        public async Task AddTodo()
        {
            if (NewTodoText.Length == 0 || string.IsNullOrWhiteSpace(NewTodoText))
            {
                UserDialog.Toast(ConstantHelper.TodoMustNotBeEmpty, TimeSpan.FromSeconds(2));
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                IsChangeEnabled = false;
                UserDialog.ShowLoading(ConstantHelper.Loading);

                var todo = new Todo
                {
                    Completed = false,
                    UserId = _user?.Id ?? 1,
                    Title = NewTodoText
                };

                var addedTodoId = await ApiService.AddTodo(todo);

                if (addedTodoId == -1)
                {
                    await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.SomethingWentWrong,
                        ConstantHelper.Ok);
                    UserDialog.HideLoading();
                    return;
                }

                todo.Id = addedTodoId;

                UnfinishedTodos.Add(todo);

                UserDialog.HideLoading();
                IsChangeEnabled = true;
            }
            else
            {
                await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.ConnectionErrorMessage,
                    ConstantHelper.Ok);
            }
        }

        public async Task UpdateTodo(Todo todo)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                IsChangeEnabled = false;
                UserDialog.ShowLoading(ConstantHelper.Loading);

                var isSuccessful = await ApiService.UpdateTodo(todo);

                // (CompletedTodos.Contains(todo) || UnfinishedTodos.Contains(todo))
                // is needed only for local added items
                if (isSuccessful || (CompletedTodos.Contains(todo) || UnfinishedTodos.Contains(todo)))
                {
                    if (todo.Completed)
                    {
                        CompletedTodos.Remove(todo);
                        todo.Completed = !todo.Completed;
                        UnfinishedTodos.Add(todo);
                    }
                    else
                    {
                        UnfinishedTodos.Remove(todo);
                        todo.Completed = !todo.Completed;
                        CompletedTodos.Insert(0, todo);
                    }
                }
                else
                {
                    UserDialog.Toast(ConnectivityHelper.SomethingWentWrong);
                }

                UserDialog.HideLoading();
                IsChangeEnabled = true;
            }
            else
            {
                await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.ConnectionErrorMessage,
                    ConstantHelper.Ok);
            }
        }

        public async Task DeleteTodo(Todo todo)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                IsChangeEnabled = false;
                UserDialog.ShowLoading(ConstantHelper.Loading);

                var isSuccessful = await ApiService.DeleteTodo(todo);

                // (CompletedTodos.Contains(todo) || UnfinishedTodos.Contains(todo))
                // is needed only for local added items
                if (isSuccessful || (CompletedTodos.Contains(todo) || UnfinishedTodos.Contains(todo)))
                {
                    UnfinishedTodos.Remove(todo);
                }
                else
                {
                    await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.SomethingWentWrong,
                        ConstantHelper.Ok);
                }

                UserDialog.HideLoading();
                IsChangeEnabled = true;
            }
            else
            {
                await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.ConnectionErrorMessage,
                    ConstantHelper.Ok);
            }
        }
    }
}