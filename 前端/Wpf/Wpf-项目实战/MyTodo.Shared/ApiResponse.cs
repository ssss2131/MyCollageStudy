using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace MyTodo.Shared
{
   
    public class ApiResponse
    {
        [JsonConstructor]
        public ApiResponse(string message, bool status = false)
        {
            Message = message;
            Status = status;
        }
    
        public ApiResponse(bool status, object result)
        {
            Status = status;
            Result = result;
        }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }
    }
    public class ApiResponse<T>
    {
 
        public ApiResponse()
        {

        }
        public string Message { get; set; }

        public bool Status { get; set; }

        public T Result { get; set; }
    }
}
