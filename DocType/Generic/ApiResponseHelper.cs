namespace DocType.Generic
{
    public static class ApiResponseHelper
    {
        public static ApiResponseModel Convert(bool IsRequestHandled, bool status, string message, int statusCode, Object data)
        {
            ApiResponseModel model = new ApiResponseModel();
            model.IsApiHandled = IsRequestHandled;
            model.IsRequestSuccess = status;
            model.StatusCode = statusCode;
            model.Message = message;
            model.Data = data;

            return model;
        }
    }
}
