namespace Application.DTO
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            Response = new ResponseDataModel<T>();
        }
        public ResponseDataModel<T> Response { get; set; }
    }

    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResponseDataModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
