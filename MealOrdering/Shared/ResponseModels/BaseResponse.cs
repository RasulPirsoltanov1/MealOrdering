using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Shared.ResponseModels
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public void SetException(Exception exception)
        {
            IsSuccess = false;
            Message = exception.Message;
        }
    }
}
