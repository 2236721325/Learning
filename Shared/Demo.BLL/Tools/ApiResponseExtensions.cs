using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Tools
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse NotFound(this ApiResponse apiResponse,string message)
        {
            return new ApiResponse(message, 404,false);
        }
        public static ApiResponse NotFound(this ApiResponse apiResponse)
        {
            return new ApiResponse(404,false);
        }
        public static ApiResponse BadRequest(this ApiResponse apiResponse, string message)
        {
            return new ApiResponse(message, 400,false);
        }
        public static ApiResponse BadRequest(this ApiResponse apiResponse)
        {
            return new ApiResponse( 400, false);
        }
        public static ApiResponse Ok(this ApiResponse apiResponse, string message)
        {
            return new ApiResponse(message, 200, true);
        }
        public static ApiResponse Ok(this ApiResponse apiResponse)
        {
            return new ApiResponse(200,true);
        }
     
    }

}
