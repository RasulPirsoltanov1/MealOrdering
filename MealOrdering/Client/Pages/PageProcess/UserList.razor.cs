using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Net.Http.Json;

namespace MealOrdering.Client.PageProcess.User
{
    public class UserListProcess : ComponentBase
    {
        public ServiceResponse<List<UserDTO>>? serviceResponse;
        [Inject]
        private HttpClient _httpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }


        public async Task LoadList()
        {
            serviceResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/User");
        }
    }
}
