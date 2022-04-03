using System;

namespace Application.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        protected BaseResponse(bool success)
        {
            Success = success;
            Message = String.Empty;
            Resource = default;
        }

        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        protected BaseResponse(bool success, string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}