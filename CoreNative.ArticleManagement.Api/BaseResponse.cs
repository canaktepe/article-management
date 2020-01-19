namespace CoreNative.ArticleManagement.Api
{
    internal class BaseResponse
    {

        public BaseResponse()
        {
        }

        public object Data { get; set; }
        public int StatusCode { get; set; }

    }
}