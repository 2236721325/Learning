namespace Demo.BLL.Tools
{
    public class ApiResponse
    {
        public ApiResponse(string message, int statusCode,bool status)
        {
            this.Message = message;
            this.StatusCode = statusCode;
            Status = status;
        }
        public ApiResponse(string message, dynamic result, int statusCode, bool status)
        {
            Message = message;
            StatusCode = statusCode;
            Result = result;
            Status = status;
        }
        public ApiResponse(int statusCode, bool status)
        {
            this.StatusCode = statusCode;
            Status = status;
        }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public dynamic Result { get; set; }
    }

}
