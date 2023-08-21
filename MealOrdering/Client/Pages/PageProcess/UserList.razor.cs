using MealOrdering.Client.Utils;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Net.Http.Json;
using MealOrdering.Client.Utils;
using MealOrdering.Shared.CustomExceptions;

namespace MealOrdering.Client.PageProcess.User
{
    public class UserListProcess : ComponentBase
    {
        public List<UserDTO>? serviceResponse;
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        private ModalManager _modalManager { get; set; }
        [Inject]
        private NavigationManager _navigationManager{ get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }


        public async Task LoadList()
        {
            try
            {
                serviceResponse = await _httpClient.GetServiceResponseAsync<List<UserDTO>>("api/User", true);
            }
            catch (ApiException ex)
            {
                await _modalManager.ShowMessage("Server error", ex.Message);
            }
        }
        public void AddUser()
        {
            _navigationManager.NavigateTo("user/add");
        }
        public void UpdateUser(Guid UserId)
        {
            _navigationManager.NavigateTo($"user/update/{UserId}");
        }
    }
}
