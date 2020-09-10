using System;

namespace Application.DTO
{
    public class ResponseModel<T> : ResponseModel where T : new()
    {
        public ResponseModel()
        {
            Data = new T();
        }

        public T Data { get; set; }
    }

    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResponseDataModel<T>
    {
        public T Data { get; set; }
    }
}
