using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.CustomComponents.ModalComponents;
using System.Reflection;

namespace MealOrdering.Client.Utils
{
    public class ModalManager
    {
        private IModalService _modalService;

        public ModalManager(IModalService modalService)
        {
            _modalService = modalService;
        }

        public async Task ShowMessage(string title, string message,int duartion=0)
        {

            ModalParameters keyValuePairs = new ModalParameters();
            //keyValuePairs.Add("Message", "Are you sure?");
            keyValuePairs.Add("OkText", message);
            keyValuePairs.Add("CancelText", "Cancel");
            var result = _modalService.Show<CofirmationPopupComponent>("warning!", keyValuePairs);
            if (duartion > 0)
            {
                await Task.Delay(duartion);
                result.Close();
            }
        }
        public async Task<bool> ConfirmationAsync(String Title,string Message)
        {
            ModalParameters keyValuePairs = new ModalParameters();
            keyValuePairs.Add("Message", Message);
            keyValuePairs.Add("OkText", "OK");
            keyValuePairs.Add("CancelText", "Cancel");
            var result = await _modalService.Show<CofirmationPopupComponent>(Title, keyValuePairs).Result;
            return !result.Cancelled;
        }

    }
}
