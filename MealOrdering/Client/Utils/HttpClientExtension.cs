using MealOrdering.Shared.CustomExceptions;
using MealOrdering.Shared.ResponseModels;
using System.Net.Http.Json;
using System.Net.Mail;

namespace MealOrdering.Client.Utils
{
    public static class HttpClientExtension
    {
        public static async Task<T> GetServiceResponseAsync<T>(this HttpClient httpClient, string url, bool throwNotSucces = false)
        {
            //throw new ApiException("qaqqa bu nedie");
            var httpRes = await httpClient.GetFromJsonAsync<ServiceResponse<T>>(url);

            if (!httpRes.IsSuccess && throwNotSucces)
            {
                throw new Exception(httpRes.Message);
            }
            return httpRes.Value;
        }
        public static async Task<TResult> PostServiceResponseAsync<TResult, TValue>(this HttpClient httpClient, string url, TValue value, bool throwNotSucces = false)
        {
            //throw new ApiException("qaqqa bu nedie");
            var httpRes = await httpClient.PostAsJsonAsync(url, value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();
                if (res.IsSuccess)
                    return !res.IsSuccess && throwNotSucces ? throw new ApiException(res.Message) : res.Value;
            }
            throw new Exception(httpRes.StatusCode.ToString());
        }
        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res.IsSuccess && ThrowSuccessException ? throw new ApiException(res.Message) : res;
            }

            throw new Exception(httpRes.StatusCode.ToString());
        }
    }
}
