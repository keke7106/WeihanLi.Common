namespace WeihanLi.Common.Models
{
    public class JsonResultModel
    {
        public JsonResultStatus Status { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }
    }

    public class JsonResultModel<T>
    {
        public JsonResultStatus Status { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }
    }

    public enum JsonResultStatus
    {
        Continue = 100,
        Processing = 102,
        Success = 200,
        RequestError = 400,
        Unauthorized = 401,
        NoPermission = 403,
        ResourceNotFound = 404,
        MethodNotAllowed = 405,
        ProcessFail = 500,
    }
}