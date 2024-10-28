using CA.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Core.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public IReadOnlyDictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();
        public T Data { get; private set; }
        public ResponseCode Code { get; set; } = ResponseCode.Success;
        public static ApiResponse<T> Success(T data, string message = null) =>
            new ApiResponse<T> { Succeeded = true, Data = data, Message = message };
        public static ApiResponse<T> Failure(string message, IReadOnlyDictionary<string, string> errors = null) =>
            new ApiResponse<T> { Succeeded = false, Message = message, Errors = errors };
        public enum ResponseCode { Success, NotFound, Error }
    }

}
